<script setup lang="ts">
import { ref } from 'vue'
import AuthLayout from '@/components/_Layouts/AuthLayout.vue'
import InputField from '@/components/InputField.vue'
import Button from '@/components/Button.vue'
import GoogleButton from '@/components/GoogleButton.vue'

const name = ref('')
const email = ref('')
const password = ref('')
const confirmPassword = ref('')
const loading = ref(false)

function submit() 
{
  loading.value = true
  // TODO: validation + API
  setTimeout(() => {
    loading.value = false
  }, 1000)
}

function registerWithGoogle() 
{
  console.log('Register with Google')
}
</script>

<template>
  <AuthLayout
    title="Create an account"
    subtitle="Start using MyApp today"
  >
    <form class="auth-form" @submit.prevent="submit">
      <InputField
        v-model="name"
        label="Full name"
        placeholder="John Doe"
        required
      />

      <InputField
        v-model="email"
        label="Email"
        type="email"
        placeholder="you@example.com"
        required
      />

      <InputField
        v-model="password"
        label="Password"
        type="password"
        required
      />

      <InputField
        v-model="confirmPassword"
        label="Confirm password"
        type="password"
        required
      />

      <Button class="submit-button"
        type="submit"
        :loading="loading"
      >
        Create account
      </Button>
    </form>

    <div class="auth-divider">
      <span>or</span>
    </div>

    <GoogleButton 
      text="Sign Up with Google"
      @click="registerWithGoogle" />

    <p class="auth-footer">
      Already have an account?
      <RouterLink to="/login">Sign in</RouterLink>
    </p>
  </AuthLayout>
</template>

<style scoped> 
.auth-form {
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.submit-button {
  margin-top: 20px;
}

.auth-divider {
  display: flex;
  align-items: center;
  gap: 12px;
  margin: 20px 0;
  color: var(--neutral-400);
}

.auth-divider::before,
.auth-divider::after {
  content: '';
  flex: 1;
  height: 1px;
  background-color: var(--neutral-200);
}

.dark .auth-divider::before,
.dark .auth-divider::after {
  background-color: var(--neutral-700);
}

.auth-footer {
  margin-top: 20px;
  font-size: 14px;
  text-align: center;
}

.auth-footer a {
  color: var(--primary-red-400);
  font-weight: 600;
}
</style>