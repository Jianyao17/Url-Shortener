<script setup lang="ts">
import { onClickOutside } from '@vueuse/core';
import { ref } from 'vue';

defineProps<{
  name: string
  plan?: string
  avatar: string
  reverse?: boolean
  block?: boolean
  align?: 'left' | 'right'
}>()

const isOpen = ref(false)
const menuRef = ref<HTMLElement | null>(null)

function toggle() {
  isOpen.value = !isOpen.value
}

onClickOutside(menuRef, () => (isOpen.value = false))
</script>

<template>
  <div
    ref="menuRef"
    class="ui-profile"
    :class="[
      { 'is-reverse': reverse },
      { 'is-block': block },
      `align-${align}`,
    ]"
  >
    <!-- TRIGGER -->
    <button
      type="button"
      class="ui-profile__trigger"
      @click="toggle"
    >
      <slot name="leading" />
      <img
        class="avatar"
        :src="avatar"
        alt="avatar"
      />
      <div class="profile-info">
        <span class="name">{{ name }}</span>
        <span v-if="plan" class="plan">{{ plan }}</span>
      </div>
    </button>

    <!-- MENU -->
    <transition name="fade-scale">
      <div
        v-if="isOpen"
        class="ui-profile__menu"
      >
        <slot name="menu" />
      </div>
    </transition>
  </div>
</template>

<style scoped>
/* =====================================================
 * BASE
 * ===================================================== 
 */
.ui-profile {
  position: relative;
  display: inline-flex;
}

.ui-profile.is-block {
  display: flex;
  width: 100%;
}

.ui-profile__trigger {
  display: flex;
  align-items: center;
  width: 100%;
  gap: 8px;

  padding: 6px 8px;
  border-radius: var(--border-radius-1);
  font-family: var(--font-family-main);

  background: transparent;
  border: none;
  cursor: pointer;

  transition: background-color 0.15s ease;
}

.ui-profile__trigger:hover {
  background-color: var(--neutral-100);
}

.is-reverse .ui-profile__trigger {
  flex-direction: row-reverse;
}

/* =====================================================
 * INFO
 * ===================================================== 
 */
.profile-info {
  display: flex;
  min-width: 0;
  flex-direction: column;
  text-align: left;
}

.is-reverse .profile-info {
  text-align: right;
}

.name {
  font-size: 14px;
  font-weight: 600;
  color: var(--neutral-700);
}

.dark .name {
  color: var(--neutral-100);
}

.plan {
  font-size: 12px;
  font-weight: 500;
  color: var(--neutral-500);
}

/* =====================================================
 * AVATAR
 * ===================================================== 
 */
.avatar {
  width: 32px;
  height: 32px;
  border-radius: 999px;
}

/* =====================================================
 * MENU
 * ===================================================== 
 */
.ui-profile__menu {
  position: absolute;
  bottom: calc(100% + 6px);
  left: 0;

  min-width: 200px;
  padding: 8px;

  background-color: var(--neutral-0);
  border: 1px solid var(--neutral-200);
  border-radius: var(--border-radius-1);

  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.08);
  z-index: 50;
}

/* =====================================================
 * ANIMATION
 * ===================================================== 
 */
.fade-scale-enter-active,
.fade-scale-leave-active {
  transition: opacity 0.15s ease, transform 0.15s ease;
}

.fade-scale-enter-from,
.fade-scale-leave-to {
  opacity: 0;
  transform: scale(0.96);
}

/* =====================================================
 * DARK MODE
 * ===================================================== 
 */
.dark .ui-profile__trigger:hover {
  background-color: var(--neutral-800);
}

.dark .ui-profile__menu {
  background-color: var(--neutral-900);
  border-color: var(--neutral-700);
}
</style>
