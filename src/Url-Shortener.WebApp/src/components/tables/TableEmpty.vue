<template>
  <tr>
    <td class="ui-table-empty" :colspan="100">
      <slot>
        Tidak ada data
      </slot>
    </td>
  </tr>
</template>

<style scoped>
.ui-table-empty {
  text-align: center;
  padding: 24px;
  color: var(--neutral-500);
}
</style>
