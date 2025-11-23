<script setup lang="ts">
import { useThemeStore } from './stores/theme.store';

const { theme, toggleTheme } = useThemeStore();
</script>

<template>
  <h1>You did it!</h1>
  <p>
    Visit <a href="https://vuejs.org/" target="_blank" rel="noopener">vuejs.org</a> to read the
    documentation
  </p>
  <button @click="toggleTheme" class="btn">
    Current theme: {{ theme }} (click to toggle)
  </button>
</template>

<style scoped>
.btn
{
  background-color: red;
  color: white;
}

.dark .btn
{
  background-color: blue;
  color: black;
}
</style>
