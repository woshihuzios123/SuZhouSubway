function exportQrCodeByUrl(url) {
    //首先在页面创建一个隐藏div
    var qr = new QRious({
        value: url
    });
    download(qr.toDataURL("image/jpeg"));

}


//下载图片
function download(src) {
    downloadFile("qrCode.png", src);
    clearTimeout();
}

//下载
function downloadFile(fileName, content) {
    var aLink = document.createElement('a');
    var blob = this.base64ToBlob(content); //new Blob([content]);

    var evt = document.createEvent("HTMLEvents");
    evt.initEvent("click", true, true); //initEvent 不加后两个参数在FF下会报错  事件类型，是否冒泡，是否阻止浏览器的默认行为
    aLink.download = fileName;
    aLink.href = URL.createObjectURL(blob);

    // aLink.dispatchEvent(evt);
    //aLink.click()
    aLink.dispatchEvent(new MouseEvent('click', { bubbles: true, cancelable: true, view: window })); //兼容火狐
}

//base64转blob
function base64ToBlob(code) {
    var parts = code.split(';base64,');
    var contentType = parts[0].split(':')[1];
    var raw = window.atob(parts[1]);
    var rawLength = raw.length;

    var uInt8Array = new Uint8Array(rawLength);

    for (var i = 0; i < rawLength; ++i) {
        uInt8Array[i] = raw.charCodeAt(i);
    }
    return new Blob([uInt8Array], { type: contentType });
}