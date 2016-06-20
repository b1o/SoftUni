(function () {
    require.config({
        paths: {
            'user' : "models/userModel",
            'userController' : 'controllers/userController',
            'userView' : "Views/userView",
            'homeController' : 'controllers/homeController',
            'homeView' : "Views/homeView",
            'jquery' : "libs/jquery.min",
            'Sammy' : "libs/sammy",
            'requester' : "helpers/requester",
            'q' : 'libs/q',
            'mustache' : 'libs/mustache.min'
        }
    })
}());

require(['user', 'userController', 'userView', 'homeController', 'homeView', 'Sammy', 'requester'], function(user, userController, userView, homeController, homeView, Sammy, requester) {
    let router = Sammy(function () {
        let selector = '#container';
        let a = new requester('kid_r152w4Vr', '2dccbef31d9646aca1f7e7045591bf6c', 'https://baas.kinvey.com/');
        let User = new user(a);
        let UserController = new userController(userView, User);
        let HomeController = new homeController(homeView);


        this.before({except:{path:'#\/(login\/|register\/)?'}}, function() {
            if(!sessionStorage['sessionId']) {
                this.redirect('#/');
                return false;
            }
        });

        this.before(function() {
            if(!sessionStorage['sessionId']) {
                //$('#menu').hide();
            } else {
                //$('#welcomeMenu').text('Welcome, ' + sessionStorage['fullName']);
                //$('#menu').show();
            }
        });

        this.get('#/', function() {
            HomeController.loadWelcomeMenu('#menu');
        });

        this.get('#/home/', function() {
            HomeController.loadHomeMenu('#menu');
        });

        this.get('#/register/', function() {
            UserController.loadRegisterPage(selector);
        });

        this.get('#/login/', function() {
            UserController.loadLoginPage(selector);
        });

        this.bind('redirectUrl', function(ev, data) {
            this.redirect(data.url);
        });

        this.bind('register', function(ev, data) {
            UserController.register(data);
        });

        this.bind('login', function(ev, data) {
            UserController.login(data);
        });
    });
    router.run('#/');
});


