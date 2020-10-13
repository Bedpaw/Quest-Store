<template>
  <div>
    <v-card v-for="_class in getClassById($route.params.id)" :key="_class.id">
        <v-card-title>{{_class.name}}</v-card-title>
        <v-card-subtitle>Mentors: {{_class.mentors.map(mentor => mentor.getFullName()).toString()}}</v-card-subtitle>
        <h3>Students</h3>
        <div
            v-for="(student, index) in _class.students"
            :key="student.name + index">
          {{index + 1}}. {{student.getFullName()}}
        </div>
        <v-card-actions>
          <v-btn class="f-text-danger" @click="$router.go(-1)">
            Back
          </v-btn>
        </v-card-actions>
    </v-card>
  </div>
</template>

<script>
import {mapGetters} from 'vuex'
export default {
  name: "ClassDetails",
  computed: {
    ...mapGetters('classroom', [
      'getClasses',
    ]),
  },
  methods: {
    getClassById(id) {
      return this.getClasses.filter(_class => _class.id === parseInt(id))
    }
  },
}
</script>

<style scoped>

</style>
