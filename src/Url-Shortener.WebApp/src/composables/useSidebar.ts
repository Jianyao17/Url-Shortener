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
    } else {
      // restore persisted state
      isCollapsed.value = persistedCollapsed.value
    }
  }, { immediate: true })

  // set and save collapsed state
  const setCollapsed = (val: boolean) =>
  {
    isCollapsed.value = val
    if (isMobile.value == false)
      persistedCollapsed.value = val
  }

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
    toggleCollapse: () => setCollapsed(!isCollapsed.value),
    open: () => (isOpen.value = true),
    close: () => (isOpen.value = false),
  }
}
