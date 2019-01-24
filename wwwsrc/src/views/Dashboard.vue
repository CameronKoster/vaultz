<template>
  <div class="dashboard">
    <Navbar />
    <h1>My Dashboard</h1>
    <router-link :to="{name: 'userkeeps'}">
      <div class="jumbotron jumbotron-fluid">
        <div class="container">
          <h1 class="display-4">My Keeps</h1>
        </div>
      </div>
    </router-link>
    <router-link :to="{name: 'uservaults'}">
      <div class="jumbotron jumbotron-fluid">
        <div class="container">
          <h1 class="display-4">My Vaults</h1>
        </div>
      </div>
    </router-link>

  </div>
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue";


  export default {
    name: 'dashboard',
    //Data
    data() {
      return {

      }
    },
    //Components
    components: {
      Navbar,

    },
    //Computed
    computed: {

      user() {
        return this.$store.state.user;
      }
    },
    //Mounted
    mounted() {


    },
    //Methods
    methods: {




    }
  }

</script>

<style>
  .plus {
    font-size: .6in;
  }
</style>