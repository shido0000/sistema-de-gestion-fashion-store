<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" />
            <q-breadcrumbs-el label="Nomencladores" icon="dashboard" @click="router.push('/gestion')" />
            <q-breadcrumbs-el label="Trabajador" />
        </q-breadcrumbs>
        <q-table class="q-pa-md" :filter="filter" title="Útiles" :rows="items" :columns="columns"
            row-key="id" no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Trabajadores</span>
                    <q-input outline color="positive" flat v-model="filter" debounce="500" label="Buscar" />
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
                        <q-btn flat dense size="sm" @click="obtenerElementoPorIdCambiarContrasenha(props.row.id)" text-color="primary"
                            icon="password">
                            <q-tooltip class="bg-primary" :offset="[10, 10]" transition-show="flip-right"
                                transition-hide="flip-left">Cambiar Contraseña</q-tooltip>
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
                            objeto?.id ? "Editar Trabajador" : "Adicionar Trabajador"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">
                    <q-input class="col-xs-12 col-md-12" label="Nombre *" v-model="objeto.nombre" color="primary" counter
                        maxlength="50" :rules="[onlyLettersAndSpaces, string]" />

                        <q-input class="col-xs-12 col-md-12" label="Apellidos *" v-model="objeto.apellidos" color="primary" counter
                        maxlength="60" :rules="[onlyLettersAndSpaces, string]" />

                        <q-input class="col-xs-12 col-md-5" label="Usuario *" v-model="objeto.username" color="primary" counter
                        maxlength="10" :rules="[onlyLetter_Number, string]" />

                          <q-select

                        transition-show="flip-up"
                        transition-hide="flip-down"
                        class="col-xs-12 col-sm-6"
                        v-model="objeto.rolId"
                        label="Rol *"
                        emit-value
                        map-options
                        :use-input="
                            objeto.rolId === null || objeto.rolId === ''
                        "
                        option-label="nombre"
                        option-value="id"
                        :options="filtradoRoles"
                        @filter="
                            (val, update) => {
                                filtradoRoles = filterOptions(
                                val,
                                update,
                                filtradoRoles,
                                'nombre',
                                itemsRoles
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

                    <q-input class="col-xs-12 col-md-5" label="Contraseña *" v-model="objeto.contrasenna" color="primary" counter
                         maxlength="8"
                          />

                          <q-input class="col-xs-12 col-md-6" label="Confirmar Contraseña *" v-model="objeto.contrasennaConfirmada" color="primary" counter
                              maxlength="8"
                          />

                    <q-card-actions class="col-12 q-mt-md justify-end">
                        <q-btn class="text-white" color="primary" aling="right" type="submit" label="Guardar" />
                        <q-btn outline color="primary" type="reset" label="Cancelar" />
                    </q-card-actions>
                </div>
            </q-form>
        </q-card>
    </q-dialog>

    <q-dialog v-model="dialogCambiarContrasenha" persistent>
        <q-card style="width: 700px; max-width: 80vw; height: auto">
            <header class="q-pa-sm bg-primary">
                <q-toolbar>
                    <q-toolbar-title class="text-subtitle6 text-white">
                        {{
                           `Cambiar contraseña del usuario: ${objeto.username}`
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="CambiarContrasenha()" @reset="closeCambiarContrasenha" ref="myFormCambiarContrasenha">
                <div class="h row q-ma-md">
                    <q-input class="col-xs-12 col-md-3" label="Contraseña anterior *" v-model="objetoContrasenha.contrasennaAntigua" color="primary" counter
                        maxlength="8" :rules="[ ]" />

                        <q-input class="col-xs-12 col-md-3" label="Nueva contraseña *" v-model="objetoContrasenha.nuevaContrasenna" color="primary" counter
                        maxlength="8" :rules="[ ]" />

                        <q-input class="col-xs-12 col-md-5" label="Confirmación de contraseña *" v-model="objetoContrasenha.contrasennaConfirmada" color="primary" counter
                        maxlength="8" :rules="[ ]" />


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
import { dataColumnTrabajador } from "src/assets/js/column_data/columnDataGestion";
import {
    loadGet,
    saveData,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    validarSoloNumeros,
    filterOptions,
    saveDataCambiarContrasenha,
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
const columns = dataColumnTrabajador;
const filter = ref("");
const items = ref([]);

// DIALOGS VAR
const dialog = ref(false)
const dialogCambiarContrasenha = ref(false)
const dialogLoad = ref(false)
const isDialogoEliminarAbierto = ref(false)

// VAR FORM
const myForm = ref(null)
const myFormCambiarContrasenha = ref(null)
const idElementoSeleccionado = ref('')

/***************************************************************************************************
 *                                         OBJECT                                                  *
 **************************************************************************************************/
const objetoInicial = {
    nombre: null,
    apellidos: null,
    username: null,
    rolId: null,
    contrasenna: null,
    contrasennaConfirmada: null,
}

const objetoInicialContrasenha = {
    contrasennaAntigua: null,
    nuevaContrasenna: null,
    contrasennaConfirmada: null,
    usuarioId: null

}

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })
const objetoContrasenha = reactive({ ...objetoInicialContrasenha })

const filtradoRoles = ref([])
const itemsRoles = ref([]);


/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('Usuario/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    itemsRoles.value = (await loadGet('Rol/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined

    dialogLoad.value = false;
});

// EXTRAS

// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = () => {
    const url = objeto.id ? 'Usuario/Actualizar' : 'Usuario/Crear'
    saveData(url, objeto, load, close, dialogLoad)
}

const CambiarContrasenha = () => {
    const url = 'Usuario/CambiarContrasenna'
    saveDataCambiarContrasenha(url, objetoContrasenha, load, closeCambiarContrasenha, dialogLoad)
}

// Funcion para Obtener los datos para editar
const obtenerElementoPorId = async (id) => {
    filtradoRoles.value = itemsRoles.value
    await obtener('Usuario/ObtenerPorId', id, objeto, dialogLoad, dialog)
}

// Funcion para Obtener los datos para cambiar contrasenha
const obtenerElementoPorIdCambiarContrasenha = async (id) => {
    await obtener('Usuario/ObtenerPorId', id, objeto, dialogLoad, dialogCambiarContrasenha)
    objetoContrasenha.usuarioId = objeto.id
    console.log("objetoContrasenha: ",objetoContrasenha)
}

// Funcion para eliminar elemento
const eliminar = async () => {
    await eliminarElemento(
        'Usuario/Eliminar',
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
    items.value = await loadGet('Usuario/ObtenerListadoPaginado')
}

// Funcion para cerrar el dialog
const handleCloseDialog = () => {
    isDialogoEliminarAbierto.value = false
}

// Funcion para cerrar el dialog principal de Adicionar y Editar y resetear los campos del formulario
const close = async () => {
    closeDialog(objeto, objetoInicial, myForm, dialog)
}

const closeCambiarContrasenha = async () => {
    closeDialog(objetoContrasenha, objetoInicialContrasenha, myFormCambiarContrasenha, dialogCambiarContrasenha)
}
</script>
