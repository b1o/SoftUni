define(["mustache"], function(mustache) {
   function showWelcomeMenu(selector) {
        $.get("templates/welcomeTempl.html", function(templ) {
            $(selector).html(templ);
        })
    }

    function showHomeMenu(selector, data) {
        $.get("templates/homeMenu.html", function(templ) {
            var rendered = mustache.render(templ, data);
            $(selector).html(rendered);
        })
    }

    return {
        showWelcomeMenu: showWelcomeMenu,
        showHomeMenu: showHomeMenu
    }
});
