<template>
  <div>
    <v-card-title class="d-flex justify-center text-h4 font-weight-bold mb-12">
      {{title}}
    </v-card-title>
    <v-row>
      <v-col
          cols="12"
          sm="6"
          md="4"
          v-for="item in items"
          :key="item.id">
        <slot :item="item">
        </slot>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
name: "GridContainer",
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
}
</script>

<style scoped>

</style>
