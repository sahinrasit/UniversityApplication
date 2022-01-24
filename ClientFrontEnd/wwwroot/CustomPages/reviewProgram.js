$(document).ready(function () {
    if (GlobalFunc.userInfo().permControl) {
        $(function () {

            $('#reviewProgram').DataTable({
                "ajax": {
                    "type": "GET",
                    "url": '/AcademicProgram/GetApplyApplication',
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
                "columnDefs": [
                    {
                        "targets": '_all',
                        "render": $.fn.dataTable.render.text()
                    }
                ],
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
                                +'<button class="btn btn-danger"  onclick="applyNotOk(' + full.id + ')" data="' + full.id + '""><i class="fa fa-ban" aria-hidden="true"></i></button>';

                        }
                    }
                ],
            });
        });
    }
    else {
        alert("Başvuruları Değerlendirme Yetkiniz Yok");
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
            status: "2",
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
            "status": 3,
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
