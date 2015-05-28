(function ($, kendo) {
    $("#mobile-device-selection").kendoDropDownList({
        change: function (e) {
            $(".get-mobile-panel").hide();
            $("#get-mobile-" + this.value()).fadeIn();
        }
    });
})(jQuery, kendo);