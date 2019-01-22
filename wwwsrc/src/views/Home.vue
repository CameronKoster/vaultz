<template>
  <div class="home">
    <navbar />


    <div>
      <button type="button" @click="logout">Logout</button>
    </div>
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue";
  export default {
    name: "home",
    data() {
      return {

      }
    },
    components: {
      Navbar
    },
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps;
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }

      this.$store.dispatch("getAllPublicKeeps")
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      }
    },
    getAllPublicKeeps() {
      this.$store.dispatch("getAllPublicKeeps")
    },
    createAccount() {

    }
  };
</script>