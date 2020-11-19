<template>
  <nav>
    <v-navigation-drawer
      v-model="drawer"
      :color="color"
      :expand-on-hover="expandOnHover"
      :mini-variant="miniVariant"
      :right="right"
      :permanent="permanent"
      absolute
      dark
      bottom
    >
      <v-list dense nav class="py-0">
        <v-list-item
          two-line
          :class="miniVariant && 'px-0'"
          class="v-chip--clickable"
          @click="pushIfNotProfilePage"
        >
          <v-list-item-avatar>
            <cld-image
              v-if="getLoggedUser.image !== ''"
              :public-id="getLoggedUser.image"
              resize="fit"
            />
            <img v-else src="../assets/avatar.svg" />
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-title
              >{{ getLoggedUser.name
              }}{{ getLoggedUser.surname }}</v-list-item-title
            >
            <v-list-item-subtitle>{{
              getLoggedUser.role
            }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>

        <v-list-item
          v-for="item in itemsFilteredByRoles"
          :key="item.title"
          :to="item.route"
          link
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item @click="logout()">
          <v-list-item-icon>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Logout</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </nav>
</template>

<script>
import { ROUTES } from '@/utils/macros/routes';
import { user } from '@/mock/user-mock';
import { mapGetters } from 'vuex';
import { ROLES } from '@/utils/macros/roles';
import { arrayUtils } from '@/utils/array-utils';

export default {
  name: 'Navbar',
  components: {},
  data: () => ({
    user: user,
    drawer: true,
    items: [
      {
        title: ROUTES.home.label,
        icon: 'mdi-home',
        route: ROUTES.home,
        guard: []
      },
      {
        title: ROUTES.admin.label,
        icon: 'mdi-account-cog',
        route: ROUTES.admin,
        guard: [ROLES.ADMIN]
      },
      {
        title: ROUTES.mentor.label,
        icon: 'mdi-teach',
        route: ROUTES.mentor,
        guard: [ROLES.MENTOR]
      },
      {
        title: ROUTES.quests.label,
        icon: 'mdi-axe',
        route: ROUTES.quests,
        guard: []
      },
      {
        title: ROUTES.artifacts.label,
        icon: 'mdi-seal',
        route: ROUTES.artifacts,
        guard: []
      },
      {
        title: 'test',
        icon: '',
        route: '/test',
        guard: []
      }
    ],
    color: 'primary',
    colors: ['primary', 'blue', 'success', 'red', 'teal'],
    right: false,
    permanent: true,
    miniVariant: true,
    expandOnHover: true,
    background: false
  }),
  computed: {
    ...mapGetters('user', ['getLoggedUser']),
    itemsFilteredByRoles() {
      const user = this.getLoggedUser;
      if (user.role === ROLES.ADMIN) return this.items;

      return this.items.filter(route => {
        if (arrayUtils.isEmptyArray(route.guard)) return true;
        return route.guard.includes(user.role);
      });
    },
    isNotProfilePage() {
      return this.$route.path !== ROUTES.profile.path;
    }
  },
  created() {
    this.$store.dispatch('user/fetchLoggedUser');
  },
  methods: {
    pushIfNotProfilePage() {
      if (this.isNotProfilePage) this.$router.push(ROUTES.profile.path);
    },
    logout() {
      this.$auth.logout({
        returnTo: window.location.origin
      });
    }
  }
};
</script>

<style scoped></style>
