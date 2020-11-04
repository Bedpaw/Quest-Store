<template>
  <div>
    <v-card>
      <v-card-title>
        {{ classroom.name }}
      </v-card-title>
            <v-card-subtitle>
              Mentors: {{mentorsFullNames}}
            </v-card-subtitle>

            <h3>Students</h3>
            <div v-for="(student, index) in classroom.students" :key="student.id">
              {{ index + 1 }}. {{ getFullName(student) }}
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
import {mapGetters} from 'vuex';

export default {
  name: 'ClassDetails',
  data() {
    return {
      classroom: {
        students: [],
        mentors: []
      }
    }
  },
  created() {
    this.$store.dispatch('classroom/fetchClass', this.$route.params.id)
        .then(response => this.classroom = response)

  },
  computed: {
    ...mapGetters('user', ['getUsersFullNameAsString', 'getFullName']),
    mentorsFullNames() {
      return this.getUsersFullNameAsString(this.classroom.mentors)
    }
  }
};
</script>

<style scoped></style>
