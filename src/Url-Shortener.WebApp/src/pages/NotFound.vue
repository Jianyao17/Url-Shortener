<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="not-found-container">
    <img src="../assets/404.svg" alt="404 Not Found" class="not-found-image" />
    <h1 class="not-found-title">404 - Page Not Found</h1>
    <p class="not-found-description">The page you are looking for might have been removed, had its name changed, or is temporarily unavailable.</p>
    <RouterLink to="/" class="not-found-button">Go to Dashboard</RouterLink>
  </div>
</template>

<style scoped>
.not-found-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  background-color: var(--neutral-50); /* Light mode background */
  color: var(--neutral-800); /* Light mode text color */
  padding: 20px;
  text-align: center;
}

.dark .not-found-container {
  background-color: var(--neutral-900); /* Dark mode background */
  color: var(--neutral-100); /* Dark mode text color */
}

.not-found-image {
  width: 100%;
  max-width: 400px;
  margin-bottom: 30px;
}

.not-found-title {
  font-size: 2.5em;
  margin-bottom: 15px;
}

.not-found-description {
  font-size: 1.1em;
  margin-bottom: 30px;
  max-width: 600px;
}

.not-found-button {
  display: inline-block;
  padding: 12px 24px;
  background-color: var(--primary-red-500);
  color: white;
  text-decoration: none;
  border-radius: 8px;
  font-weight: 600;
  transition: background-color 0.3s ease;
}

.not-found-button:hover {
  background-color: var(--primary-red-600);
}

/* Ensure the RouterLink looks like a button */
.not-found-button {
  -webkit-appearance: none;
  -moz-appearance: none;
  appearance: none;
  border: none;
  cursor: pointer;
}
</style>
