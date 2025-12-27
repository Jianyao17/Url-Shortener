<script setup lang="ts">
import { Icon } from '@iconify/vue';

defineProps({
  text: {
    type: String,
    default: 'Continue with Google',
  },
})

</script>

<template>
  <button
      type="button"
      class="google-login-btn"
    >
      <Icon icon="logos:google-icon" width="18" />
      <span>{{ text }}</span>
    </button>
</template>

<style scoped>
.google-login-btn {
  display: flex;
  align-items: center;
  justify-content: center;

  gap: 8px;
  width: 100%;
  padding: 10px 0;
  margin-bottom: 0;

  border: 1px solid var(--neutral-300);
  border-radius: var(--border-radius-1);
  color: var(--neutral-800);

  font-family: var(--font-family-main);
  font-size: 16px;
  font-weight: 400;
  
  cursor: pointer;
  transition: 
    background-color 0.15s, 
    border-color 0.15s;
}

.google-login-btn:hover {
  background: var(--neutral-100);
  border-color: var(--neutral-400);
}

.dark .google-login-btn {
  background: var(--neutral-900);
  color: var(--neutral-100);
  border-color: var(--neutral-700);
}

.dark .google-login-btn:hover {
  background: var(--neutral-800);
  border-color: var(--neutral-600);
}
</style>