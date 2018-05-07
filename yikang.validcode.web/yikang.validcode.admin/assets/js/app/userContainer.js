var userContainer = {
    __username: '',
    __loginname: '',
    __blanace: 0,
    __company: '',
    checkLoginFlag: function () {
        var cookiename = ".ASPXAUTH";
        var vals = document.cookie.split(';');
        var checkflag = false;

        for (var i = 0; i < vals.length; i++) {
            var key = $.trim(vals[i].split('=')[0]);
            var value = $.trim(vals[i].split('=')[1]);
            if (key == cookiename) {
                checkflag = true;
            }
            if (key == "__username") {
                userContainer.__username = value;
            } 
            if (key == "__loginname") {
                userContainer.__loginname = value;
            }
            if (key == "__blanace") {
                userContainer.__blanace = value;
            }
            if (key == "__company") {
                userContainer.__company = value;
            }
        }
        if (!checkflag) {
            alert("用户登录过期，请重新登陆！");
            location.href = "/login.html";
        }
    }
};
setInterval(function () {
    userContainer.checkLoginFlag();
}, 2000);

