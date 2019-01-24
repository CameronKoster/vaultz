<template>
  <div class="vaults">
    <div class="row d-flex justify-content-around">
      <div class="card" style="width: 15rem">
        <!-- <i class="far fa-eye">: {{keep.views}}</i>
    <i class="fas fa-camera-retro">: {{keep.keeps}}</i> -->
        <!-- <img class="card-img-top " :src="keep.img"> -->
        <div class="card-header d-flex justify-content-between">
          <h1>{{vault.name}}</h1>
        </div>
        <div>
          <h4>{{vault.description}}</h4>
        </div>
        <div>
          <!-- <button onclick="//run viewKeep">View</button> -->
          <button @click="deleteVault(vault.id)">Delete</button>
          <div>
            <button @click="$router.push({name: 'vaultkeeps', params: {vaultId: vault.id}})">View Keeps</button>
          </div>
          <!-- <button @click="getVaultKeeps(vault.id)">View Keeps</button> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaults',
    //Data
    data() {
      return {

      }
    },
    //Props
    props: ["vault"],
    //Components
    components: {

    },
    //Computed
    computed: {
      Vaults() {
        return this.$store.state.userVaults
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    //Mounted
    mounted() {
      this.$store.dispatch("getUserVaults")
    },
    //Methods
    methods: {
      getUserVaults() {
        this.$store.dispatch("getUserVaults", userId)
      },
      deleteVault() {
        this.$store.dispatch("deleteVault", this.vault.id)
      },
      getVaultKeeps(vaultid) {
        this.$store.dispatch("getVaultKeeps", vaultid)
      }
    }
  }

</script>

<style>


</style>