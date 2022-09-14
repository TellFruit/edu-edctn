function getPartial(url, data, destination) {
    $ajax({
        type: "Get",
        url: url,
        data: data,
        traditional: true,
        success: function (result) {
            $(destination).html(result);
        }
    });
}

export { getPartial };