<template>
  <v-card>
    <cld-image
        v-if="artifact.image !== ''"
        :public-id="artifact.image"
        dpr="auto"
        responsive="width"
        width="auto"
        crop="scale"
        loading="lazy"
    />
    <v-img v-else src="../assets/artifact.jpg" height="300px"></v-img>

    <v-card-title>{{ artifact.name }}</v-card-title>

    <v-card-subtitle :class="{ 'red--text': noQuantityLeft }">
      {{ artifact.quantity !== null ? artifact.quantity + ' left' : 'unlimited' }}
    </v-card-subtitle>

    <div class="d-flex flex-column align-center pb-5 text-h6">
      <p class="ma-0 font-weight-bold ">COST</p>
      <p class="ma-0">{{ artifact.cost }} COINS</p>

      <v-btn
          v-if="getLoggedUser.role === ROLES.STUDENT"
          class="my-4 success"
          :disabled="noQuantityLeft"
          @click="buy()"
      >
        Buy artifact
      </v-btn>
      <group-buy-dialog
          v-else
          :dialog="dialog"
          :artifact="artifact"
          @toggleDialog="dialog = !dialog"
          @groupBuy="groupBuy"
      />
    </div>
    <card-bottom-description>
      {{artifact.description}}
    </card-bottom-description>
  </v-card>
</template>

<script>
import {BUY_ARTIFACT, PUSH_ARTIFACT} from '@/utils/macros/mutation-types';
import {mapMutations, mapGetters} from 'vuex';
import {ROLES} from '@/utils/macros/roles';
import GroupBuyDialog from "@/components/dialogs/GroupBuyDialog";
import CardBottomDescription from "@/components/CardBottomDescription";

export default {
  name: 'ArtifactCard',
  components: {CardBottomDescription, GroupBuyDialog},
  data: () => ({
    show: false,
    dialog: false,
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
    ...mapGetters('user', ['getLoggedUser']),
  },
  methods: {
    ...mapMutations('artifact', [BUY_ARTIFACT]),
    ...mapMutations('user', [PUSH_ARTIFACT]),
    buy() {
      window.confirm("Are you sure?")
      {
        this.$store.dispatch('artifact/buyArtifact',
            {
              user: this.getLoggedUser,
              artifact: this.artifact
            })
        .then(() => {
          window.alert(`You successfully bought - ${this.artifact.name}`)
        })
      }
    },
    groupBuy(classroom) {
      this.$store.dispatch('classroom/artifactGroupPurchase',
          {
            _class: classroom,
            artifact: this.artifact
          })
      this.dialog = false
    }
  }
}

</script>

<style scoped></style>
