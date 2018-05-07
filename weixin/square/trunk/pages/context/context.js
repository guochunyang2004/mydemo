// pages/context/context.js
let wxDraw = require("../../utils/wxdraw.min.js").wxDraw;
let Shape = require("../../utils/wxdraw.min.js").Shape;
const M = 15
const N = 10
const borderWidth = 10
let matrix = null
let squareModel = []//存储对象原型的几种情况，
let unitWith = 0
let systemInfo = null
let basePoint = { x: 0, y: 0 }//图形原点坐标
let currentSquare = null
let moveDownSquareTimer;
Page({

  /**
   * 页面的初始数据
   */
  data: {
    wxCanvas: null //    需要创建一个对象来接受wxDraw对象,

  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var context = wx.createCanvasContext('first');//还记得 在wxml里面canvas的id叫first吗
    this.wxCanvas = new wxDraw(context, 0, 0, 400, 500);
    /*var rect = new Shape('rect', 
      { x: 60, y: 60, w: 40, h: 40, fillStyle: "#2FB8AC", rotate: Math.PI / 2 }, 
      'mix', true);
    this.wxCanvas.add(rect);//添加到canvas上面
   
    //rect.animate({ "x": "+=100", "y": "+=100" }, { duration: 1000 })

    // rect.setOrigin([10, 10]);//设置旋转中心为 （100 ，100）
     rect.animate("rotate", Math.PI * 5, { duration: 5000 }).start(3);
    var x=0
    for(var i=0;i<8;i++){
      x=i*40
      let rect2 = rect.clone();
      this.wxCanvas.add(rect2);
      rect2.updateOption({ fillStyle: "#E6324B", x: x, y: 200 });
    }*/
    // rect2.updateOption({ fillStyle: "#E6324B", x: 100, y: 200 });
    this.initSquare()

  },
  bindtouchstart: function (e) {
    // 检测手指点击开始事件
    this.wxCanvas.touchstartDetect(e);

  },
  bindtouchmove: function (e) {
    // 检测手指点击 之后的移动事件
    this.wxCanvas.touchmoveDetect(e);
  },
  bindtouchend: function () {
    //检测手指点击 移出事件
    this.wxCanvas.touchendDetect();
  },
  bindtap: function (e) {
    // 检测tap事件
    this.wxCanvas.tapDetect(e);
  },
  bindlongpress: function (e) {
    // 检测longpress事件
    this.wxCanvas.longpressDetect(e);
  },
  initSquare() {
    this.initDraw();
    this.drawBroder();
    //this.drawsQuare();
    this.initMatrix(M, N);
    this.initSquareModel();
    this.StartNewSquare()
    //console.info(matrix);
  },
  //-----------绘图方法开始-----------------
  initDraw() {
    systemInfo = wx.getSystemInfoSync()
    unitWith = (systemInfo.windowWidth - borderWidth * 2 - 2) / 10
    basePoint.x = borderWidth + unitWith / 2 + 1
    basePoint.y = basePoint.x
  },
  drawBroder() {
    let line = new Shape('line', {
      points: [[borderWidth, borderWidth], [systemInfo.windowWidth - borderWidth, borderWidth],
      [systemInfo.windowWidth - borderWidth, systemInfo.windowHeight - borderWidth],
      [borderWidth, systemInfo.windowHeight - borderWidth], [borderWidth, borderWidth]],
      strokeStyle: "#2FB8AC", lineWidth: 1, rotate: 0, needShadow: false, smooth: false
    },
      'fill', true)
    this.wxCanvas.add(line)
  },
  drawSquareUnit(rowIndex, colIndex) {//画单元格  
    let mx = basePoint.x + unitWith * colIndex
    let my = basePoint.y + unitWith * rowIndex
    let rect = new Shape('rect',
      { x: mx, y: my, w: unitWith, h: unitWith, fillStyle: "#2FB8AC", rotate: Math.PI / 2 },
      'mix', true);
    this.wxCanvas.add(rect)
    return rect
  },
  drawMoveSquareUnit(rect, rowIndex, colIndex) {
    let mx = basePoint.x + unitWith * colIndex
    let my = basePoint.y + unitWith * rowIndex
    rect.updateOption({ x: mx, y: my });
  },
  //--------------矩阵方法开始----------------
  initMatrix(m, n) {
    matrix = []
    for (let i = 0; i < m; i++) {
      matrix[i] = new Array()
      for (let j = 0; j < n; j++) {
        matrix[i][j] = 0
      }
    }
  },
  initSquareModel() {
    squareModel[0] = []
    squareModel[0][0] = [[0, 0], [1, 0], [2, 0], [3, 0]]
    squareModel[0][1] = [[0, 0], [0, 1], [0, 2], [0, 3]]

    squareModel[1] = []
    squareModel[1][0] = [[0, 0], [1, 0], [2, 0], [2, 1]]
    squareModel[1][1] = [[0, 2], [1, 0], [1, 1], [1, 2]]
  },
  createSquare(index, directIndex, moveX, moveY) {
    let square = squareModel[index % squareModel.length][directIndex % (squareModel[index].length)]
    let rowIndex, colIndex
    let rects = []
    for (let i = 0; i < square.length; i++) {
      rowIndex = square[i][0] + moveY
      square[i][0] = rowIndex
      colIndex = square[i][1] + moveX
      square[i][1] = colIndex
      //matrix[rowIndex][colIndex]=1
      rects.push(this.drawSquareUnit(rowIndex, colIndex))
    }
    let squareInfo = { index: index, directIndex: directIndex, square: square, rects: rects }
    return squareInfo;
  },

  StartNewSquare() {
    let rnd = Math.random();//0.0 ~ 1.0
    let index = Math.floor(squareModel.length * rnd)
    rnd = Math.random();//0.0 ~ 1.0
    let directIndex = Math.floor(squareModel[index].length * rnd)
    rnd = Math.random();//0.0 ~ 1.0
    let moveX = Math.floor(N / 4)
    currentSquare = this.createSquare(index, directIndex, moveX, 0)
    moveDownSquareTimer = setInterval(this.moveDownSquare, 1000)

  },

  moveSquare(square, moveX, moveY) {
    let rowIndex, colIndex
    let isStop = false
    for (let i = 0; i < square.length; i++) {
      rowIndex = square[i][0]
      colIndex = square[i][1]
      if (rowIndex + moveY >= M - 1
        || matrix[rowIndex + moveY][colIndex + moveX] > 0) {
        isStop = true//停止下落,       
        break;
      }
    }
    if (isStop) {
      clearInterval(moveDownSquareTimer)
      for (let i = 0; i < square.length; i++) {
        rowIndex = square[i][0]
        colIndex = square[i][1]
        matrix[rowIndex][colIndex] = 1
      }
      setTimeout(this.StartNewSquare, 100)//异步调用
    }
    else {
      for (let i = 0; i < square.length; i++) {
        rowIndex = square[i][0]
        colIndex = square[i][1]
        rowIndex += moveY
        square[i][0] = rowIndex
        colIndex += moveX
        square[i][1] = colIndex
        this.drawMoveSquareUnit(currentSquare.rects[i], rowIndex, colIndex)
      }
    }

  },
  moveDownSquare() {
    if (currentSquare) {
      let square = currentSquare.square
      this.moveSquare(square, 0, 1)
    }
  },
  // 判断arr是否为一个数组，返回一个bool值
  isArray(arr) {
    //return Object.prototype.toString.call(arr) === '[object Array]';
    return arr instanceof Array
  },
  // 深度克隆
  deepClone(obj) {
 
    if (typeof obj !== "object" && typeof obj !== 'function') {
      return obj;        //原始类型直接返回
    }
    var o = obj instanceof Array ? [] : {};
    for (let i in obj) {
      if (obj.hasOwnProperty(i)) {
        o[i] = typeof obj[i] === "object" ? this.deepClone(obj[i]) : obj[i];
      }
    }
    return o;
  }
})