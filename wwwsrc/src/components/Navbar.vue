<template>
  <div class="Navbar">
    <nav class="Navbar navbar-dark bg-success container-fluid">
      <div class="row w-100">
        <div class="col-3 logo">
          <router-link class="font" :to="{name: 'home'}">Vaultz</router-link>
        </div>
        <div class="col-9 menuItems">
          <div class="row">
            <div class="col">
              <router-link class="font" to="/dashboard">Dashboard</router-link>
            </div>
            <div class="col">
              <router-link @click.native='login()' class="font" to="/login">Login/Register</router-link>
            </div>
            <div class="col">
              <router-link @click.native='logout()' class="font" to="/login">Logout</router-link>
            </div>
          </div>
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