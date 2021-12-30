$(document).ready(function () {
    $("#btnLogin").click(function (e) {
        //GlobalFunc.eraseCookie("UserInfo");
        $.ajax({
            url: "/AcademicProgram/Login",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify({
                "userName": $("#username").val(),
                "password": $("#password").val()
            }),
            success: function (response) {
                $('#modal-successLogin').modal('show');
                console.log(response);
                GlobalFunc.setCookie("UserInfo", JSON.stringify(response), 2);

                setTimeout(function () {
                    window.location.href = '/Home/Index';
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
