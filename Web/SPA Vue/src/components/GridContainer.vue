<template>
  <div>
    <v-card class="bg">
      <v-card-title class="d-flex justify-center text-h4 font-weight-bold mb-6">
        {{ title }}
      </v-card-title>
      <v-text-field v-model="search" label="Search" single-line class="px-4" />
    </v-card>
    <v-row>
      <v-col
        cols="12"
        sm="6"
        md="4"
        v-for="item in searchedItems"
        :key="item.id"
      >
        <slot :item="item"></slot>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  name: 'GridContainer',
  data() {
    return {
      search: ''
    };
  },
  computed: {
    searchedItems() {
      return this.items.filter(item =>
        item.name?.toLowerCase().includes(this.search?.toLowerCase())
      );
    }
  },
  props: {
    items: {
      type: Array,
      required: true
    },
    title: {
      type: String,
      required: true
    }
  }
};
</script>

<style scoped>
.bg {
  background-color: rgb(139 239 246);
}
</style>
