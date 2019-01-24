import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})





export default new Vuex.Store({
  //STATE
  state: {
    user: {},
    publicKeeps: [],
    userKeeps: [],
    userVaults: [],
    activeKeep: {}
  },
  //MUTATIONS
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    setUserVaults(state, userVaults) {
      state.userVaults = userVaults
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },
  },
  //ACTIONS
  actions: {

    //Auth
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },

    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },

    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },

    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit("setUser")
          router.push({ name: 'home' })
        })
    },


    //Keeps
    getPublicKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit("setPublicKeeps", res.data)
        })
    },

    getUserKeeps({ commit, dispatch }) {
      api.get("keeps/user") //check replacement for user
        .then(res => {
          commit("setUserKeeps", res.data)
        })
    },

    addKeep({ commit, dispatch }, keep) {
      api.post("keeps", keep)
        .then(res => {
          dispatch("getUserKeeps", res.data)
        })
    },

    activeKeep({ commit, dispatch }, keepid) {
      api.get("keep/" + keepid)
        .then(res => {
          commit("setActiveKeep", res.data)
        })
    },

    addKeepToVault({ commit, dispatch }, keepAddedToVault) { //need help on this
      api.post("vaultkeeps/", keepAddedToVault)
        .then(res => {
          dispatch("getVaultKeeps", keepAddedToVault.vaultid)
        })
    },

    deleteKeep({ commit, dispatch }, keepid) {
      api.delete("keeps/" + keepid)
        .then(res => {
          dispatch("getPublicKeeps")
        })
    },



    //Vaults
    getUserVaults({ commit, dispatch }, userId) {
      api.get("vaults", userId)
        .then(res => {
          commit("setUserVaults", res.data)
        })
    },
    addVault({ commit, dispatch }, newVault) {
      api.post("vaults", newVault)
        .then(res => {
          dispatch("getUserVaults")
        })
    },
    deleteVault({ commit, dispatch }, vaultid) { //need help with this
      api.delete("vaults/" + vaultid)
        .then(res => {
          dispatch("getUserVaults")
        })
    },


    //VaultKeeps
    getVaultKeeps({ commit, dispatch }, vaultid) { //need help with this
      api.get("vaultkeeps/" + vault.id)
    }
  }
})