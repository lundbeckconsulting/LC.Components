function handleBeforeRequest(e) {

};

function handleHeadersReceived(e) {

};

function handleCompleted(e) {

};

browser.webRequest.onBeforeRequest.addListener(handleBeforeRequest);
browser.webRequest.onHeadersReceived.addListener(handleHeadersReceived);
browser.webRequest.onCompleted.addListener(handleCompleted);
