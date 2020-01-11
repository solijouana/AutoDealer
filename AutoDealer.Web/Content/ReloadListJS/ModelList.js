function GetCity(_stateId) {

    var procemessage = "<option value='0'> Please wait...</option>";
    $("#ddlModel").html(procemessage).show();
    var url = "/Advertise/ReloadModelList/";

    $.ajax({
        url: url,
        data: { stateid: _stateId },
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