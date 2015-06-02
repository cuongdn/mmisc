var gridHelper = (function ($) {

    this._getFilters = function (id) {
        var filter = new Array();
        $("#" + id + " [data-filter]").each(function () {
            var $this = $(this);
            if ($this.val() == '') return;

            filter.push({
                field: $this.attr("data-field"),
                operator: $this.attr("data-op"),
                value: $this.val()
            });
        });
        return filter;
    }

    this.filter = function (id) {
        var filters = this._getFilters(id + "_filter");
        $("#" + id).data("kendoGrid").dataSource.filter(filters);
    }

    this.edit = function (e, url) {
        e.preventDefault();
        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        alert(dataItem.id);
    }

    return this;

}).call({}, jQuery);
