define(["Sammy"], function(Sammy) {
    function UserController(view, model) {
        this.model = model;
        this.view = view;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        this.view.showLoginPage(selector);
    };

    UserController.prototype.login = function(data) {
        return this.model.login(data)
            .then(function(success) {
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success.userId;

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'})
                });

            }).done();
    };

    UserController.prototype.loadRegisterPage = function(selector) {
        this.view.showRegisterPage(selector);
    };

    UserController.prototype.register = function(data) {
        return this.model.register(data)
            .then(function(success) {
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success.userId;

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'})
                });
            }).done();
    };

    return UserController;
});