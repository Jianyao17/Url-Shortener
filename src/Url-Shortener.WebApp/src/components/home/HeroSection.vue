<script setup lang="ts">
import { Icon } from '@iconify/vue'

defineProps<{
  title: string
  subtitle: string
}>()
</script>

<template>
  <section class="hero-section">
    <div class="hero-container">
      <div class="hero-content">
        <h1 class="hero-title">{{ title }}</h1>
        <p class="hero-subtitle">{{ subtitle }}</p>
        <form class="shorten-form">
          <Icon icon="mdi:link-variant" class="input-icon" />
          <input type="text" placeholder="Enter your long URL here" />
          <button type="submit">Shorten</button>
        </form>
      </div>
      <div class="hero-image-container">
        <img src="@/assets/home/hero-illustration.svg" alt="Hero Illustration" class="hero-image" />
      </div>
    </div>
  </section>
</template>

<style scoped>
.hero-section {
  padding: 60px 24px 80px;
  background-color: var(--neutral-100);
}
.dark .hero-section {
  background-color: var(--neutral-800);
}

.hero-container {
  max-width: 1200px;
  margin: 0 auto;
  display: grid;
  align-items: center;
  gap: 48px;
  grid-template-columns: 1fr;
}
@media (min-width: 992px) {
  .hero-container {
    grid-template-columns: 1fr 1fr;
  }
}

.hero-title {
  font-size: 3.2rem;
  font-weight: 800;
  line-height: 1.2;
  margin-bottom: 16px;
  color: var(--neutral-900);
}
.dark .hero-title {
  color: var(--neutral-100);
}

.hero-subtitle {
  font-size: 1.2rem;
  color: var(--neutral-600);
  margin-bottom: 32px;
  max-width: 500px;
}
.dark .hero-subtitle {
  color: var(--neutral-400);
}

.shorten-form {
  display: flex;
  position: relative;
  max-width: 500px;
  box-shadow: 0 10px 25px -5px rgba(0,0,0,0.1);
  border-radius: 8px;
}
.dark .shorten-form {
  box-shadow: 0 10px 25px -5px rgba(0,0,0,0.4);
}

.shorten-form input {
  flex-grow: 1;
  padding: 16px 20px 16px 50px;
  border: 1px solid var(--neutral-300);
  border-radius: 8px 0 0 8px;
  font-size: 1rem;
  background-color: var(--neutral-50);
  color: var(--neutral-800);
}
.dark .shorten-form input {
  border-color: var(--neutral-700);
  background-color: var(--neutral-800);
  color: var(--neutral-200);
}

.shorten-form .input-icon {
  position: absolute;
  left: 16px;
  top: 50%;
  transform: translateY(-50%);
  font-size: 24px;
  color: var(--neutral-400);
}

.shorten-form button {
  padding: 16px 24px;
  border: none;
  background-color: var(--primary-red-500);
  color: white;
  font-size: 1rem;
  font-weight: 600;
  border-radius: 0 8px 8px 0;
  cursor: pointer;
  transition: background-color 0.2s;
}
.shorten-form button:hover {
  background-color: var(--primary-red-600);
}

.hero-image-container {
  display: flex;
  justify-content: center;
}
.hero-image {
  width: 100%;
  max-width: 500px;
}
</style>
