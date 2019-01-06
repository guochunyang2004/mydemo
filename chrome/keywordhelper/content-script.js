//监听消息
chrome.extension.onMessage.addListener(
    function (request, sender, sendResponse) {
		console.info("bb");
        if (request.action === "copy") {
    //收到copy信息，开始获取当前页面id为sb_form_q的值
            var ctrl = $("#kw");
            if (ctrl.length > 0) {
            // 如果获取的值不为空则返回数据到popup.js的回调函数
                if (sendResponse) sendResponse("xxx");
            } else {
                alert("No data");
            }
        }
		 sendResponse({"data":"xxx"});
		 return true;
    }
);

chrome.runtime.onMessage.addListener(
  function (request, sender,  sendResponse) {
        if (request.action === "copy") {
    //收到copy信息，开始获取当前页面id为sb_form_q的值
            var ctrl = $("#kw");
            if (ctrl.length > 0) {
            // 如果获取的值不为空则返回数据到popup.js的回调函数
                if (sendResponse) sendResponse({"data":"xxx"});
            } else {
                alert("No data");
            }
        }
		 sendResponse({"data":"xxx"});
		chrome.tabs.executeScript(
          {code: 'document.body.style.backgroundColor="orange"'});
		};
		return true;
    }
});
