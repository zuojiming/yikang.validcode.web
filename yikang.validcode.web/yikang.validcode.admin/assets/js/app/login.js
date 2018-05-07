var loginMod = function () {
    this.login = function () {
        $.post("/api/users/login", { loginName: $("#loginName").val(), Pwd: $("#passWord").val() },
            function (data) {
                if (!data.s) {
                    alert(data.m);
                    return;
                }
                location.href = "/index.html";
            }, "json").
            error(function (error) {
                alert(error.responseJSON.m || error.statusText);
            });
    };
}