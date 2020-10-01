import Vue from 'vue';
import Vuex from 'vuex';

import { auth } from './auth';
import { classroom } from "./classroom";
import {user} from "./user";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    auth,
    classroom,
    user
  }
});
