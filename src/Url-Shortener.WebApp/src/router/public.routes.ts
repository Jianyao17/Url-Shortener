import type { RouteRecordRaw } from "vue-router";

export const publicRoutes: RouteRecordRaw = 
{
  path: "/",
  children: [
    {
      path: "/",
      name: "public.home",
      component: () => import("@/pages/public/HomePage.vue"),
    },
    {
      path: "/login",
      name: "public.login",
      component: () => import("@/pages/public/LoginPage.vue"),
    },
    {
      path: "/register",
      name: "public.register",
      component: () => import("@/pages/public/RegisterPage.vue"),
    },
    {
      path: "/:pathMatch(.*)*",
      name: "public.not-found",
      component: () => import("@/pages/public/NotFoundPage.vue"),
    }
  ]
}