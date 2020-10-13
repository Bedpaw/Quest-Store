<template>
  <v-card>
    <v-img src="../assets/background1.jpg" height="200px"></v-img>
    <v-card-title>
      {{ quest.name }}
    </v-card-title>

    <v-card-subtitle>
      {{ quest.type }}
    </v-card-subtitle>

    <div class="d-flex flex-column align-center font-weight-bold pb-5 text-h6">
      <p class="ma-0">REWARD</p>
      {{ quest.reward }}
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
          {{ quest.description }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
export default {
  name: "QuestCard",
  data: () => ({
    show: false,
  }),
  props: {
    quest: {
      type: Object
    },
  },
  methods: {
    getSrc() {
      return '../assets/background1.jpg'
    }
  },
}
</script>

<style scoped>

</style>
