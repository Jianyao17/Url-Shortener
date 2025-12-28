<template>
  <div class="chart-skeleton">
    <div class="chart-skeleton__shimmer" />
  </div>
</template>

<style scoped>
.chart-skeleton {
  width: 100%;
  min-height: 240px;
  border-radius: var(--border-radius-2);
  background-color: var(--neutral-100);
  overflow: hidden;
  position: relative;
}

.dark .chart-skeleton {
  background-color: var(--neutral-800);
}

.chart-skeleton__shimmer {
  position: absolute;
  inset: 0;
  background: linear-gradient(
    90deg,
    transparent,
    rgba(255, 255, 255, 0.8),
    transparent
  );
  animation: shimmer 1.2s infinite;
}

.dark .chart-skeleton__shimmer {
  background: linear-gradient(
    90deg,
    transparent,
    rgba(255, 255, 255, 0.08),
    transparent
  );
}

@keyframes shimmer {
  0% { transform: translateX(-100%); }
  100% { transform: translateX(100%); }
}
</style>
