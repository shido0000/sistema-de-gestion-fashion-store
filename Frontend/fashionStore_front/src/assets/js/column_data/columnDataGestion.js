// #region GESTION COLUMN DATA
/**************************************************************************************************
*                                     GESTION COLUMN DATA                                        *
**************************************************************************************************/



// #region CONVERSION-PRECIO
/*********************************************************************
*                CONVERSION-PRECIO COLUMN DATA                     *
*********************************************************************/

export const dataColumnConversion_Precio = Object.freeze([
    {
        name: 'descripcion',
        align: 'center',
        label: 'Descripción',
        field: 'descripcion',
        sortable: true
    },
    {
        name: 'valorCambio',
        align: 'center',
        label: 'Valor al Cambio',
        field: 'valorCambio',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region CONVERSION-PRECIO
/*********************************************************************
*                CONVERSION-PRECIO COLUMN DATA                     *
*********************************************************************/

export const dataColumnEstado_Producto = Object.freeze([
    {
        name: 'descripcion',
        align: 'center',
        label: 'Descripción',
        field: 'descripcion',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])


// #region PRODUCTO
/*********************************************************************
*                PRODUCTO COLUMN DATA                     *
*********************************************************************/
export const dataColumnProducto = Object.freeze([
    {
        name: 'codigo',
        align: 'center',
        label: 'Código',
        field: 'codigo',
        sortable: true
    },
    {
        name: 'descripcion',
        align: 'center',
        label: 'Descripción',
        field: 'descripcion',
        sortable: true
    },
    {
        name: 'costo',
        align: 'center',
        label: 'Costo',
        field: 'costo',
        sortable: true
    },
    {
        name: 'precio',
        align: 'center',
        label: 'Precio en USD',
        field: 'precioUSD',
        sortable: true
    },
   /* {
        name: 'imagen',
        align: 'center',
        label: 'Imagen',
        field: 'imagen',
        sortable: true
    },*/
    {
        name: 'cantidad',
        align: 'center',
        label: 'Cantidad',
        field: 'cantidad',
        sortable: true
    },
    {
        name: 'cantidadStock',
        align: 'center',
        label: 'Stock',
        field: 'cantidadStock',
        sortable: true
    },
    {
        name: 'estadoProducto',
        align: 'center',
        label: 'Estado del Producto',
        field: 'estadoProductoDescripcion',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])


// #region GESTOR
/*********************************************************************
*                GESTOR COLUMN DATA                     *
*********************************************************************/

export const dataColumnGestor = Object.freeze([
    {
        name: 'nombre',
        align: 'center',
        label: 'Nombre',
        field: 'nombre',
        sortable: true
    },
    {
        name: 'apellido',
        align: 'center',
        label: 'Apellidos',
        field: 'apellidos',
        sortable: true
    },
    {
        name: 'direccion',
        align: 'center',
        label: 'Dirección',
        field: 'direccion',
        sortable: true
    },
    {
        name: 'telefono',
        align: 'center',
        label: 'teléfono',
        field: 'telefono',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region TRABAJADOR
/*********************************************************************
*                TRABAJADOR COLUMN DATA                     *
*********************************************************************/

export const dataColumnTrabajador = Object.freeze([
    {
        name: 'nombre',
        align: 'center',
        label: 'Nombre',
        field: 'nombre',
        sortable: true
    },
    {
        name: 'apellido',
        align: 'center',
        label: 'Apellidos',
        field: 'apellidos',
        sortable: true
    },
    {
        name: 'username',
        align: 'center',
        label: 'Usuario',
        field: 'username',
        sortable: true
    },

    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region CONCEPTO-FACTURACION
/*********************************************************************
*                CONCEPTO-FACTURACION COLUMN DATA                     *
*********************************************************************/
export const dataColumnConcepto_Facturacion = Object.freeze([
    {
        name: 'codigoConceptoFacturacion',
        align: 'center',
        label: 'Código',
        field: 'codigoConceptoFacturacion',
        sortable: true
    },
    {
        name: 'descripcion',
        align: 'center',
        label: 'Descripción',
        field: 'descripcion',
        sortable: true
    },
    {
        name: 'cargo',
        align: 'center',
        label: 'Cargo',
        field: 'cargo',
        sortable: true
    },
    {
        name: 'conceptoProduccion',
        align: 'center',
        label: 'Concepto de Producción',
        field: 'conceptoProduccionDescripcion',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region VALE DE VENTA
/*********************************************************************
*                VALE DE VENTA COLUMN DATA                     *
*********************************************************************/

export const dataColumnValeVenta = Object.freeze([
    {
        name: 'fecha',
        align: 'center',
        label: 'Fecha',
        field: 'fecha',
        sortable: true
    },
    {
        name: 'contacto',
        align: 'center',
        label: 'Contacto',
        field: 'contacto',
        sortable: true
    },
    {
        name: 'direccion',
        align: 'center',
        label: 'Dirección',
        field: 'direccion',
        sortable: true
    },
    {
        name: 'domicilio',
        align: 'center',
        label: 'Domicilio',
        field: 'domicilio',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region VENTA
/*********************************************************************
*                VENTA COLUMN DATA                     *
*********************************************************************/

export const dataColumnVenta = Object.freeze([
    {
        name: 'fecha',
        align: 'center',
        label: 'Fecha',
        field: 'fecha',
        sortable: true
    },
    {
        name: 'codigo',
        align: 'center',
        label: 'Código',
        field: 'codigo',
        sortable: true
    },
    {
        name: 'gestor',
        align: 'center',
        label: 'Gestor',
        field: 'gestor',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region VENTA-AUXILIAR
/*********************************************************************
*                VENTA COLUMN-Auxiliar DATA                     *
*********************************************************************/

export const dataColumnVentaAuxiliar = Object.freeze([

    {
        name: 'producto',
        align: 'center',
        label: 'Producto',
        field: 'productoNombre',
        sortable: true
    },
    {
        name: 'cantidad',
        align: 'center',
        label: 'Cantidad',
        field: 'cantidad',
        sortable: true
    },
    {
        name: 'precioGestor',
        align: 'center',
        label: 'Precio del Gestor',
        field: 'precioGestor',
        sortable: true
    },
    {
        name: 'precioGestorTotal',
        align: 'center',
        label: 'Precio Total',
        field: 'precioGestorTotal',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])

// #region VENTA POR GESTOR
/*********************************************************************
*                VENTA POR GESTOR COLUMN DATA                     *
*********************************************************************/
export const dataColumnVentaPorGestor = Object.freeze([
    {
        name: 'codigo',
        align: 'center',
        label: 'Gestor',
        field: 'gestor',
        sortable: true
    },
    {
        name: 'venta',
        align: 'center',
        label: 'Venta',
        field: 'venta',
        sortable: true
    },
    {
        name: 'producto',
        align: 'center',
        label: 'Producto',
        field: 'producto',
        sortable: true
    },
    {
        name: 'precioGestor',
        align: 'center',
        label: 'Precio del Gestor',
        field: 'precioGestor',
        sortable: true
    },
    {
        name: 'cantidad',
        align: 'center',
        label: 'Cantidad',
        field: 'cantidad',
        sortable: true
    },
    {
        name: 'action',
        align: 'center',
        label: 'Acciones',
        field: 'action',
        sortable: true
    }
])
