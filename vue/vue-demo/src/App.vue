<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">

    <HelloWorld msg="Welcome to Your Vue.js App" btnTxt="abcd"/>
    <p>
      <label for="new-todo">Add a todo</label>
      <input v-model="newLiText" id="new-todo" placeholder="E.g. Feed the cat" v-on:keyup.ctrl.enter="onAddLi">
      <button v-on:click="onAddLi">Add</button>
    </p>
    <ol>
      <!--
      现在我们为每个 todo-item 提供 todo 对象
      todo 对象是变量，即其内容可以是动态的。
      我们也需要为每个组件提供一个“key”，稍后再
      作详细解释。
      -->
      <todoitem v-for="(item,index) in groceryList" v-bind:todo="item" v-bind:key="item.id" v-on:remove="groceryList.splice(index,1)"></todoitem>
    </ol>
    <p v-html="html" v-on:click="onShow"></p>
    <p>
      <a v-bind:href="link" v-text="linkText"/>
    </p>
    <template v-if="ok">
      <p v-bind:style="[classObject,{fontSize: 20+'px'}]">{{msg}}</p>
      <p>msgLog：{{msgLog}}</p>
    </template>

    <p>
      <button v-on:click="onloginType">{{loginType.text}}</button>
      <br>
      <template v-if="loginType.type === 'username'">
        <label>Username</label>
        <input placeholder="Enter your username" key="username-input">
      </template>
      <template v-else>
        <label>Email</label>
        <input placeholder="Enter your email address" key="email-input">
      </template>
    </p>

    <button id="btnClick" v-on:click="onClick2('点击',$event)">点击</button>
   
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import todoitem from "./components/Todo-item.vue";

export default {
  name: "app",
  components: {
    HelloWorld,
    todoitem
  },
  created: function() {
    // `this` 指向 vm 实例
    console.log("a is: " + this.html);
  },
  data() {
    return {
      newLiText:"",
      groceryList: [
        { id: 0, text: "蔬菜" },
        { id: 1, text: "奶酪" },
        { id: 2, text: "随便其它什么人吃的东西 " },
        { id: 3, text: "随便其它什么人吃的东西 " }
      ],
      ok: true,
      msg: "",
      msgLog: "",
      html:
        "<b>html粗体</b><a v-bind:href='link' v-text=\"linkText\" >测试</a>",
      link: "https://www.baidu.com",
      linkText: "百度",
      classObject: {
        color: "red"
      },
      loginType: { type: "username", text: "用户名登录" }
    };
  },
  methods: {
    onAddLi(){
      this.groceryList.push({
        id:this.groceryList.length,
        text:this.newLiText
      });
      this.newLiText = "";
    },
    onShow() {
      this.msg = "时间：" + CurentTime();
      this.ok = !this.ok;
    },
    onloginType() {
      if (this.loginType.type) this.loginType = { type: "", text: "Email登录" };
      else this.loginType = { type: "username", text: "用户名登录" };
    },
    onClick(event){
      alert(event.target.id)
    },    
    onClick2(txt,event){
      alert(txt)
      alert(event.target.id)
    }
  },
  computed: {
    msgShow: {
      get() {
        //this.msg="time:"+Date.now();
        return this.msg;
      },
      set(value) {
        this.msg = "time:" + CurentTime();
      }
    }
  },
  watch: {
    msg(newValue, oldValue) {
      this.msgLog = oldValue + "," + newValue;
    }
  }
};


function CurentTime() {
  var now = new Date();

  var year = now.getFullYear(); //年
  var month = now.getMonth() + 1; //月
  var day = now.getDate(); //日

  var hh = now.getHours(); //时
  var mm = now.getMinutes(); //分
  var ss = now.getSeconds(); //获取秒
  var clock = year + "-";

  if (month < 10) clock += "0";

  clock += month + "-";

  if (day < 10) clock += "0";

  clock += day + " ";

  if (hh < 10) clock += "0";
  clock += hh + ":";

  if (mm < 10) clock += "0";
  clock += mm + ":";

  if (ss < 10) clock += "0";
  clock += ss;

  return clock;
}
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
</style>
