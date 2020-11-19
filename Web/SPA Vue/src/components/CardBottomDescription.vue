<template>
  <div>
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
          <slot></slot>
        </v-card-text>
      </div>
    </v-expand-transition>
  </div>
</template>

<script>
export default {
  name: 'CardBottomDescription',
  data: () => ({
    show: false
  })
};
</script>

<style scoped></style>
