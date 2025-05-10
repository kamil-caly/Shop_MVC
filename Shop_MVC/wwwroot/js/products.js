const shop_mvc_basket = 'shop_mvc_basket';

function collectFilter() {
    const category = $('input[name="categoryRadio"]:checked').val();
    const company = $('input[name="companyRadio"]:checked').val();
    const color = $('input[name="colorRadio"]:checked').val();

    const searchTxt = $('input#searchTextId').val();

    const priceSortTxt = $('#sortDropdownBtn').text();
    let priceSort = null;
    if (priceSortTxt.includes('Asc')) priceSort = 1;
    else if (priceSortTxt.includes('Desc')) priceSort = 0;

    let result = {
        SearchText: searchTxt,
        PriceSort: priceSort
    };
    if (category != 'All') result.Category = Number(category);
    if (company != 'All') result.Company = Number(company);
    if (color != 'All') result.Color = Number(color);

    return result;
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
            updateProductViewBasedOnUserBasket();
        },
        error: function (xhr, status, error) {
            console.error('Error during filtering:', error);
            alert('An error occurred while filtering products. Please try again.');
        }
    });
}

// product: Shop_MVC.Entities.Product, amount: +1 or -1
function addToCart(product, amount) {
    debugger;
    const basket = localStorage.getItem(shop_mvc_basket);
    if (!basket) {
        if (amount === -1) return;
        const firstProduct = {
            Id: product.Id,
            Quantity: amount
        }
        const products = [firstProduct];
        localStorage.setItem(shop_mvc_basket, JSON.stringify(products));
    } else {
        let basketProducts = JSON.parse(basket);
        const existingProduct = basketProducts.find(p => p.Id === product.Id);
        if (amount === -1 && (existingProduct?.Quantity === 1)) {
            basketProducts = basketProducts.filter(p => p.Id !== existingProduct.Id);
            showAddToCartBtnOnly(existingProduct.Id);
        }
        else if (existingProduct) {
            existingProduct.Quantity += amount;
        } else {
            basketProducts.push({
                Id: product.Id,
                Quantity: amount
            });
        }
        localStorage.setItem(shop_mvc_basket, JSON.stringify(basketProducts));
    }

    updateProductViewBasedOnUserBasket();
}


export function updateProductViewBasedOnUserBasket() {
    //debugger;
    const basket = localStorage.getItem(shop_mvc_basket);
    if (!basket) return;

    const basketProducts = JSON.parse(basket);
    basketProducts.forEach(product => {
        debugger;
        let display_btn = "none";
        let display_div = "flex";
        if (product.Quantity == 0) {
            display_btn = "block";
            display_div = "none";
        }
        if ($('#user_identity_name_span').length === 0) {
            display_btn = "block";
            display_div = "none";
        }

        debugger;
        const btn = $(`.add_to_cart_btn_${product.Id}`);
        const div = $(`.add_to_cart_div_${product.Id}`);

        $(`.add_to_cart_btn_${product.Id}`).css("display", display_btn);
        $(`.add_to_cart_div_${product.Id}`).css("display", display_div);
        $(`.add_to_cart_div_${product.Id}`).children('div').text(product.Quantity);
    });
}

function showAddToCartBtnOnly(productId) {
    $(`.add_to_cart_btn_${productId}`).css("display", "block");
    $(`.add_to_cart_div_${productId}`).css("display", "none");
}


$(function () {
    $('input[type=radio]').on('change', function () {
        updateProducts();
    });

    $('input#searchTextId').on('input', function () {
        updateProducts();
    });

    $('.dropdown-menu .dropdown-item').on('click', function () {
        const selectedText = $(this).text();
        $('#sortDropdownBtn').text(selectedText);
        updateProducts();
    });

    updateProductViewBasedOnUserBasket();
});

window.addToCart = addToCart;