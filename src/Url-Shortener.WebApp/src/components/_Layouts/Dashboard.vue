<script setup lang="ts">
import DashboardContent from './DashboardContent.vue';
import DashboardHeader from './DashboardHeader.vue';
import DashboardSidebar from './DashboardSidebar.vue';
</script>

<template>
  <div class="dashboard-layout">
    <DashboardSidebar>
      <template #menu>
        <slot name="sidebar-menu" />
      </template>
    </DashboardSidebar>

    <div class="dashboard-main">
      <DashboardContent>
        <slot name="main-page" />
      </DashboardContent>
    </div>
  </div>
</template>

<style scoped>
.dashboard-layout {
  display: flex;
  height: 100vh;
  overflow: hidden;
  background-color: var(--neutral-50);
}

.dashboard-main {
  margin-left: 260px;
  flex: 1;
  display: flex;
  flex-direction: column;
  min-width: 0;
}

.dark .dashboard-layout {
  background-color: var(--neutral-900);
}
</style>
