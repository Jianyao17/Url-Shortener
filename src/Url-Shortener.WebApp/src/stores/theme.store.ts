import { defineStore } from 'pinia';
import { computed, ref } from 'vue';

type Theme = 'light' | 'dark';

export const useThemeStore = defineStore('theme', () => 
{
  const currentTheme = ref<Theme>('light');
  const theme = computed(() => currentTheme.value);

  const initTheme = () => 
  {
    // First check local storage for a saved theme
    const storedTheme = localStorage.getItem('theme') as Theme | null;
    if (storedTheme)
    { currentTheme.value = storedTheme; }
    else 
    {
      // Then check system preferences
      const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
      currentTheme.value = prefersDark ? 'dark' : 'light';
    }

    // Apply the resolved theme
    setTheme(currentTheme.value);
  };

  const toggleTheme = () => 
  {
    currentTheme.value = currentTheme.value === 'light' ? 'dark' : 'light';
    setTheme(currentTheme.value);
  };

  const setTheme = (theme: Theme) => 
  {
    const html = document.documentElement;

    // Remove the existing theme class
    html.classList.remove('dark');
    
    // Add the dark theme class if it's dark
    if (theme === 'dark')
    { html.classList.add('dark'); }

    localStorage.setItem('theme', theme);
  };

  initTheme();

  return {
    theme,
    toggleTheme,
    setTheme,
  };
});
