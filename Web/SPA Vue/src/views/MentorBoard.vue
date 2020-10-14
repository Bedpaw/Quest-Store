<template>
  <v-container class="pl-12">
    <v-row>
      <v-col cols="12">
        <v-card>
          <quests-table></quests-table>
        </v-card>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12">
        <v-card>
          <artifacts-table></artifacts-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import QuestsTable from "@/components/data-tables/QuestsTable";
import ArtifactsTable from "@/components/data-tables/ArtifactsTable";
export default {
  name: "MentorBoard",
  components: {ArtifactsTable, QuestsTable}
}

</script>

<style scoped>

</style>
