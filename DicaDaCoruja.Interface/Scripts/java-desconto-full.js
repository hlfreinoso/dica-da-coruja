﻿(function ($) {

    var pluginName = "carousel",
        initSelector = "." + pluginName,
        transitionAttr = "data-transition",
        transitioningClass = pluginName + "-transitioning",
        itemClass = pluginName + "-item",
        activeClass = pluginName + "-active",
        inClass = pluginName + "-in",
        outClass = pluginName + "-out",
        navClass = pluginName + "-nav",
        cssTransitionsSupport = (function () {
            var prefixes = "webkit Moz O Ms".split(" "),
                supported = false,
                property;

            while (prefixes.length) {
                property = prefixes.shift() + "Transition";

                if (property in document.documentElement.style !== undefined && property in document.documentElement.style !== false) {
                    supported = true;
                    break;
                }
            }
            return supported;
        }()),
        methods = {
            _create: function () {
                $(this)
                    .trigger("beforecreate." + pluginName)
                [pluginName]("_init")
                [pluginName]("_addNextPrev")
                    .trigger("create." + pluginName);
            },

            _init: function () {
                var trans = $(this).attr(transitionAttr);

                if (!trans) {
                    cssTransitionsSupport = false;
                }

                return $(this)
                    .addClass(
                    pluginName +
                    " " + (trans ? pluginName + "-" + trans : "") + " "
                    )
                    .children()
                    .addClass(itemClass)
                    .first()
                    .addClass(activeClass);
            },

            next: function () {
                $(this)[pluginName]("goTo", "+1");
            },

            prev: function () {
                $(this)[pluginName]("goTo", "-1");
            },

            goTo: function (num) {

                var $self = $(this),
                    trans = $self.attr(transitionAttr),
                    reverseClass = " " + pluginName + "-" + trans + "-reverse";

                // clean up children
                $(this).find("." + itemClass).removeClass([outClass, inClass, reverseClass].join(" "));

                var $from = $(this).find("." + activeClass),
                    prevs = $from.index(),
                    activeNum = (prevs < 0 ? 0 : prevs) + 1,
                    nextNum = typeof (num) === "number" ? num : activeNum + parseFloat(num),
                    $to = $(this).find(".carousel-item").eq(nextNum - 1),
                    reverse = (typeof (num) === "string" && !(parseFloat(num))) || nextNum > activeNum ? "" : reverseClass;

                if (!$to.length) {
                    $to = $(this).find("." + itemClass)[reverse.length ? "last" : "first"]();
                }

                if (cssTransitionsSupport) {
                    $self[pluginName]("_transitionStart", $from, $to, reverse);
                } else {
                    $to.addClass(activeClass);
                    $self[pluginName]("_transitionEnd", $from, $to, reverse);
                }

                // added to allow pagination to track
                $self.trigger("goto." + pluginName, $to);
            },

            update: function () {
                $(this).children().not("." + navClass).addClass(itemClass);

                return $(this).trigger("update." + pluginName);
            },

            _transitionStart: function ($from, $to, reverseClass) {
                var $self = $(this);

                $to.one(navigator.userAgent.indexOf("AppleWebKit") > -1 ? "webkitTransitionEnd" : "transitionend otransitionend", function () {
                    $self[pluginName]("_transitionEnd", $from, $to, reverseClass);
                });

                $(this).addClass(reverseClass);
                $from.addClass(outClass);
                $to.addClass(inClass);
            },

            _transitionEnd: function ($from, $to, reverseClass) {
                $(this).removeClass(reverseClass);
                $from.removeClass(outClass + " " + activeClass);
                $to.removeClass(inClass).addClass(activeClass);
            },

            _bindEventListeners: function () {
                var $elem = $(this)
                    .bind("click", function (e) {
                        var targ = $(e.target).closest("a[href='#next'],a[href='#prev']");
                        if (targ.length) {
                            $elem[pluginName](targ.is("[href='#next']") ? "next" : "prev");
                            e.preventDefault();
                        }
                    });

                return this;
            },

            _addNextPrev: function () {
                return $(this)
                    .append("<nav class='" + navClass + "'><a href='#prev' class='prev' aria-hidden='true' title='Anterior'>Anterior</a><a href='#next' class='next' aria-hidden='true' title='Próximo'>Próximo</a></nav>")
                [pluginName]("_bindEventListeners");
            },

            destroy: function () {
                // TODO
            }
        };

    // Collection method.
    $.fn[pluginName] = function (arrg, a, b, c) {
        return this.each(function () {

            // if it's a method
            if (arrg && typeof (arrg) === "string") {
                return $.fn[pluginName].prototype[arrg].call(this, a, b, c);
            }

            // don't re-init
            if ($(this).data(pluginName + "data")) {
                return $(this);
            }

            // otherwise, init
            $(this).data(pluginName + "active", true);
            $.fn[pluginName].prototype._create.call(this);
        });
    };

    // add methods
    $.extend($.fn[pluginName].prototype, methods);

}(jQuery));

(function ($, undefined) {
    var pluginName = "carousel",
        initSelector = "." + pluginName,
        interval = 4000,
        autoPlayMethods = {
            play: function () {
                var $self = $(this),
                    intAttr = $self.attr("data-interval"),
                    thisInt = parseFloat(intAttr) || interval;
                return $self.data(
                    "timer",
                    setInterval(function () {
                        $self[pluginName]("next");
                    },
                        thisInt)
                );
            },

            stop: function () {
                clearTimeout($(this).data("timer"));
            },

            _bindStopListener: function () {
                return $(this).bind("mousedown", function () {
                    $(this)[pluginName]("stop");
                });
            },

            _initAutoPlay: function () {
                var autoplay = $(this).attr("data-autoplay");
                if (autoplay === true || (autoplay !== null && autoplay !== false)) {
                    $(this)
                    [pluginName]("_bindStopListener")
                    [pluginName]("play");
                }
            }
        };

    // add methods
    $.extend($.fn[pluginName].prototype, autoPlayMethods);

    // DOM-ready auto-init
    $(initSelector).live("create." + pluginName, function () {
        $(this)[pluginName]("_initAutoPlay");
    });

}(jQuery));

(function ($) {
    // DOM-ready auto-init
    $(function () {
        $(".carousel").carousel();
    });
}(jQuery));

(function ($) {

    $.fn.fitText = function (kompressor, options) {

        // Setup options
        var compressor = kompressor || 1,
            settings = $.extend({
                'minFontSize': Number.NEGATIVE_INFINITY,
                'maxFontSize': Number.POSITIVE_INFINITY
            }, options);

        return this.each(function () {

            // Store the object
            var $this = $(this);

            // Resizer() resizes items based on the object width divided by the compressor * 10
            var resizer = function () {
                $this.css('font-size', Math.max(Math.min($this.width() / (compressor * 10), parseFloat(settings.maxFontSize)), parseFloat(settings.minFontSize)));
            };

            // Call once to set.
            resizer();

            // Call on resize. Opera debounces their resize by default.
            $(window).on('resize.fittext orientationchange.fittext', resizer);

        });

    };

})(jQuery);
