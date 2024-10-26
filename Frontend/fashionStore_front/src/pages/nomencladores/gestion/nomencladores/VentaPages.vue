<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md" style="color: #e1e1e1">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" style="color: #e1e1e1"/>
            <q-breadcrumbs-el label="Nomencladores" icon="dashboard" @click="router.push('/gestion')" style="color: #e1e1e1"/>
            <q-breadcrumbs-el label="Venta" />
        </q-breadcrumbs>
        <q-table class="q-pa-md" :filter="filter" title="Útiles" :rows="items" :columns="columns" row-key="id"
        no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Ventas</span>
                    <q-input bottom-slots v-model="filtroBusqueda" label="Buscar" counter maxlength="30" >
                        <q-btn round dense flat icon="search" @click="CargarBusquedaFiltro" />
                    </q-input>
                </div>
                <q-space />




                <q-btn class="bg-primary" style="width: 20px" color="primary" icon="add" @click="abrirDialogoInsertar()">
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
                        {{ PonerPuntosSupensivosACampo(props.row?.codigo, 30) }}
                        <q-tooltip>{{ props.row?.descripcion }}</q-tooltip>
                    </div>
                </q-td>
            </template>

            <template v-slot:body-cell-fecha="props">
                <q-td :props="props">
                    <div>
                        {{ getFechaVentaPasandoFechaDeBaseDatos(props.row.fecha) }}
                    </div>
                </q-td>
            </template>


            <template v-slot:body-cell-gestor="props">
                <q-td :props="props">
                    <div>
                        {{ getGestorNombre(props.row.id) }}
                    </div>
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
        <q-card style="width: auto; max-width: 80vw; height: auto">
            <header class="q-pa-sm " style="background: linear-gradient(146deg,#222222  0%, #656e6e 150%)">
                <q-toolbar>
                    <q-toolbar-title class="text-subtitle6 text-white">
                        {{
                            objeto?.id ? "Editar Venta" : "Adicionar Venta"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">

                    <q-input class="col-xs-12  col-sm-12 col-md-6 q-pa-md" label="Código *" v-model="objeto.codigo" color="primary" counter
                        maxlength="30" :rules="[onlyLetter_Number_No_White_Spaces, string, (val) =>
                            (items.length > 0
                                ? !isValorRepetido(val, 'Codigo', objeto, items)
                                : true) || 'Ya existe un Código con ese valor',]" />

                    <q-input class="col-xs-12 col-sm-12  col-md-6 q-pa-md" label="Fecha y Hora *" v-model="objeto.fecha" color="primary"
                        type="datetime-local" :rules="[string]" />


                        <q-form class="col-xs-12 q-pa-md" @submit.prevent="guardarProducto()" ref="myFormLista">
                                <div class="row q-col-gutter-lg">
                                    <q-select class="col-xs-12 col-sm-12 col-md-6   " :disable="disableVendedor"
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
                                    <q-select class="col-xs-12 col-sm-12 col-md-6  "
                                        v-model="objetoAuxiliar.productoId"
                                        @update:model-value="cantidadStockPorProducto(objetoAuxiliar.productoId)"
                                        label="Producto *" emit-value map-options :use-input="objetoAuxiliar.productoId === null || objetoAuxiliar.productoId === ''
                                            " option-label="codigo" option-value="id" :options="filtradoProducto"
                                        @filter="(val, update) => {
                                            filtradoProducto = filterOptions(
                                                val,
                                                update,
                                                filtradoProducto,
                                                'codigo',
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
                                        class="col-xs-12 col-sm-5 col-md-6  " label="Cantidad *" type="number"
                                        v-model="objetoAuxiliar.cantidad" :min="1" :max="cantidadStockProducto" :rules="[
                                            (val) => (val === 0 || val === '0') ? 'El valor de la Cantidad no puede estar en cero' : true
                                        ]">
                                    </q-input>
                                    <q-input :disable="!objetoAuxiliar.productoId" class="col-xs-12 col-sm-6  col-md-4  " label="Precio del Gestor *"
                                        v-model="objetoAuxiliar.precioGestor" mask="#.##" fill-mask="0"
                                        reverse-fill-mask prefix="$" :min="0" :rules="[
                                            (val) => (val === 0 || val === '0') ? 'El valor de Precio no puede estar en cero' : true
                                        ]">
                                    </q-input>

                                    <q-btn  outline
                                        class="bg-primary col-xs-1 col-sm-1  col-md-2 q-ma-md q-py-none q-px-none q-mt-xl"
                                          color="white" style="height: 5%; width: 5%; border-radius: 30%;"
                                        icon="save" type="submit">
                                        <q-tooltip>
                                            {{ "Guardar" }}
                                        </q-tooltip>
                                    </q-btn>

                                </div>


                            </q-form>

                    <q-table flat class="col-xs-12 q-px-md" :rows="objeto.productosVendidos" :columns="columnasTablaAuxiliar"
                        row-key="id" no-data-label="No hay elementos disponibles"
                        no-results-label="No hay elementos disponibles" loading-label="Cargando..."
                        rows-per-page-label="Filas por página" :rows-per-page-options="[3]" :rows-per-page="3">


                        <template v-slot:top>

                            <div class="col-12 q-table__title ">
                                <span>Productos agregados</span>
                            </div>
                        </template>


                        <template v-slot:body-cell-producto="props">
                            <q-td :props="props">
                                {{ getProductoDescripcion(props.row.productoId) }}
                            </q-td>
                        </template>

                        <template v-slot:body-cell-precioGestor="props">
                <q-td :props="props">
                    {{convertirValoresADecimal(props.row.precioGestor)}}
                </q-td>
            </template>

                        <template v-slot:body-cell-precioGestorTotal="props">
                            <q-td :props="props">
                                {{ convertirValoresADecimal(calcularPrecioTotal(props.row.cantidad, props.row.precioGestor)) }}
                            </q-td>
                        </template>

                        <template v-slot:body-cell-action="props">
                            <q-td :props="props">
                                <div class="q-gutter-sm">
                                  <!--  <q-btn flat dense size="sm" @click="obtenerElementoPorIdCuentasMoneda(props.row.id)"
                                        text-color="primary" icon="edit">
                                        <q-tooltip>Editar</q-tooltip>
                                    </q-btn>-->
                                    <q-btn flat dense size="sm" @click="eliminarProductoAgregado(props.rowIndex)"
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
    saveDataSinMensaje,
    isValorRepetido,
    eliminarElemento,
    obtener,
    closeDialog,
    filterOptions,
    loadGetOneElement,
    loadListaFiltro,
} from 'src/assets/js/util/funciones'
import { PonerPuntosSupensivosACampo, convertirValoresADecimal, getFechaVentaPasandoFechaDeBaseDatos } from 'src/assets/js/util/extras'
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
const itemsProductoCompleto = ref([])
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
    //const itemsProductosTodos = (await loadGet('Producto/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined

    itemsProductoCompleto.value = (await loadGet('Producto/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined

    productosConStock(itemsProductoCompleto.value)
    console.log("ventas: ", items)

    itemsProducto.value = (await loadGet('Producto/ObtenerListadoPaginado')) ?? [];
    itemsProductoOficial.value = (await loadGet('Producto/ObtenerListadoPaginado')) ?? [];
    dialogLoad.value = false;
});

// EXTRAS


// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = async () => {
    const url = objeto.id ? 'Venta/Actualizar' : 'Venta/Crear'

    await actualizarStockProductos()
    saveData(url, objeto, load, close, dialogLoad)
}

const actualizarStockProductos = async () =>{
    const urlProducto = 'Producto/Actualizar'
    for(let i=0;i<objeto.productosVendidos.length;i++){
        console.log("objeto.productosVendidos[i]: ",objeto.productosVendidos[i])
        let producto = await loadGetOneElement(`Producto/ObtenerPorId/${objeto.productosVendidos[i].productoId}`)
        producto.cantidadStock = producto.cantidadStock-objeto.productosVendidos[i].cantidad

        saveDataSinMensaje(urlProducto, producto)
    }
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
    Object.assign(objetoAuxiliar, objetoAuxiliarInicial)
    objeto.productosVendidos = []
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
    productosConStock(itemsProductoCompleto.value)




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

/*const productosConStock = (lista) => {
    const vendidosIds = objeto.productosVendidos.map(p => p.productoId)
    for (let i = 0; i < lista.length; i++) {
        const producto = lista[i]
        if (producto.cantidadStock !== 0) {
       // if (lista[i].cantidadStock !== 0) {
           // itemsProducto.value.push(lista[i])
           // Verifica si el producto no está en productosVendidos
      if (!vendidosIds.includes(producto.id)) {
        itemsProducto.value.push(producto);
      }
        }
    }

    // Agrega productos de itemsProductoCompleto que no están en productosVendidos
  for (let i = 0; i < itemsProductoCompleto.value.length; i++) {
    const productoCompleto = itemsProductoCompleto.value[i];

    if (!vendidosIds.includes(productoCompleto.id) && !itemsProducto.value.some(p => p.id === productoCompleto.id)) {
      itemsProducto.value.push(productoCompleto);
    }
  }
    console.log("itemsProducto: ", itemsProducto)
}*/

const productosConStock = (lista) => {
  const vendidosIds = new Set(objeto.productosVendidos.map(p => p.productoId));

  itemsProducto.value = lista.filter(producto => {
    return producto.cantidadStock !== 0 && !vendidosIds.has(producto.id);
  });

  console.log("itemsProducto: ", itemsProducto);
};


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
    return producto ? producto.codigo : ''
}

const getGestorNombre = (id) => {
    const venta = items.value.find(item => item.id === id)
    return venta ? venta.productosVendidos[0].gestor.nombre : ''
}



const calcularPrecioTotal = (cantidad, precioGestor) => {
    return cantidad * precioGestor
}


const eliminarProductoAgregado = (posicion) => {
  console.log("ID: ", posicion)
  objeto.productosVendidos.splice(posicion, 1)
  console.log("objeto.productosVendidos: ", objeto.productosVendidos)
  productosConStock(itemsProductoCompleto.value)
}


watch(
    () => objeto.productosVendidos,
    (newVal) => {
        disableVendedor.value = newVal.length > 0;
    },
    { immediate: true, deep: true }
);

const abrirDialogoInsertar = () =>{
    objeto.productosVendidos = []
    dialog.value = true
}

const convertirFecha = (formatoISO) =>{
  const fecha = new Date(formatoISO);
  const dia = String(fecha.getDate()).padStart(2, '0');
  const mes = String(fecha.getMonth() + 1).padStart(2, '0');
  const anio = fecha.getFullYear();
  return `${dia}/${mes}/${anio}`;
}


</script>
