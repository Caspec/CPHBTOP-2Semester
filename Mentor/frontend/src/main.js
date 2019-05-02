import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import VueResource from 'vue-resource'
import { routes } from './routes/routes'

Vue.use(VueRouter)
Vue.use(VueResource)

const router = new VueRouter({
  mode: 'history',
  routes
});

// currency filter
Vue.filter('currency', function (value) {
  if (typeof value !== "number") {
      return value;
  }
  let formatter = new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency: 'USD',
      minimumFractionDigits: 0
  });
  return formatter.format(value);
});

// Mixin with get() tax
Vue.mixin({
  data: function() {
    return {
      get tax() {
        return 1.25;
      }
    }
  }
})

new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
