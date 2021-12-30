$(document).ready(function () {
    debugger;
    if (GlobalFunc.userInfo().permApply) {
        $(function () {

            $('#applyProgram').DataTable({
                "ajax": {
                    "type": "GET",
                    "url": '/AcademicProgram/GetProgramList',
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
                    { data: "programName" },
                    { data: "faculty" },
                    { data: "branch" },
                    { data: "term" },
                    {
                        data: 'id',
                        "render": function (data, type, full, meta) {
                            return '<button class="btn btn-success" id="deleteMember" onclick="applyProgramBtn(' + full.id + ')" data="' + full.id + '""><i class="fa fa-plus" aria-hidden="true"></i></button >';

                        }
                    }
                ],
            });
        });
    }
    else {
        alert("Programa Başvuramazsınzız Yetkiniz Yok");
        setTimeout(function () {
            window.location.href="/Home/Index";
        }, 100);
    }
   
 
});
function applyProgramBtn(programId) {
    $.ajax({
        url: "/AcademicProgram/ProgramApply",
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify({
            "userName": GlobalFunc.userInfo().userName,
            "programId": programId,
        }),
        success: function (response) {
            alert("Programa Başarıyla Başvuruldu");
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