import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/HomeView.vue';
import Menu from '../views/Menu.vue'; 
import Cart from '../views/Cart.vue';
import Profile from '../views/Profile.vue';

const routes = [
  { path: '/', component: Home },
  { path: '/menu', component: Menu },
  { path: '/cart', component: Cart }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
