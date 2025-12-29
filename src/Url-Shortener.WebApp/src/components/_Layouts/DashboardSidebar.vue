<script setup lang="ts">
import { Icon } from '@iconify/vue'
import { sidebarMenu } from '@/types/sidebar.menu';
import SidebarItem from '@/components/SidebarItem.vue';
import ProfileMenu from '../ProfileMenu.vue';
import ButtonTheme from '../ButtonTheme.vue';

defineProps<{
  collapsed: boolean
  open: boolean
  mobile: boolean
}>()

defineEmits(['close'])
</script>

<template>
  <aside 
      class="dashboard-sidebar"
      :class="{
        'is-collapsed': collapsed && !mobile,
        'is-open': mobile && open,
        'is-mobile': mobile,
      }"
    >
    <!-- LOGO -->
    <div class="sidebar-logo">
      <Icon icon="mdi:hexagon-outline" width="28" />
      <span v-if="!collapsed" class="logo-label">MyApp</span>
    </div>

    <!-- MENU -->
    <nav class="sidebar-menu">
      <SidebarItem
        v-for="item in sidebarMenu"
        :collapsed="collapsed"
        :key="item.label"
        :item="item"b
      />
    </nav>

    <!-- PROFILE -->
    <div class="sidebar-bottom">
      <ProfileMenu block
        name="John Doe"
        plan="Pro Plan"
        avatar="https://i.pravatar.cc/150?img=3"
        :collapsed="collapsed"
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
      <ButtonTheme v-if="!collapsed" />
    </div>
  </aside>
</template>

<style scoped>
.dashboard-sidebar {
  display: flex;
  flex-direction: column;
  position: fixed;
  inset: 0 auto 0 0;
  width: 260px;
  display: flex;
  flex-direction: column;
  background-color: var(--neutral-50);
  border-right: 1px solid var(--neutral-200);
  transition: width 0.2s ease, transform 0.3s ease;
  z-index: 20;
}

/* COLLAPSED (DESKTOP) */
.dashboard-sidebar.is-collapsed {
  width: 80px;
}

/* MOBILE DEFAULT = HIDDEN */
.dashboard-sidebar.is-mobile {
  transform: translateX(-100%);
}

/* MOBILE OPEN */
.dashboard-sidebar.is-mobile.is-open {
  transform: translateX(0);
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

.is-collapsed .sidebar-logo {
  justify-content: center;
}

.logo-label {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
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
  background-color: var(--neutral-900);
}
</style>
