<template>
  <li> {{ todo.id +","+ todo.text }}
    <button v-on:click="$emit('remove')">Remove</button>
  </li>
</template>

<script>
export default {
  name: 'todo-item',
  props: {
    todo: Object
  }
}
</script>
