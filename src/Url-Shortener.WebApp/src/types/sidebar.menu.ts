// sidebar.menu.ts
export interface SidebarMenuItem {
  label: string
  icon?: string
  to?: string
  children?: SidebarMenuItem[]
  disabled?: boolean
}

export const sidebarMenu: SidebarMenuItem[] = 
[
  {
    label: 'Dashboard',
    icon: 'mdi:view-dashboard',
    to: '/app/dashboard',
  },
  {
    label: 'Users',
    icon: 'mdi:account-group',
    to: '/users',
  },
  {
    label: 'Settings',
    icon: 'mdi:cog',
    to: '/settings',
  },
]
