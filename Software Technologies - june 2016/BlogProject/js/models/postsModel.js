define([], function() {
    function PostModel(requester) {
        this.requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/Posts/';
    }

    PostModel.prototype.getCurrentUserPosts = function() {
        let url = this.serviceUrl + "?query={\"author\":" + "\"" + sessionStorage['username'] + "\"}";
        return this.requester.get(url, true);
    };

    PostModel.prototype.addPost = function(data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    PostModel.prototype.deletePost = function(id) {
        return this.requester.post(this.serviceUrl + "id", null, true)
    };

    return PostModel;
});