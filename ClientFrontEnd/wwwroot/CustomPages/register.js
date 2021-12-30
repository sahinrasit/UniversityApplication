$(document).ready(function () {
    $("#btnRegister").click(function (e) {
        $.ajax({
            url: "/AcademicProgram/Register",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify({
                "userName": $("#username").val(),
                "name": $("#name").val(),
                "family": $("#family").val(),
                "gender": $("#gender").val(),
                "birthDate": $("#birthDate").val(),
                "password": $("#password").val()
            }),
            success: function (response) {
                $('#modal-successLogin').modal('show');
                setTimeout(function () {
                    window.location.href = '/Auth/Login';
                }, 100);
            },
            failure: function (response) {
                $('#modal-wrongPass').modal('show');
            },
            error: function (response) {
                $('#modal-wrongPass').modal('show');
            }
        });
    });
});