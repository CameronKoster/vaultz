<template>
  <div class="VaultKeeps">
    <Navbar />
    <Keeps v-for="keep in vaultKeeps" :keep="keep" />
  </div>
</template>

<script>
  import Navbar from "@/components/Navbar.vue"
  import Keeps from "@/components/Keeps.vue"
  // import Vault from "@/components/Vaults.vue"

  export default {
    // name: 'VaultKeeps',
    data() {
      return {

      }
    },
    components: {
      Navbar,
      Keeps,
      // Vaults
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeep;
      }
    },
    mounted() {
      this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId)
    },
    methods: {
      //need to get vaultid from html
      deleteVaultKeep(keepid, vaultid) {
        this.$store.dispatch("deleteVaultKeep", { keep: keepId, vault: vaultId })
      }
    }
  }

</script>

<style>


</style>