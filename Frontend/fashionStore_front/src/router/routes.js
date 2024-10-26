const routes = [
    {
        path: "/",
         component: () => import("src/layouts/MainLayout.vue"),
       //component: () => import("src/layouts/AuthLayout.vue"),
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
                path: "Trabajador",
                name: "Trabajador",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/TrabajadorPages.vue"
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
            {
                path: "Ventas_Por_Gestor",
                name: "VentasPorGestor",
                component: () =>
                    import(
                        "src/pages/nomencladores/gestion/nomencladores/VentaPorGestorPages.vue"
                    ),
            },

             // #region PAGOS
            /*********************************************************************
             *                          INDEX PAGOS                         *
             *********************************************************************/
            {
                path: "/Pago",
                name: "Pago",
                component: () =>
                    import(
                        "src/pages/pagos/IndexPagePago.vue"
                    ),
            },

            /*********************************************************************
             *                      NOMENCLADORES PAGOS                     *
             *********************************************************************/

            {
                path: "Ganancia_gestor",
                name: "GananciaPorGestor",
                component: () =>
                    import(
                        "src/pages/pagos/registros/GananciaGestorPages.vue"
                    ),
            },

            ],
    },

  // #region LOGIN
            /*********************************************************************
             *                          INDEX LOGIN                         *
             *********************************************************************/

    {
        path: "/",
        redirect: "/login"  // Redirige a /login cuando el usuario accede a "/"
      },
      {
        path: "/login",
        component: () => import("src/layouts/AuthLayout.vue"),
        children: [
          {
            path: "",
            name: "Login",
            component: () => import("pages/nomencladores/seguridad/IndexPageLogin.vue"),
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
