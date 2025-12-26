<script setup lang="ts">

interface Props {
  as?: 'td' | 'th'
  align?: 'left' | 'center' | 'right'
  width?: string
}

withDefaults(
  defineProps<Props>(), 
{
  as: 'td',
  align: 'left',
})
</script>

<template>
  <component
    :is="as"
    class="ui-table-cell"
    :class="`is-${align}`"
    :style="{ width }"
  >
    <slot />
  </component>
</template>

<style scoped>
.ui-table-cell {
  padding: 12px;
  vertical-align: middle;
  flex-grow: 1;
}

.dark .ui-table__cell {
  color: var(--neutral-200);
}

.ui-table.is-dense .ui-table-cell {
  padding: 8px;
}

.ui-table-cell.is-left {
  text-align: left;
}

.ui-table-cell.is-center {
  text-align: center;
}

.ui-table-cell.is-right {
  text-align: right;
}

/* header */
th.ui-table-cell {
  font-weight: 600;
  font-size: 14px;
  color: var(--neutral-700);
}

.dark th.ui-table-cell {
  color: var(--neutral-100);
}
</style>
