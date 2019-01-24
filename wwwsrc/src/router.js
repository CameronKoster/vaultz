import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import UserVaults from './views/UserVaults.vue'
// @ts-ignore
import UserKeeps from './views/UserKeeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/uservaults',
      name: 'uservaults',
      component: UserVaults
    },
    {
      path: '/userkeeps',
      name: 'userkeeps',
      component: UserKeeps
    }
  ]
})
