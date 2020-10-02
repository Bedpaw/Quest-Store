<template>
  <div class="d-flex align-center justify-center flex-column mt-10">
    <v-btn @click="callApi">Test API</v-btn>
    <p>{{ apiMessage }}</p>
    <p v-for="(value,name, index) in this.$store.state.profile.user" :key="index">
      {{ name }} : {{ value }}
    </p>
  </div>
</template>

<script>
import axios from "axios";
import { mapMutations } from "vuex";
export default {
  name: "Home",
  data() {
    return {
      serverPath: "https://localhost:5001/api/test/welcomeadmin",
      apiMessage: ""
    };
  },
  methods: {
    ...mapMutations("profile", ["setUser"]),
    callApi: async function() {
      //:TODO move to better place
      this.setUser(this.$auth.user);
      // Get the access token from the auth wrapper
      const token = await this.$auth.getTokenSilently();

      // Use Axios to make a call to the API
      const { data } = await axios.get(this.serverPath, {
        headers: {
          Authorization: `Bearer ${token}` // send the access token through the 'Authorization' header
        }
      });

      this.apiMessage = data;
    }
  }
};
</script>
