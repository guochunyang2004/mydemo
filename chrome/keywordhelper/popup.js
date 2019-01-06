
function sayHello(){
	var message = document.createTextNode("Hello World!");
	var out = document.createElement("div");
	out.appendChild(message);
	document.body.appendChild(out);
}

$(function () {
	sayHello();
    $("#btnClick").click(function () {	
		console.log("ccc");
		chrome.tabs.getSelected(null, function (tab) {　　// 先获取当前页面的tabID
		alert("aa");
			console.log("getSelected");
			chrome.tabs.sendMessage(tab.id, {action: "copy"},0, function(response) {
					alert(response);
					console.log(response);　　// 向content-script.js发送请求信息
				});
		});
     
    });
});
