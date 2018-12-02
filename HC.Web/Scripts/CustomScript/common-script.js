$(document).ajaxStart(function () {
    $("#progress").modal('show');
});
$(document).ajaxComplete(function () {
    $("#progress").modal('hide');
});

function ajaxRequest(type, url, inputJSON, dataType) {
    var promiseObj = new Promise(function (resolve, reject) {
        $.ajax({
            type: type,
            url: url,
            data: inputJSON,
            contentType: "application/json; charset=utf-8",
            dataType: dataType,
            success: function (responseData) {
                resolve(responseData);
            },
            error: function (xhr, status, error) {
                reject("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
                alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
            }
        });        
    });
    return promiseObj;
}
