<template>
  <form @submit.prevent="handleNext" class="w-full max-w-md bg-white p-8 rounded-xl shadow-lg text-gray-800">
    <h2 class="text-2xl font-bold mb-6 text-center text-indigo-700">Registro - Paso 1</h2>
    <input
        v-model="email"
        type="email"
        placeholder="Correo"
        class="w-full mb-4 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
        required
    />
    <input
        v-model="password"
        type="password"
        placeholder="Contraseña"
        class="w-full mb-4 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
        required
    />
    <input
        v-model="confirmPassword"
        type="password"
        placeholder="Confirmar contraseña"
        class="w-full mb-6 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
        required
    />
    <button
        type="submit"
        class="w-full bg-indigo-600 text-white font-semibold py-2 rounded hover:bg-indigo-700 transition"
    >
      Siguiente
    </button>
  </form>
</template>

<script lang="ts" setup>
import { ref } from 'vue';

const emit = defineEmits(['next']);

const email = ref('');
const password = ref('');
const confirmPassword = ref('');

function handleNext() {
  if (password.value !== confirmPassword.value) {
    alert('Las contraseñas no coinciden');
    return;
  }

  emit('next', { email: email.value, password: password.value });
}
</script>
