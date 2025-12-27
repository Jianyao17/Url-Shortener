<script setup lang="ts">
import { Icon } from "@iconify/vue";
import { useThemeStore } from './stores/theme.store';
import Button from "./components/Button.vue";
import InputField from "./components/InputField.vue";
import Table from "./components/Table.vue";
import Dashboard from "./components/_Layouts/Dashboard.vue";

const themeStore = useThemeStore();
</script>

<template>
  <Dashboard>
    <template #global-search>
      <InputField
        type="text"
        placeholder="Search..."
        leadingIcon="mdi:magnify"
      />
    </template>
    <template #main-page>
      <InputField
        type="text"
        label="Original Url" required
        placeholder="Enter URL here..."
        leadingIcon="mdi:link-variant"
      />
      <Button variant="primary" size="md"
      @click="themeStore.toggleTheme" 
      leadingIcon="tabler:square-rounded-plus"
      >
        Toggle Theme
      </Button>
      <Table />
    </template>
  </Dashboard>
</template>

<style scoped>
</style>
