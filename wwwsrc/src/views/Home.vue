<template>
  <div class="home container-fluid">
    <Navbar />
    <div class="row">
      <Keeps v-for="keep in publicKeeps" :keep="keep" />
    </div>
    <h1>no public keeps currently</h1>
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue";
  import Keeps from "@/components/Keeps.vue";

  export default {
    name: "home",
    //Data
    data() {
      return {

      }
    },
    //Components
    components: {
      Navbar,
      Keeps

    },
    //COMPUTED
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps;
      },
      user() {
        return this.$store.state.user;
      }

    },
    //Mounted
    mounted() {

      if (!this.$store.state.user.id) {
        this.$router.push({ name: "home" }); //blocks users not logged in
      }


      this.$store.dispatch("getPublicKeeps");
    },
    //METHODS
    methods: {

      logout() {
        this.$store.dispatch("logout")
      },
      // viewKeep() {

      // },
      addKeep(newKeep) {
        this.$store.dispatch("addKeep", newKeep);
      },

      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep);
      },

      viewSelectedKeep() {

      },

      getPublicKeeps() {
        this.$store.dispatch("getPublicKeeps")
      },

      getUserKeeps(user) {
        this.$store.dispatch("getUserKeeps", user)
      }
    },


  };
</script>