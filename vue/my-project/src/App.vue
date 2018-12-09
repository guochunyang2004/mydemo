<template>
  <div id="app">
    <el-container>
      <el-header>
         <!-- 使用 router-link 组件来导航. -->
        <!-- 通过传入 `to` 属性指定链接. -->
        <!-- <router-link> 默认会被渲染成一个 `<a>` 标签 -->
        <el-row :gutter="20">
          <el-col :span="6">
            <div class="grid-content bg-purple">
              <router-link to="/">Home</router-link>
            </div>
          </el-col>
          <el-col :span="6">
            <div class="grid-content bg-purple">
              <router-link to="/Demo/100/200">Demo</router-link>
            </div>
          </el-col>
          <el-col :span="6">
            <div class="grid-content bg-purple">
              <router-link to="/Demo/detail">Demo</router-link>
            </div>
          </el-col>
          <el-col :span="6">
            <div class="grid-content bg-purple">
              <router-link to="/HelloWorld">Hello</router-link>
            </div>
          </el-col>
        </el-row>
       
      </el-header>
      <el-main>
        <router-view/>
      </el-main>
 
      <el-footer>
        <el-menu
          :default-active="activeIndex"
          class="el-menu-demo"
          mode="horizontal"
          :router="true"
          @select="handleSelect"
          background-color="#545c64"
          text-color="#fff"
          active-text-color="#ffd04b"
        >
          <el-menu-item index="/" >首页</el-menu-item>
          <el-menu-item index="/Demo/100/200" >Demo</el-menu-item>
          <el-menu-item index="/Demo/detail" >detail</el-menu-item>
          <el-menu-item index="/HelloWorld" >Hello</el-menu-item>
        </el-menu>
      </el-footer>
    </el-container>
  </div>
</template>

<script>
export default {
  name: "App",
  data(){
    return {
      activeIndex: '1'
    }
  },
  computed: {
    username() {
      // 我们很快就会看到 `params` 是什么
      return this.$route.params.username;
    }
  },
  methods: {
    goBack() {
      window.history.length > 1 ? this.$router.go(-1) : this.$router.push("/");
    },
    handleSelect(key, keyPath) {
        console.log(key, keyPath);
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.el-menu-demo{
  width: 100%;
}
.el-row {
  margin-bottom: 20px;
 
}
.el-row:last-child {
    margin-bottom: 0;
}
.el-col {
  border-radius: 4px;
}
.bg-purple-dark {
  background: #99a9bf;
}
.bg-purple {
  background: #d3dce6;
}
.bg-purple-light {
  background: #e5e9f2;
}
.grid-content {
  border-radius: 4px;
  min-height: 36px;
}
.row-bg {
  padding: 10px 0;
  background-color: #f9fafc;
}

/* ----container begin------- */
.el-header,
.el-footer {
  /* background-color: #b3c0d1; */
  color: #333;
  text-align: center;
  line-height: 60px;
}

.el-aside {
  /* background-color: #d3dce6; */
  color: #333;
  text-align: center;
  line-height: 200px;
}

.el-main {
  /* background-color: #e9eef3; */
  color: #333;
  text-align: center;
  line-height: 160px;
}

body > .el-container {
  margin-bottom: 40px;
}

.el-container:nth-child(5) .el-aside,
.el-container:nth-child(6) .el-aside {
  line-height: 260px;
}

.el-container:nth-child(7) .el-aside {
  line-height: 320px;
}
/* ------container end----------- */
</style>
