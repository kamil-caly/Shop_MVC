import { updateProductViewBasedOnUserBasket } from './products.js';

const shop_mvc_basket = 'shop_mvc_basket';

function getBasket(updateProducts = true) {
    const basket = localStorage.getItem(shop_mvc_basket);
    const basketProducts = JSON.parse(basket);

    $.ajax({
        type: 'POST',
        url: '/Basket/GetBasket',
        contentType: 'application/json',
        data: JSON.stringify(basketProducts),
        success: function (html) {
            $('#basket-container').html(html);
            if (updateProducts) updateProductViewBasedOnUserBasket();
        },
        error: function (s, a, error) {
            console.error('Error during getBasket:', error);
        }
    });
}

function buy() {
    if (confirm('Are you sure you want to complete the purchase?')) {
        const basket = localStorage.getItem(shop_mvc_basket);
        const basketProducts = JSON.parse(basket);

        $.ajax({
            type: 'POST',
            url: '/Order/Buy',
            contentType: 'application/json',
            data: JSON.stringify(basketProducts),
            success: function () {
                //window.location.href = '/myProducts';
                alert('success');
            },
            error: function (xhr, status, error) {
                console.error('Error during purchasing:', error);
            }
        });
    }
}

$(function () {
    getBasket(true);

    $(document).on('click', '#buy_btn', function () {
        buy();
    });
});

window.getBasket = getBasket;