<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" />
            <q-breadcrumbs-el label="Nomencladores" icon="dashboard" @click="router.push('/gestion')" />
            <q-breadcrumbs-el label="Producto" />
        </q-breadcrumbs>
        <q-table class="q-pa-md" :filter="filter" title="Útiles" :rows="items" :columns="columns" row-key="id"
            no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Productos</span>
                    <q-input debounce="500" bottom-slots v-model="filtroBusqueda" label="Buscar" counter maxlength="30"
                    :dense="dense">
                    <q-btn round dense flat icon="search" @click="CargarBusquedaFiltro" />
                </q-input>
                </div>
                <q-space />



                <span>Todos</span>
                <q-toggle class="q-mr-md" color="primary" label="Disponibles" v-model="filtroDisponibles"
                    @update:model-value="CargarBusquedaFiltro" />

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


            <template v-slot:body-cell-produccion="props">
                <q-td :props="props">
                    <q-icon name="done" v-if="props.value == 0" style="color: #bdbdbd" size="25px" />
                    <q-icon name="done" v-else style="color: #3a7779" size="25px" />
                </q-td>
            </template>
            <template v-slot:body-cell-activo="props">
                <q-td :props="props">
                    <q-icon flat :name="(props.value == 0) ? 'highlight_off' : 'check_circle'"
                        :class="(props.value == 0) ? 'text-grey' : 'text-primary'" size="20px" />
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
            <header class="q-pa-sm bg-primary">
                <q-toolbar>
                    <q-toolbar-title class="text-subtitle6 text-white">
                        {{
                            objeto?.id ? "Editar Producto" : "Adicionar Producto"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">

                    <q-input class="col-xs-12" label="Código*" v-model="objeto.codigo" color="primary" counter
                        maxlength="100" :rules="[onlyLetter_Number, string, (val) =>
                            (items.length > 0
                                ? !isValorRepetido(val, 'codigo', objeto, items)
                                : true) || 'Ya existe un código  con ese valor',]" />

                    <q-input class="col-xs-12" label="Descripción*" v-model="objeto.descripcion" color="primary" counter
                        maxlength="255" :rules="[onlyLetter_Number, string, (val) =>
                            (items.length > 0
                                ? !isValorRepetido(val, 'descripcion', objeto, items)
                                : true) || 'Ya existe una descripción  con ese valor',]" />

                    <q-input class="col-xs-12 col-sm-5 q-mt-md" label="Costo *" outlined
                            v-model="objeto.costo"   prefix="$" :min="0" mask="#.##" fill-mask="0" reverse-fill-mask
                             :rules="[
                                (val) => (val === 0 || val === '0') ? 'El valor de Costo no puede estar en cero' : true
                            ]">
                    </q-input>

                    <q-input class="col-xs-12 col-sm-6 q-mt-md" label="Precio *" outlined
                            v-model="objeto.precioUSD" prefix="$" :min="0" mask="#.##" fill-mask="0" reverse-fill-mask
                             :rules="[
                                (val) => (val === 0 || val === '0') ? 'El valor de Precio no puede estar en cero' : true
                            ]">
                    </q-input>


                    <q-input class="col-xs-12 col-sm-5" label="Cantidad *" outlined
                            v-model="objeto.cantidad"   mask="#" fill-mask="1" reverse-fill-mask :min="1"
                             :rules="[
                                (val) => (val === 0 || val === '0') ? 'El valor de la Cantidad no puede estar en cero' : true
                            ]">
                    </q-input>

                    <q-select
                        v-show="!!objeto.id"
                        transition-show="flip-up"
                        transition-hide="flip-down"
                        class="col-xs-12 col-sm-6"
                        v-model="objeto.estadoProductoId"
                        label="Estado del producto *"
                        emit-value
                        map-options
                        :use-input="
                            objeto.estadoProductoId === null || objeto.estadoProductoId === ''
                        "
                        option-label="descripcion"
                        option-value="id"
                        :options="filtradoEstadoProducto"
                        @filter="
                            (val, update) => {
                                filtradoEstadoProducto = filterOptions(
                                val,
                                update,
                                filtradoEstadoProducto,
                                'descripcion',
                                itemsEstadoProducto
                            );
                            }
                        "
                        lazy-rules
                        :rules="[
                            (val) =>
                            (val !== null && val !== '') ||
                            'Debe seleccionar un elemento',
                        ]"
                        >
                        <template v-slot:no-option>
                            <q-item>
                            <q-item-section class="text-italic text-grey">
                                No hay elementos disponibles
                            </q-item-section>
                            </q-item>
                        </template>
                    </q-select>



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
import { dataColumnProducto } from "src/assets/js/column_data/columnDataGestion";
import {
    loadGet,
    saveData,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    filterOptions,
    loadListaFiltro,
} from 'src/assets/js/util/funciones'
import {PonerPuntosSupensivosACampo} from 'src/assets/js/util/extras'
import { onlyLetter_Number, string } from 'src/assets/js/util/validator_form'
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
const columns = dataColumnProducto;
const filter = ref("");
const items = ref([]);

// DIALOGS VAR
const dialog = ref(false)
const dialogLoad = ref(false)
const isDialogoEliminarAbierto = ref(false)
const filtroDisponibles = ref(false)

// VAR FORM
const myForm = ref(null)
const idElementoSeleccionado = ref('')
const filtroBusqueda = ref('')

/***************************************************************************************************
 *                                         OBJECT                                                  *
 **************************************************************************************************/
const objetoInicial = {

    codigo: null,
    descripcion: null,
    costo: 0,
    precioUSD: 0,
    //imagen: null,
    cantidad: 1,
    cantidadStock: 1,
    estadoProductoId: "1C8FCFE3-5718-4A36-BD3A-681241488A6B"
}

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })



/***************************************************************************************************
 *                                         LISTAS                                                  *
 **************************************************************************************************/
const itemsEstadoProducto = ref([])
const filtradoEstadoProducto = ref([])


/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('Producto/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    itemsEstadoProducto.value = (await loadGet('EstadoProducto/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    dialogLoad.value = false;
});

// EXTRAS


// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = () => {
    const url = objeto.id ? 'Producto/Actualizar' : 'Producto/Crear'
    objeto.cantidadStock = objeto.cantidad
    saveData(url, objeto, load, close, dialogLoad)
}

// Funcion para Obtener los datos para editar
const obtenerElementoPorId = async (id) => {
    filtradoEstadoProducto.value = itemsEstadoProducto.value
    await obtener('Producto/ObtenerPorId', id, objeto, dialogLoad, dialog)
}

// Funcion para eliminar elemento
const eliminar = async () => {
    await eliminarElemento(
        'Producto/Eliminar',
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
    items.value = await loadGet('Producto/ObtenerListadoPaginado')
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
    //Tiene texto escrito
    if (filtroBusqueda.value != null && filtroBusqueda.value != '') {
        items.value = await loadListaFiltro(`Producto/ObtenerListadoPaginado?TextoBuscar=${filtroBusqueda.value}`)

        //Filtra por todos
        if (filtroDisponibles.value) {
            const itemsAuxiliar = ref([]);
            for (let i = 0; i < items.value.length; i++) {
                if (items.value[i].estadoProductoDescripcion === "Disponible") {
                    itemsAuxiliar.value.push(items.value[i])
                }
            }
            items.value = []
            items.value = [...itemsAuxiliar.value]
         }
    }

    //No Tiene texto escrito
     else {
        //Filtra por todos
        if (!filtroDisponibles.value) {
            items.value = await loadListaFiltro('Producto/ObtenerListadoPaginado')
        }
        //Filtra por activos
        else {
            items.value = await loadListaFiltro(`Producto/ObtenerListadoPaginado?TextoBuscar=Disponible`)
        }
    }
}
</script>
