import { createRouter, createWebHistory } from 'vue-router'
import Layout from '../pages/Layout.vue';
import PoemList from "../views/PoemList.vue";
import PoetList from "../views/PoetList.vue";
import DetailPoem from "../views/DetailPoem.vue";
import DetailPoet from "../views/DetailPoet.vue";



const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path:'/',
      name:'Layout',
      component:Layout,
      children:[
        {path:'/',component:PoemList},
        {path:'PoetList',component:PoetList},
        {path:'DetailPoem/:id',component:DetailPoem},
        {path:'DetailPoet/:id',component:DetailPoet}
      ]
    },

  
    
  
  ]
})

export default router
