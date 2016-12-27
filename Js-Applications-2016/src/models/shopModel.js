import * as requester from "./requesterModel"


function getAllProducts() {
    return requester.get('appdata', 'products', 'kinvey')
}

function getUserCart(userId) {
    return requester.get('user', userId, 'kinvey')
}

function purchaseItem(product) {
    return requester.get('user', sessionStorage.getItem("userId"), 'kinvey')
        .then(function (data) {
            if(!data.cart) {
                data.cart = {};
            }

            if(!data.cart[product.id]) {
                data.cart[product.id] = {
                    quantity: 1,
                    product: {
                        name: product.name,
                        description: product.description,
                        price: product.price
                    }
                }
            } else {
                data.cart[product.id].quantity++;
            }
            return requester.update('user', sessionStorage.getItem("userId"), data, 'kinvey')
        });

}

export {getAllProducts, getUserCart, purchaseItem}