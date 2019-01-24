<template>
  <div class="UserVaults">
    <Navbar />
    <div class="row">
      <Vaults v-for="vault in userVaults" :vault="vault" />
    </div>
    <div>
      <form>
        <i @click="addVault" class="far fa-plus-square plus">
          <h3>add a vault</h3>
        </i>
        <!-- v-if this form if add a vault is clicked -->
        <input type="text" v-model="newVault.Name" placeholder="Enter Vault Name">
        <input type="text" v-model="newVault.Description" placeholder="Enter Vault Description">
      </form>
      <!-- <form @submit.prevent="addVault">
            <input type="text" placeholder="title" v-model="newVault.name" required>
            <input type="text" placeholder="description" v-model="newVault.description">
            <button type="submit">Create Vault</button>
          </form> -->


    </div>
  </div>
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue"
  import Vaults from "@/components/Vaults.vue"
  export default {
    name: 'UserVaults',
    data() {
      return {
        newVault: {
          Name: "",
          Description: ""
        },
      }
    },
    components: {
      Navbar,
      Vaults
    },
    computed: {
      userVaults() {
        return this.$store.state.userVaults;
      },
      user() {
        return this.$store.state.user;
      }
    },
    mounted() {
      this.$store.dispatch("getUserVaults");
    },
    methods: {
      getUserVaults() {
        this.$store.dispatch("getUserVaults")
      },
      // getVaultKeeps(vaultid) {
      //   this.$store.dispatch("getVaultKeeps", vaultid)
      // },
      addVault(newVault) {
        this.$store.dispatch("addVault", this.newVault) //need to pass newVault and an userId to add vault into
        //do I add the userId into data or pass it another way?
      },
      // deleteVault(vaultid) {
      //   this.$store.dispatch("deleteVault", vaultid)
      // }
    }
  }

</script>

<style>


</style>