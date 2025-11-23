import { defineStore } from 'pinia';
import { ref } from 'vue';

// Simple authentication store to manage auth token
export const useAuthStore = defineStore('auth', () =>
{
  const token = ref<string>(localStorage.getItem('auth_token') || '');
  const setToken = (newToken: string) =>
  {
    token.value = newToken;
    localStorage.setItem('auth_token', newToken);
  };
  const logout = () =>
  {
    token.value = '';
    localStorage.removeItem('auth_token');
  };

  return { token, setToken, logout };
});
