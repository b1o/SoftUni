define(['Sammy'], function(sammy) {
    function showLoginPage(selector) {
        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);
            $('#loginButton').on('click', function() {
                let userName = $('#username').val(),
                    password = $('#password').val();

                sammy(function() {
                    this.trigger('login', {username: userName, password: password});
                })
            })
        })
    }

    function showRegisterPage(selector) {
        $.get('templates/register.html', function(templ) {
            $(selector).html(templ);
            $("#registerButton").on('click', function() {
                let username = $('#username').val(),
                    password = $('#password').val();

                sammy(function() {
                    this.trigger('register', {username: username, password: password});
                })
            })
        })
    }

    return {
        showLoginPage: showLoginPage,
        showRegisterPage: showRegisterPage
    }
});