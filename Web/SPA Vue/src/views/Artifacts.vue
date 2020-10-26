<template>
  <v-container>
    <grid-container title="Artifacts" :items="getArtifacts">
      <template v-slot:default="slotProps">
        <artifact-card :artifact="slotProps.item"></artifact-card>
      </template>
    </grid-container>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import ArtifactCard from '@/components/ArtifactCard';
import GridContainer from '@/components/GridContainer';

export default {
  name: 'Artifacts',
  components: { ArtifactCard, GridContainer },
  computed: {
    ...mapGetters('artifact', ['getArtifacts'])
  },
  created() {
    this.$store.dispatch('artifact/fetchArtifacts');
  }
};
</script>

<style scoped></style>
