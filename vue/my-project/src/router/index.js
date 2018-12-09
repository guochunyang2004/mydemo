import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import HelloWorld from '@/components/HelloWorld'
import Demo from '@/components/Demo'
import DemoDetail from '@/components/DemoDetail'

Vue.use(Router)

export default new Router({
  routes: [    
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/HelloWorld',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/Demo/:subpath',
      name: 'Demo',
      component: Demo,
      children: [
        //{ path: '', component: DemoDefault },        
        {
          path:':dataId',
          component: DemoDetail
        },
        {
          // 当 /user/:id/profile 匹配成功，
          // UserProfile 会被渲染在 User 的 <router-view> 中
          path: 'detail',
          component: DemoDetail
        }
      ]
    }
  ]
})
