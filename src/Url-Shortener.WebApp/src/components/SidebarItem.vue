<script setup lang="ts">
import { computed } from 'vue'
import { Icon } from '@iconify/vue'
import { useRoute, useRouter } from 'vue-router'
import type { SidebarMenuItem } from '@/types/sidebar.menu';

const props = defineProps<{
  item: SidebarMenuItem
  collapsed?: boolean
}>()

const route = useRoute()
const router = useRouter()

const isActive = computed(() => 
{
  if (!props.item.to) return false
  return route.path === props.item.to
})

function navigate() 
{
  if (props.item.disabled || !props.item.to) return
  router.push(props.item.to)
}
</script>

<template>
  <button
    type="button"
    class="ui-sidebar-item"
    :class="{
      'is-active': isActive,
      'is-disabled': item.disabled,
      'is-collapsed': collapsed
    }"
    :disabled="item.disabled"
    @click="navigate"
  >
    <Icon
      v-if="item.icon"
      class="ui-sidebar-item__icon"
      :icon="item.icon"
      :inline="true"
    />

    <span v-if="!collapsed" class="ui-sidebar-item__label">
      {{ item.label }}
    </span>
  </button>
</template>

<style scoped>
/* =====================================================
 * BASE
 * ===================================================== 
 */
.ui-sidebar-item {
  display: flex;
  align-items: center;
  width: 100%;
  height: 48px;

  padding-left: 16px;
  padding-right: 12px;
  gap: 8px;

  justify-content: flex-start;
  text-align: left;

  border: none;
  border-radius: var(--border-radius-2);

  background-color: transparent;
  color: var(--neutral-700);

  font-family: var(--font-family-main);
  font-size: 16px;
  font-weight: 500;

  cursor: pointer;

  transition:
    background-color 0.15s ease,
    color 0.15s ease;
}

.ui-sidebar-item__icon {
  width: 20px;
  height: 20px;
  flex-shrink: 0;
}

.ui-sidebar-item__label {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

/* =====================================================
 * STATES
 * ===================================================== 
 */
.ui-sidebar-item:hover {
  background-color: var(--primary-red-100);
  color: var(--primary-red-600);
}

.ui-sidebar-item:active {
  background-color: var(--primary-red-100);
}

.ui-sidebar-item.is-active {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.ui-sidebar-item.is-active:hover {
  background-color: var(--primary-red-600);
}

.ui-sidebar-item.is-disabled {
  opacity: 0.5;
  pointer-events: none;
}

.ui-sidebar-item.is-collapsed {
  justify-content: center;
  padding-left: 0;
  padding-right: 0;
}

/* =====================================================
 * FOCUS (NO SHIFT)
 * ===================================================== 
 */
.ui-sidebar-item:focus-visible {
  outline: none;
  box-shadow: 0 0 0 2px var(--primary-red-400);
}

/* =====================================================
 * DARK MODE
 * ===================================================== 
 */
.dark .ui-sidebar-item {
  color: var(--neutral-200);
}

.dark .ui-sidebar-item:hover {
  background-color: var(--neutral-800);
  color: var(--neutral-100);
}

.dark .ui-sidebar-item.is-active {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}
</style>
