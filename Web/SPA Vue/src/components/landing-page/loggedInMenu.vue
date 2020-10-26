<template>
  <v-card class="d-flex flex-column justify-center align-center card">
    <v-card class="px-10 lime lighten-5 mt-4">
      <v-card-title class="text-h3 font-weight-bold"> QuestStore</v-card-title>
      <v-card-subtitle class="text-h5 pt-4 font-italic">
        What do You want to do?</v-card-subtitle
      >
    </v-card>
    <v-container>
      <v-row>
        <menu-item
          v-for="item in menuItems"
          :key="item.path"
          :title="item.title"
          :icon="item.icon"
          :path="item.path"
        />
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import MenuItem from '@/components/landing-page/menuItem';
import { ROUTES } from '@/utils/macros/routes';

export default {
  name: 'loggedInMenu',
  components: { MenuItem },
  data() {
    return {
      menuItems: [
        {
          title: 'Explore Quests',
          icon: 'mdi-axe',
          path: ROUTES.quests.path
        },
        {
          title: 'Buy Artifacts',
          icon: 'mdi-seal',
          path: ROUTES.artifacts.path
        },
        {
          title: 'My Profile',
          icon: 'mdi-account-box',
          path: ROUTES.profile.path
        },
        {
          title: 'My Classes',
          icon: 'mdi-account-group',
          path: ROUTES.myClasses.path
        }
      ]
    };
  }
};
</script>

<style scoped>
.card {
  background: rgba(255, 255, 255, 0.5);
}
</style>
