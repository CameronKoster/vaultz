<template>
  <div class="container-fluid">
    <nav class="row d-flex align-items-center justify-content-center Navbar navbar-dark bg-success">
      <i class="fas fa-shield-alt col-3 d-flex align-items-center justify-content-center logo">
        <router-link class="font" :to="{name: 'home'}">Vaultz</router-link>
      </i>
      <div class="col-9 d-flex align-items-center justify-content-end menuItems">
        <div>
          <router-link class="font" to="/dashboard">Dashboard</router-link>
        </div>
        <div>
          <router-link @click='login()' class="font" to="/login">Login/Register</router-link>
        </div>
        <div>
          <router-link @click='logout()' class="font" to="/login">Logout</router-link>
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
  .Navbar {
    height: 1in;
  }

  .logo {
    height: 1in;
    font-size: 35px;
  }

  .menuItems {
    font-size: 35px;
  }

  .font {
    color: white;
    font-size: 35px;
  }
</style>