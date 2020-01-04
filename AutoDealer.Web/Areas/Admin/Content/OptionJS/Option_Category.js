function DeleteCategory(id) {
    $.get("/Admin/option_Category/Delete/" + id,
        function(res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("NotFound");
            }
        });
}

function ReturnCategory(id) {
    $.get("/Admin/option_Category/ReturnCategory/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("NotFound");
            }
        });
}