(function ($) {
    $.fn.menumaker = function (options) {
        var Bar = $(this), settings = $.extend({
            title: "Menu",
            format: "dropdown",
            sticky: false
        }, options);
        return this.each(function () {
            Bar.prepend('<div id="menu-button">' + settings.title + '</div>');
            $(this).find("#menu-button").on('click', function () {
                $(this).toggleClass('menu-opened');
                var mainmenu = $(this).next('ul');
                if (mainmenu.hasClass('open')) {
                    mainmenu.hide().removeClass('open');
                }
                else {
                    mainmenu.show().addClass('open');
                    if (settings.format === "dropdown") {
                        mainmenu.find('ul').show();
                    }
                }
            });
            Bar.find('li ul').parent().addClass('has-sub');
            multiTg = function () {
                Bar.find(".has-sub").prepend('<span class="submenu-button"></span>');
                Bar.find('.submenu-button').on('click', function () {
                    $(this).toggleClass('submenu-opened');
                    if ($(this).siblings('ul').hasClass('open')) {
                        $(this).siblings('ul').removeClass('open').hide();
                    }
                    else {
                        $(this).siblings('ul').addClass('open').show();
                    }
                });
            };
            if (settings.format === 'multitoggle') multiTg();
            else Bar.addClass('dropdown');
            if (settings.sticky === true) Bar.css('position', 'fixed');
            resizeFix = function () {
                if ($(window).width() > 768) {
                    Bar.find('ul').show();
                }
                if ($(window).width() <= 768) {
                    Bar.find('ul').hide().removeClass('open');
                }
            };
            resizeFix();
            return $(window).on('resize', resizeFix);
        });
    };
})(jQuery);
(function ($) {
    $(document).ready(function () {
        $("#Bar").menumaker({
            title: "Menu",
            format: "multitoggle"
        });
    });
})(jQuery);
$(function () {
    $("#PopupCad").dialog({
        autoOpen: false,
        resizable: false,
        width: 380,
        height: 605,
        modal: true
    })
    $("#BtnVizualizar").on('click', function () {
        $("#PopupCad").dialog("open");
    })
});
(function ($) {
    $.fn.fitText = function (kompressor, options) {
        var compressor = kompressor || 1,
            settings = $.extend({
                'minFontSize': Number.NEGATIVE_INFINITY,
                'maxFontSize': Number.POSITIVE_INFINITY
            }, options);
        return this.each(function () {
            var $this = $(this);
            var resizer = function () {
                $this.css('font-size', Math.max(Math.min($this.width() / (compressor * 10), parseFloat(settings.maxFontSize)), parseFloat(settings.minFontSize)));
            };
            resizer();
            $(window).on('resize.fittext orientationchange.fittext', resizer);
        });
    };
})(jQuery);