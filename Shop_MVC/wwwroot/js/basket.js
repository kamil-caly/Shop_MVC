import { updateProductViewBasedOnUserBasket } from './products.js';

const shop_mvc_basket = 'shop_mvc_basket';

function getBasket(updateProducts = true) {
    const basket = localStorage.getItem(shop_mvc_basket);
    const basketProducts = JSON.parse(basket);
    debugger;

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


$(function () {
    getBasket(true);
});

window.getBasket = getBasket;