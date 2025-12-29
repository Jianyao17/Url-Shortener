<script setup lang="ts">
import { useThemeStore } from "@/stores/theme.store";
import Button from "@/components/Button.vue";
import InputField from "@/components/InputField.vue";
import MetricCard from "@/components/MetricCard.vue";
import BarChart from "@/components/charts/BarChart.vue";
import LineChart from "@/components/charts/LineChart.vue";
import ChartCard from "@/components/ChartCard.vue";
import Table from "@/components/tables/Table.vue";

const themeStore = useThemeStore();

// Data contoh untuk chart
const chartLabels = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'];
const barChartData = [120, 200, 150, 80, 70, 110];
const lineChartData = [100, 180, 130, 90, 60, 140];
</script>

<template>
  <div class="metric-cards-container">
    <MetricCard
      label="Total Revenue"
      value="Rp 12.450.000"
      icon="mdi:currency-usd"
      change-type="percent"
      :change="12.4"
    />

    <MetricCard
      label="Active Users"
      value="1,245"
      icon="mdi:account-group"
      :change="-4.1"
    />
    <MetricCard
      label="New Signups"
      value="320"
      icon="mdi:account-plus"
      change-type="number"
      :change="24"
    />
    <MetricCard
      label="Server Uptime"
      value="95.9%"
      :change="-0.5"
      icon="mdi:server"
    />
  </div>
  <!-- Chart Section -->
  <div class="chart-cards-container">
    <ChartCard title="User Signups" icon="mdi:chart-bar">
      <BarChart :height="320" :labels="chartLabels" :data="barChartData" />
    </ChartCard>
    <ChartCard title="Revenue Over Time" icon="mdi:chart-line">
      <LineChart :height="320" :labels="chartLabels" :data="lineChartData" />
    </ChartCard>
  </div>
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

<style scoped>
.metric-cards-container {
  display: flex;
  flex-grow: 1;
  flex-wrap: wrap;
  gap: 24px;
}

.chart-cards-container {
  display: flex;
  flex-direction: row;
  margin: 24px 0;
  gap: 24px;
}

@media (max-width: 1024px) {
  .chart-cards-container {
    flex-direction: column;
  }
}
</style>