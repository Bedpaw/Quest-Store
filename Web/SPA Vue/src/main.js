import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { ROUTES } from "@/utils/macros/routes.js";
import { Auth0Plugin } from "@/auth";
import { domain, clientId, audience } from "../auth_config.json";

Vue.config.productionTip = false;

Vue.mixin({
  computed: {
    ROUTES: () => ROUTES
  }
});

Vue.use(Auth0Plugin, {
  domain,
  clientId,
  audience,
  onRedirectCallback: appState => {
    router
      .push(
        appState && appState.targetUrl
          ? appState.targetUrl
          : window.location.pathname
      );
  }
});

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount("#app");
