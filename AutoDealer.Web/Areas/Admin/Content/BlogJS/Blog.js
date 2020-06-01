function DeleteBlog(id) {
    $.get("/Admin/Blog/DeleteBlog/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert(res.status);
            }
        });
}

function ReturnBlog(id) {
    $.get("/Admin/Blog/ReturnBlog/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert(res.status);
            }
        });
}