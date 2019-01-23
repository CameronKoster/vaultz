<template>
  <div class="dashboard">
    <Navbar />
    <div class="row">
      <Vaults v-for="vault in userVaults" :vault="vault" />
    </div>
    <div>
      <div>
        <i @click="addVault" class="far fa-plus-square plus">
          <h3>add a vault</h3>
        </i>
        <form>
          <!--v-if this form if add a vault is clicked-->
          <input type="text" placeholder="Enter Vault Name">
          <input type="text" placeholder="Enter Vault Description">
        </form>
      </div>
      <div>
        <i class="far fa-plus-square plus">
          <h3>add a keep</h3>
        </i>
        <form>
          <!--v-if this form if add a keep is clicked-->
          <input type="text" placeholder="Enter Keep Name">
          <input type="text" placeholder="Enter Keep Description">
          <input type="text" placeholder="Enter Keep Img Url">
        </form>
      </div>
    </div>
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue";
  import Vaults from "@/components/Vaults.vue";

  export default {
    name: 'dashboard',
    //Data
    data() {
      return {
        newVault: {
          Name: "",
          Description: ""
        },
        newKeep: {
          Name: "",
          Description: "",
          Img: ""
        }
      }
    },
    //Components
    components: {
      Navbar,
      Vaults
    },
    //Computed
    computed: {
      userVaults() {
        return this.$store.state.userVaults;
      },
      user() {
        return this.$store.state.user;
      }
    },
    //Mounted
    mounted() {
      this.$store.dispatch("getUserVaults");

    },
    //Methods
    methods: {
      //vaults

      getUserVaults() {
        this.$store.dispatch("getUserVaults")
      },
      addVault(newVault) {
        this.$store.dispatch("addVault", newVault) //need to pass newVault and an userId to add vault into
        //do I add the userId into data or pass it another way?
      },
      deleteVault() {

      }

      //keeps
      addPublicKeep(newKeep) {
        this.$store.dispatch("addPublicKeep", newKeep);
      },
      addKeepToVault() {

      },
      deleteKeep() {

      }
      viewKeepsInVault() {

      },
    }
  }

</script>

<style>
  .plus {
    font-size: .6in;
  }
</style>