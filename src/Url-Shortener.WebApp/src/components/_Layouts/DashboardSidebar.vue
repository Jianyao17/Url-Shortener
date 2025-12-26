<script setup lang="ts">
import { Icon } from '@iconify/vue'
import { sidebarMenu } from '@/types/sidebar.menu';
import SidebarItem from '@/components/SidebarItem.vue';
import ProfileMenu from '../ProfileMenu.vue';
import ButtonTheme from '../ButtonTheme.vue';
</script>

<template>
  <aside class="dashboard-sidebar">
    <!-- LOGO -->
    <div class="sidebar-logo">
      <Icon icon="mdi:hexagon-outline" width="28" />
      <span>MyApp</span>
    </div>

    <!-- MENU -->
    <nav class="sidebar-menu">
      <!-- <slot name="menu" /> -->
      <SidebarItem
        v-for="item in sidebarMenu"
        :key="item.label"
        :item="item"
      />
    </nav>

    <!-- PROFILE -->
    <div class="sidebar-bottom">
      <ProfileMenu block
        name="John Doe"
        plan="Pro Plan"
        avatar="https://i.pravatar.cc/150?img=3"
      >
        <template #menu>
          <button
            type="button"
            class="ui-profile__menu-item"
          >
            Profile Settings
          </button>

          <button
            type="button"
            class="ui-profile__menu-item"
          >
            Logout
          </button>
        </template>
      </ProfileMenu>
      <ButtonTheme />
    </div>
  </aside>
</template>

<style scoped>
.dashboard-sidebar {
  position: fixed;
  inset: 0 auto 0 0;
  width: 260px;
  display: flex;
  flex-direction: column;
  border-right: 1px solid var(--neutral-200);
  z-index: 20;
}

.sidebar-logo {
  height: 64px;
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 0 16px;
  font-weight: 600;
  font-size: 18px;
}

.sidebar-menu {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 4px;

  margin-top: 16px;
  padding: 0 12px;
  overflow-y: auto;
}

.sidebar-bottom {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  
  padding: 8px;
  border-top: 1px solid var(--neutral-200);
  gap: 4px;
}

.dark .sidebar-bottom {
  border-top-color: var(--neutral-700);
}

.dark .dashboard-sidebar {
  border-right-color: var(--neutral-700);
}
</style>
