<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md" style="color: #e1e1e1">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" style="color: #e1e1e1"/>
            <q-breadcrumbs-el label="Nomencladores" icon="dashboard" @click="router.push('/gestion')" style="color: #e1e1e1"/>
            <q-breadcrumbs-el label="Gestor" />
        </q-breadcrumbs>
        <q-table class="q-pa-md"  title="Útiles" :rows="items" :columns="columns"
            row-key="id" no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Gestores</span>
                   <q-input debounce="500" bottom-slots v-model="filtroBusqueda" label="Buscar" counter maxlength="30"
                     >
                    <q-btn round dense flat icon="search" @click="CargarBusquedaFiltro" />
                </q-input>
                </div>
                <q-space />

                <q-btn class="bg-primary" style="width: 20px" color="primary" icon="add" @click="dialog = true">
                    <q-tooltip class="bg-primary" transition-show="flip-right" transition-hide="flip-left"
                        :offset="[10, 10]">Adicionar</q-tooltip>
                </q-btn>
                <q-btn outline class="bg-white q-ml-sm" style="width: 20px" color="primary" icon="print"
                    @click="imprimir()">
                    <q-tooltip class="bg-primary" :offset="[10, 10]" transition-show="flip-right"
                        transition-hide="flip-left">
                        Imprimir
                    </q-tooltip>
                </q-btn>
            </template>
            <template v-slot:body-cell-nombre="props">
                <q-td :props="props">
                    <div>
                        {{ PonerPuntosSupensivosACampo(props.row?.nombre, 30) }}
                        <q-tooltip>{{ props.row?.nombre }}</q-tooltip>
                    </div>
                </q-td>
            </template>
            <template v-slot:body-cell-apellido="props">
                <q-td :props="props">
                    <div>
                        {{ PonerPuntosSupensivosACampo(props.row?.apellidos, 30) }}
                        <q-tooltip>{{ props.row?.apellidos }}</q-tooltip>
                    </div>
                </q-td>
            </template>
            <template v-slot:body-cell-direccion="props">
                <q-td :props="props">
                    <div>
                        {{ PonerPuntosSupensivosACampo(props.row?.direccion, 30) }}
                        <q-tooltip>{{ props.row?.direccion }}</q-tooltip>
                    </div>
                </q-td>
            </template>

            <template v-slot:body-cell-action="props">
                <q-td :props="props">
                    <div class="q-gutter-sm">
                        <q-btn flat dense size="sm" @click="obtenerElementoPorId(props.row.id)" text-color="primary"
                            icon="edit">
                            <q-tooltip class="bg-primary" :offset="[10, 10]" transition-show="flip-right"
                                transition-hide="flip-left">Editar datos</q-tooltip>
                        </q-btn>
                        <q-btn flat dense size="sm" @click="abrirDialogoEliminar(props.row.id)" text-color="negative"
                            icon="delete">
                            <q-tooltip class="bg-red" :offset="[10, 10]" transition-show="flip-right"
                                transition-hide="flip-left">Eliminar</q-tooltip>
                        </q-btn>
                    </div>
                </q-td>
            </template>
        </q-table>
    </div>

    <!-- DIALOGS -->
    <DialogLoad :dialogLoad="dialogLoad" />

    <DialogEliminar v-if="isDialogoEliminarAbierto" :isOpen="isDialogoEliminarAbierto"
        :idElemento="idElementoSeleccionado" @eliminar="eliminar" @closeDialog="handleCloseDialog" />

    <!-- Add & Delete -->
    <q-dialog v-model="dialog" persistent>
        <q-card style="width: 700px; max-width: 80vw; height: auto">
            <header class="q-pa-sm" style="background: linear-gradient(146deg,#222222  0%, #656e6e 150%)">
                <q-toolbar>
                    <q-toolbar-title class="text-subtitle6 text-white">
                        {{
                            objeto?.id ? "Editar Gestor" : "Adicionar Gestor"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">
                    <q-input class="col-xs-12 col-md-12 q-pa-md" label="Nombre *" v-model="objeto.nombre" color="primary" counter
                        maxlength="100" :rules="[onlyLettersAndSpaces, string]" />

                        <q-input class="col-xs-12 col-md-12 q-pa-md" label="Apellidos *" v-model="objeto.apellidos" color="primary" counter
                        maxlength="100" :rules="[onlyLettersAndSpaces, string]" />

                        <q-input class="col-xs-12 col-md-12 q-pa-md" label="Dirección *" v-model="objeto.direccion" color="primary" counter
                        maxlength="255" :rules="[onlyLetter_Number, string]" />

                        <q-input class="col-xs-12 col-md-12 q-pa-md" label="Teléfono *" v-model="objeto.telefono" color="primary" counter
                        mask="########"
                        maxlength="8"   />

                    <q-card-actions class="col-12 q-mt-md justify-end">
                        <q-btn class="text-white" color="primary" aling="right" type="submit" label="Guardar" />
                        <q-btn outline color="primary" type="reset" label="Cancelar" />
                    </q-card-actions>
                </div>
            </q-form>
        </q-card>
    </q-dialog>
</template>

<script setup>
// IMPORT LIBRERIES
import { dataColumnGestor } from "src/assets/js/column_data/columnDataGestion";
import {
    loadGet,
    saveData,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    validarSoloNumeros,
    imprimirTodosFiltradoSoloTexto,
    loadListaFiltro,
} from 'src/assets/js/util/funciones'
import { PonerPuntosSupensivosACampo } from 'src/assets/js/util/extras'
import { onlyLetter_Number, string, onlyLetter_Number_No_White_Spaces,onlyLettersAndSpaces } from 'src/assets/js/util/validator_form'
import { Error } from "src/assets/js/util/notify";
import { Error_Notify_DelecteObject } from "src/assets/js/util/dicc_notify";

// IMPORT COMPONENTS
import DialogLoad from 'src/components/dialog_boxes/DialogLoad.vue'
import DialogEliminar from 'src/components/dialog_boxes/DialogEliminar.vue'

// IMPORT HOOKS
import { ref, onMounted, reactive } from "vue";
import { useRouter } from "vue-router";

/***************************************************************************************************
 *                                        VARIABLES                                                *
 **************************************************************************************************/

// HOOKS
const router = useRouter();

// DATOS DE LA TABLA
const columns = dataColumnGestor;
const filtroBusqueda = ref('')
const items = ref([]);

// DIALOGS VAR
const dialog = ref(false)
const dialogLoad = ref(false)
const isDialogoEliminarAbierto = ref(false)

// VAR FORM
const myForm = ref(null)
const idElementoSeleccionado = ref('')

/***************************************************************************************************
 *                                         OBJECT                                                  *
 **************************************************************************************************/
const objetoInicial = {
    nombre: null,
    apellidos: null,
    direccion: null,
    telefono: null
}

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })




//objeto prueba


const objeto2 = {
    email: null,
    codigoPostal: null,
    fax: null,

}
const parameter = reactive({ ...objeto2 })
/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('Gestor/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    dialogLoad.value = false;
});

// EXTRAS

// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = () => {
    const url = objeto.id ? 'Gestor/Actualizar' : 'Gestor/Crear'
    saveData(url, objeto, load, close, dialogLoad)
}

// Funcion para Obtener los datos para editar
const obtenerElementoPorId = async (id) => {
    await obtener('Gestor/ObtenerPorId', id, objeto, dialogLoad, dialog)
}

// Funcion para eliminar elemento
const eliminar = async () => {
    await eliminarElemento(
        'Gestor/Eliminar',
        idElementoSeleccionado.value,
        load,
        dialogLoad
    ).
        then(async (response) => {
            return response
        }).catch(async (error) => {
            Error(Error_Notify_DelecteObject)
        })
}

// Funcion para abrir el dialog de eliminar y pasar el id del elemento
const abrirDialogoEliminar = (id) => {
    idElementoSeleccionado.value = id
    isDialogoEliminarAbierto.value = true
}

// 2- Funcion para pasar por parametro el arreglo de los elmentos de la tabla
const load = async () => {
    items.value = await loadGet('Gestor/ObtenerListadoPaginado')
}

// Funcion para cerrar el dialog
const handleCloseDialog = () => {
    isDialogoEliminarAbierto.value = false
}

// Funcion para cerrar el dialog principal de Adicionar y Editar y resetear los campos del formulario
const close = async () => {
    closeDialog(objeto, objetoInicial, myForm, dialog)
}


// Funcion para cargar lista de busqueda por codigo o descripcion ademas del filtro seleccionado
const CargarBusquedaFiltro = async () => {
    dialogLoad.value=true
    //Tiene texto escrito
    if (filtroBusqueda.value != null && filtroBusqueda.value != '') {
        items.value = await loadListaFiltro(`Gestor/ObtenerListadoPaginado?TextoBuscar=${filtroBusqueda.value}`)
    }

    //No Tiene texto escrito
     else {
        items.value = await loadListaFiltro('Gestor/ObtenerListadoPaginado')

    }
    dialogLoad.value=false
}

const imprimir = async () =>{

if(items.value.length !== 0){
const texto = filtroBusqueda.value
    const url = '/Gestor/ImprimirPorFiltro'
    dialogLoad.value = true // activar Loading
    await imprimirTodosFiltradoSoloTexto(url, texto)
    dialogLoad.value = false // Desactivar Loading
}
else{
    Error("No tiene elementos para imprimir")
}
}

</script>
