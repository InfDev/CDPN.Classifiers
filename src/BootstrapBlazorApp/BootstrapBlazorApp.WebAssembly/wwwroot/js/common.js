
function getBlazorCulture() {
    return window.localStorage['BlazorCulture'];
};
function setBlazorCulture(value) {
    window.localStorage['BlazorCulture'] = value;
};

(function ($) {
    $.blazorCulture = {
        get: () => {
            return window.localStorage['BlazorCulture'];
        },
        set: (value) => {
            window.localStorage['BlazorCulture'] = value;
        }
    };

    $.extend({
        loading: function () {
            var $loader = $("#loading");
            if ($loader.length > 0) {
                $loader.addClass("is-done");
                var handler = window.setTimeout(function () {
                    window.clearTimeout(handler);
                    $loader.remove();
                    $('body').removeClass('overflow-hidden');
                }, 300);
            }
        },
    });
})(jQuery);
