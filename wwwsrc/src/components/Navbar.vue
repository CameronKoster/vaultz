<template>
  <div class="Navbar">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">Vaultz</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div class="navbar-nav">
          <a class="nav-item nav-link active" href="#">Home <span class="sr-only">(current)</span></a>
          <a class="nav-item nav-link" href="#">Dashboard</a>
          <!-- <a class="nav-item nav-link" href="#">Login/Register</a> shows up on home page if not logged in
          <a class="nav-item nav-link" href="#">Logout</a> shows up on any page if logged in -->
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


</style>