import * as requester from './requesterModel'

function discardItem(item) {
    let userId = sessionStorage.getItem("userId");
    return requester.get('user', userId, 'kinvey')
        .then(function (data) {
            delete data.cart[item.id];
            return requester.update('user', userId, data, 'kinvey')
        })
}

export {discardItem}