<script setup lang="ts">
import { Icon } from '@iconify/vue'

const props = defineProps<{
  title: string
  icon?: string

}>()

</script>

<template>
  <section class="ui-chart-card">
    <!-- HEADER -->
    <header class="ui-chart-card__header">
      <div class="left">
        <Icon
          v-if="icon"
          class="icon"
          :icon="icon"
          :inline="true"
        />
        <h3 class="title">{{ title }}</h3>
      </div>

      <!-- optional action slot -->
      <slot name="action" />
    </header>

    <!-- BODY -->
    <div class="ui-chart-card__body">
      <slot />
    </div>
  </section>
</template>

<style scoped>
/* =====================================================
 * BASE
 * ===================================================== 
 */
.ui-chart-card {
  --chart-accent: var(--neutral-600);

  display: flex;
  flex-direction: column;
  flex-grow: 0;
  width: 100%;
  min-width: 0;
  gap: 8px;
  
  padding: 16px;
  border-radius: var(--border-radius-2);

  background-color: var(--neutral-50);
  border: 1px solid var(--neutral-200);

  transition:
    box-shadow 0.2s ease,
    transform 0.2s ease,
    border-color 0.2s ease;
}

@media (max-width: 1024px) {
  .ui-chart-card {
    flex-grow: 1;
    width: auto;
  }
}

/* =====================================================
 * HOVER INTERACTION
 * ===================================================== 
 */
.ui-chart-card:hover {
  --chart-accent: var(--neutral-800);
  
  box-shadow: var(--shadow-red-soft);
  transform: translateY(-2px);
}


/* =====================================================
 * HEADER
 * ===================================================== 
 */
.ui-chart-card__header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 12px;
}

.left {
  display: flex;
  align-items: center;
  gap: 8px;
}

.icon {
  width: 24px;
  height: 24px;
  color: var(--chart-accent);
}

.title {
  font-size: 16px;
  font-weight: 500;
  margin: 8px 0;
  color: var(--chart-accent);
}

/* =====================================================
 * BODY
 * ===================================================== 
 */
.ui-chart-card__body {
  position: relative;
  min-height: 240px;
  flex: 1;
}

/* =====================================================
 * DARK MODE
 * ===================================================== 
 */
.dark .ui-chart-card {
  --chart-accent: var(--neutral-300);

  background-color: var(--neutral-900);
  border-color: var(--neutral-700);
}

.dark .ui-chart-card:hover {
  --chart-accent: var(--neutral-200);
}

</style>
