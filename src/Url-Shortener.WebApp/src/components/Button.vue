<script setup lang="ts">
import { computed } from 'vue'
import { Icon } from '@iconify/vue'

type ButtonVariant = 'primary' | 'outline' | 'ghost' | 'neutral'
type ButtonSize = 'sm' | 'md' | 'lg'

interface Props {
  variant?: ButtonVariant
  size?: ButtonSize
  type?: 'button' | 'submit' | 'reset'
  leadingIcon?: string
  trailingIcon?: string
  disabled?: boolean
  active?: boolean
}

const props = withDefaults(
  defineProps<Props>(), 
{
  variant: 'primary',
  size: 'md',
  type: 'button',
  disabled: false,
  active: false,
})

const classes = computed(() => 
[
  'ui-button',
  `ui-button--${props.variant}`,
  `ui-button--${props.size}`,
  { 'is-active': props.active },
])

</script>

<template>
  <button
    :type="type"
    :disabled="disabled"
    :class="classes"
  >
    <Icon v-if="leadingIcon"
      class="ui-button__icon"
      :icon="leadingIcon"
      :inline="true"
    />

    <span v-if="$slots.default" 
      class="ui-button__content">
      <slot />
    </span>

    <Icon v-if="trailingIcon"
      class="ui-button__icon"
      :icon="trailingIcon"
      :inline="true"
    />
  </button>
</template>

<style scoped>
/* =====================================================
 * BASE
 * ===================================================== 
 */
.ui-button {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  min-width: fit-content;

  border-radius: var(--border-radius-1);
  font-size: var(--btn-font-size);
  font-family: var(--font-family-main);
  font-weight: 500;
  cursor: pointer;

  transition: background-color 0.15s ease,
              box-shadow 0.15s ease,
              color 0.15s ease;
}

.ui-button:disabled {
  pointer-events: none;
  cursor: not-allowed;
}

/* =====================================================
 * SIZE
 * ===================================================== 
 */
.ui-button--sm {
  gap: 4px;
  height: 32px;
  padding: 6px 8px;
  --btn-font-size: 14px;
  --btn-icon-size: 18px;
}

.ui-button--md {
  gap: 6px;
  height: 40px;
  padding: 8px 12px;
  --btn-font-size: 16px;
  --btn-icon-size: 20px;
}

.ui-button--lg {
  gap: 8px;
  height: 48px;
  padding: 12px 16px;
  --btn-font-size: 18px;
  --btn-icon-size: 24px;
}

.ui-button__icon {
  align-self: center;
  justify-self: center;
  width: var(--btn-icon-size);
  height: var(--btn-icon-size);
}

/* =====================================================
 * VARIANT: PRIMARY
 * ===================================================== 
 */
.ui-button--primary {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
  border: none;
  border-bottom: 2px solid var(--primary-red-700);
}

.ui-button--primary:hover {
  background-color: var(--primary-red-600);
}

.ui-button--primary:active {
  background-color: var(--primary-red-600);
  box-shadow: inset 0 4px 4px var(--primary-red-800);
}

.ui-button--primary:disabled {
  background-color: var(--primary-red-300);
  border-bottom: none;
}

.ui-button--primary:focus-visible {
  outline: 2px solid var(--primary-red-400);
}

/* =====================================================
 * VARIANT: OUTLINE
 * ===================================================== 
 */
.ui-button--outline {
  background-color: transparent;
  color: var(--primary-red-500);
  border: 1px solid var(--primary-red-500);
}

.ui-button--outline.is-active {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.ui-button--outline:hover {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.ui-button--outline:active {
  background-color: var(--primary-red-600);
  box-shadow: inset 0 4px 4px var(--primary-red-800);
}

.ui-button--outline:disabled {
  border-color: var(--neutral-300);
  color: var(--neutral-400);
}

.ui-button--outline:focus-visible {
  outline: 2px solid var(--primary-red-500);
}

/* =====================================================
 * VARIANT: GHOST
 * ===================================================== 
 */
.ui-button--ghost {
  background-color: transparent;
  color: var(--neutral-800);
  border: none;
}

.ui-button--ghost.is-active {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
  border: none;
  border-bottom: 2px solid var(--primary-red-700);
}

.ui-button--ghost:hover {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.ui-button--ghost:active {
  background-color: var(--primary-red-600);
  box-shadow: inset 0 4px 4px var(--primary-red-800);
}

.ui-button--ghost:disabled {
  color: var(--neutral-400);
}

.ui-button--ghost:focus-visible {
  outline: 2px solid var(--primary-red-500);
}

/* =====================================================
 * VARIANT: NEUTRAL
 * ===================================================== 
 */
.ui-button--neutral {
  background-color: var(--neutral-200);
  color: var(--neutral-600);
  border: none;
  border-bottom: 1px solid var(--neutral-300);
}

.ui-button--neutral:hover {
  background-color: var(--neutral-300);
}

.ui-button--neutral:active {
  background-color: var(--neutral-300);
  box-shadow: inset 0 4px 4px var(--neutral-400);
}

.ui-button--neutral:disabled {
  background-color: var(--neutral-300);
  color: var(--neutral-200);
  border-bottom: none;
}

.ui-button--neutral:focus-visible {
  outline: 2px solid var(--neutral-500);
}

/* =====================================================
 * DARK MODE
 * ===================================================== 
 */

.dark .ui-button--primary:disabled {
  background-color: var(--primary-red-800);
  color: var(--neutral-400);
}

.dark .ui-button--outline.is-active {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.dark .ui-button--outline:hover {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.dark .ui-button--ghost {
  background-color: transparent;
  color: var(--neutral-100);
  border: none;
}

.dark .ui-button--ghost.is-active {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
  border-bottom: 2px solid var(--primary-red-700);
}

.dark .ui-button--ghost:hover {
  background-color: var(--primary-red-500);
  color: var(--neutral-100);
}

.dark .ui-button--ghost:disabled {
  color: var(--neutral-400);
}

.dark .ui-button--neutral {
  background-color: var(--neutral-700);
  color: var(--neutral-200);
  border-bottom: 1px solid var(--neutral-800);
}

.dark .ui-button--neutral:active {
  box-shadow: inset 0 4px 4px var(--neutral-800);
}
</style>
