<template>
  <v-container>
    <v-card>
      <v-card-title>CLASSSES</v-card-title>
      <v-card-text>
        <p v-for="_class in getClasses" :key="_class.id">
          {{_class}}
        </p>
      </v-card-text>
    </v-card>
    <v-card>
      <v-card-title>USERS</v-card-title>
      <v-card-text>
        <p v-for="user in getUsers" :key="user.id">
          {{user}}
        </p>
      </v-card-text>
    </v-card>
    <v-card>
      <v-card-title>QUESTS</v-card-title>
      <v-card-text>
        <p v-for="quest in getQuests" :key="quest.id">
          {{quest}}
        </p>
      </v-card-text>
    </v-card>
    <v-card>
      <v-card-title>ARTIFACTS</v-card-title>
      <v-card-text>
        <p v-for="artifact in getArtifacts" :key="artifact.id">
          {{artifact}}
        </p>
      </v-card-text>
    </v-card>
  </v-container>
</template>


<script>
import {mapGetters} from 'vuex'

export default {
  name: 'test',
  computed: {
    ...mapGetters('classroom', [
      'getClasses',
    ]),
    ...mapGetters('user', [
      'getUsers',
    ]),
    ...mapGetters('artifact', [
      'getArtifacts',
    ]),
    ...mapGetters('quest', [
      'getQuests',
    ]),
  },
  methods: {
    showObjectDetails(object) {
      for (const property in object) {
        console.log(`${property}: ${object[property]}`);
      }
    }
  }
}
</script>
