  <template>
    <v-row align="center" class="d-flex justify-center">
      <v-form
          class="pb-4"
          ref="form"
          v-model="valid"
          :lazy-validation="lazy"
      >
        <v-text-field
            v-model="name"
            :counter="10"
            :rules="nameRules"
            label="Name"
            required
        ></v-text-field>

        <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required
        ></v-text-field>

        <v-select
            v-model="select"
            :items="roles"
            :rules="[v => !!v || 'Role is required']"
            label="Item"
            required
            multiple
        ></v-select>

        <v-btn
            :disabled="!valid"
            color="success"
            class="mr-4"
            @click="validate"
        >
          Add
        </v-btn>

        <v-btn
            color="error"
            class="mr-4"
            @click="reset"
        >
          Reset
        </v-btn>
      </v-form>
    </v-row>
  </template>



  <script>
  export default {
    name: "UserForm",
    data: () => ({
      valid: true,
      name: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters',
      ],
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],
      select: null,
      roles: [
        'User',
        'Mentor',
        'Admin',
      ],
      checkbox: false,
      lazy: false,
    }),

    methods: {
      validate () {
        this.$refs.form.validate()
      },
      reset () {
        this.$refs.form.reset()
      },
    },
  }
  </script>

<style scoped>

</style>
