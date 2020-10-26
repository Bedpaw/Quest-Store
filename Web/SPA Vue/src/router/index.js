import Vue from 'vue';
import VueRouter from 'vue-router';
import { routes } from '@/router/routes';
import { ROUTES } from '@/utils/macros/routes';
import { getInstance } from '@/auth';

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

router.beforeEach((to, from, next) => {
  if (to.path === ROUTES.home.path) {
    next();
  }
  const authService = getInstance();

  const fn = () => {
    const isGuest = authService && authService.isGuest();
    if (authService.isAuthenticated && isGuest === false) {
      return next();
    }
    next('/');
  };

  if (!authService.loading) {
    return fn();
  }

  authService.$watch('loading', loading => {
    if (loading === false) {
      return fn();
    }
  });
});

export default router;
