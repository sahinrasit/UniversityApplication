$(document).ready(function () {
    if (GlobalFunc.userInfo().permControl) {
        $(function () {
            $('#userListTbl').DataTable({
                "ajax": {
                    "type": "GET",
                    "url": '/AcademicProgram/ListUser',
                    "contentType": 'application/json; charset=utf-8',
                    'data': function (data) {

                        return data = JSON.stringify(data);
                    },
                    "failure": function (response) {
                        alert("Yetkiniz Yok!!!");
                    },
                    "error": function (response) {
                        alert("Yetkiniz Yok!!!");
                    }
                },
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false,
                "responsive": true,
                columns: [
                    { data: "userName" },
                    { data: "name" },
                    { data: "family" },
                    {
                        data: 'permApply',
                        "render": function (data, type, full, meta) {
                            if (full.permApply)
                                return '<span class="bg-green"> Yetki Var </span>';
                            return '<span class="bg-red">  Yetki Yok </span>';
                        }
                    },
                    {
                        data: 'permControl',
                        "render": function (data, type, full, meta) {
                            if (full.permControl)
                                return '<span class="bg-green"> Yetki Var </span>';
                            return '<span class="bg-red"> Yetki Yok </span>';
                        }
                    },
                    {
                        data: 'permDecision',
                        "render": function (data, type, full, meta) {
                            if (full.permDecision)
                                return '<span class="bg-green"> Yetki Var </span>';
                            return '<span class="bg-red">Yetki Yok</span>';
                        }
                    },
                    {
                        data: 'permAdmin',
                        "render": function (data, type, full, meta) {
                            if (full.permAdmin)
                                return '<span class="bg-green"> Yetki Var </span>';
                            return '<span class="bg-red">Yetki Yok</span>';
                        }
                    },
                    {
                        data: 'userName',
                        "render": function (data, type, full, meta) {
                            return '<button class="btn btn-success"  onclick="updateUserShowModal(\'' + full.userName + '\')"><i class="fa fa-plus" aria-hidden="true"></i></button>';

                        }
                    }
                ],
            });
        });
    }
    else {
        alert("Yetkiniz Yok!!!");
        setTimeout(function () {
            window.location.href = "/Home/Index";
        }, 100);
    }
    $("#btnUpdateUser").click(function () {

        updateUser($("#UserNameTxt").val());

    });

});


function updateUserShowModal(userName) {
    $("#UserNameTxt").val(userName);
    $.ajax({
        url: "/AcademicProgram/GetUser?userName=" + userName,
        type: "POST",
        contentType: 'application/json',
       
        success: function (response) {
            var user = JSON.parse(response);
            var _permApply=0;
            var _permControl=0;
            var _permDecision= 0;
            var _permAdmin = 0;
            if (user[0].permApply)
                _permApply = 1
            if (user[0].permControl)
                _permControl = 1;
            if (user[0].permDecision)
                _permDecision = 1;
            if (user[0].permAdmin)
                _permAdmin = 1;
            $("#userNameText").html("<strong>"+userName+"</strong>" +" Bilgilerini Güncelleyebilirsiniz");
            $("#name").val(user[0].name);
            $("#family").val(user[0].family);
            $("#permApply").val(_permApply).change();
            $("#permControl").val(_permControl).change();
            $("#permDecision").val(_permDecision).change();
            $("#permAdmin").val(_permAdmin).change();
        },
        failure: function (response) {
            alert("Hata Oluştu");
        },
        error: function (response) {
            alert("Hata Oluştu");
        }
    });
    $("#updateUserModal").modal("show");
    
};
function updateUser(userName) {
    var _permApply = false;
    var _permControl = false;
    var _permDecision = false;
    var _permAdmin = false;
    if ($("#permApply option:selected").val() == "1")
        _permApply = true;
    if ($("#permControl option:selected").val() == "1")
        _permControl = true;
    if ($("#permDecision option:selected").val() == "1")
        _permDecision = true;
    if ($("#permAdmin option:selected").val() == "1")
        _permAdmin = true;
    $.ajax({
        url: "/AcademicProgram/UpdateUser",
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify({
            "userName": userName,
            "name": $("#name").val(),
            "family": $("#family").val(),
            "permApply": _permApply,
            "permControl": _permControl,
            "permDecision": _permDecision,
            "permAdmin": _permAdmin

        }),
        success: function (response) {
            alert("Kullanıcı Bilgileri Güncellendi");
            setTimeout(function () {
                window.location.reload();
            }, 100);
        },
        failure: function (response) {
            alert("Hata Oluştu");
        },
        error: function (response) {
            alert("Hata Oluştu");
        }
    });
}