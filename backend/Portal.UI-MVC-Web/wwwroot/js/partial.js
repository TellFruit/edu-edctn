// general function for a simple get 
function getPartial(url, data, destination) {
    $.ajax({
        type: "Get",
        url: url,
        data: data,
        traditional: true,
        success: function (result) {
            $(destination).html(result);
        }
    });
}

// delete button response call for article table$(function() {
$(function () {
    $("#article-table-view .btn-danger").each(function () {
        $(this).click(function () {
            let url = $(this).attr("url");
            let id = { id: $(this).attr("data_id") };
            let destination = $("#article-table-view");

            getPartial(url, id, destination);
        });
    });
});