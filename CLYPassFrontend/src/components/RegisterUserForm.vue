<template>
  <form @submit.prevent="handleSubmit" class="w-full max-w-md bg-white p-8 rounded-xl shadow-lg text-gray-800">
    <h2 class="text-2xl font-bold mb-6 text-center text-indigo-700">Registro - Paso 2</h2>

    <label class="block mb-4">
      <span class="text-sm font-semibold text-gray-700">¿Tiene alguna discapacidad?</span>
      <select
          v-model="disability"
          class="w-full mt-1 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
          required
      >
        <option value="">Seleccione una opción</option>
        <option value="ninguna">Ninguna</option>
        <option value="visual">Visual</option>
        <option value="auditiva">Auditiva</option>
        <option value="motora">Motora</option>
        <option value="intelectual">Intelectual</option>
        <option value="otra">Otra</option>
      </select>
    </label>

    <div v-if="disability === 'otra'" class="mb-4">
      <label class="block">
        <span class="text-sm font-semibold text-gray-700">Especifique la discapacidad</span>
        <input
            v-model="otherDisability"
            type="text"
            class="w-full mt-1 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
            required
        />
      </label>
    </div>

    <label class="block mb-4">
      <span class="text-sm font-semibold text-gray-700">Edad</span>
      <input
          v-model.number="age"
          type="number"
          min="0"
          class="w-full mt-1 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
          required
      />
    </label>

    <label class="block mb-4">
      <span class="text-sm font-semibold text-gray-700">Nombre</span>
      <input
          v-model="firstName"
          type="text"
          class="w-full mt-1 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
          required
      />
    </label>

    <label class="block mb-6">
      <span class="text-sm font-semibold text-gray-700">Apellido</span>
      <input
          v-model="lastName"
          type="text"
          class="w-full mt-1 px-4 py-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-indigo-400"
          required
      />
    </label>

    <button
        type="submit"
        class="w-full bg-indigo-600 text-white font-semibold py-2 rounded hover:bg-indigo-700 transition"
    >
      Registrarse
    </button>
  </form>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { useUserStore } from '@/stores/user';

const { accountData } = defineProps<{
  accountData: {
    email: string;
    password: string;
  };
}>();

const disability = ref('');
const otherDisability = ref('');
const age = ref<number | null>(null);
const firstName = ref('');
const lastName = ref('');
const router = useRouter();
const userStore = useUserStore();

function handleSubmit() {
  const name = `${firstName.value} ${lastName.value}`;

  userStore.setUser(name, accountData.email);

  router.push('/dashboard');
}
</script>
