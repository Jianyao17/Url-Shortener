import { createRouter, createWebHistory } from 'vue-router';
import { publicRoutes } from './public.routes';
import { mainRoutes } from './main.routes';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  scrollBehavior: () => ({ top: 0 }),
  routes: [
    publicRoutes,
    mainRoutes
  ],
});

export default router;
