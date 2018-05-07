
var v = new Vue({
    el: "#container",
    data: {
        username: userContainer.__username,
        blanace: 0,
        company: '',
        datalist: null,
        pagesize: 20,
        datacount: 0,
        pagecount: 0,
        pages: [],
        searchkey: '',
        searchval: '',
        edituser: {
            loginname: '',
            pwd: '',
            confirmpwd:'',
            companyname: '',
            nickname: '',
            mobile: '',
            id: 0,
            uid: '',
            status:0,
        }
    },
    methods: {
        init: function () {
            var self = this;
            self.page(1);
        },
        page: function (idx) {
            var self = this;
            $.post("/api/users/list", {
                pageidx: idx,
                pagesize: self.pagesize,
                searchkey: self.searchkey,
                searchval: self.searchval
            }, function (data) {
                self.datalist = data.d.l;
                self.datacount = data.d.t || 0;
                self.pagecount = parseInt(self.datacount / self.pagesize) + ((self.datacount % self.pagesize) > 0 ? 1 : 0);
                self.pages = [];
                for (var pagei = idx - 5; pagei <= self.pagecount; pagei++) {
                    if (pagei <= 0)
                        continue;
                    self.pages.push(pagei);
                }
            }, "json");
        },
        edit: function () {
            var self = this;
            for (var i = 0; i < self.datalist; i++) {
                if (self.datalist[i].checked) {
                    self.edituser.id = self.datalist[i].id;
                    break;
                }
            }
            $.post("/api/users/update", self.edituser, function (data) {
                alert(data.m);
                self.page(1);
            }, "json");
        },
        insert: function () {
            var self = this;
            $.post("/api/users/create", self.edituser, function (data) {
                alert(data.m);
                self.page(1);
            }, "json");
        },
        bindedit: function () {
            var self = this;
            for (var i = 0; i < self.datalist.length; i++) {
                if (self.datalist[i].checked) {
                    self.edituser.loginname = self.datalist[i].LoginName;
                    self.edituser.id = self.datalist[i].Id;
                    self.edituser.companyname = self.datalist[i].CompanyName;
                    self.edituser.nickname = self.datalist[i].NIckName;
                    self.edituser.mobile = self.datalist[i].Mobile;
                    self.edituser.uid = self.datalist[i].UId;
                    self.edituser.status = self.datalist[i].Status;
                    console.log(self.edituser);
                    break;
                }
            }
        },
        initPwd: function () {
            var ids = [];
            var self = this;
            ids = self.datalist.map(md => {
                if (md.checked) {
                    return md.Id;
                }
                return 0;
            });
            $.post("/api/users/initpwd", { ids: ids }, (d) => {
                alert(d.m);
            }).error((err) => {
                alert(err.responseBody.m);
                });
        }
    },
    mounted: function () {
        var self = this;
        var timer = setInterval(function () {
            if (self.username == "" || !self.username) {
                self.username = $.trim(userContainer.__username);
                self.blanace = userContainer.__blanace || 0;
                self.company = userContainer.__company;
            }
        }, 2000);
        self.init();
    }
});