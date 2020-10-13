<template>
  <div class="d-flex align-center justify-center flex-column mt-10">
    <v-btn @click="test()">Test API</v-btn>
  </div>
</template>

<script>
import { mockApi } from "@/api/mock/mock";

export default {

  name: "Home",
  data() {
    return {
    };
  },
  methods: {
    test: mockApi.testApi
  }
};
</script>
