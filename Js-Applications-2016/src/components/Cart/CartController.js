import React, {Component} from 'react';
import * as shop from '../../models/shopModel'
import CartItem from './CartItem'
import observer from '../../models/observer'

export default class CartController extends Component {
    constructor(props) {
        super(props);
        this.state = {products: []};

        this.onGetSuccess = this.onGetSuccess.bind(this);
        observer.onDiscard = this.onDiscard.bind(this);
    }

    componentDidMount() {
        shop.getUserCart(sessionStorage.getItem("userId")).then(this.onGetSuccess)
    }

    onDiscard() {
        shop.getUserCart(sessionStorage.getItem("userId")).then(this.onGetSuccess)
    }

    onGetSuccess(data) {
        this.setState({products: data.cart})
    }

    render() {
        let products = [];
        if(this.state.products) {
            let keys = Object.keys(this.state.products);
            for(let p of keys) {
                let obj = this.state.products[p].product;
                let quantity = this.state.products[p].quantity
                let entry = <CartItem key={p} id={p} name={obj.name} description={obj.description} quantity={quantity} price={obj.price}/>
                products.push(entry)
            }
        }

        return (
            <section id="viewCart">
                <h1>My Cart</h1>
                <div className="products" id="cartProducts">
                    <table>
                        <thead>
                        <tr>
                            <th>Product</th>
                            <th>Description</th>
                            <th>Quantity</th>
                            <th>Total Price</th>
                            <th>Actions</th>
                        </tr>
                        </thead>
                        <tbody>
                        {products}
                        </tbody>
                    </table>
                </div>
            </section>
        )
    }
}