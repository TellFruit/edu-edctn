import { getPartial } from '../../js/site.js';

// delete button response call for article table
$("#article-table").find(".btn-danger").click(function () {
    let url = $(this).attr("url");
    let id = $(this).attr("data_id");
    let destination = $("#article-table-view");

    getPartial(url, id, destination);
})