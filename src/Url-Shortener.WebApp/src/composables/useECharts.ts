import { useThemeStore } from '@/stores/theme.store'
import { computed } from 'vue'

export function getCssVar(name: string, fallback?: string) 
{
  return getComputedStyle(document.documentElement)
    .getPropertyValue(name)
    .trim() || fallback
}

export function useEChartsTheme() 
{
  const themeStore = useThemeStore()
  const isDark = computed(() => themeStore.theme === 'dark')

  const colors = computed(() => 
  ({
    text: getCssVar('--neutral-600'),
    textMuted: getCssVar('--neutral-500'),
    grid: isDark.value
      ? getCssVar('--neutral-700')
      : getCssVar('--neutral-200'),

    primary: getCssVar('--primary-red-500', '#ef4444'),
    primarySoft: isDark.value
      ? 'rgba(239,68,68,0.5)'
      : 'rgba(239,68,68,0.35)',

    background: isDark.value
      ? getCssVar('--neutral-900')
      : getCssVar('--neutral-50'),
  }))

  return {
    isDark,
    colors,
  }
}
