﻿!function (n) { n.fn.menumaker = function (i) { var e = n(this), t = n.extend({ title: "Menu", format: "dropdown", sticky: !1 }, i); return this.each(function () { return e.prepend('<div id="menu-button">' + t.title + "</div>"), n(this).find("#menu-button").on("click", function () { n(this).toggleClass("menu-opened"); var i = n(this).next("ul"); i.hasClass("open") ? i.hide().removeClass("open") : (i.show().addClass("open"), "dropdown" === t.format && i.find("ul").show()) }), e.find("li ul").parent().addClass("has-sub"), multiTg = function () { e.find(".has-sub").prepend('<span class="submenu-button"></span>'), e.find(".submenu-button").on("click", function () { n(this).toggleClass("submenu-opened"), n(this).siblings("ul").hasClass("open") ? n(this).siblings("ul").removeClass("open").hide() : n(this).siblings("ul").addClass("open").show() }) }, "multitoggle" === t.format ? multiTg() : e.addClass("dropdown"), t.sticky === !0 && e.css("position", "fixed"), resizeFix = function () { n(window).width() > 768 && e.find("ul").show(), n(window).width() <= 768 && e.find("ul").hide().removeClass("open") }, resizeFix(), n(window).on("resize", resizeFix) }) } }(jQuery), function (n) { n(document).ready(function () { n("#Bar").menumaker({ title: "Menu", format: "multitoggle" }) }) }(jQuery), $(function () { $("#PopupCad").dialog({ autoOpen: !1, resizable: !1, width: 380, height: 605, modal: !0 }), $("#BtnVizualizar").on("click", function () { $("#PopupCad").dialog("open") }) }), function (n) { n.fn.fitText = function (i, e) { var t = i || 1, o = n.extend({ minFontSize: Number.NEGATIVE_INFINITY, maxFontSize: Number.POSITIVE_INFINITY }, e); return this.each(function () { var i = n(this), e = function () { i.css("font-size", Math.max(Math.min(i.width() / (10 * t), parseFloat(o.maxFontSize)), parseFloat(o.minFontSize))) }; e(), n(window).on("resize.fittext orientationchange.fittext", e) }) } }(jQuery);