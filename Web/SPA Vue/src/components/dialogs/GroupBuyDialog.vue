<template>
  <v-dialog
      v-model="dialog"
      max-width="500px"
      class="my-4"
  >
    <!--Button activator-->
    <template v-slot:activator="{ on, attrs }">
      <v-btn
          color="primary"
          dark
          class="mb-2"
          v-bind="attrs"
          @click="$emit('toggleDialog')"
      >
        Class payment
      </v-btn>
    </template>
    <v-card class="d-flex flex-column align-center font-weight-bold pb-5 text-h6">
      <v-card-title class="ma-0">
        Group Buy - {{artifact.name}}
      </v-card-title  >
      <v-select
          v-model="classroom"
          :items="classSelectList"
          :menu-props="{ maxHeight: '400' }"
          label="Classrooms"
      ></v-select>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="$emit('toggleDialog')">
          Cancel
        </v-btn>
        <v-btn color="blue darken-1" text @click="groupBuy">
          Buy
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>

import {mapGetters} from "vuex";

export default {
  name: "GroupBuyDialog",
  data: () => ({
    show: false,
    classroom: null,
  }),
  props: {
    dialog: {
      type: Boolean,
      default: false
    },
    artifact: {
      type: Object,
    }
  },
  watch: {
    dialog: function() {
      if(this.dialog === true) {
        this.$store.dispatch('classroom/fetchClasses')
      }
    }
  },
  computed: {
    ...mapGetters('classroom', {classSelectList: 'getClassesAsNameAndDataFormat'})
  },
  methods: {
    groupBuy() {
      if (this.classroom !== null) {
        const message = `Are you sure that ${this.classroom.name} wants to buy ${this.artifact.name}?`
        if(window.confirm(message))
        this.$emit('groupBuy', this.classroom)
        this.classroom = null
      }
    }
  }
}
</script>

<style scoped>

</style>
