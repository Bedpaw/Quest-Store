const initialState = {
  user: {
    email: "",
    roles: [],
    name: "",
    nickname: "test",
    picture: "",
    id: ""
  }
};

export const profile = {
  namespaced: true,
  state: initialState,
  getters: {
    isAdmin: state => state.user.roles.includes("Admin")
  },
  mutations: {
    setUser: (state, payload) => {
      let u = state.user;
      u.email = payload.email;
      u.roles =
        payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      u.name = payload.name;
      u.picture = payload.picture;
      u.id = payload.sub;
    }
  }
};
