function Paging(pageId) {

    $("#PageId").val(pageId);

    $("#filter-search").submit();
}

function changeEntity(takeEntity) {

    $.get("/Admin/Advertise/ListAdvertise?takeEntity=" + takeEntity, function(res) {
        $("#list").html(res);
    });

}