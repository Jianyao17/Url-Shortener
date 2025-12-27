<script setup lang="ts">
import { ref } from 'vue'
import { Icon } from '@iconify/vue'
import AuthLayout from '@/components/_Layouts/AuthLayout.vue'
import InputField from '@/components/InputField.vue'
import Button from '@/components/Button.vue'
import GoogleButton from '@/components/GoogleButton.vue'

const email = ref('')
const password = ref('')
const loading = ref(false)

function submit() 
{
  loading.value = true
  // TODO: call API
  setTimeout(() => {
    loading.value = false
  }, 1000)
}

function loginWithGoogle() 
{
  // TODO: integrate Google OAuth
  console.log('Login with Google')
}
</script>

<template>
  <AuthLayout
    title="Welcome back"
    subtitle="Sign in to your account"
  >
    <form class="auth-form" @submit.prevent="submit">
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
        placeholder="••••••••"
        required
      />

      <Button class="submit-button"
        type="submit"
        :loading="loading"
        block
      >
        Sign in
      </Button>
    </form>

    <div class="auth-divider">
      <span>or</span>
    </div>

    <GoogleButton @click="loginWithGoogle" />

    <p class="auth-footer">
      Don’t have an account?
      <RouterLink to="/register">Create one</RouterLink>
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
