<template>
  <div class="min-h-screen flex items-center justify-center bg-gradient-to-br from-indigo-500 to-indigo-700 text-white">
    <div class="bg-white text-indigo-700 p-10 rounded-lg shadow-md text-center">
      <h1 class="text-3xl font-bold mb-2">Bienvenido, {{ userStore.name }}</h1>
      <p class="text-gray-600">¡Nos alegra verte!</p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useUserStore } from '@/stores/user';
const userStore = useUserStore();
</script>
