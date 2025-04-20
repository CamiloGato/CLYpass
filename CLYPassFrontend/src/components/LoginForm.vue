<template>
  <form @submit.prevent="handleLogin" class="w-full max-w-sm bg-white p-8 rounded-xl shadow-lg text-gray-800">
    <h2 class="text-2xl font-bold mb-6 text-center text-indigo-700">Iniciar sesión</h2>
    <input
        v-model="email"
        type="email"
        placeholder="Correo electrónico"
        class="w-full mb-4 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
        required
    />
    <input
        v-model="password"
        type="password"
        placeholder="Contraseña"
        class="w-full mb-6 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
        required
    />
    <button
        type="submit"
        class="w-full bg-indigo-600 text-white font-semibold py-2 rounded hover:bg-indigo-700 transition"
    >
      Entrar
    </button>
  </form>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const email = ref('');
const password = ref('');
const router = useRouter();

function handleLogin() {
  const name = email.value.split('@')[0] || 'user';
  router.push(`/dashboard/${name}`);
}
</script>
