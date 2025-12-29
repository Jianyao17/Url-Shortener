import type { RouteRecordRaw } from "vue-router";

export const mainRoutes: RouteRecordRaw = 
{
  path: "/app",
  component: () => import("@/components/_Layouts/Dashboard.vue"),
  children: [
    {
      path: "dashboard",
      name: "app.dashboard",
      component: () => import("@/pages/app/DashboardPage.vue"),
    },
    {
      path: ":pathMatch(.*)*",
      name: "app.not-found",
      component: () => import("@/pages/public/NotFoundPage.vue"),
    }
  ]
}