define(["mustache", "Sammy"], function(mustache, Sammy) {
    function showRecentPosts(selector, posts) {
        $.get("templates/recent-post.html", function(templ) {
        $(selector).html("");
            for(let i = 0; i < posts.length; i++) {
                console.log(posts[i]);
                let rendered = mustache.render(templ, posts[i]);
                $(selector).append(rendered);
            }
        })
    }

    function showDeletePostModal(data) {
        $.get("templates/deletePostModal.html", function(templ) {
            let rendered = mustache.render(templ, data);
            $("#postModal").html(rendered);
            $("#confirm-btn").on("click", function() {
                Sammy(function() {
                    this.trigger('deletePost', {id: data._id})
                })
            })
            $("#close").on('click', function() {
                $("#postModal").modal('toggle');
            })
        })
    }
    return {
        showDeletePostModal: showDeletePostModal,
        showRecentPosts: showRecentPosts
    }
});