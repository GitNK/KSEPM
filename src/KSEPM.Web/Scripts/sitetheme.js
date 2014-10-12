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
});
