$(document).ready(function () {
    $("#addProgramBtn").click(function (e) {
        $.ajax({
            url: "/AcademicProgram/ProgramAdd",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify({
                "programName": $("#programName").val(),
                "faculty": $("#faculty").val(),
                "branch": $("#branch").val(),
                "term": $("#term").val()
            }),
            success: function (response) {
                alert("Program Başarıyla Eklendi");
                setTimeout(function () {
                    window.location.reload();
                }, 100);
            },
            failure: function (response) {
                alert("Yetkiniz Yok!!!");
            },
            error: function (response) {
                alert("Yetkiniz Yok!!!");
            }
        });
    });
    $(function () {
        
        $('#addProgram').DataTable({
            "ajax": {
                "type": "GET",
                "url": '/AcademicProgram/GetProgramList',
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
            columns:[
                { data: "id" },
                { data: "programName" },
                { data: "faculty" },
                { data: "branch" },
                { data: "term" }
            ],
        });
    });
});
