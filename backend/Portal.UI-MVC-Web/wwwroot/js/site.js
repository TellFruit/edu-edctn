$(function () {
    $('#timepicker').timepicker({
        showMeridian: false,
        showInputs: true
    });
});

$(function () {
    $(".progress-bar").each(function () {
        let wdth = $(this).attr("aria-valuenow");
        let courseId = $(this).attr("course-id");

        $(this).css({ width: wdth+"%" })

        $("#progress_" + courseId).html(wdth + "%");
    })
});