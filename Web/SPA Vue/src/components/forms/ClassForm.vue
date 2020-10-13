<template>
  <v-row align="center" class="d-flex justify-center pb-4" >
    <v-form
        ref="form"
        v-model="valid"
        :lazy-validation="lazy"
    >
      <v-text-field
          v-model="name"
          :counter="24"
          :rules="nameRules"
          label="Class Name"
          required
      ></v-text-field>

      <v-select
          v-model="select"
          :items="mentorsNames"
          :rules="[v => !!v || 'Mentor is required']"
          label="Mentor"
          required
          multiple
      ></v-select>


      <v-btn
          :disabled="!valid"
          color="success"
          class="mr-4"
          @click="addNewClass()"
      >
        Add
      </v-btn>

      <v-btn
          color="error"
          class="mr-4"
          @click="reset"
      >
        Reset
      </v-btn>
    </v-form>
  </v-row>
</template>

<script>
import {mapGetters, mapMutations} from 'vuex'
import {ADD_CLASS} from "@/utils/macros/mutation-types";
import {Classroom} from "@/structures/classroom";
export default {
  name: "",
  props: {
    mentors: {
      type: Array,
      required: true
    },
  },
  computed: {
    ...mapGetters('user', [
      'getListOfFullNames'
    ]),
    mentorsNames() {
      return this.getListOfFullNames(this.mentors)
    },
    selectedMentor() {
      return this.mentors.find(mentor => mentor.getFullName() === this.select)
    }
  },
  data: () => ({
    valid: true,
    name: '',
    nameRules: [
      v => !!v || 'Class Name is required',
      v => (v && v.length < 25) || 'Name must be less than 25 characters',
        v => (v && v.length > 3) || 'Class name must be longer than 3 characters'
    ],
    select: false,
    checkbox: false,
    lazy: false,
  }),

  methods: {
      ...mapMutations('classroom', [
        ADD_CLASS,
      ]),
    addNewClass () {
      const _class = new Classroom({
        users: [],
        id: 3,
        name: this.name,
        mentor: this.selectedMentor
      })
      this.ADD_CLASS(_class)
      console.log(_class)
    },
    reset () {
      this.$refs.form.reset()
    },
  },
}
</script>

<style scoped>

</style>
