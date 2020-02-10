
var data = {
    ManufacturerId: parseInt($("#ManufacturerId").val()),
    ModelId: parseInt($("#ModelId").val()),
    TakeEntity: parseInt($("#TakeEntity").val())
};

$.get("/List/ListCatalog/", data).done(function (res) {
    $("#listCar").html(res);
});



function Pagging(pageId) {

    var data = {
        ManufacturerId: parseInt($("#ManufacturerId").val()),
        ModelId: parseInt($("#ModelId").val()),
        TakeEntity: parseInt($("#TakeEntity").val()),
        PageId: pageId
    };
    $.get("/List/ListCatalog/", data).done(function (res) {
        $("#listCar").html(res);
        $("#PageId").val(data.PageId);
    });
}
