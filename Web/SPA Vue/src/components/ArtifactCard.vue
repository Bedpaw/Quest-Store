<template>
  <v-card>
    <v-img src="../assets/artifact.jpg" height="300px"></v-img>
    <v-card-title>
      {{ artifact.name }}
    </v-card-title>

    <v-card-subtitle :class="{ 'red--text': noQuantityLeft }">
      {{ artifact.quantity }} left
    </v-card-subtitle>

    <div class="d-flex flex-column align-center pb-5 text-h6">
      <p class="ma-0 font-weight-bold ">COST</p>
      <p class="ma-0">{{ artifact.cost }} COINS</p>
      <v-btn
          class="my-4 success"
          :disabled="noQuantityLeft"
      >
        Buy artifact
      </v-btn>
    </div>


    <v-card-actions>
      <v-btn color="orange lighten-2" text>
        Description
      </v-btn>
      <v-spacer></v-spacer>

      <v-btn icon @click="show = !show">
        <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
      </v-btn>
    </v-card-actions>

    <v-expand-transition>
      <div v-show="show">
        <v-divider></v-divider>

        <v-card-text>
          {{ artifact.description }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
export default {
  name: "ArtifactCard",
  data: () => ({
    show: false,
  }),
  props: {
    artifact: {
      type: Object
    },
  },
  computed: {
    noQuantityLeft() {
      return this.artifact.quantity === 0
    }
  }
}
</script>

<style scoped>

</style>
