<template>
  <header class="dashboard-header">
    <div class="header-left">
      <slot name="search" />
    </div>

    <div class="header-right">
      <span class="username">Arief WT</span>
      <span class="plan">Pro</span>
      <img class="avatar" src="https://i.pravatar.cc/40" />
    </div>
  </header>
</template>

<style scoped>
.dashboard-header {
  position: sticky;
  top: 0;
  z-index: 10;

  height: 64px;
  display: flex;
  align-items: center;
  justify-content: space-between;

  padding: 0 64px;
  background-color: var(--neutral-0);
  border-bottom: 1px solid var(--neutral-200);
}

.header-right {
  display: flex;
  align-items: center;
  gap: 8px;
}

.username {
  font-size: 14px;
  font-weight: 500;
}

.plan {
  font-size: 12px;
  color: var(--neutral-500);
}

.avatar {
  width: 32px;
  height: 32px;
  border-radius: 999px;
}

.dark .dashboard-header {
  background-color: var(--neutral-900);
  border-bottom-color: var(--neutral-700);
}
</style>
