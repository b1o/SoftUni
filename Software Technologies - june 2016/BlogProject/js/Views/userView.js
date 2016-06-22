define(['Sammy'], function(sammy) {
    function showLoginPage(selector) {
        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);
            $(".register-form").hide();
            $(".login-form").show();
            $('#loginButton').on('click', function() {
                let userName = $('#login-user').val(),
                    password = $('#login-pass').val();

                sammy(function() {
                    this.trigger('login', {username: userName, password: password});
                })
            })
        })
    }

    function showRegisterPage(selector) {
        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);
            $(".login-form").hide();
            $(".register-form").show();
            $("#registerButton").on('click', function() {
                let username = $('#reg-user').val(),
                    password = $('#reg-pass').val(),
                    email = $('#reg-email').val();

                sammy(function() {
                    this.trigger('register', {username: username, password: password, email: email});
                })
            })
        })
    }

    return {
        showLoginPage: showLoginPage,
        showRegisterPage: showRegisterPage
    }
});