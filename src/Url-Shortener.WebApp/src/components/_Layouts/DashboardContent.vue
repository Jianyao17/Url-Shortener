<template>
  <main class="dashboard-content">
    <slot />
  </main>
</template>

<style scoped>
.dashboard-content {
  flex: 1;
  padding: 64px 72px;
  overflow-y: auto;
  background-color: var(--neutral-50);
}

.dark .dashboard-content {
  background-color: var(--neutral-900);
}
</style>
