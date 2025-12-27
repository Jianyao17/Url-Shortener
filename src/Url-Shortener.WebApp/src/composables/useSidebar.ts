import { ref, computed, watch } from 'vue'
import { useBreakpoints, breakpointsTailwind, useStorage } from '@vueuse/core'

export function useSidebar() 
{
  const breakpoints = useBreakpoints(breakpointsTailwind)

  const isMobile = breakpoints.smaller('md') // < 768px
  const isDesktopSmall = breakpoints.between('md', 'lg') // 768 - 1024
  const persistedCollapsed = useStorage<boolean>('sidebar:collapsed', false)

  const isCollapsed = ref(false)
  const isOpen = ref(true)

  // auto collapse
  watch(isDesktopSmall, (val) => 
  {
    if (val) isCollapsed.value = true
    else isCollapsed.value = persistedCollapsed.value
  }, { immediate: true })

  // mobile logic
  watch(isMobile, (val) => 
  {
    if (val) {
      isOpen.value = false
      isCollapsed.value = false
    }
  }, { immediate: true })

  // persist collapsed state
  watch(isCollapsed, (val) => 
  {
    if (!isMobile.value) {
      persistedCollapsed.value = val
    }
  })

  const sidebarWidth = computed(() => 
  {
    if (isMobile.value) return 0
    return isCollapsed.value ? 80 : 260
  })

  return {
    isMobile,
    isCollapsed,
    isOpen,
    sidebarWidth,
    toggleCollapse: () => (isCollapsed.value = !isCollapsed.value),
    open: () => (isOpen.value = true),
    close: () => (isOpen.value = false),
  }
}
