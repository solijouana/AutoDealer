function DeleteOption(id) {
    $.get("/Admin/Option_Category/DeleteOption/" + id,
        function(res) {
            if (res.status === "Done") {
                location.reload();
            } else {
                alert("Not Found");
            }
        });
}