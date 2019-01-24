<template>
  <div class="row d-flex justify-content-around">
    <div class="card" style="width: 15rem">
      <i class="far fa-eye"> {{keep.views}}</i>
      <i class="fab fa-korvue"></i>{{keep.keeps}}</i>
      <i class="fas fa-retweet">0</i>
      <img class="card-img-top " :src="keep.img">
      <div class="card-header d-flex justify-content-between">
        <h1>{{keep.name}}</h1>
      </div>
      <div class="card-body d-flex justify-content-space-between">
        <!-- <button onclick="">View</button>
        <button onclick="">Keep</button>
        <button onclick="">Share</button> -->
        <i @click="" class="far fa-eye"></i>
        <i @click="addKeepToVault(keep.id, vault.id)" class="fab fa-korvue"></i></i>
        <i @click="" class="fas fa-retweet"></i>
        <i @click="deleteKeep(keep.id)" class="fas fa-trash-alt"></i>
        <button @click="viewActiveKeep(keep.id)">View</button>
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

      }
    },
    props: ["keep"],
    components: {

    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      }
    },
    mounted() {
      this.$store.state.publicKeeps;
    },
    methods: {
      viewActiveKeep(keepid) {
        this.$store.dispatch("activeKeep", keepid)
      },
      addKeepToVault(keepid, vaultid) {
        this.$store.dispatch("addKeepToVault", keepid, vaultid)
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