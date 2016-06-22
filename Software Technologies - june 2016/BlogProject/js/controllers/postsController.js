define(["Sammy"], function(Sammy) {
   function PostsController(view, model) {
       this.view = view;
       this.model = model;
   }

    PostsController.prototype.loadRecentPosts = function(selector) {
        let postsData = [];
        let self = this;
        this.model.getCurrentUserPosts().then(function(success) {
            for(let i = 0; i < success.length; i++) {
                postsData.push({'title': success[i].author, 'date':success[i].postedOn, 'content': success[i].content, cols: 12/success.length, _id: success[i]._id})
            }
        }).done(function() {
            self.view.showRecentPosts(selector, postsData);
            console.log(postsData);
        });
    };

    PostsController.prototype.loadAddPostModal = function() {
        this.model.showAddPostModal();
    };

    PostsController.prototype.addPost = function(data) {
        this.model.addPost(data)
            .done(function(success) {

                Sammy(function() {
                    this.trigger('redurectUrl', {url: '#/posts/'})
                })
            });

        $(function() {
            $("#postModal").modal('toggle');
        })
    };

    PostsController.prototype.loadDeletePostModal = function() {
        this.view.showDeletePostModal();
    };

    PostsController.prototype.deletePost = function(post) {
        this.model.deletePost(post);
    };

    return PostsController;
});