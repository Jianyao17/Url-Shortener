<script setup lang="ts">
defineProps<{
  title: string
  subtitle?: string
}>()
</script>

<template>
  <div class="auth-page">
    <div class="auth-card">
      <h1 class="auth-title">{{ title }}</h1>
      <p v-if="subtitle" class="auth-subtitle">
        {{ subtitle }}
      </p>

      <slot />
    </div>
  </div>
</template>

<style scoped>
.auth-page {
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;

  background-color: var(--neutral-50);
}

.auth-card {
  width: 100%;
  max-width: 420px;
  padding: 32px;

  border-radius: var(--border-radius-2);
  border: 1px solid var(--neutral-200);
  box-shadow: 8px 12px 16px 8px var(--primary-red-50);
}

.auth-title {
  font-size: 24px;
  font-weight: 700;
  margin-bottom: 4px;
}

.auth-subtitle {
  font-size: 14px;
  color: var(--neutral-500);
  margin-bottom: 24px;
}

.dark .auth-page {
  background-color: var(--neutral-900);
}

.dark .auth-card {
  border: 1px solid var(--neutral-700);
  box-shadow: 8px 12px 16px 8px rgba(102, 25, 0, 0.10);
}
</style>
