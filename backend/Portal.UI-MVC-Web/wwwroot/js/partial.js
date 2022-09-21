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

createArticleEvents();
createBookEvents();
createVideoEvents();
createPerkEvents();