<template>
  <div class="row d-flex justify-content-around">
    <div class="card" style="width: 15rem">
      <!--how to do a v-for in both public and user keeps. Do i need to?-->
      <i class="far fa-eye"> {{keep.views}}</i>
      <i class="fab fa-korvue"></i>{{keep.keeps}}</i>
      <i class="fas fa-retweet">0</i>
      <img class="card-img-top " :src="keep.img">
      <div class="card-header d-flex justify-content-between">
        <h1>{{keep.name}}</h1>
      </div>
      <div class="card-body d-flex justify-content-space-between">
        <button @click="viewActiveKeep(keep.id)">View</button>

        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Add
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <div class="dropdown-item" @click="addKeepToVault(keep.id, vault.id)" v-for="vault in getUserVaults" href="#">{{vault.name}}</div>
          </div>
        </div>

        <i @click="deleteKeep(keep.id)" class="fas fa-trash-alt"></i>
        <!-- Need to do a v-if to display a modal of larger keep -->
      </div>
    </div>
















  </div>
</template>

<script>
  export default {
    name: 'keeps',
    data() {
      return {
        newVault: {
          Name: "",
          Description: ""
        },
      }
    },
    props: ["keep"],
    components: {

    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      getUserVaults() {
        return this.$store.state.userVaults
      }
    },
    mounted() {
      // this.$store.dispatch("publicKeeps");
      this.$store.dispatch("getUserVaults");
    },
    methods: {


      viewActiveKeep(keepid) {

        this.$store.dispatch("activeKeep", keepid)
      },




      addKeepToVault(keepid, vaultid) {

        this.$store.dispatch("addKeepToVault", { keepId: keepid, vaultId: vaultid })
      },





      deleteKeep(keepid) {
        this.$store.dispatch("deleteKeep", keepid);
      },

      getPublicKeeps() {
        this.$store.dispatch("getPublicKeeps")
      },

      getUserKeeps(user) {
        this.$store.dispatch("getUserKeeps", user)
      }
    }
  }

</script>








<style>


</style>