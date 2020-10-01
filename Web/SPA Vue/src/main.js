import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { ROUTES } from "@/utils/macros/routes.js";

Vue.config.productionTip = false;

Vue.mixin({
  computed: {
    ROUTES: () => ROUTES,
  },
});

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount("#app");
