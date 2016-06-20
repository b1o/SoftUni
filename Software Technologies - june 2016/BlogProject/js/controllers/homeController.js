define([], function() {
    function HomeController(view) {
        this.view = view;
    }

    HomeController.prototype.loadWelcomeMenu = function(selector) {
        this.view.showWelcomeMenu(selector);
    };

    HomeController.prototype.loadHomeMenu = function(selector) {
        var data = {
            username: sessionStorage['username']
        };

        this.view.showHomeMenu(selector, data);
    };

    return HomeController;
});