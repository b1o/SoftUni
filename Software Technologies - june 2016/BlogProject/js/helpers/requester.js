define(['q'], function(q) {
    function Requester(appId, appSecret, baseUrl) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = baseUrl;
    }

    Requester.prototype.get = function (url, useSession) {
        var headers = getHeaders.call(this, false, useSession);
        return makeRequest('GET', url, headers, null);
    };

    Requester.prototype.post = function (url, data, useSession) {
        var headers = getHeaders.call(this, data, useSession);
        return makeRequest('POST', url, headers, data);
    };

    Requester.prototype.put = function (url, data, useSession) {
        var headers = getHeaders.call(this, data, useSession);
        return makeRequest('PUT', url, headers, data);
    };

    Requester.prototype.delete = function (url, useSession) {
        var headers = getHeaders.call(this, false, useSession);
        return makeRequest('DELETE', url, headers, null);
    };

    function makeRequest(method, url, headers, data) {
        var defer = q.defer();

        $.ajax({
            method: method,
            url: url,
            headers: headers,
            data: JSON.stringify(data) || null,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                let errorMessage = "Something went wrong";
                if (error.status == "401") {
                    errorMessage = "Wrong username or password!"
                } else if (error.status == "400") {
                    errorMessage = "Please make sure you've entered both username and passoword"
                } else if (error.status == "409") {
                    errorMessage = "Such user already exists!"
                }

                let n = noty({
                    text: errorMessage,
                    animation: {
                        open: "animated bounceInUp",
                        close: "animated bounceOutDown"
                    },
                    closeWith: [],
                    timeout:2000
                });
                defer.reject(error);
            }
        });

        return defer.promise;
    }

    function getHeaders(isJSON, useSession) {
        var headers = {},
            token;

        if (isJSON) {
            headers['Content-Type'] = 'application/json';
        }

        if (useSession) {
            token = sessionStorage['sessionId'];
            headers['Authorization'] = 'Kinvey ' + token;
        } else {
            token = this.appId + ':' + this.appSecret;
            headers['Authorization'] = 'Basic ' + btoa(token);
        }

        return headers;
    }

    return Requester;
});
