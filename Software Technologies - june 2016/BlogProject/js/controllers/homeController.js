define([], function(    ) {
    function HomeController(view) {
        this.view = view;
    }

    HomeController.prototype.loadRegisterMenu = function(selector) {
        this.view.showRegisterMenu(selector);
    };

    HomeController.prototype.loadWelcomeMessage = function(selector) {
        this.view.showWelcomeMessage(selector);
    };

    HomeController.prototype.loadLoginMenu = function(selector) {
        this.view.showLoginMenu(selector);
    };

    HomeController.prototype.loadHomeMenu = function(selector) {
        let data = {
            username: sessionStorage['username']
        };

        this.view.showHomeMenu(selector, data);
    };

    return HomeController;
});