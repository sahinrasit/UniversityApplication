$(document).ready(function () {
    if (GlobalFunc.userInfo().permDecision) {
        $(function () {

            $('#evaluationProgram').DataTable({
                "ajax": {
                    "type": "GET",
                    "url": '/AcademicProgram/GetEvaluationApplication',
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
                    { data: "id" },
                    { data: "username" },
                    { data: "programName" },
                    { data: "applicationDate" },
                    { data: "statusName" },
                    {
                        data: 'id',
                        "render": function (data, type, full, meta) {
                            return '<button class="btn btn-success"  onclick="applyOk(' + full.id + ')" data="' + full.id + '""><i class="fa fa-plus" aria-hidden="true"></i></button>'
                                + '<button class="btn btn-danger"  onclick="applyNotOk(' + full.id + ')" data="' + full.id + '""><i class="fa fa-ban" aria-hidden="true"></i></button>';

                        }
                    }
                ],
            });
        });
    }
    else {
        alert("Başvuruları Sonuçlandırma Yetkiniz Yok");
        setTimeout(function () {
            window.location.href = "/Home/Index";
        }, 100);
    }


});
function applyOk(id) {
    $.ajax({
        url: "/AcademicProgram/CheckApplications",
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify({
            id: parseInt(id),
            status: 4,
        }),
        success: function (response) {
            alert("Kontrol Ok Onaylandı");
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
};
function applyNotOk(id) {
    $.ajax({
        url: "/AcademicProgram/CheckApplications",
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify({
            "id": id,
            "status": 5,
        }),
        success: function (response) {
            alert("Kontrol Ok Reddedildi");
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
};
