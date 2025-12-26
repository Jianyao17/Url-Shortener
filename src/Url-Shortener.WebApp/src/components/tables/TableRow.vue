<script setup lang="ts">
import { computed } from 'vue'

interface Props {
  selectable?: boolean
  selected?: boolean
  devider?: boolean
}

const props = withDefaults(
  defineProps<Props>(), 
{
  selectable: false,
  selected: false,
  devider: true,
})

const rowClasses = computed(() => 
[
  'ui-table__row',
  {
    'is-selectable': props.selectable,
    'is-selected': props.selected,
    'has-devider': props.devider,
  },
])
</script>

<template>
  <tr :class="rowClasses">
    <slot />
  </tr>
</template>

<style scoped>
.ui-table__row {
  transition: background-color 0.15s ease;
}

.ui-table__row.is-selectable:hover {
  background-color: var(--neutral-100);
  cursor: pointer;
}

.ui-table__row.is-selectable:active {
  background-color: var(--neutral-200);
}

.dark .ui-table__row.is-selectable:hover {
  background-color: var(--neutral-700);
}

.dark .ui-table__row.is-selectable:active {
  background-color: var(--neutral-800);
}

.ui-table__row.is-selected  {
  background-color: var(--primary-red-100);
}

.dark .ui-table__row.is-selected {
  background-color: var(--primary-red-900);
}

.has-devider {
  border-bottom: 1px solid var(--neutral-800);
}
</style>
