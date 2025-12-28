<script setup lang="ts">
import VChart from 'vue-echarts'
import { computed } from 'vue'
import { useEChartsTheme } from '@/composables/useECharts'
import type { EChartsOption } from '@/types/echarts';
import type { AxisTickConfig } from '@/types/charts';
import SkeletonChart from './SkeletonChart.vue';

const props = defineProps<{
  loading?: boolean
  height?: number
  labels: string[] | number[]
  data: number[]
  accentColor?: string
  yAxisTick?: AxisTickConfig
  yAxisName?: string
}>()

const { colors } = useEChartsTheme()
const barColor = computed(() => props.accentColor ?? colors.value.primary)

const option = computed<EChartsOption>(() => 
({
  tooltip: {
    trigger: 'axis',
    axisPointer: { 
      type: 'shadow',
    },
  },

  grid: {
    left: 12,
    right: 12,
    top: 24,
    bottom: 16,
    containLabel: true,
  },

  xAxis: {
    type: 'category',
    data: props.labels,
    axisLine: { show: false },
    axisTick: { show: false },
    axisLabel: {
      color: colors.value.textMuted,
    },
  },

  yAxis: {
    type: 'value',
    name: props.yAxisName,
    nameTextStyle: {
      color: colors.value.textMuted,
    },
    min: props.yAxisTick?.min,
    max: props.yAxisTick?.max,
    interval: props.yAxisTick?.interval,
    axisLabel: {
      color: colors.value.textMuted,
      formatter: props.yAxisTick?.formatter,
    },
    axisLine: { show: false },
    axisTick: { show: false },
    splitLine: {
      lineStyle: {
        color: colors.value.grid,
        type: 'dashed',
      },
    },
  },

  series: [
    {
      name: props.yAxisName ?? 'Value',
      type: 'bar',
      data: props.data,
      barWidth: '40%',
      itemStyle: {
        color: barColor.value,
        borderRadius: 4,
      },
    },
  ],
}))
</script>

<template>
  <SkeletonChart 
    v-if="loading" 
    :style="{ height: height + 'px' }"
  />
  <VChart
    v-else
    class="chart"
    :style="{ height: height + 'px' }"
    :option="option"
    autoresize
  />
</template>

<style scoped>
.chart {
  width: 100%;
  height: 100%;
  min-height: 240px;
}
</style>
