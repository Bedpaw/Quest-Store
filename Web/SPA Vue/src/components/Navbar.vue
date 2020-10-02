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
      <v-list
          dense
          nav
          class="py-0"
      >
        <v-list-item two-line :class="miniVariant && 'px-0'">
          <v-list-item-avatar>
            <img :src="user.avatar">
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-title>{{ user.name }}</v-list-item-title>
            <v-list-item-subtitle>{{ user.role }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>

        <v-list-item
            v-for="item in items"
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
      <v-list-item>
        <login></login>
      </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </nav>

</template>

<script>
import { ROUTES } from "../utils/macros/routes";
import { user } from "../mock/user-mock";
import Login from "@/components/Login";

export default {
name: "Navbar",
  components: {Login},
  data: () => ({
    user: user,
    drawer: true,
    items: [
      { title: ROUTES.home.label,
        icon: 'mdi-home',
        route: ROUTES.home,
      },
      { title: ROUTES.admin.label,
        icon: 'mdi-account-cog',
        route: ROUTES.admin,
      },
      { title: ROUTES.mentor.label,
        icon: 'mdi-teach',
        route: ROUTES.mentor
      },
    ],
    color: 'primary',
    colors: [
      'primary',
      'blue',
      'success',
      'red',
      'teal',
    ],
    right: false,
    permanent: true,
    miniVariant: true,
    expandOnHover: true,
    background: false,
  })
}
</script>

<style scoped>

</style>
