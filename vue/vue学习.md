
### 

1. 环境配置
   安装cnpm：  npm install -g cnpm –registry=http://registry.npm.taobao.org 

1. 创建vue项目（2种方法）
    1. 创建一个基于 webpack 模板的新项目
        $ vue init webpack my-project
    2. vue create elementui-demo

2. 运行项目：
    npm run serve


3. 其他
    1.  addEventListener的参数passive？
    2. v-on:keyup.enter 或 @keyup.13
    3. // 可以使用 `v-on:keyup.f1`
        Vue.config.keyCodes.f1 = 112
        @keyup.alt.67="clear"
		
4. 修改启动端口
 "dev": "webpack-dev-server --inline --hot --host 0.0.0.0 --port 8090",