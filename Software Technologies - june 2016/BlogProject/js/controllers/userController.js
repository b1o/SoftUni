define(["Sammy"], function(Sammy) {
    function UserController(view, model) {
        this.model = model;
        this.view = view;
    }

    UserController.prototype.login = function(data) {
        return this.model.login(data)
            .then(function(success) {
                console.log(success);
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success._id;
            })
            .done(function() {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/'} )
                });
                var n = noty({
                    text: "logged in",
                    animation: {
                        open: "animated bounceInUp",
                        close: "animated bounceOutDown"
                    },
                    closeWith: [],
                    timeout:1200
                })
            });
    };

    UserController.prototype.register = function(data) {
        return this.model.register(data)
            .then(function(success) {
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success._id;


            }).done(function() {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/'})
                });
                $.notify({
                    title: "Logged in",
                    message: "Welcome, " + sessionStorage['username']
                });
            });
    };

    UserController.prototype.logout = function() {
        return this.model.logout()
            .then(function(success) {
                sessionStorage.clear();

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/'})
                })
            })
    };

    return UserController;
});