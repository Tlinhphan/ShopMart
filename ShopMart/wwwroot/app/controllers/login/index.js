var loginController = function () {
    this.initialize = function () {

        registerEvents();

    }

    var registerEvents = function () {
        $('#btnLogin').on('click', function (e) {
            debugger;
            e.preventDefault();
            var user = $('#txtUserName').val();
            var password = $('#txtPassword').val();
            login(user, password);
        });
    }

    var login = function (user, pass) {
        $.ajax({
            type: "POST",
            data: {
                UserName: user,
                Password: pass,
            },

            dateType: "json",
            url: '/admin/login/authen',
            success: function (res) {
                debugger;
                if (res.Success) {
                    window.location.href = "/Admin/Home/Index";
                }
                else {
                    shopmart.notify('Đăng nhập không đúng', 'eror');
                }
            }
        })
    }
}