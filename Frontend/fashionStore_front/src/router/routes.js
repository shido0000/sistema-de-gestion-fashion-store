const routes = [
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
    {
      path: "/",
      component: () => import("src/layouts/MainLayout.vue"),
      children: [
        {
          path: "Inicio",
          name: "Inicio",
          component: () => import("src/pages/IndexPage.vue"),
        },
       
      ],
    },
    {
      path: "/:catchAll(.*)*",
      component: () => import("src/pages/ErrorNotFound.vue"),
    },
  ];

  export default routes;
