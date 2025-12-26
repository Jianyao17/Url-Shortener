<script setup lang="ts">
import { computed, useSlots } from 'vue'
import { Icon } from '@iconify/vue'

type InputType = 'text' | 'password' | 'email' | 'number' | 'url'

interface Props {
  modelValue?: string | number
  type?: InputType
  label?: string
  placeholder?: string
  leadingIcon?: string
  required?: boolean
  readonly?: boolean
  error?: boolean
  errorMessage?: string
}

const slots = useSlots()
const hasTrailing = computed(() => !!slots.trailing)

const props = withDefaults(
  defineProps<Props>(), 
{
  type: 'text',
  label: '',
  placeholder: '',
  required: false,
  readonly: false,
  disabled: false,
  error: false,
  errorMessage: '',
})


const emit = defineEmits<{
  (e: 'update:modelValue', value: string | number): void
}>()

const inputClasses = computed(() => [
  'ui-input-field',
  {
    'is-error': props.error,
    'is-readonly': props.readonly,
    'has-icon': !!props.leadingIcon,
    'has-trailing': hasTrailing.value,
  },
])

</script>

<template>
  <div class="ui-input-field__wrapper">
    <!-- LABEL -->
    <div v-if="label" class="ui-input-field__label-container">
      <label class="ui-input-field__label">
        {{ label }}
      </label>
      <Icon
        v-if="required"
        class="ui-input-field__required-icon"
        icon="tabler:asterisk"
        width="10"
        height="10"
      />
    </div>

    <!-- INPUT CONTAINER -->
    <div class="ui-input-field__control">
      <Icon
        v-if="leadingIcon"
        class="ui-input-field__leading-icon"
        :icon="leadingIcon"
      />

      <input
        :type="type"
        :placeholder="placeholder"
        :value="modelValue"
        :readonly="readonly"
        :required="required"
        :class="inputClasses"
        @input="emit('update:modelValue', ($event.target as HTMLInputElement).value)"
      />
      <!-- TRAILING SLOT -->
      <div
        v-if="hasTrailing"
        class="ui-input-field__trailing"
      >
        <slot name="trailing" />
      </div>
    </div>

    <!-- ERROR MESSAGE -->
    <p v-if="error && errorMessage" class="ui-input-field__error-message">
      {{ errorMessage }}
    </p>
  </div>
</template>

<style scoped>
/* =====================================================
 * WRAPPER
 * ===================================================== 
 */
.ui-input-field__wrapper {
  display: flex;
  flex-direction: column;
}

/* =====================================================
 * LABEL
 * ===================================================== 
 */
.ui-input-field__label-container {
  display: flex;
  align-items: start;
  margin-bottom: 2px;
  gap: 2px;
}

.ui-input-field__label {
  font-size: 16px;
  font-weight: 500;
  color: var(--neutral-800);
}

.ui-input-field__required-icon {
  width: 12px;
  height: 12px;
  color: var(--danger-500);
}

/* =====================================================
 * CONTROL
 * ===================================================== 
 */
.ui-input-field__control {
  position: relative;
  display: flex;
  align-items: center;
}

/* =====================================================
 * INPUT BASE
 * ===================================================== 
 */
.ui-input-field {
  width: 100%;
  padding: 6px 12px;
  font-size: 16px;
  font-family: var(--font-family-main);

  color: var(--neutral-800);
  background-color: transparent;

  border-radius: var(--border-radius-1);
  border: 1px solid var(--neutral-500);

  transition: border-color 0.15s ease,
              box-shadow 0.15s ease;
}

/* with icon */
.ui-input-field.has-icon {
  padding-left: 40px;
}

/* =====================================================
 * ICON
 * ===================================================== 
 */
.ui-input-field__leading-icon {
  position: absolute;
  left: 12px;
  width: 18px;
  height: 18px;
  color: var(--neutral-500);
  pointer-events: none;
}

/* =====================================================
 * TRAILING SLOT
 * ===================================================== 
 */
.ui-input-field.has-trailing {
  padding-right: 40px;
}

/* trailing container */
.ui-input-field__trailing {
  display: flex;
  position: absolute;
  right: 12px;
  width: 18px;
  height: 18px;
  align-items: center;
  height: 100%;
}

/* =====================================================
 * STATES
 * ===================================================== 
 */
.ui-input-field:focus {
  outline: none;
  border-color: var(--primary-red-500);
  box-shadow: 0 0 0 1px var(--primary-red-500);
}

.ui-input-field.is-error {
  border-color: var(--danger-500);
}

.ui-input-field.is-readonly {
  background-color: var(--neutral-100);
  color: var(--neutral-600);
  cursor: default;
}

.ui-input-field:disabled {
  background-color: var(--neutral-200);
  color: var(--neutral-400);
  cursor: not-allowed;
}

/* =====================================================
 * ERROR MESSAGE
 * ===================================================== 
 */
.ui-input-field__error-message {
  margin-top: 2px;
  font-size: 14px;
  color: var(--danger-500);
}

/* =====================================================
 * DARK MODE
 * ===================================================== 
 */
.dark .ui-input-field__label {
  color: var(--neutral-200);
}

.dark .ui-input-field {
  color: var(--neutral-200);
}

.dark .ui-input-field:focus {
  outline: none;
  border-color: var(--primary-red-400);
  box-shadow: 0 0 0 1px var(--primary-red-400);
}

.dark .ui-input-field.is-readonly {
  background-color: var(--neutral-800);
}

.dark .ui-input-field__leading-icon {
  color: var(--neutral-400);
}
</style>
