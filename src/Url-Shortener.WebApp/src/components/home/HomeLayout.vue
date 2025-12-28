<script setup lang="ts">
import HomeFooter from './HomeFooter.vue'
import { Icon } from '@iconify/vue'
import { useThemeStore } from '@/stores/theme.store'

const themeStore = useThemeStore()
</script>

<template>
  <div class="home-layout">
    <header class="home-header">
      <div class="header-container">
        <div class="logo">
          <Icon icon="mdi:link-variant" class="logo-icon" />
          <span>Shorty</span>
        </div>
        <nav class="main-nav">
          <a href="#features">Features</a>
          <a href="#">Pricing</a>
          <a href="#">Contact</a>
        </nav>
        <div class="header-actions">
          <button @click="themeStore.toggleTheme()" class="theme-toggle">
            <Icon :icon="themeStore.theme === 'dark' ? 'mdi:weather-sunny' : 'mdi:weather-night'" />
          </button>
          <a href="/login" class="login-link">Login</a>
          <a href="/register" class="signup-button">Sign Up</a>
        </div>
      </div>
    </header>

    <main>
      <slot />
    </main>

    <HomeFooter />
  </div>
</template>

<style scoped>
.home-layout {
  background-color: var(--neutral-50);
  color: var(--neutral-800);
}
.dark .home-layout {
  background-color: var(--neutral-900);
  color: var(--neutral-200);
}

.home-header {
  position: sticky;
  top: 0;
  z-index: 10;
  width: 100%;
  padding: 16px 24px;
  background-color: rgba(255, 255, 255, 0.8);
  backdrop-filter: blur(8px);
  border-bottom: 1px solid var(--neutral-200);
}
.dark .home-header {
  background-color: rgba(17, 24, 39, 0.8);
  border-bottom: 1px solid var(--neutral-800);
}

.header-container {
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.logo {
  display: flex;
  align-items: center;
  font-weight: 700;
  font-size: 24px;
  color: var(--neutral-900);
}
.dark .logo {
  color: var(--neutral-100);
}

.logo-icon {
  color: var(--primary-red-500);
  margin-right: 8px;
  font-size: 28px;
}

.main-nav {
  display: none; /* Hidden on mobile */
}
@media (min-width: 768px) {
  .main-nav {
    display: flex;
    gap: 24px;
    font-weight: 500;
  }
  .main-nav a {
    text-decoration: none;
    color: var(--neutral-600);
    transition: color 0.2s;
  }
  .main-nav a:hover {
    color: var(--primary-red-500);
  }
  .dark .main-nav a {
    color: var(--neutral-400);
  }
  .dark .main-nav a:hover {
    color: var(--primary-red-400);
  }
}

.header-actions {
  display: flex;
  align-items: center;
  gap: 16px;
}

.theme-toggle {
  background: none;
  border: none;
  cursor: pointer;
  color: var(--neutral-600);
  font-size: 22px;
}
.theme-toggle:hover {
  color: var(--primary-red-500);
}
.dark .theme-toggle {
  color: var(--neutral-400);
}
.dark .theme-toggle:hover {
  color: var(--primary-red-400);
}

.login-link {
  font-weight: 500;
  text-decoration: none;
  color: var(--neutral-600);
}
.dark .login-link {
  color: var(--neutral-400);
}

.signup-button {
  display: none; /* Hidden on mobile */
}
@media (min-width: 768px) {
  .signup-button {
    display: block;
    padding: 8px 16px;
    background-color: var(--primary-red-500);
    color: white;
    text-decoration: none;
    border-radius: 6px;
    font-weight: 500;
    transition: background-color 0.2s;
  }
  .signup-button:hover {
    background-color: var(--primary-red-600);
  }
}
</style>
