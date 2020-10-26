<template>
  <v-container class="d-flex justify-center">
    <v-row class="d-flex justify-center">
      <v-col cols="12" md="6">
        <v-card class="d-flex flex-column align-center">
          <v-avatar>
            <img src="../assets/avatar.svg" />
          </v-avatar>
          <v-card-title>{{ getFullName(getLoggedUser) }}</v-card-title>
          <v-card-text class="width60">
            {{ getLoggedUser.description }}
          </v-card-text>
          <v-row class="width100">
            <v-col cols="12" md="6">
              <p>Email: {{ getLoggedUser.email }}</p>
              <p>Role: {{ getLoggedUser.role }}</p>
              <p>Coins: {{ getLoggedUser.coins }}</p>
            </v-col>

            <v-col cols="12" md="6">
              <v-card-title class="flex justify-center pa-0"
                >My classes</v-card-title
              >

              <v-card-text class="flex flex-column align-center">
                <div
                  v-for="_class in getClassesByUserId(getLoggedUser.id)"
                  :key="_class.id"
                  class="d-flex justify-space-between"
                >
                  <p>{{ _class.name }}</p>
                  <v-btn
                    @click="
                      $router.push(ROUTES.classroom.name + '/' + _class.id)
                    "
                  >
                    Details
                  </v-btn>
                </div>
              </v-card-text>
            </v-col>
          </v-row>
          <v-card-title>My artifacts</v-card-title>
          <p
            v-for="(artifact, index) in getLoggedUser.artifacts"
            :key="artifact.id + index"
          >
            {{ artifact.name }}
          </p>
        </v-card>
      </v-col>
    </v-row>
    <template>
      <upload-file></upload-file>
    </template>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import UploadFile from '@/components/uploadFile';

export default {
  name: 'Profile',
  components: { UploadFile },
  computed: {
    ...mapGetters('classroom', ['getClassesByUserId']),
    ...mapGetters('user', ['getLoggedUser', 'getFullName'])
  }
};
</script>

<style scoped>
.width100 {
  width: 100%;
}

.width60 {
  width: 60%;
}
</style>
