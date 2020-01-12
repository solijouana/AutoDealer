function GetModel(_manufacturerId) {

    var procemessage = "<option value='0'> Please wait...</option>";
    $("#ddlModel").html(procemessage).show();
    var url = "/Advertise/ReloadModelList/";

    $.ajax({
        url: url,
        data: { manufacturerId: _manufacturerId },
        cache: false,
        type: "POST",
        success: function (data) {

            var markup = "<option value='0'>مدل را انتخاب کنید</option>";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#ddlModel").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function GetSubModel(_modelId) {

    var procemessage = "<option value='0'> Please wait...</option>";
    $("#ddlSubModel").html(procemessage).show();
    var url = "/Advertise/ReloadSubModelList/";

    $.ajax({
        url: url,
        data: { modelId: _modelId },
        cache: false,
        type: "POST",
        success: function (data) {

            var markup = "<option value='0'>زیر مدل را انتخاب کنید</option>";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#ddlSubModel").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}