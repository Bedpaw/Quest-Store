<template>
  <div>
    <v-card>
      <v-card-title>
        {{ _class.name }}
      </v-card-title>
      <v-card-subtitle>
        Mentors: {{ getUsersFullNameAsString(_class.mentors) }}
      </v-card-subtitle>

      <h3>Students</h3>
      <div v-for="(student, index) in _class.students" :key="student.id">
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
import { mapGetters } from 'vuex';

export default {
  name: 'ClassDetails',
  computed: {
    ...mapGetters('classroom', ['getClassById']),
    ...mapGetters('user', ['getUsersFullNameAsString', 'getFullName']),
    _class() {
      return this.getClassById(this.$route.params.id);
    }
  }
};
</script>

<style scoped></style>
