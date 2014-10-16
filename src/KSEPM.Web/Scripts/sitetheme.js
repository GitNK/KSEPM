﻿
function sellerNameFormatter(value, row) {
    return row.Seller.Name;
}

function sellPointCityFormatter(value, row) {
    return row.SellPoint.City;
}

function sellPointNameFormatter(value, row) {
    return row.SellPoint.Name;
}

function sellDateFormatter(value, row) {
    return moment(row.Date * 1000).format("DD.MM.YYYY");
}

function rowStyle(row, index, totalRows) {
    if (index === 0)
        return { classes: 'success' };
    if (index === totalRows - 1)
        return { classes: 'danger' };
    return {};
}

$(function () {
    var datetimePickerDiv = $('.datetimepicker');
    datetimePickerDiv.datetimepicker({
        pick12HourFormat: false,
        pickTime: false
    });
    if (datetimePickerDiv.data("DateTimePicker")) {
        datetimePickerDiv.data("DateTimePicker").setDate(moment());
        datetimePickerDiv.data("DateTimePicker").setMaxDate(new Date());
    }

    var KSEPMTemplateHelpers = (function () {

        function _getArrayLength(array) {
            return array.length;
        }

        function _parseData(data) {
            return moment(data * 1000).format("DD.MM.YYYY");
        }

        function _init() {
            $.views.helpers({ getArrayLength: _getArrayLength });
            $.views.helpers({ parseData: _parseData });
        }

        return {
            Initialize: _init
    };
    })();
    KSEPMTemplateHelpers.Initialize();

    $(".table-btngroup-timespan-selector > .btn").click(function () {
        $(this).addClass("active").siblings().removeClass("active");
    });

    $('.table-btngroup-timespan-selector button').click(function (e) {
        var timespan = $(this).data('timespan');
        var thisTable = $(this).closest('.table-box-div').find('table[data-toggle="table"]');
        var thisUrl = thisTable.data('url');

        $(thisTable).bootstrapTable('refresh', {
            url: thisUrl + '?timespan=' + timespan
        });
    });

    
});
