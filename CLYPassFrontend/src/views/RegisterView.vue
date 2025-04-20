<template>
  <div class="min-h-screen flex items-center justify-center bg-gradient-to-br from-indigo-500 to-indigo-700 text-white">
    <RegisterForm v-if="step === 1" @next="goToStepTwo" />
    <RegisterUserForm v-else :accountData="accountData" />
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import RegisterForm from '@/components/RegisterForm.vue';
import RegisterUserForm from '@/components/RegisterUserForm.vue';

const step = ref(1);
const accountData = ref({ email: '', password: '' });

function goToStepTwo(data: { email: string; password: string }) {
  accountData.value = data;
  step.value = 2;
}
</script>
