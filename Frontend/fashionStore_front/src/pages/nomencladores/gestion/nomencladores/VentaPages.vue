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
                    <q-input bottom-slots v-model="filtroBusqueda" label="Buscar" counter maxlength="30" :dense="dense">
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
                        <!--  <q-btn flat dense size="sm" @click="obtenerElementoPorId(props.row.id)" text-color="primary"
                            icon="edit">
                            <q-tooltip class="bg-primary" :offset="[10, 10]" transition-show="flip-right"
                                transition-hide="flip-left">Editar datos</q-tooltip>
                        </q-btn>-->
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
        <q-card style="width: 800px; max-width: 80vw; height: auto">
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
                    <q-input class="col-xs-12  col-sm-5" label="Código*" v-model="objeto.codigo" color="primary" counter
                        maxlength="100" :rules="[onlyLetter_Number_No_White_Spaces, string, (val) =>
                            (items.length > 0
                                ? !isValorRepetido(val, 'Codigo', objeto, items)
                                : true) || 'Ya existe un Código con ese valor',]" />

                    <q-input class="col-xs-12 col-sm-6" label="Fecha y Hora*" v-model="objeto.fecha" color="primary"
                        type="datetime-local" :rules="[string]" />

                    <q-table flat class="q-mt-lg" :rows="objeto.productosVendidos" :columns="columnasTablaAuxiliar"
                        row-key="id" no-data-label="No hay elementos disponibles"
                        no-results-label="No hay elementos disponibles" loading-label="Cargando..."
                        rows-per-page-label="Filas por página" :rows-per-page-options="[3]" :rows-per-page="3">


                        <template v-slot:top>

                            <q-form class="col-xs-12 " @submit.prevent="guardarProducto()" ref="myFormLista">
                                <div class="row q-col-gutter-lg">
                                    <q-select class="col-xs-12 col-sm-12 col-md-3 q-py-none" :disable="disableVendedor"
                                        v-model="objetoAuxiliar.gestorId" label="Gestor *" emit-value map-options
                                        :use-input="objetoAuxiliar.gestorId === null || objetoAuxiliar.gestorId === ''
                                            " option-label="nombre" option-value="id" :options="filtradoGestor"
                                        @filter="(val, update) => {
                                            filtradoGestor = filterOptions(
                                                val,
                                                update,
                                                filtradoGestor,
                                                'nombre',
                                                itemsGestor
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
                                    <q-select class="col-xs-12 col-sm-12 col-md-3 q-py-none"
                                        v-model="objetoAuxiliar.productoId"
                                        @update:model-value="cantidadStockPorProducto(objetoAuxiliar.productoId)"
                                        label="Producto *" emit-value map-options :use-input="objetoAuxiliar.productoId === null || objetoAuxiliar.productoId === ''
                                            " option-label="descripcion" option-value="id" :options="filtradoProducto"
                                        @filter="(val, update) => {
                                            filtradoProducto = filterOptions(
                                                val,
                                                update,
                                                filtradoProducto,
                                                'descripcion',
                                                itemsProducto
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
                                    <q-input :disable="!objetoAuxiliar.productoId"
                                        class="col-xs-12 col-sm-5 col-md-2 q-py-none" label="Cantidad *" type="number"
                                        v-model="objetoAuxiliar.cantidad" :min="1" :max="cantidadStockProducto" :rules="[
                                            (val) => (val === 0 || val === '0') ? 'El valor de la Cantidad no puede estar en cero' : true
                                        ]">
                                    </q-input>
                                    <q-input class="col-xs-12 col-sm-6  col-md-2 q-py-none" label="Precio del Gestor*"
                                        v-model="objetoAuxiliar.precioGestor" mask="#.##" fill-mask="0"
                                        reverse-fill-mask prefix="$" :min="0" :rules="[
                                            (val) => (val === 0 || val === '0') ? 'El valor de Precio no puede estar en cero' : true
                                        ]">
                                    </q-input>

                                    <q-btn
                                        class="bg-primary col-xs-1 col-sm-1  col-md-1 q-py-none q-px-none q-ml-md q-mt-md justify-end"
                                        outline color="white" style="height: 2%; width: 5%; border-radius: 10%;"
                                        icon="save" type="submit">
                                        <q-tooltip>
                                            {{ "Guardar" }}
                                        </q-tooltip>
                                    </q-btn>

                                </div>


                            </q-form>


                            <div class="col-12 q-table__title">
                                <span>Productos agregados</span>
                            </div>
                        </template>


                        <template v-slot:body-cell-producto="props">
                            <q-td :props="props">
                                {{ getProductoDescripcion(props.row.productoId) }}
                            </q-td>
                        </template>

                        <template v-slot:body-cell-precioGestorTotal="props">
                            <q-td :props="props">
                                {{ calcularPrecioTotal(props.row.cantidad, props.row.precioGestor) }}
                            </q-td>
                        </template>

                        <template v-slot:body-cell-action="props">
                            <q-td :props="props">
                                <div class="q-gutter-sm">
                                  <!--  <q-btn flat dense size="sm" @click="obtenerElementoPorIdCuentasMoneda(props.row.id)"
                                        text-color="primary" icon="edit">
                                        <q-tooltip>Editar</q-tooltip>
                                    </q-btn>-->
                                    <q-btn flat dense size="sm" @click="eliminarProductoAgregado(props.row.id)"
                                        text-color="negative" icon="delete">
                                        <q-tooltip>Eliminar datos</q-tooltip>
                                    </q-btn>
                                </div>
                            </q-td>
                        </template>
                        <template v-slot:body-cell-esPorciento="props">
                            <q-td :props="props">
                                <q-icon flat :name="(props.value == 0) ? 'highlight_off' : 'check_circle'"
                                    :class="(props.value == 0) ? 'text-grey' : 'text-primary'" size="20px" />
                            </q-td>
                        </template>
                    </q-table>

                    <!--<q-btn flat dense size="sm" @click="eliminarProducto(props.row.id)"
                                            text-color="negative" icon="delete">
                                            <q-tooltip class="bg-red" :offset="[10, 10]" transition-show="flip-right"
                                                transition-hide="flip-left">Eliminar</q-tooltip>
                                        </q-btn>-->


                    <q-card-actions class="col-12 q-mt-md justify-end">
                        <!--  <q-btn class="text-white" color="primary" aling="right" :disable="!validarBotonAgregarProducto()"
                            @click="guardarProducto(objetoAuxiliar.productoId)" type="button"
                            label="Agregar producto a la lista" />  -->
                        <q-btn :disable="objeto.productosVendidos.length ===0" class="text-white" color="primary" aling="right"
                            type="submit" label="Guardar venta" />
                        <q-btn outline color="primary" type="reset" label="Cancelar" />
                    </q-card-actions>
                </div>
            </q-form>
        </q-card>
    </q-dialog>
</template>

<script setup>
// IMPORT LIBRERIES
import { dataColumnVenta, dataColumnVentaAuxiliar } from "src/assets/js/column_data/columnDataGestion";
import {
    loadGet,
    saveData,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    filterOptions,
    loadGetOneElement,
    loadListaFiltro,
} from 'src/assets/js/util/funciones'
import { PonerPuntosSupensivosACampo } from 'src/assets/js/util/extras'
import { onlyLetter_Number, onlyLetter_Number_No_White_Spaces, string } from 'src/assets/js/util/validator_form'
import { Error } from "src/assets/js/util/notify";
import { Error_Notify_DelecteObject } from "src/assets/js/util/dicc_notify";

// IMPORT COMPONENTS
import DialogLoad from 'src/components/dialog_boxes/DialogLoad.vue'
import DialogEliminar from 'src/components/dialog_boxes/DialogEliminar.vue'

// IMPORT HOOKS
import { ref, onMounted, reactive, watch, nextTick, computed } from "vue";
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
const filtroBusqueda = ref('')



// DIALOGS VAR
const dialog = ref(false)
const dialogLoad = ref(false)
const isDialogoEliminarAbierto = ref(false)

const disableVendedor = ref(false)


// VAR FORM
const myForm = ref(null)
const myFormLista = ref(null)
const idElementoSeleccionado = ref('')
let cantidadStockProducto = 0

/***************************************************************************************************
 *                                         OBJECT                                                  *
 **************************************************************************************************/
/*const objetoInicial = {
    fecha: null,
    gestorId: null,
    productosIds:null,
    preciosGestor:null,
    cantidades:null,
    codigo:null,
}*/

const objetoInicial = {
    codigo: null,
    fecha: null,
    productosVendidos: []
    /* productosVendidos : [{
         precioGestor: 0,
         cantidad: 0,
         productoId: null,
         gestorId: null,
         ventaId: null

     }]*/
}

const objetoAuxiliarInicial = {
    precioGestor: 0,
    cantidad: 0,
    productoId: null,
    gestorId: null,
    ventaId: "93332a5c-f55b-430d-aa6c-08dce57ce488"
}

const objetoProductoAuxiliarInicial = {
    cantidad: 0,
    productoId: null,
}

/*const objetoAuxiliarInicial = {
    id: null,
    productoId: null,
    productoNombre: null,
    cantidad: 1,
    precioGestor: 0,
}
*/
// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })
const objetoAuxiliar = reactive({ ...objetoAuxiliarInicial })
const objetoProductoAuxiliar = reactive({ ...objetoProductoAuxiliarInicial })


/***************************************************************************************************
 *                                         LISTAS                                                  *
 **************************************************************************************************/
const itemsGestor = ref([])
const filtradoGestor = ref([])
const itemsProducto = ref([])
const filtradoProducto = ref([])
const listaPrecios = ref([])
const listaCantidades = ref([])
const listaProductosIds = ref([])
const itemsTablaAuxiliar = ref([]);

const itemsproductosVendidosAuxiliar = ref([]);

const itemsProductoOficial = ref([]);

const itemsProductoAdicionados = ref([]);
/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('Venta/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    itemsGestor.value = (await loadGet('Gestor/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    const itemsProductosTodos = (await loadGet('Producto/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    productosConStock(itemsProductosTodos)
    console.log("ventas: ", items)

    itemsProducto.value = (await loadGet('Producto/ObtenerListadoPaginado')) ?? [];
    itemsProductoOficial.value = (await loadGet('Producto/ObtenerListadoPaginado')) ?? [];
    dialogLoad.value = false;
});

// EXTRAS


// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = () => {
    const url = objeto.id ? 'Venta/Actualizar' : 'Venta/Crear'
    //guardarPreciosCantidadesEnListas()
  /*  objeto.productosIds = listaProductosIds.value
    objeto.preciosGestor = listaPrecios.value
    objeto.cantidades = listaCantidades.value*/
    saveData(url, objeto, load, close, dialogLoad)
}

// Funcion para Obtener los datos para editar

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
        }).catch(async () => {
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
    //itemsGestor.value = await loadGet('Gestor/ObtenerListadoPaginado')
    // itemsProducto.value = await loadGet('Producto/ObtenerListadoPaginado')
}

// Funcion para cerrar el dialog
const handleCloseDialog = () => {
    isDialogoEliminarAbierto.value = false
}

// Funcion para cerrar el dialog principal de Adicionar y Editar y resetear los campos del formulario
const close = async () => {
    closeDialog(objeto, objetoInicial, myForm, dialog)
}

function eliminarProducto(id) {
    const producto = itemsTablaAuxiliar.value.find(item => item.id === id);
    console.log("producto_eliminar: ", producto)
    if (producto) {
        const reinsertarProducto = { id: producto.productoId, descripcion: producto.productoNombre };
        itemsProducto.value.push(reinsertarProducto);
        console.log("producto_lista: ", itemsProducto)
        itemsTablaAuxiliar.value = itemsTablaAuxiliar.value.filter(item => item.id !== id);
    }
}

function guardarPreciosCantidadesEnListas() {
    if (Array.isArray(itemsTablaAuxiliar.value) && itemsTablaAuxiliar.value.length > 0) {
        for (let i = 0; i < itemsTablaAuxiliar.value.length; i++) {
            if (itemsTablaAuxiliar.value[i] && itemsTablaAuxiliar.value[i].precioGestor) {
                listaPrecios.value.push(itemsTablaAuxiliar.value[i].precioGestor);
                listaProductosIds.value.push(itemsTablaAuxiliar.value[i].productoId);
                listaCantidades.value.push(itemsTablaAuxiliar.value[i].cantidad);
            }
        }
    } else {
        console.error("itemsTablaAuxiliar no está definido o está vacío.");
    }
}

/*function guardarProducto(id) {
    const producto = itemsProducto.value.find(item => item.id === id);
    console.log(producto)
    if (producto) {
        objetoAuxiliar.id = producto.id;
        objetoAuxiliar.productoId = producto.id;
        objetoAuxiliar.productoNombre = producto.descripcion;
        itemsTablaAuxiliar.value.push({ ...objetoAuxiliar });
        itemsProducto.value = itemsProducto.value.filter(item => item.id !== id);
    }
}*/

const guardarProducto = () => {
    //const producto = itemsProducto.value.find(item => item.id === id);
    objetoAuxiliar.cantidad = Number(objetoAuxiliar.cantidad)
    objetoAuxiliar.precioGestor = Number(objetoAuxiliar.precioGestor)
    const producto = itemsProducto.value.find(item => item.id === objetoAuxiliar.productoId)


    if (objetoAuxiliar.cantidad === producto.cantidadStock) {
        itemsProducto.value = itemsProducto.value.filter(item => item.id !== producto.id)
    }

    objeto.productosVendidos.push({ ...objetoAuxiliar })

    objetoProductoAuxiliar.productoId = objetoAuxiliar.productoId
    objetoProductoAuxiliar.cantidad = objetoAuxiliar.cantidad

    itemsProductoAdicionados.value.push({ ...objetoProductoAuxiliar })

    Object.assign(objetoProductoAuxiliar, objetoProductoAuxiliarInicial)
    objetoAuxiliar.productoId = null
    objetoAuxiliar.precioGestor = 0
    objetoAuxiliar.cantidad = 0





    console.log("objeto: ", objeto)
}

const validarButtonGuardar = () => {
    console.log("itemsTablaAuxiliar.value.length: ", itemsTablaAuxiliar.value.length)
    return itemsTablaAuxiliar.value.length === 0 ? true : false
}

const cantidadStockPorProducto = async (id) => {
    let producto = await loadGetOneElement(`Producto/ObtenerPorId/${id}`)
    cantidadStockProducto = producto.cantidadStock
    await nextTick();
}

watch(() => objetoAuxiliar.productoId, async (newVal) => {
    if (newVal) {
        await cantidadStockPorProducto(newVal)
    }
})

const productosConStock = (lista) => {
    for (let i = 0; i < lista.length; i++) {
        if (lista[i].cantidadStock !== 0) {
            itemsProducto.value.push(lista[i])
        }
    }
    console.log("itemsProducto: ", itemsProducto)

}

const validarBotonAgregarProducto = () => {
    let todoCorrecto = true
    if (!objetoAuxiliar.productoId) {
        todoCorrecto = false
    }
    else if (!objetoAuxiliar.precioGestor) {
        todoCorrecto = false
    }
    else if (!objetoAuxiliar.cantidad) {
        todoCorrecto = false
    }
    return todoCorrecto
}

/*const transformData = (data) => {
  return data.map(item => ({
    id: item.id, // Incluye el id en los datos transformados
    fecha: item.fecha,
    codigo: item.codigo,
    gestor: item.gestor.nombre +" "+ item.gestor.apellidos,
    action: 'Acciones' // Puedes personalizar esto según tus necesidades
  }))
}

const transformedItems = computed(() => transformData(items.value))
*/

// Funcion para cargar lista de busqueda por codigo o descripcion ademas del filtro seleccionado
const CargarBusquedaFiltro = async () => {
    //Tiene texto escrito
    if (filtroBusqueda.value != null && filtroBusqueda.value != '') {
        items.value = await loadListaFiltro(`Venta/ObtenerListadoPaginado?TextoBuscar=${filtroBusqueda.value}`)

        //Filtra por todos
        if (filtroActivos.value) {
            const itemsAuxiliar = ref([]);
            for (let i = 0; i < items.value.length; i++) {
                if (items.value[i].activo) {
                    itemsAuxiliar.value.push(items.value[i])
                }
            }
            items.value = []
            items.value = [...itemsAuxiliar.value]
        }
    }
    //No Tiene texto escrito
    else {
        items.value = await loadListaFiltro('Venta/ObtenerListadoPaginado')
    }
}

const getProductoDescripcion = (id) => {
    const producto = itemsProductoOficial.value.find(item => item.id === id)
    return producto ? producto.descripcion : ''
}

const calcularPrecioTotal = (cantidad, precioGestor) => {
    return cantidad * precioGestor
}


const eliminarProductoAgregado = (id) => {
    objeto.productosVendidos = objeto.productosVendidos.filter(item => item.id !== id)
   // itemsProducto.value = itemsProducto.value.filter(item => item.id !== producto.id)

   itemsProducto.value = itemsProductoOficial.value.filter(item =>
        !objeto.productosVendidos.some(vendido => vendido.id === item.id)
    );
    /* itemsMonedas.value = itemsMonedasAuxiliar.value.filter(moneda =>
         !itemsListaAuxiliarCuentasMonedas.value.some(aux => aux.monedaId === moneda.id)
     )*/
}

watch(
    () => objeto.productosVendidos,
    (newVal) => {
        disableVendedor.value = newVal.length > 0;
    },
    { immediate: true, deep: true }
);

</script>
