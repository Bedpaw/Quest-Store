<template>
  <v-app>
    <v-toolbar
        dark
        prominent
        src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg"
    >
      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>Vuetify</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-export</v-icon>
      </v-btn>
    </v-toolbar>
    <v-main>
      <div class="wrapper"> <!-- wrapper div starts -->

        <div class="fixed-bg bg-1">
          <h1>Fixed Background scrolling</h1>
        </div>

        <div class="scroll-bg">
          <h3>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec in dolor tempor, posuere mi id, eleifend magna. Nulla at lectus magna. Etiam sodales arcu at lectus porttitor accumsan. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur id urna dolor. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin et pharetra justo, quis suscipit risus. Maecenas tincidunt efficitur ex in pharetra.</h3>
        </div>

        <div class="fixed-bg bg-2">
          <h1>Fixed Background scrolling</h1>
        </div>

        <div class="scroll-bg">
          <h3>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec in dolor tempor, posuere mi id, eleifend magna. Nulla at lectus magna.</h3>
        </div>

        <div class="fixed-bg bg-3">
          <h1>Fixed Background scrolling</h1>
        </div>

      </div> <!-- wrapper div ends-->
    </v-main>
  </v-app>
</template>

<script>

//import Navbar from "./components/Navbar";
export default {
  name: "App",
  components: {},
  data: () => ({
    //
  })
};
</script>
<style>

@import url('https://fonts.googleapis.com/css?family=Quicksand');

html,body {
  height: 100%;
}

.wrapper {
  height: 100%;
  font-family: 'Quicksand', sans-serif;
  line-height: 1.5;
  word-spacing: 4px;
  letter-spacing: 1px;
}

.fixed-bg {
  background-attachment: fixed;
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center center;
  height: 100%;
  width: 100%;
  color: white;
  text-align: center;
  display: table;
}

.fixed-bg h1 {
  display: table-cell;
  vertical-align: middle;
}

.scroll-bg {
  background-color: #0f0f0a;
  padding: 10px 70px;
  color: #676767;
}

/* first section */

.bg-1 {
  background-image: url("background3.jpg");
}

/* third section */

.bg-2 {
  background-image: url('background2.jpg');
}

/* fifth section */

.bg-3 {
  background-image: url('background1.jpg');
}
</style>
