require('./weapp-adapter')
var context = canvas.getContext('2d')
var bg = 'rgba(0,0,0,0.1)'
context.fillStyle = bg
context.fillRect(0, 0, canvas.width, canvas.height)

context.fillStyle = 'green'
context.fillRect(100, 0, 100, 100)


var offScreenCanvas = wx.createCanvas()
var offContext = offScreenCanvas.getContext('2d')
offContext.fillStyle = 'blue'
offContext.fillRect(0, 0, 50, 50)


var x=0
var y=0
var movX=10
var movY = 10
//move()
//move()
setInterval(move,500,)
function move(){

  moveObj()
}
function moveObj(){  
  clearObj()
  x=x+movX
  y = y + movY
  if (x+50>canvas.width)
    x=0
  else if (x<0)
    x=0
  if (y + 50 > canvas.height)
    y = 0
  else if (y<0)
    y=0
  offContext.fillStyle = 'blue'
  offContext.fillRect(0, 0, 50, 50)
  context.drawImage(offScreenCanvas, x, y)
}
function clearObj(){
  context.clearRect(x, y, 50, 50)
}
