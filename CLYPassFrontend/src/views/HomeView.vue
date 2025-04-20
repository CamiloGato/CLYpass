<template>
  <div class="min-h-screen flex flex-col items-center justify-center bg-gradient-to-br from-indigo-500 to-indigo-700 text-white">
    <h1 class="text-4xl font-bold mb-8">Bienvenido a CLYPass</h1>
    <div class="flex space-x-4">
      <button @click="$router.push('/login')" class="bg-white text-indigo-700 font-semibold px-6 py-2 rounded shadow hover:bg-gray-200 transition">
        Login
      </button>
      <button @click="$router.push('/register')" class="bg-white text-indigo-700 font-semibold px-6 py-2 rounded shadow hover:bg-gray-200 transition">
        Register
      </button>
    </div>
  </div>
</template>
