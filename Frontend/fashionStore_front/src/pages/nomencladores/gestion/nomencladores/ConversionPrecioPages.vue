<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" />
            <q-breadcrumbs-el label="Nomencladores" icon="dashboard" @click="router.push('/gestion')" />
            <q-breadcrumbs-el label="ConversionPrecio" />
        </q-breadcrumbs>
        <q-table class="q-pa-md" :filter="filter" title="Útiles" :rows="transformedItems" :columns="columns"
            row-key="id" no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Conversión de Precios</span>
                    <q-input outline color="primary" flat v-model="filter" debounce="500" label="Buscar" />
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
            <template v-slot:body-cell-descripcion="props">
                <q-td :props="props">
                    <div>
                        {{ PonerPuntosSupensivosACampo(props.row?.descripcion, 30) }}
                        <q-tooltip>{{ props.row?.descripcion }}</q-tooltip>
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
            <header class="q-pa-sm bg-primary">
                <q-toolbar>
                    <q-toolbar-title class="text-subtitle6 text-white">
                        {{
                            objeto?.id ? "Editar Conversión de Precio" : "Adicionar Conversión de Precio"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">
                    <q-select :disable="!!objeto.id" transition-show="flip-up" transition-hide="flip-down"
                        class="col-xs-5 col-sm-5" v-model="objeto.descripcion" label="Moneda *" emit-value map-options
                        :use-input="objeto.descripcion === null || objeto.descripcion === ''
                            " option-label="name" option-value="name" :options="filtradoMoneda" @filter="(val, update) => {
                                filtradoMoneda = filterOptions(
                                    val,
                                    update,
                                    filtradoMoneda,
                                    'name',
                                    itemsMonedas
                                );
                            }
                            " lazy-rules :rules="[
                            (val) =>
                                (val !== null && val !== '') ||
                                'Debe seleccionar un elemento',
                        ]">
                        <template v-slot:no-option>
                            <q-item>
                                <q-item-section class="text-italic text-grey">
                                    No hay elementos disponibles
                                </q-item-section>
                            </q-item>
                        </template>
                    </q-select>

                    <q-input class="col-xs-6 col-md-6" label="Valor *" outlined v-model="objeto.valorCambio"
                        @keypress="(event) => validarSpinnerGenerico(event, objeto.valorCambio, '0-9', 4, false)"
                        fill-mask="0" reverse-fill-mask prefix="$" :min="0" :rules="[
                            (val) => (val === 0 || val === '0') ? 'El valor no puede estar en cero' : true
                        ]">
                    </q-input>

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
import { dataColumnConversion_Precio } from "src/assets/js/column_data/columnDataGestion";
import {
    loadGet,
    saveData,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    filterOptions,
    validarSpinnerGenerico,
} from 'src/assets/js/util/funciones'
import { PonerPuntosSupensivosACampo } from 'src/assets/js/util/extras'
import { onlyLetter_Number, string, onlyLetter_Number_No_White_Spaces } from 'src/assets/js/util/validator_form'
import { Error } from "src/assets/js/util/notify";
import { Error_Notify_DelecteObject } from "src/assets/js/util/dicc_notify";

// IMPORT COMPONENTS
import DialogLoad from 'src/components/dialog_boxes/DialogLoad.vue'
import DialogEliminar from 'src/components/dialog_boxes/DialogEliminar.vue'

// IMPORT HOOKS
import { ref, onMounted, reactive, computed } from "vue";
import { useRouter } from "vue-router";

/***************************************************************************************************
 *                                        VARIABLES                                                *
 **************************************************************************************************/

// HOOKS
const router = useRouter();

// DATOS DE LA TABLA
const columns = dataColumnConversion_Precio;
const filter = ref("");
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
    descripcion: null,
    valorCambio: 0,
}

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })

/***************************************************************************************************
 *                                         LISTAS                                                  *
 **************************************************************************************************/
const filtradoMoneda = ref([])
const itemsMonedas = ref([
    { id: 1, name: 'US Dollar', code: 'USD' },
    { id: 2, name: 'Euro', code: 'EUR' },
    { id: 3, name: 'Japanese Yen', code: 'JPY' },
    { id: 4, name: 'British Pound', code: 'GBP' },
    { id: 5, name: 'Australian Dollar', code: 'AUD' },
    { id: 6, name: 'Canadian Dollar', code: 'CAD' },
    { id: 7, name: 'Swiss Franc', code: 'CHF' },
    { id: 8, name: 'Chinese Yuan Renminbi', code: 'CNY' },
    { id: 9, name: 'Swedish Krona', code: 'SEK' },
    { id: 10, name: 'New Zealand Dollar', code: 'NZD' }
]);

/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('ConversionPrecio/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    console.log(items)
    dialogLoad.value = false;

    // Filtrar las monedas que no están en la lista items
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
});

// EXTRAS

// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = async () => {
    const url = objeto.id ? 'ConversionPrecio/Actualizar' : 'ConversionPrecio/Crear'

    console.log("objeto: ", objeto)
    await saveData(url, objeto, load, close, dialogLoad)
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
}

// Funcion para Obtener los datos para editar
const obtenerElementoPorId = async (id) => {
    filtradoMoneda.value = itemsMonedas.value
    await obtener('ConversionPrecio/ObtenerPorId', id, objeto, dialogLoad, dialog)
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
}

// Funcion para eliminar elemento
const eliminar = async () => {
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
    await eliminarElemento(
        'ConversionPrecio/Eliminar',
        idElementoSeleccionado.value,
        load,
        dialogLoad
    ).
        then(async (response) => {
            return response
        }).catch(async (error) => {
            Error(Error_Notify_DelecteObject)
        })

    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
}

// Funcion para abrir el dialog de eliminar y pasar el id del elemento
const abrirDialogoEliminar = (id) => {
    idElementoSeleccionado.value = id
    isDialogoEliminarAbierto.value = true
}

// 2- Funcion para pasar por parametro el arreglo de los elmentos de la tabla
const load = async () => {
    items.value = await loadGet('ConversionPrecio/ObtenerListadoPaginado')
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
}

// Funcion para cerrar el dialog
const handleCloseDialog = () => {
    isDialogoEliminarAbierto.value = false
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
}

// Funcion para cerrar el dialog principal de Adicionar y Editar y resetear los campos del formulario
const close = async () => {
    closeDialog(objeto, objetoInicial, myForm, dialog)
    itemsMonedas.value = itemsMonedas.value.filter(moneda => !items.value.some(item => item.descripcion === moneda.name))
}

const transformData = (data) => {
    return data.map(item => ({
        id: item.id, // Incluye el id en los datos transformados
        descripcion: item.descripcion,
        valorCambio: item.valorCambio + " cup",

        action: 'Acciones' // Puedes personalizar esto según tus necesidades
    }))
}

const transformedItems = computed(() => transformData(items.value))
</script>
