
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

function Search() {
    var data = {
        manufacturerId: $("#ddlmanufacture").val(),
        modelId: $("#ddlModel").val(),
        FromPrice: $("#ddlFrom").val(),
        ToPrice: $("#ddlTo").val(),
        FromYear: $("#txtFromYear").val(),
        ToYear:$("#txtToYear").val(),
        TakeEntity:$("#TakeEntity").val()
    };

    $.get("/List/ListCatalog/", data).done(function (res) {
        $("#ManufacturerId").val(data.manufacturerId);
        $("#ModelId").val(data.modelId);
        $("#listCar").html(res);
    });
}