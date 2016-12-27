import React, {Component} from 'react';
import * as shop from '../../models/shopModel'
import ShopItem from './ShopItem'
import $ from 'jquery';

export default class ShopController extends Component {
    constructor(props) {
        super(props);
        this.state = {products: []}

        this.onGetSuccess = this.onGetSuccess.bind(this);
    }

    componentDidMount() {
        shop.getAllProducts().then(this.onGetSuccess)

    }

    onGetSuccess(data) {
        this.setState({products: data})
    }

    render() {
        let products = [];
        let self = this;
        this.state.products.forEach(function (p) {
            let entry = <ShopItem key={p._id} id={p._id} name={p.name} description={p.description} price={p.price}/>;
            products.push(entry)
        })

        return (
            <section id="viewShop">
                <h1>Products</h1>
                <div className="products" id="shopProducts">
                    <table>
                        <thead>
                        <tr>
                            <th>Product</th>
                            <th>Description</th>
                            <th>Price</th>
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