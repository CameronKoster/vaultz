<template>
  <div class="UserKeeps">
    <Navbar />
    <div class="row">
      <Keeps v-for="keep in userKeeps" :keep="keep" />
    </div>
    <div>
      <form>
        <i @click="addKeep()" class="far fa-plus-square plus">
          <h3>add a keep</h3>
        </i>
        <!-- v-if this form if add a keep is clicked -->
        <input type="text" v-model="newKeep.Name" placeholder="Enter Keep Name">
        <input type="text" v-model="newKeep.Description" placeholder="Enter Keep Description">
        <input type="text" v-model="newKeep.Img" placeholder="Enter Keep Img Url">
        <input type="checkbox" v-model="newKeep.isPrivate">Private?</input>
      </form>
    </div>
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue"
  import Keeps from "@/components/Keeps.vue"
  export default {
    name: 'UserKeeps',
    data() {
      return {
        newKeep: {
          Name: "",
          Description: "",
          Img: "",
          isPrivate: 0
        }
      }
    },
    components: {
      Navbar,
      Keeps
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      userKeeps() {
        return this.$store.state.userKeeps;
      }
    },
    mounted() {
      this.$store.dispatch("getUserKeeps")
    },
    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.newKeep);
      },
    }
  }

</script>

<style>


</style>