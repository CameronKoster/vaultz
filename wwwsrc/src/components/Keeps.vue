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
        <button onclick="//increase views">View</button>
        <button onclick="//increase keeps">Keep</button>
        <button onclick="//increase shares">Share</button>
        <button @click="deleteKeep(keep.id)">Delete</button>
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

    },
    mounted() {
      this.$store.state.publicKeeps;
    },
    methods: {
      viewActiveKeep() {
        this.$store.dispatch("viewActiveKeep", keep)
      },
      // addKeepToVault() {

      // },

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