(function () {
    var $ = jQuery;
    $.fn.extend({
        filterTable: function () {
            return this.each(function () {
                $(this).on("keyup", function () {
                    $(".filterTable_no_results").remove();
                    var $this = $(this), search = $this.val().toLowerCase(), target = $this.attr("data-filters"), $target = $(target), $rows = $target.find("tbody tr");
                    if (search === '') {
                        $rows.show();
                    } else {
                        $rows.each(function () {
                            const $this = $(this);
                            $this.text().toLowerCase().indexOf(search) === -1 ? $this.hide() : $this.show();
                        });
                        if ($target.find("tbody tr:visible").size() === 0) {
                            const colCount = $target.find("tr").first().find("td").size();
                            const noResults = $('<tr class="filterTable_no_results"><td colspan="' + colCount + '">Нет данных</td></tr>');
                            $target.find("tbody").append(noResults);
                        }
                    }
                });
            });
        }
    });
    $('[data-action="filter"]').filterTable();
})(jQuery);