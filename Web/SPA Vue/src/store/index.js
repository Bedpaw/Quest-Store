import Vue from 'vue';
import Vuex from 'vuex';

import { auth } from './auth';
import { classroom } from "./classroom";
import {user} from "./user";
import {profile} from "@/store/profile";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    auth,
    classroom,
    profile,
    user
  }
});
