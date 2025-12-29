<script setup lang="ts">
import { computed } from 'vue'
import { Icon } from '@iconify/vue'

type Trend = 'up' | 'down' | 'neutral'
type ChangeType = 'percent' | 'number'


const props = defineProps<{
  label: string
  value: string | number
  change?: number
  changeType?: ChangeType
  icon?: string
  trend?: Trend
  loading?: boolean
}>()

const resolvedTrend = computed<Trend>(() => 
{
  if (props.trend) return props.trend
  if (props.change == null) return 'neutral'
  return props.change >= 0 ? 'up' : 'down'
})

const trendIcon = computed(() => 
{
  if (resolvedTrend.value === 'up') return 'mdi:arrow-up'
  if (resolvedTrend.value === 'down') return 'mdi:arrow-down'
  return 'mdi:minus'
})

const trendClass = computed(() => `is-${resolvedTrend.value}`)
const formattedChange = computed(() => 
{
  if (props.change == null) return ''

  const value = Math.abs(props.change)
  const sign =
    resolvedTrend.value === 'up'
      ? '+'
      : resolvedTrend.value === 'down'
      ? '−'
      : ''

  return props.changeType === 'number'
    ? `${sign}${value}`
    : `${sign}${value}%`
})

</script>

<template>
  <Transition name="fade-slide-up" :appear="true">
    <div
      class="ui-stat-card"
      :class="{ skeleton: loading }"
    >
      <!-- HEADER (tetap tampil) -->
      <div class="ui-stat-card__header animate-row-1">
        <Icon
          v-if="icon"
          :icon="icon"
          :inline="true"
          class="metric-icon"
        />
        <span class="label">{{ label }}</span>
      </div>

      <!-- VALUE -->
      <div class="ui-stat-card__value animate-row-2">
        <span v-if="!loading">
          {{ value }}
        </span>
        <span
          v-else
          class="skeleton skeleton-value"
        />
      </div>

      <!-- FOOTER / CHANGE -->
      <div
        v-if="change !== undefined"
        class="ui-stat-card__trend animate-row-3"
        :class="trendClass"
      >
        <template v-if="!loading">
          <Icon
            :icon="trendIcon"
            class="trend-icon"
          />
          <span class="trend-value">
            {{ formattedChange }}
          </span>
          <span class="trend-label">
            vs last period
          </span>
        </template>

        <template v-else>
          <span class="skeleton skeleton-change" />
        </template>
      </div>
    </div>
  </Transition>
</template>


<style scoped>
/* =====================================================
 * ANIMATION
 * ===================================================== 
 */
.fade-slide-up-enter-active, .fade-slide-up-leave-active {
  transition: opacity 0.4s cubic-bezier(.4,0,.2,1), transform 0.4s cubic-bezier(.4,0,.2,1);
}
.fade-slide-up-enter-from, .fade-slide-up-leave-to {
  opacity: 0;
  transform: translateY(24px);
}
.fade-slide-up-enter-to, .fade-slide-up-leave-from {
  opacity: 1;
  transform: translateY(0);
}

/* Staggered animation for rows */
.animate-row-1 {
  animation: fade-in-up 0.5s ease-out forwards;
}
.animate-row-2 {
  animation: fade-in-up 0.5s ease-out 0.1s forwards;
  opacity: 0;
}
.animate-row-3 {
  animation: fade-in-up 0.5s ease-out 0.2s forwards;
  opacity: 0;
}

@keyframes fade-in-up {
  from {
    opacity: 0;
    transform: translateY(16px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

/* =====================================================
 * SKELETON
 * ===================================================== 
 */
.skeleton {
  position: relative;
  overflow: hidden;
  background-color: var(--neutral-200);
  border-radius: 6px;
}

.skeleton::after {
  content: '';
  position: absolute;
  inset: 0;
  transform: translateX(-100%);
  background: linear-gradient(
    90deg,
    transparent,
    rgba(255,255,255,0.5),
    transparent
  );
  animation: skeleton-shimmer 1.4s infinite;
}

@keyframes skeleton-shimmer {
  100% {
    transform: translateX(100%);
  }
}

/* VALUE skeleton */
.skeleton-value {
  display: inline-block;
  width: 120px;
  height: 36px;
}

/* CHANGE skeleton */
.skeleton-change {
  display: inline-block;
  width: 80px;
  height: 14px;
}

/* Dark mode */
.dark .skeleton {
  background-color: var(--neutral-700);
}

.dark .skeleton::after {
  background: linear-gradient(
    90deg,
    transparent,
    rgba(255,255,255,0.15),
    transparent
  );
}


/* =====================================================
 * BASE
 * ===================================================== 
 */
.ui-stat-card {
  display: flex;
  flex-grow: 1;
  flex-direction: column;
  gap: 12px;

  padding: 16px;
  border-radius: var(--border-radius-2);

  background-color: var(--neutral-0);
  border: 1px solid var(--neutral-200);
  
  cursor: pointer;
  transition:
    background-color 0.15s ease,
    box-shadow 0.15s ease,
    transform 0.2s ease;
}

.ui-stat-card:hover {
  box-shadow: var(--shadow-red-soft);
  transform: translateY(-1%);
  scale: 1.002;
}

.ui-stat-card.skeleton:hover {
  box-shadow: none;
  transform: none;
  scale: 1;
}

/* =====================================================
 * HEADER
 * ===================================================== 
 */
.ui-stat-card__header {
  display: flex;
  align-items: center;
  justify-content: start;
  color: var(--neutral-600);
  gap: 8px;
}

.ui-stat-card:hover .ui-stat-card__header {
  color: var(--neutral-800);
}

.label {
  font-size: 14px;
  font-weight: 500;
}

.metric-icon {
  width: 20px;
  height: 20px;
}

/* =====================================================
 * VALUE
 * ===================================================== 
 */
.ui-stat-card__value {
  font-size: 32px;
  font-weight: 700;
  color: var(--neutral-800);
  line-height: 1.2;
}

/* =====================================================
 * TREND
 * ===================================================== 
 */
.ui-stat-card__trend {
  display: inline-flex;
  align-items: center;
  gap: 6px;

  font-size: 13px;
  font-weight: 500;
}

.trend-icon {
  width: 16px;
  height: 16px;
}

/* UP */
.ui-stat-card__trend.is-up {
  color: var(--success-600, #16a34a);
}

/* DOWN */
.ui-stat-card__trend.is-down {
  color: var(--danger-600, #dc2626);
}

/* NEUTRAL */
.ui-stat-card__trend.is-neutral {
  color: var(--neutral-500);
}

.trend-label {
  font-weight: 400;
  color: inherit;
  opacity: 0.7;
}

/* =====================================================
 * DARK MODE
 * ===================================================== 
 */
.dark .ui-stat-card {
  background-color: var(--neutral-900);
  border-color: var(--neutral-700);
}

.dark .ui-stat-card__value {
  color: var(--neutral-100);
}

.dark .ui-stat-card__header {
  color: var(--neutral-300);
}

.dark .ui-stat-card:hover .ui-stat-card__header {
  color: var(--neutral-200);
}

/* UP */
.dark .ui-stat-card__trend.is-up {
  color: var(--success-500, #16a34a);
}

/* DOWN */
.dark .ui-stat-card__trend.is-down {
  color: var(--danger-500, #dc2626);
}

/* NEUTRAL */
.dark .ui-stat-card__trend.is-neutral {
  color: var(--neutral-500);
}
</style>
