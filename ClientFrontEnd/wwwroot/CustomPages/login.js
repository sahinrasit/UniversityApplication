$(document).ready(function () {
    $("#btnLogin").click(function (e) {
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
                //GlobalFunc.setCookie("X-Access-Token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6InJhc2l0c2FoaW4iLCJQZXJtIjoiQWRtaW4iLCJleHAiOjE2NDA3OTM0MjksImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.vkqYpIODMQWJoXVXes-btm-JzoMYsZwbKEwKm9Y8wB8", 2);

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
