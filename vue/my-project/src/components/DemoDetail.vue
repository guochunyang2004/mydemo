<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2>{{ $route.params.dataId }}</h2>
  </div>
</template>

<script>
export default {
  name: 'DemoDetail',
  data () {
    return {
      msg: 'DemoDetail'
    }
  }
}
</script>