$(document).ready(function() {
    $.datetimepicker.setLocale("ru");
    $(".txt-datetime").datetimepicker({ lang: "ru", format: "d.m.Y", timepicker: false, dayOfWeekStart: 1 });
});