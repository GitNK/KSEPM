$(function () {
    var datetimePickerDiv = $('.datetimepicker');
    datetimePickerDiv.datetimepicker({
        pick12HourFormat: false,
        pickTime: false
    });
    if (datetimePickerDiv.data("DateTimePicker")) {
        datetimePickerDiv.data("DateTimePicker").setMaxDate(new Date());
        datetimePickerDiv.data("DateTimePicker").setDate(new Date());
    }
});
