function getPartial(type, url, data, destination, callbackfunc) {
    $.ajax({
        type: type,
        url: url,
        data: data,
        traditional: true,
        success: function (result) {
            $(destination).html(result);
            callbackfunc();
        }
    });
}

function createDeleteEvents(table, callbackfunc) {
    $(table + " .btn-danger").each(function () {
        $(this).click(function () {
            let url = $(this).attr("url");
            let id = { id: $(this).attr("data_id") };
            let destination = $(table);

            getPartial("Get", url, id, destination, callbackfunc);
        });
    });
}

function createArticleEvents() {
    createDeleteEvents("#article-table-view", createBookEvents);
}

function createBookEvents() {
    createDeleteEvents("#book-table-view", createBookEvents);
}

function createVideoEvents() {
    createDeleteEvents("#video-table-view", createVideoEvents);
}

function createPerkEvents() {
    createDeleteEvents("#perk-table-view", createPerkEvents);
}

function createCourseEvents() {
    createDeleteEvents("#course-table-view", createCourseEvents);
}

$(function () {
    $(".learn-material").each(function () {
        $(this).click(function () {
            let progress = $(this).attr("progress");
            let material = { materialId: $(this).attr("material") };
            let url = $(this).attr("url");

            if (progress < 100) {
                getPartial("Post", url, material, null, null);
            }
            else {
                $(this).attr('checked', true);
            }
        });
    })
});

createArticleEvents();
createBookEvents();
createVideoEvents();
createPerkEvents();
createCourseEvents();