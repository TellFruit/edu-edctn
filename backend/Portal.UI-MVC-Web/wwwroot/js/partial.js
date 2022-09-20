﻿// general function for a simple get 
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

// delete button response call for article table$(function() {
function createArticleEvents() {
    $("#article-table-view .btn-danger").each(function () {
        $(this).click(function () {
            let url = $(this).attr("url");
            let id = { id: $(this).attr("data_id") };
            let destination = $("#article-table-view");
            
            getPartial("Get", url, id, destination, createArticleEvents);
        });
    });
}

createArticleEvents();