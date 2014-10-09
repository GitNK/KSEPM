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
});
