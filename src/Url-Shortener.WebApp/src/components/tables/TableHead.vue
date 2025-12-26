<template>
  <thead class="ui-table__head">
    <slot />
  </thead>
</template>

<style scoped>
.ui-table__head {
  background-color: var(--neutral-200);
}

.dark .ui-table__head {
  background-color: var(--neutral-800);
}
</style>
