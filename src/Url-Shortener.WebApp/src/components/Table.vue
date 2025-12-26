<script setup lang="ts">
import { Icon } from '@iconify/vue';
import TableBody from './tables/TableBody.vue';
import TableCell from './tables/TableCell.vue';
import TableHead from './tables/TableHead.vue';
import TableRoot from './tables/TableRoot.vue';
import TableRow from './tables/TableRow.vue';


const users = [
  { id: 1, name: 'Alice Johnson', email: 'alice@email.com' },
  { id: 2, name: 'Bob Smith', email: 'bob@email.com' },
  { id: 3, name: 'Charlie Brown', email: 'charlie@email.com' },
  { id: 4, name: 'Diana Prince', email: 'diana@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
  { id: 5, name: 'Ethan Hunt', email: 'ethan@email.com' },
]

const log = (msg: string) => {
  console.log(msg);
}
</script>

<template>
  <TableRoot striped hover>
    <TableHead>
      <TableRow>
        <TableCell as="th">Name</TableCell>
        <TableCell as="th">Email</TableCell>
        <TableCell as="th" align="right">Action</TableCell>
      </TableRow>
    </TableHead>

    <TableBody>
      <TableRow v-for="user in users" :key="user.id" selectable>
        <TableCell>{{ user.name }}</TableCell>
        <TableCell>{{ user.email }}</TableCell>
        <TableCell align="right">
          <Icon
            icon="mdi:pencil"
            style="cursor: pointer;"
          />
        </TableCell>
      </TableRow>

    </TableBody>
  </TableRoot>
</template>

<style scoped>
  
</style>