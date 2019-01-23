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
          <button onclick="//run viewKeep">View</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaults',
    data() {
      return {

      }
    },
    props: ["vault"],
    components: {

    },
    computed: {

    },
    mounted() {
      this.$store.state.userVaults;
    },
    methods: {
      getUserVaults() {
        this.$store.dispatch("getUserVaults", userId)
      }
    }
  }

</script>

<style>


</style>