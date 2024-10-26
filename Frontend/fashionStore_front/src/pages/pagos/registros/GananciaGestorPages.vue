<template>
    <div class="q-pa-xl">
        <q-breadcrumbs class="qb cursor-pointer q-pb-md" style="color: #e1e1e1">
            <q-breadcrumbs-el label="Inicio" icon="home" @click="router.push('/inicio')" style="color: #e1e1e1"/>
            <q-breadcrumbs-el label="Registros" icon="dashboard" @click="router.push('/pago')" style="color: #e1e1e1"/>
            <q-breadcrumbs-el label="Ganancia de los gestores" />
        </q-breadcrumbs>
        <q-table class="q-pa-md" :filter="filter" title="Útiles" :rows="items" :columns="columns" row-key="id"
            no-data-label="No hay elementos disponibles" no-results-label="No hay elementos disponibles"
            loading-label="Cargando..." rows-per-page-label="Filas por página">
            <template v-slot:top>
                <div class="col-4 q-table__title">
                    <span>Ganancia de los gestores</span>
                   <!-- <q-input debounce="500" bottom-slots v-model="filtroBusqueda" label="Buscar" counter maxlength="30"
                    :dense="dense">
                    <q-btn round dense flat icon="search" @click="CargarBusquedaFiltro" />
                </q-input>-->
                </div>
                <q-space />


                <span>Todos</span>
                <q-toggle class="q-mr-md" color="primary" label="Pagados" v-model="filtroPagados"
                    @update:model-value="CargarBusquedaFiltro" />

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
                        {{ PonerPuntosSupensivosACampo(props.row?.descripcion, 30) }}
                        <q-tooltip>{{ props.row?.descripcion }}</q-tooltip>
                    </div>
                </q-td>
            </template>

            <template v-slot:body-cell-fecha="props">
                <q-td :props="props">
                    <div>
                        {{ getFechaVenta(props.row.ventaId) }}
                    </div>
                </q-td>
            </template>

            <template v-slot:body-cell-gestor="props">
                <q-td :props="props">
                    <div>
                        {{ getGestorNombre(props.row.ventaId) }}
                    </div>
                </q-td>
            </template>

            <template v-slot:body-cell-produccion="props">
                <q-td :props="props">
                    <q-icon name="done" v-if="props.value == 0" style="color: #bdbdbd" size="25px" />
                    <q-icon name="done" v-else style="color: #3a7779" size="25px" />
                </q-td>
            </template>
            <template v-slot:body-cell-pagado="props">
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
            <header class="q-pa-sm " style="background: linear-gradient(146deg,#222222  0%, #656e6e 150%)">
                <q-toolbar>
                    <q-toolbar-title class="text-subtitle6 text-white">
                        {{
                            objeto?.id ? "Editar Registro Pago Gestor" : "Adicionar Registro Pago Gestor"
                        }}</q-toolbar-title>
                </q-toolbar>
            </header>
            <q-form @submit.prevent="Guardar()" @reset="close" ref="myForm">
                <div class="h row q-ma-md">
                    <q-select
                       :on-update:model-value="objeto.ventaId !== null ? obtenerElementoPorIdAdiccionar(objeto.ventaId) : null"
                        :disable="!!objeto.id"
                        transition-show="flip-up"
                        transition-hide="flip-down"
                        class="col-xs-12 q-pa-md"
                        v-model="objeto.ventaId"
                        label="Venta *"
                        emit-value
                        map-options
                        :use-input="
                            objeto.ventaId === null || objeto.ventaId === ''
                        "
                        option-label="codigo"
                        option-value="id"
                        :options="filtradoVentaNoPagadas"
                        @filter="
                            (val, update) => {
                                filtradoVentaNoPagadas = filterOptions(
                                val,
                                update,
                                filtradoVentaNoPagadas,
                                'codigo',
                                listaVentasNoPagadas
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

                    <label class="col-xs-12 col-md-6 q-pa-md" :class="{ 'text-primary': objeto.id }">
                        Nombre del Gestor : {{ objeto.nombreGestor }}
                    </label>

                    <label class="col-xs-12 col-md-6 q-pa-md" :class="{ 'text-primary': objeto.id }">
                       Pago Total: {{ objeto.pagoTotal }}
                    </label>


                    <q-checkbox class="q-px-md" right-label v-model="objeto.pagado"
                         label="Pagado" color="primary" />

                    <q-card-actions class="col-12 q-mt-md q-pa-md justify-end">
                        <q-btn :disable="!objeto.pagado && !objeto.id" class="text-white" color="primary" aling="right" type="submit" label="Guardar" />
                        <q-btn outline color="primary" type="reset" label="Cancelar" />
                    </q-card-actions>
                </div>
            </q-form>
        </q-card>
    </q-dialog>
</template>

<script setup>
// IMPORT LIBRERIES
import { dataColumnGanancias } from "src/assets/js/column_data/columnDataPago";
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
    imprimirTodosFiltradoPagos,
} from 'src/assets/js/util/funciones'
import { PonerPuntosSupensivosACampo } from 'src/assets/js/util/extras'
import { onlyLetter_Number, onlyLetter_Number_No_White_Spaces, string } from 'src/assets/js/util/validator_form'
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
//const columns = dataColumnGanancias;
const columns = dataColumnGanancias;
const filter = ref("");
const items = ref([]);


// DIALOGS VAR
const dialog = ref(false)
const dialogLoad = ref(false)
const isDialogoEliminarAbierto = ref(false)
const filtroPagados = ref(false)

// VAR FORM
const myForm = ref(null)
const idElementoSeleccionado = ref('')
const filtroBusqueda = ref('')

/***************************************************************************************************
 *                                         OBJECT                                                  *
 **************************************************************************************************/
const objetoInicial = {
    ventaId: null,
    pagoTotal: null,
    pagado:false,
    nombreGestor:null,
}

const objetoAuxiliarInicial = {
    id: null,
    productoId: null,
    productoNombre: null,
    cantidad: 1,
    precioGestor: 0,
}

const ventaSeleccionada = ref()

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })
const objetoAuxiliar = reactive({ ...objetoAuxiliarInicial })


/***************************************************************************************************
 *                                         LISTAS                                                  *
 **************************************************************************************************/
const itemsVenta = ref([])
const filtradoVentaNoPagadas = ref([])
const listaVentasNoPagadas = ref([])
const listaProductosIds = ref([])
const itemsTablaAuxiliar = ref([]);


/***************************************************************************************************
*                                      FUNCIONES                                                   *
 **************************************************************************************************/

// HOOKS

// Craga los datos de la tabla
onMounted(async () => {
    dialogLoad.value = true;
    // Se llena el listado de la pagina
    items.value = (await loadGet('PagoGestor/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    itemsVenta.value = (await loadGet('Venta/ObtenerListadoPaginado')) ?? []; // Condicion para en caso de error la tabla no de error ya q la api devulve undefined
    actualizarListaVentasNoPagadas()
    dialogLoad.value = false;
});

// EXTRAS


// Filtrado
// 1- Funcion para pasar parametros en el Adicionar SaveData
const Guardar = () => {
    const url = objeto.id ? 'PagoGestor/Actualizar' : 'PagoGestor/Crear'
    actualizarListaVentasNoPagadas()
    saveData(url, objeto, load, close, dialogLoad)
}

// Funcion para Obtener los datos para editar
/*const obtenerElementoPorId = async (id) => {
    filtradoVentaNoPagadas.value = listaVentasNoPagadas.value
    await obtener('PagoGestor/ObtenerPorId', id, objeto, dialogLoad, dialog)
}*/


const obtenerElementoPorIdAdiccionar = async (id) => {
    ventaSeleccionada.value = await loadGetOneElement(`Venta/ObtenerPorId/${id}`)
    objeto.nombreGestor = ventaSeleccionada.value.productosVendidos[0].gestor.nombre + " " + ventaSeleccionada.value.productosVendidos[0].gestor.apellidos
  //  venta.productosVendidos[0].gestor.nombre
    console.log("ventaSeleccionada: ",ventaSeleccionada)
    objeto.pagoTotal=calcularDiferenciaPrecios()
}

const obtenerElementoPorId = async (id) => {
    await obtener('PagoGestor/ObtenerPorId', id, objeto, dialogLoad, dialog)
    filtradoVentaNoPagadas.value = itemsVenta.value
    actualizarListaVentasNoPagadas()
    console.log("ventaSeleccionada: ",ventaSeleccionada)
}

// Funcion para eliminar elemento
const eliminar = async () => {

    await eliminarElemento(
        'PagoGestor/Eliminar',
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
    items.value = await loadGet('PagoGestor/ObtenerListadoPaginado')
 }

// Funcion para cerrar el dialog
const handleCloseDialog = () => {
    isDialogoEliminarAbierto.value = false
}

// Funcion para cerrar el dialog principal de Adicionar y Editar y resetear los campos del formulario
const close = async () => {
    closeDialog(objeto, objetoInicial, myForm, dialog)
}

// Función para actualizar lista Ventas No Pagadas
/*const actualizarListaVentasNoPagadas = () =>{
    console.log("itemsVenta: ", itemsVenta.value);
    console.log("items: ", items.value);
    listaVentasNoPagadas.value = itemsVenta.value.filter(item =>
        !items.value.includes(item)
    );
    console.log("listaVentasNoPagadas: ", listaVentasNoPagadas.value);
}*/

const actualizarListaVentasNoPagadas = () => {
    const itemsVentaCodigos = items.value.map(item => item.ventaCodigo);
    listaVentasNoPagadas.value = itemsVenta.value.filter(item => !itemsVentaCodigos.includes(item.codigo));
    filtradoVentaNoPagadas.value = itemsVenta.value
}



/*const actualizarListaVentasNoPagadas = async () => {
     listaVentasNoPagadas.value = await loadGet(`PagoGestor/ObtenerListadoPaginado?TextoBuscar=${false}`) ?? [];

}*/

const calcularDiferenciaPrecios = () => {
    let pagoTotal=0
    const objeto = ventaSeleccionada.value
    for (let i = 0; i < objeto.productosVendidos.length; i++) {
        const productoPrecio = objeto.productosVendidos[i].producto.precioUSD
        const precioGestor = objeto.productosVendidos[i].precioGestor
        const cantidad = objeto.productosVendidos[i].cantidad

        const diferencia = (precioGestor - productoPrecio) * cantidad
        pagoTotal+=diferencia
    }
    return pagoTotal
}

/*const transformData = (data) => {
    console.log("data: ",data)
  return data.map(item => ({

    id: item.id, // Incluye el id en los datos transformados
    fecha: item.venta.fecha,
    ventaCodigo: item.ventaCodigo,
   // nombreGestor: item.productosVendidos[0].gestor.nombre + " " + item.productosVendidos[0].gestor.apellidos,
    pagoTotal: item.pagoTotal,
    pagado: item.pagado,
    action: 'Acciones' // Puedes personalizar esto según tus necesidades
  }))
}*/

//const transformedItems = computed(() => transformData(items.value))

// Funcion para cargar lista de busqueda por codigo o descripcion ademas del filtro seleccionado
/*const CargarBusquedaFiltro = async () => {
    //Tiene texto escrito
    if (filtroBusqueda.value != null && filtroBusqueda.value != '') {
        items.value = await loadListaFiltro(`PagoGestor/ObtenerListadoPaginado?TextoBuscar=${filtroBusqueda.value}`)

        //Filtra por todos
        if (filtroPagados.value) {
            const itemsAuxiliar = ref([]);
            for (let i = 0; i < items.value.length; i++) {
                if (items.value[i].pagado) {
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
        if (!filtroPagados.value) {
            items.value = await loadListaFiltro('PagoGestor/ObtenerListadoPaginado')
        }
        //Filtra por activos
        else {
            items.value = await loadListaFiltro(`PagoGestor/ObtenerListadoPaginado?TextoBuscar=${filtroPagados.value}`)
        }
    }
}*/

const CargarBusquedaFiltro = async () => {

        //Filtra por todos
        if (!filtroPagados.value) {
            items.value = await loadListaFiltro('PagoGestor/ObtenerListadoPaginado')
        }
        //Filtra por activos
        else {
            items.value = await loadListaFiltro(`PagoGestor/ObtenerListadoPaginado?TextoBuscar=${filtroPagados.value}`)
        }

}

const getGestorNombre = (id) => {
    const venta = itemsVenta.value.find(item => item.id === id)
    return venta ? venta.productosVendidos[0].gestor.nombre +" "+ venta.productosVendidos[0].gestor.apellidos: ''
}

const getFechaVenta = (id) => {
    const venta = itemsVenta.value.find(item => item.id === id)
    if (!venta) return ''

    const fecha = new Date(venta.fecha)
    const dia = String(fecha.getDate()).padStart(2, '0')
    const mes = String(fecha.getMonth() + 1).padStart(2, '0') // Los meses en JavaScript son 0-indexados
    const anio = fecha.getFullYear()

    let horas = fecha.getHours();
    const minutos = String(fecha.getMinutes()).padStart(2, '0')
    const segundos = String(fecha.getSeconds()).padStart(2, '0')
    const ampm = horas >= 12 ? 'PM' : 'AM'
    horas = horas % 12
    horas = horas ? horas : 12 // La hora '0' debe ser '12'
    const horasFormateadas = String(horas).padStart(2, '0')

    const fechaFormateada = `${dia}/${mes}/${anio}`
    const horaFormateada = `${horasFormateadas}:${minutos}:${segundos} ${ampm}`

    return `${fechaFormateada} ${horaFormateada}`
}

const abrirDialogoInsertar = () =>{
    actualizarListaVentasNoPagadas()
    dialog.value=true
}

const imprimir = async () =>{

if(items.value.length !== 0){
const texto = filtroBusqueda.value
const esPagado =filtroPagados.value
    const url = '/PagoGestor/ImprimirPorFiltro'
    dialogLoad.value = true // activar Loading
    await imprimirTodosFiltradoPagos(url, texto, esPagado)
    dialogLoad.value = false // Desactivar Loading
}
else{
    Error("No tiene elementos para imprimir")
}
}
</script>
