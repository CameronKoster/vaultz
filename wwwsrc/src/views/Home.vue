<template>
  <div class="home">
    <h1>Welcome to Keepr</h1>
    <div>
      <button type="button" @click="logout">Logout</button>
    </div>
  </div>
</template>

<script>
  // import navbar from "@/components/Navbar.vue";
  export default {
    name: "home",
    data() {

    },
    components: {
      // Navbar
    },
    computed: {

    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      }
    }
  };
</script>