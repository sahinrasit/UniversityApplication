$(document).ready(function () {
    if (GlobalFunc.userInfo().permApply) {
        $(function () {

            $('#myAppProgram').DataTable({
                "ajax": {
                    "type": "GET",
                    "url": '/AcademicProgram/MyApplicationList',
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
                ],
            });
        });
    }
    else {
        alert("Bu sayfada sadece öğrencilerin başvurduğu programlar gözükür lütfen yan menüden ilerleyiniz.");
    }


});

