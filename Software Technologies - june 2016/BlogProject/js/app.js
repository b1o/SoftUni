(function () {
    require.config({
        paths: {
            'user' : "models/userModel",
            'userController' : 'controllers/userController',
            'userView' : "Views/userView",
            'homeController' : 'controllers/homeController',
            'homeView' : "Views/homeView",
            'PostModel': "models/postsModel",
            'postsView' : "Views/postsView",
            'postsController' : 'controllers/postsController',
            'jquery' : "libs/jquery.min",
            'Sammy' : "libs/sammy",
            'requester' : "helpers/requester",
            'q' : 'libs/q',
            'mustache' : 'libs/mustache.min'
        }
    })
}());

require(['user', 'userController', 'userView', 'homeController', 'homeView', 'Sammy', 'requester', "PostModel", "postsView", "postsController"],
    function(user, userController, userView, homeController, homeView, Sammy, requester, postModel, postsView, postsController) {
    let router = Sammy(function () {
        let selector = '#container';
        let requster = new requester('kid_r152w4Vr', '2dccbef31d9646aca1f7e7045591bf6c', 'https://baas.kinvey.com/');
        let User = new user(requster);

        let postsModel = new postModel(requster);
        let postController = new postsController(postsView, postsModel);

        let UserController = new userController(userView, User);
        let HomeController = new homeController(homeView);


        this.before({except:{path:'#\/(login\/|register\/)?'}}, function() {
            if(!sessionStorage['sessionId']) {
                this.trigger('redirectUrl', {url: '#/'});
                return false;
            }
        });

        this.before(function() {
            if(sessionStorage['sessionId']) {
                HomeController.loadHomeMenu("#navbar")
            } else {
                HomeController.loadLoginMenu("#navbar")
            }
        });

        this.get('#/', function() {
            HomeController.loadWelcomeMessage("#header");
        });

        this.get('#/posts/', function() {
           postController.loadRecentPosts("#recent-posts");
        });

        this.get('#/logout/', function() {
            UserController.logout();
        });

        this.get('#/register/', function() {
            if(!sessionStorage['sessionId']) {
                HomeController.loadRegisterMenu("#navbar");
            } else {
                this.redirect('#/');
            }
        });

        this.get('#/addPosts/', function() {
            postController.loadAddPostModal();
        });

        this.get('#/post/delete/:id?/', function(context) {
            //postController.loadDeletePostModal({_id: context.params.id});
        });

        this.get('#/login/', function() {
            HomeController.loadLoginMenu("#navbar")
        });

        this.bind('redirectUrl', function(ev, data) {
            this.redirect(data.url);
        });

        this.bind('register', function(ev, data) {
            UserController.register(data);
        });

        this.bind('deletePost', function(ev, data) {
            //postController.showDeletePostModal();
            console.log(data);
        });

        this.bind('addPost', function(ev, data) {
            postController.addPost(data);
        });

        this.bind('login', function(ev, data) {
            UserController.login(data);
        });
    });
        $("#submit-btn").on('click', function() {
            let title = $("#title").val(),
                content = $("#content").val(),
                author = sessionStorage['username'],
                userId = sessionStorage['userId'],
                isPrivate = $("#isPrivate").val();
            console.log("asdasd");

            Sammy(function() {
                this.trigger('addPost', {title: title, content: content, author: author, userId: userId, isPrivate: isPrivate, postedOn: new Date(), })
            })
        });
    router.run('#/');

});


