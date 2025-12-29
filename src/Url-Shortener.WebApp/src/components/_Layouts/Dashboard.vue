<script setup lang="ts">
import { computed } from 'vue';
import { useSidebar } from '@/composables/useSidebar';
import DashboardContent from './DashboardContent.vue';
import DashboardSidebar from './DashboardSidebar.vue';
import SidebarToggle from '../SidebarToggle.vue';

const { 
  isCollapsed, isOpen, isMobile, 
  close, toggleCollapse, sidebarWidth } = useSidebar();

const paddingLeft = computed(() => isMobile.value ? 24 : 16)
</script>

<template>
  <div class="dashboard-layout">
    <!-- BACKDROP (mobile) -->
    <div
      v-if="isMobile && isOpen"
      class="sidebar-backdrop"
      @click="close"
    />

    <!-- SIDEBAR -->
    <DashboardSidebar 
      :collapsed="isMobile ? false : isCollapsed"
      :open="isOpen"
      :mobile="isMobile"
      @close="close"
    />

    <div 
      class="dashboard-main"
      :style="{ marginLeft: isMobile ? '0' : `${sidebarWidth}px` }"
    >
      <SidebarToggle
        :position="{ left: `${sidebarWidth + paddingLeft}px`, top: '12px' }"
        @click=" isMobile ? (isOpen = true) : toggleCollapse()"
      />
      <DashboardContent>
        <RouterView />
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

.sidebar-backdrop {
  position: fixed;
  inset: 0;
  background: rgba(0,0,0,0.3);
  z-index: 15;
}
</style>
