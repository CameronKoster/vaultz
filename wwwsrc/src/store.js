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
    activeKeep: {},
    vaultKeep: []
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
    setVaultKeep(state, vaultKeep) {
      state.vaultKeep = vaultKeep
    }
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
      //this should api.put request to increment the views of the keep with keepid
      //then can save the returned updated keep as the state.activeKeep and trigger a modal open
      api.get("keep/" + keepid)
        .then(res => {
          commit("setActiveKeep", res.data)
        })
    },






    addKeepToVault({ commit, dispatch }, payload) { //need help on this
      api.post("vaultkeeps/", payload)
        .then(res => {

          dispatch("getVaultKeeps", payload.vaultId)
        })
    },






    deleteKeep({ commit, dispatch }, keepid) {
      api.delete("keeps/" + keepid)
        .then(res => {
          dispatch("getPublicKeeps")
          dispatch("getUserKeeps")
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
      api.get("vaultkeeps/" + vaultid, vaultid)
        .then(res => {
          console.log(res)
          commit("setVaultKeep", res.data)
          // commit("setActiveVault", vaultid)
        })
    },
    deleteVaultKeeps({ commit, dispatch }, vaultid) {
      api.put("/vaultkeeps" + vaultid)
        .then(res => {

          dispatch("getVaultKeeps")
        })
    }
  }
})