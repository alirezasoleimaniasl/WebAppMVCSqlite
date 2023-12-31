﻿$(function () {
    $("#AddRow").click(function () {
        if ($("#PublisherName").length == 0)
            $("#myTable tr:first").after("<tr><td><input id='PublisherName' type='text' class='form-control' data-toggle='tooltip' data-placement='bottom' title='وارد نمودن نام ناشر الزامی است.' placeholder='نام ناشر را وارد کنید ...'/></td><td class='text-center'><a class='btn btn-success btn-sm text-white' onclick='Insert()'>افزودن</a> <a class='btn btn-danger btn-sm text-white' onclick='Cancel()'>انصراف</a> </td></tr>")
    });

});

function Insert() {
    var obj = {};
    var PublisherName = $("#PublisherName").val();
    obj.PublisherName = PublisherName;
    if (PublisherName == "")
        $("#PublisherName").tooltip('show');
    else {
        $.ajax({
            url: "/Admin/Publishers/Index/@Model.CurrentPage?handler=Insert",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(obj),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
                $("body").preloader();
            },
            success: function (response) {
                BindData(response.publishers, response.totalPage, response.currentPage);
            },

            complete: function () { $("body").preloader('remove'); },

            failure: function (response) {
                alert(response);
            }
        })
    }

}

function BindData(tableData, totalPage, currentPage) {
    var tbody = $("#myTable tbody");
    var pagination = $(".pagination");
    tbody.empty();
    pagination.empty();
    if (currentPage > 1)
        pagination.append('<li class="page-item"><a class= "page-link" href = "/Admin/Publishers/' + parseInt(currentPage - 1) + '" >«</a></li>')

    for (var i = 1; i <= totalPage; i++) {
        var activeClass = "";
        if (i == currentPage)
            activeClass = "active";

        var htmlLi = ['<li class="page-item ', activeClass, '">', '<a class="page-link" href="/Admin/Publishers/ ', i, '">', i, '</a>', '</li>'];
        pagination.append(htmlLi.join(''));
    }

    if (currentPage < totalPage)
        pagination.append('<li class="page-item"><a class= "page-link" href = "/Admin/Publishers/' + parseInt(currentPage + 1) + '" >»</a></li>')

    $('thead tr:nth-child(2)').remove();

    var JsonArray = JSON.parse(tableData);
    for (var i = 0; i < JsonArray.length; i++) {
        var htmlRow = ['<tr>', '<td>', JsonArray[i]["PublisherName"], '</td>', '<td class="text-center"> <a asp-page="./Edit" asp-route-id="' + JsonArray[i]["PublisherID"] + '" class="btn btn-success btn-icon text-white"><i class="fa fa-edit"></i></a> <button type="submit" asp-route-id="' + JsonArray[i]["PublisherID"] + '" asp-page-handler="Delete" class="btn btn-danger btn-icon"><i class="fa fa-trash"></i></button></td>', '</tr>'];
        tbody.append(htmlRow.join(''));
    }
}

function Cancel() {
    $("#myTable thead tr:nth-child(2)").remove();
}