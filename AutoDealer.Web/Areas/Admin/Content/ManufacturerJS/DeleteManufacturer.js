function Delete(id) {
    $.get("/Admin/Manufacturers/Delete/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("Not Found");
            }
        });
}

function Return(id) {
    $.get("/Admin/Manufacturers/ReturnManufacturer/" + id,
        function (res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("Not Found");
            }
        });
}