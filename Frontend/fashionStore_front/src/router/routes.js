const routes = [
    {
        path: "/",
        component: () => import("src/layouts/MainLayout.vue"),
        children: [
            // #region INICIO
            /*********************************************************************
             *                                INICIO                              *
             *********************************************************************/
            {
                path: "Inicio",
                name: "Inicio",
                component: () => import("src/pages/IndexPage.vue"),
            },

            // #region GESTION
            /*********************************************************************
             *                          INDEX GESTION                         *
             *********************************************************************/
            {
                path: "/Gestion",
                name: "Gestion",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/IndexPageGestion.vue"
                    ),
            },

            /*********************************************************************
             *                      NOMENCLADORES GESTION                     *
             *********************************************************************/
            {
                path: "Conversion_Precio",
                name: "ConversionPrecio",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/ConversionPrecioPages.vue"
                    ),
            },
           /* {
                path: "Estado_Producto",
                name: "EstadoProducto",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/EstadoProductoPages.vue"
                    ),
            },*/
            {
                path: "Producto",
                name: "Producto",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/ProductoPages.vue"
                    ),
            },
            {
                path: "Gestor",
                name: "Gestor",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/GestorPages.vue"
                    ),
            },
            {
                path: "Vale_Venta",
                name: "ValeVenta",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/ValeVentaPages.vue"
                    ),
            },
            {
                path: "Venta",
                name: "Venta",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/VentaPages.vue"
                    ),
            },

            ],
    },

    // Always leave this as last one,
    // but you can also remove it
    {
        path: "/:catchAll(.*)*",
        component: () => import("src/pages/ErrorNotFound.vue"),
    },
];

export default routes;
