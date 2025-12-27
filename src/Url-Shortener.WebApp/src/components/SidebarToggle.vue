<script setup lang="ts">
import { Icon } from '@iconify/vue'

interface Props {
  position?: {
    top?: string | number
    bottom?: string | number
    left?: string | number
    right?: string | number
  }
}
const props = withDefaults(
  defineProps<Props>(), {
    position: () => ({ top: '16px', right: '16px' })
})

defineEmits(['click'])
</script>

<template>
  <button
    class="sidebar-toggle" 
    @click="$emit('click')"
    :style="{
      top: position.top,
      bottom: position.bottom,
      left: position.left,
      right: position.right,
    }"
  >
    <Icon icon="tabler:menu-2" width="20" />
  </button>
</template>

<style scoped>
.sidebar-toggle {
  position: fixed;
  display: inline-flex;
  align-items: center;
  justify-content: center;

  width: 40px;
  height: 40px;
  border-radius: var(--border-radius-1);

  color: var(--neutral-800);
  background-color: var(--neutral-0);
  border: 1px solid var(--neutral-200);
  cursor: pointer;
  z-index: 10;

  transition:
    background-color 0.15s ease,
    transform 0.2s ease;
}

.sidebar-toggle:hover {
  background-color: var(--neutral-100);
}

.sidebar-toggle:active {
  transform: scale(0.96);
}

.dark .sidebar-toggle {
  background-color: var(--neutral-900);
  border-color: var(--neutral-700);
  color: var(--neutral-100);
}

.dark .sidebar-toggle:hover {
  background-color: var(--neutral-800);
}
</style>
