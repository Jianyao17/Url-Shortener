<script setup lang="ts">
import * as echarts from 'echarts/core'
import VChart from 'vue-echarts'
import { computed } from 'vue'
import { useEChartsTheme } from '@/composables/useECharts'
import type { AxisTickConfig } from '@/types/charts';
import type { EChartsOption } from '@/types/echarts';
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
const lineColor = computed(() => props.accentColor ?? colors.value.primary)

const option = computed<EChartsOption>(() => 
({
  tooltip: {
    trigger: 'axis',
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
    boundaryGap: false,
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
      padding: [0, 0, 4, 0],
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
      type: 'line',
      name: props.yAxisName ?? 'Value',
      data: props.data,
      smooth: true,
      showSymbol: false,

      lineStyle: {
        width: 3,
        color: lineColor.value,
      },

      areaStyle: {
        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, 
        [
          { offset: 0, color: lineColor.value + '55' },
          { offset: 1, color: 'rgba(0,0,0,0)' },
        ]),
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
