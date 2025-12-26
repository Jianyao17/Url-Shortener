<script setup lang="ts">
import { useThemeStore } from '@/stores/theme.store';
import { Icon } from '@iconify/vue'

const themeStore = useThemeStore()
</script>

<template>
  <button
    class="ui-theme-toggle"
    @click="themeStore.toggleTheme"
    :aria-label="`Switch to ${themeStore.theme === 'light' ? 'dark' : 'light'} mode`"
  >
    <Icon
      :icon="themeStore.theme === 'light'
        ? 'tabler:sun'
        : 'tabler:moon'"
      width="18"
      height="18"
    />
  </button>
</template>

<style scoped>
.ui-theme-toggle {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  height: 100%;

  border: none;
  border-radius: 32px;
  background-color: transparent;
  color: var(--neutral-700);

  cursor: pointer;
  aspect-ratio: 1 / 1;

  transition:
    background-color 0.15s ease,
    color 0.15s ease,
    transform 0.1s ease;
}

.ui-theme-toggle:hover {
  background-color: var(--neutral-200);
}

.ui-theme-toggle:active {
  transform: scale(0.95);
}

.dark .ui-theme-toggle {
  color: var(--neutral-200);
}

.dark .ui-theme-toggle:hover {
  background-color: var(--neutral-700);
}
</style>
