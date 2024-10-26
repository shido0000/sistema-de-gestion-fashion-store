<template>
  <router-view />
</template>

<script setup>
import { useRouter } from 'vue-router'
import { onMounted } from 'vue'
import {checkAuthentication}from 'src/assets/js/util/funciones'
defineOptions({
  name: 'App'
});


const router = useRouter()

onMounted(() => {
  const isAuthenticated = checkAuthentication()
  if (isAuthenticated) {
    router.push('/Inicio')
  } else {
    router.push('/login')
  }
})
</script>
