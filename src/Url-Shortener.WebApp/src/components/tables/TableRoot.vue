<template>
  <div class="ui-table__wrapper">
    <table class="ui-table">
      <slot />
    </table>
  </div>
</template>

<style scoped>
.ui-table__wrapper {
  width: 100%;
  overflow-x: auto;
  border-radius: var(--border-radius-1);
  background-color: var(--neutral-0);
}

.dark .ui-table__wrapper {
  background-color: var(--neutral-900);
}

.ui-table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
}
</style>
