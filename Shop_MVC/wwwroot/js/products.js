function collectFilter() {
    debugger;
    const category = $('input[name="categoryRadio"]:checked').val();
    //const company = $('input[name="companyRadio"]:checked').val();
    //const color = $('input[name="colorRadio"]:checked').val();

    return {
        Category: category,
        //Company: company === "All" ? null : company,
        //Color: color === "All" ? null : color
    };
}

function updateProducts() {
    const filter = collectFilter();

    $.ajax({
        type: 'POST',
        url: '/Products/Filter',
        contentType: 'application/json',
        data: JSON.stringify(filter),
        success: function (html) {
            $('#products-container').html(html);
        },
        error: function (xhr, status, error) {
            console.error('Error during filtering:', error);
            alert('An error occurred while filtering products. Please try again.');
        }
    });
}

$(function () {
    $('input[type=radio]').on('change', function () {
        updateProducts();
    });
});