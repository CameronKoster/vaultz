<template>
  <div class="Navbar">
    <nav class="Navbar navbar-dark bg-success container-fluid">
      <div class="row w-100">
        <div class="col-3 logo"><a class="navbar-brand" href="#">Vaultz</a>
        </div>
        <div class="col-9 menuItems">
          <div class="row">
            <!-- <div v-if="getUser"> -->
            <div class="col">
              <router-link class="font" :to="{name: 'home'}">Home</router-link>
            </div>
            <div class="col">
              <router-link class="font" to="/dashboard">Dashboard</router-link>
            </div>
            <div class="col">
              <router-link @click.native='logout()' class="font" to="/login">Logout</router-link>
            </div>
          </div>
          <!-- </div> -->
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
  export default {
    name: 'Navbar',
    data() {
      return {

      }
    },
    components: {

    },
    computed: {

    },
    mounted() {

    },
    methods: {

    }
  }

</script>

<style>
  .font {
    color: white;
  }
</style>