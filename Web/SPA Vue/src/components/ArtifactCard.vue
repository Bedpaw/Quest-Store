<template>
  <v-card>
    <v-img src="../assets/artifact.jpg" height="300px"></v-img>
    <v-card-title>
      {{ artifact.name }}
    </v-card-title>

    <v-card-subtitle :class="{ 'red--text': noQuantityLeft }">
      {{ artifact.quantity }} left
    </v-card-subtitle>

    <div class="d-flex flex-column align-center pb-5 text-h6">
      <p class="ma-0 font-weight-bold ">COST</p>
      <p class="ma-0">{{ artifact.cost }} COINS</p>
      <v-btn
        class="my-4 success"
        :disabled="noQuantityLeft"
        @click="buy()"
        v-if="getLoggedUser.role === ROLES.STUDENT"
      >
        Buy artifact
      </v-btn>
      <v-btn v-else class="my-4 success" :disabled="noQuantityLeft">
        Class payment
      </v-btn>
    </div>

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
          {{ artifact.description }}
        </v-card-text>
      </div>
    </v-expand-transition>
  </v-card>
</template>

<script>
import { BUY_ARTIFACT, PUSH_ARTIFACT } from '@/utils/macros/mutation-types';
import { mapMutations, mapGetters } from 'vuex';
import { ROLES } from '@/utils/macros/roles';

export default {
  name: 'ArtifactCard',
  data: () => ({
    show: false,
    ROLES
  }),
  props: {
    artifact: {
      type: Object
    }
  },
  computed: {
    noQuantityLeft() {
      return this.artifact.quantity === 0;
    },
    ...mapGetters('user', ['getLoggedUser'])
  },
  methods: {
    ...mapMutations('artifact', [BUY_ARTIFACT]),
    ...mapMutations('user', [PUSH_ARTIFACT]),
    buy() {
      console.log(this.getLoggedUser.coins);
      if (this.getLoggedUser.coins >= this.artifact.cost) {
        this.BUY_ARTIFACT(this.artifact.id);
        this.PUSH_ARTIFACT({
          artifact: this.artifact,
          user: this.getLoggedUser
        });
      }
    }
  }
};
</script>

<style scoped></style>
