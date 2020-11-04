<template>
  <div>
    <v-card class="bg">
      <v-row>
        <v-col cols="12" md="6" class="pt-0">
          <img src="@/assets/classroom-default.jpg" :alt="classroom.name" class="cover">
        </v-col>

        <v-col cols="12" md="6" class="pt-0 d-flex align-center justify-center">
          <v-card-title class=" text-md-h1 text-h5 font-weight-bold text-center">
            {{ classroom.name }}
          </v-card-title>
        </v-col>
      </v-row>
      <v-row>

        <v-col cols="12" md="6">
          <v-card-subtitle class="text-center text-h6 text-sm-h4 font-weight-bold">
            Students
          </v-card-subtitle>
          <p
              v-for="(student, index) in classroom.students"
              :key="student.id"
              class="text-center text-h6 text-sm-h5"
          >
            {{index + 1}}. {{getFullName(student)}}
          </p>
        </v-col>

        <v-col cols="12" md="6">
          <v-card-subtitle class="text-center text-h6 text-sm-h4 font-weight-bold">
            Mentors
          </v-card-subtitle>
          <p
              v-for="(mentor, index) in classroom.mentors"
              :key="mentor.id"
              class="text-center text-h6 text-sm-h5"
          >
            {{index + 1}}. {{getFullName(mentor)}}
          </p>
        </v-col>
      </v-row>
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

<style scoped>
.cover {
  object-fit: cover;
  width: 100%;
}
.bg {
  background-color: #07689f
}
</style>
