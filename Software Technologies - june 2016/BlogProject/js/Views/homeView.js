define(["mustache", "Sammy"], function(mustache, Sammy) {
    function showHomeMenu(selector) {
        $.get("templates/home-nav-menu.html", function(templ) {
            $(selector).html(templ);
        });
    }

    function showRegisterMenu(selector) {
        $.get("templates/register.html", function(templ) {
            $(selector).html(templ);
            $("#navbar #action-btn").on('click', function() {
                let username = $("#username").val(),
                    password = $("#password").val(),
                    email = $("#email").val();
                Sammy(function() {
                    this.trigger('register', {username:username, password:password, email: email})
                })
            })
        })
    }

    function showLoginMenu(selector) {
        $.get("templates/login.html", function(templ) {
            $(selector).html(templ);
            $("#navbar #action-btn").on('click', function() {
                let username = $("#username").val(),
                    password = $("#password").val();
                Sammy(function() {
                    this.trigger('login', {username: username, password: password});
                });
            })
        });
    }

    function showWelcomeMessage(selector) {
        $.get("templates/welcome.html", function(templ) {
            $(selector).html(templ)
        });
    }

    return {
        showRegisterMenu: showRegisterMenu,
        showLoginMenu: showLoginMenu,
        showHomeMenu: showHomeMenu,
        showWelcomeMessage: showWelcomeMessage
    }
});
