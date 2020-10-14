<template>
  <div>
    <!--Search -->
    <v-text-field v-model="search" label="Search" single-line clearable class="px-4" />

    <v-data-table
        :items="getArtifacts"
        :headers="headers"
        :search="search"
    >
      <!--Add editing/deleting buttons -->
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)">
          mdi-pencil
        </v-icon>
        <v-icon small @click="deleteItem(item)">
          mdi-delete
        </v-icon>
      </template>

      <!--Add Header and Dialog-->
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>Artifacts Manager</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer/>

          <artifact-data-dialog
              :dialog="dialog"
              :current-item="currentItem"
              @toggleDialog="dialog = !dialog"
              @itemChanged="saveChange"
          />
        </v-toolbar>

      </template>

      <!--No data view-->
      <template v-slot:no-data>
        <p>No artifacts available</p>
      </template>

    </v-data-table>
  </div>
</template>

<script>
import {mapGetters, mapMutations} from "vuex";
import {ADD_ARTIFACT, DELETE_ARTIFACT, UPDATE_ARTIFACT} from "@/utils/macros/mutation-types";
import {artifactTableHeaders} from "@/components/data-tables/table-headers";
import {dataTableMixin} from "@/mixins/dataTablesMixin";
import {Artifact} from "@/structures/artifact";
import ArtifactDataDialog from "@/components/data-tables/dialogs/ArtifactDataDialog";

export default {
  name: "ArtifactsTable",
  components: {ArtifactDataDialog},
  data: () => ({
    search: "",
    headers: artifactTableHeaders
  }),
  mixins: [dataTableMixin],
  computed: {
    ...mapGetters('artifact', [
      'getArtifacts', 'getArtifactById'
    ]),
  },
  methods: {
    ...mapMutations('artifact', [
      ADD_ARTIFACT, DELETE_ARTIFACT, UPDATE_ARTIFACT
    ]),
    deleteItem (artifact) {
      if(confirm('Are you sure you want to delete this artifact?')) this.DELETE_ARTIFACT(artifact)
    },
    saveChange(changedItem) {
      // Try to find artifact
      let artifact = this.getArtifactById(changedItem.id)

      // Artifact exist, so update him
      if (artifact) {
        artifact = Object.assign(artifact, changedItem)
        this.UPDATE_ARTIFACT(artifact)
      }
      // Artifact not found, so create
      else {
        artifact= new Artifact({...changedItem })
        this.ADD_ARTIFACT(artifact)
      }
      this.clearEditedItem()
    },
  }
}
</script>
