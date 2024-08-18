<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" />
            <q-breadcrumbs-el label="Nomencladores" icon="dashboard" @click="router.push('/gestion')" />
            <q-breadcrumbs-el label="Venta" />
        </q-breadcrumbs>
        <q-table class="q-pa-md" :filter="filter" title="Útiles" :rows="items" :columns="columns" row-key="id"
            no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Ventas</span>
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
                            objeto?.id ? "Editar Venta" : "Adicionar Venta"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">
                    <q-input class="col-xs-12  col-sm-5" label="Código*" v-model="objeto.codigo" color="primary"
                        counter maxlength="100" :rules="[onlyLetter_Number_No_White_Spaces, string, (val) =>
                            (items.length > 0
                                ? !isValorRepetido(val, 'Codigo', objeto, items)
                                : true) || 'Ya existe un Código con ese valor',]" />

                    <q-input class="col-xs-12 col-sm-6" label="Fecha y Hora*" v-model="objeto.fechaHora"
                                color="primary" type="datetime-local"/>

                    <q-select
                        transition-show="flip-up"
                        transition-hide="flip-down"
                        class="col-xs-12 col-sm-5"
                        v-model="objeto.gestorId"
                        label="Gestor *"
                        emit-value
                        map-options
                        :use-input="
                            objeto.gestorId === null || objeto.gestorId === ''
                        "
                        option-label="descripcion"
                        option-value="id"
                        :options="filtradoGestor"
                        @filter="
                            (val, update) => {
                                filtradoGestor = filterOptions(
                                val,
                                update,
                                filtradoGestor,
                                'descripcion',
                                itemsGestor
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

                    <q-select
                        transition-show="flip-up"
                        transition-hide="flip-down"
                        class="col-xs-12 col-sm-6"
                        v-model="objetoAuxiliar.productoId"
                        label="Producto *"
                        emit-value
                        map-options
                        :use-input="
                            objetoAuxiliar.productoId === null || objetoAuxiliar.productoId === ''
                        "
                        option-label="descripcion"
                        option-value="id"
                        :options="filtradoProducto"
                        @filter="
                            (val, update) => {
                                filtradoProducto = filterOptions(
                                val,
                                update,
                                filtradoProducto,
                                'descripcion',
                                itemsProducto
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

                    <q-input class="col-xs-12 col-sm-5 q-mt-md" label="Cantidad *" outlined
                            v-model="objetoAuxiliar.cantidad" type="number" :min="1"
                             :rules="[
                                (val) => (val === 0 || val === '0') ? 'El valor de la Cantidad no puede estar en cero' : true
                            ]">
                    </q-input>
                    <q-input class="col-xs-12 col-sm-6 q-mt-md" label="Precio del Gestor*" outlined
                            v-model="objetoAuxiliar.precioGestor" type="number" prefix="$" :min="0"
                             :rules="[
                                (val) => (val === 0 || val === '0') ? 'El valor de Precio no puede estar en cero' : true
                            ]">
                    </q-input>


                       <!-- Tabla con scroll vertical -->
                <div class="col-xs-12" style="max-height: 200px; overflow-y: auto;">
                    <q-table
                        :rows="itemsTablaAuxiliar"
                        :columns="columnasTablaAuxiliar"
                        row-key="id">

                        <template v-slot:body-cell-action="props">
                            <q-td :props="props">
                                <div class="q-gutter-sm">
                                    <q-btn flat dense size="sm" @click="eliminarProducto(props.row.id)" text-color="negative"
                                        icon="delete">
                                        <q-tooltip class="bg-red" :offset="[10, 10]" transition-show="flip-right"
                                            transition-hide="flip-left">Eliminar</q-tooltip>
                                    </q-btn>
                                </div>
                            </q-td>
                        </template>
                    </q-table>
                </div>

                    <q-card-actions class="col-12 q-mt-md justify-end">
                        <q-btn class="text-white" color="primary" aling="right" @click="guardarProducto(objetoAuxiliar.productoId)"
                         type="button" label="Agregar producto a la lista" />
                        <q-btn class="text-white" color="primary" aling="right" type="submit" label="Guardar venta" />
                        <q-btn outline color="primary" type="reset" label="Cancelar" />
                    </q-card-actions>
                </div>
            </q-form>
        </q-card>
    </q-dialog>
</template>

<script setup>
// IMPORT LIBRERIES
import { dataColumnVenta,dataColumnVentaAuxiliar } from "src/assets/js/column_data/columnDataGestion";
import {
    loadGet,
    saveData,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    filterOptions,
} from 'src/assets/js/util/funciones'
import {PonerPuntosSupensivosACampo} from 'src/assets/js/util/extras'
import { onlyLetter_Number, onlyLetter_Number_No_White_Spaces, string } from 'src/assets/js/util/validator_form'
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
const columns = dataColumnVenta;
const columnasTablaAuxiliar = dataColumnVentaAuxiliar;
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
    fecha: null,
    gestorId: null,
    productoId:null,
    cantidad:1,
    precioGestor:0,
}

const objetoAuxiliarInicial = {
    id:null,
    productoId:null,
    productoNombre:null,
    cantidad:1,
    precioGestor:0,
}

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })
const objetoAuxiliar = reactive({ ...objetoAuxiliarInicial })


/***************************************************************************************************
 *                                         LISTAS                                                  *
 **************************************************************************************************/
const itemsGestor = ref([])
const filtradoGestor = ref([])
//const itemsProducto = ref([])
const filtradoProducto = ref([])

const itemsProducto = ref([
  { id: 1, descripcion: 'Producto 1'},
  { id: 2, descripcion: 'Producto 2' },
  { id: 3, descripcion: 'Producto 3' },
]);



const itemsTablaAuxiliar = ref([]);

/*const itemsTablaAuxiliar = ref([
  { id: 1, nombreProducto: 'Producto 1', precioGestor: 20 },
  { id: 2, nombreProducto: 'Producto 2', precioGestor: 22  },
  { id: 3, nombreProducto: 'Producto 3' , precioGestor: 10 },
]);*/

/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('Venta/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined

    dialogLoad.value = false;
});

// EXTRAS


// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = () => {
    const url = objeto.id ? 'Venta/Actualizar' : 'Venta/Crear'
    saveData(url, objeto, load, close, dialogLoad)
}

// Funcion para Obtener los datos para editar
const obtenerElementoPorId = async (id) => {
    filtradoProducto.value=itemsProducto.value
    await obtener('Venta/ObtenerPorId', id, objeto, dialogLoad, dialog)
}

// Funcion para eliminar elemento
const eliminar = async () => {
    await eliminarElemento(
        'Venta/Eliminar',
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
    items.value = await loadGet('Venta/ObtenerListadoPaginado')
}

// Funcion para cerrar el dialog
const handleCloseDialog = () => {
    isDialogoEliminarAbierto.value = false
}

// Funcion para cerrar el dialog principal de Adicionar y Editar y resetear los campos del formulario
const close = async () => {
    closeDialog(objeto, objetoInicial, myForm, dialog)
}

// Funcion para eliminar producto de la lista auxiliar
/*function eliminarProducto(id) {
  itemsTablaAuxiliar.value = itemsTablaAuxiliar.value.filter(item => item.id !== id);
}*/

function eliminarProducto(id) {
  const producto = itemsTablaAuxiliar.value.find(item => item.id === id);
  console.log("producto_eliminar: ",producto)
  if (producto) {
    const reinsertarProducto={ id: producto.productoId, descripcion: producto.productoNombre};
    itemsProducto.value.push(reinsertarProducto);
    console.log("producto_lista: ",itemsProducto)
    itemsTablaAuxiliar.value = itemsTablaAuxiliar.value.filter(item => item.id !== id);
  }
}

// Funcion para guardar valores en la lista auxiliar
/*function guardarProducto() {
  if (!itemsTablaAuxiliar.value.includes(objetoAuxiliar.productoId)) {
    itemsTablaAuxiliar.value.push(objetoAuxiliar);
  }
  }*/

  function guardarProducto(id) {
  const producto = itemsProducto.value.find(item => item.id === id);
  console.log(producto)
  if (producto) {
    objetoAuxiliar.id=producto.id;
    objetoAuxiliar.productoId = producto.id;
    objetoAuxiliar.productoNombre = producto.descripcion;
    console.log(objetoAuxiliar)
    itemsTablaAuxiliar.value.push({ ...objetoAuxiliar });
   // itemsTablaAuxiliar.value.push(objetoAuxiliar);
    itemsProducto.value = itemsProducto.value.filter(item => item.id !== id);
  }
}
</script>
