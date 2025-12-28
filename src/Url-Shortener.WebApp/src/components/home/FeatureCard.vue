<script setup lang="ts">
import { Icon } from '@iconify/vue'

defineProps<{
  icon: string
  title: string
  description: string
}>()
</script>

<template>
  <div class="feature-card">
    <div class="icon-wrapper">
      <Icon :icon="icon" class="feature-icon" />
    </div>
    <h3 class="feature-title">{{ title }}</h3>
    <p class="feature-description">{{ description }}</p>
  </div>
</template>

<style scoped>
.feature-card {
  padding: 24px;
  border-radius: 12px;
  background-color: var(--neutral-100);
  border: 1px solid var(--neutral-200);
  text-align: center;
  transition: transform 0.2s, box-shadow 0.2s;
}
.dark .feature-card {
  background-color: var(--neutral-800);
  border-color: var(--neutral-700);
}

.feature-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 10px 20px rgba(0,0,0,0.05);
}
.dark .feature-card:hover {
  box-shadow: 0 10px 20px rgba(0,0,0,0.2);
}

.icon-wrapper {
  margin: 0 auto 20px;
  width: 60px;
  height: 60px;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: var(--primary-red-100);
  color: var(--primary-red-500);
}
.dark .icon-wrapper {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.feature-icon {
  font-size: 32px;
}

.feature-title {
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 12px;
}

.feature-description {
  color: var(--neutral-600);
}
.dark .feature-description {
  color: var(--neutral-400);
}
</style>
