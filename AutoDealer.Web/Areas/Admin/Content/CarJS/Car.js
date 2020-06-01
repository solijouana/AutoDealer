function Paging(pageId) {

    $("#PageId").val(pageId);
    $("#filter-search").submit();

}

function changeEntity(takeEntity) {

    $.get("/Admin/Advertise/ListAdvertise?takeEntity=" + takeEntity, function (res) {

        $("#list").html(res);
    });

}

function DeleteAdv(id) {
    $.get("/Admin/Advertise/DeleteAdv/" + id,
        function(res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function ReturnAdv(id) {
    $.get("/Admin/Advertise/ReturnAdv/" + id,
        function(res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function ActiveAdv(id) {
    $.get("/Admin/Advertise/ActiveAdv/" + id,
        function(res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function DeActiveAdv(id) {
    $.get("/Admin/Advertise/DeActiveAdv/" + id,
        function(res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function Specific(id) {
    $.get("/Admin/Advertise/Specific/" + id,
        function (res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function ReturnSpecific(id) {
    $.get("/Admin/Advertise/ReturnSpecific/" + id,
        function (res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function InSlider(id) {
    $.get("/Admin/Advertise/InSlider/" + id,
        function (res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}

function OutSlider(id) {
    $.get("/Admin/Advertise/OutSlider/" + id,
        function (res) {
            if (res.status === "Done") {
                var take = $("#TakeEntity").val();
                changeEntity(take);
            } else {
                alert(res.status);
            }
        });
}