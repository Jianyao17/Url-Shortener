<script setup lang="ts">
import { useThemeStore } from '@/stores/theme.store';
import { onMounted } from 'vue';

const themeStore = useThemeStore();
onMounted(() => themeStore.initTheme())
</script>

<template>
  <RouterView />
</template>

