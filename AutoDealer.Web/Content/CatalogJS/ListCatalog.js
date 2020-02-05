var data = {
    ManufacturerId: parseInt($("#ManufacturerId").val()),
    ModelId: parseInt($("#ModelId").val()),
    TakeEntity: parseInt($("#TakeEntity").val())
};

$.get("/List/ListCatalog/", data).done(function (res) {
    $("#listCar").html(res);
});

