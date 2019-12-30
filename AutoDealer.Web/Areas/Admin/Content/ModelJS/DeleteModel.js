function DeleteModel(id) {
    $.get("/Admin/Manufacturers/DeleteModel/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("Not Found");
            }
        });
}

function DeleteSubModel(id) {
    $.get("/Admin/Manufacturers/DeleteSubModel/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("Not Found");
            }
        });
}

