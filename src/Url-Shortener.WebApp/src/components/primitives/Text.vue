<script setup lang="ts">
type Variant = 'body' | 'label' | 'caption' | 'error'

interface Props {
  as?: string
  variant?: Variant
}

withDefaults(
  defineProps<Props>(), 
{
  as: 'span',
  variant: 'body',
})
</script>

<template>
  <component
    :is="as"
    :class="['ui-text', `ui-text--${variant}`]"
  >
    <slot />
  </component>
</template>

<style scoped>
.ui-text--body {
  font-size: 16px;
  color: var(--neutral-800);
}

.ui-text--label {
  font-size: 16px;
  font-weight: 500;
}

.ui-text--caption {
  font-size: 14px;
}

.ui-text--error {
  font-size: 14px;
  color: var(--danger-500);
}
</style>
