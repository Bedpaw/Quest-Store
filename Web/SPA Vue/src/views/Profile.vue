<template>
  <v-container class="d-flex justify-center fill-height">
    <v-row class="d-flex justify-center">
      <v-col cols="12" md="6">
        <v-card class="d-flex flex-column align-center pt-4 opacity">
          <cld-image v-if="getLoggedUser.image !== ''"  :publicId="getLoggedUser.image">
            <cld-transformation width="160" height="160"  radius="max" crop="thumb"/>
          </cld-image>
          <v-avatar v-else>
            <v-img src="../assets/avatar.svg" />
          </v-avatar>

          <v-card-title class="text-sm-h4">{{ getFullName(getLoggedUser) }}</v-card-title>

          <v-card-text class="px-sm-16">
            {{ getLoggedUser.description }}
          </v-card-text>

          <expander title="Personal information" class="my-2">
            <v-col cols="12" class="flex flex-column text-center">
              <p>Email: {{ getLoggedUser.email }}</p>
              <p>Role: {{ getLoggedUser.role }}</p>
              <p>Coins: {{ getLoggedUser.coins }}</p>
            </v-col>
          </expander>

          <expander title="My classes" class="my-2">
            <v-col cols="12" md="6">
              <v-card-text class="flex flex-column align-center">
                <div
                    v-for="_class in getLoggedUser.classrooms"
                    :key="_class.id"
                    class="d-flex justify-space-between"
                >
                  <v-btn class="primary mb-2" @click="$router.push(ROUTES.classroom.name + '/' + _class.id)">
                    {{_class.name}}
                  </v-btn>
                </div>
              </v-card-text>
            </v-col>
          </expander>

          <expander title="My artifacts" class="my-2">
            <p v-for="(artifact, index) in getLoggedUser.artifacts" :key="artifact.id + index">
              {{ artifact.name }}
            </p>
          </expander>



          <upload-file v-if="false" @image-uploaded="setAvatar">Change avatar</upload-file>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import UploadFile from '@/components/utils/uploadFile';
import {UPDATE_USER} from "@/utils/macros/mutation-types";
import Expander from "@/components/utils/expander";

export default {
  name: 'Profile',
  components: {Expander, UploadFile},
  data() {
    return {
    }
  },
  computed: {
    ...mapGetters('user', ['getLoggedUser', 'getFullName'])
  },
  methods: {
    setAvatar(newImage) {
      const updatedUser = {...this.getLoggedUser, image:newImage}
      this.$store.commit('user/' + UPDATE_USER, updatedUser)
      //this.$store.dispatch('user/updateUser', updatedUser)
    }
  }
}
</script>

<style scoped>
.opacity {
  background-color: rgba(255,255,255, 0.9)
}
</style>
