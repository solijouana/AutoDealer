function DeleteSinger(singerId) {
    $.get("/Admin/Singer/Delete/" + singerId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });

};

function ReturnSinger(singerId) {
    $.get("/Admin/Singer/Return/" + singerId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });
};