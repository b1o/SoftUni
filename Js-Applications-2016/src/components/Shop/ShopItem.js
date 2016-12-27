import React, {Component} from 'react';
import {purchaseItem} from '../../models/shopModel'
import observer from '../../models/observer'

export default class ShopItem extends Component {
    constructor(props) {
        super(props);

        this.purchase = this.purchase.bind(this);
    }

    purchase() {
        purchaseItem(this.props).then(() => observer.showInfo("Product purchased"))
    }

    render() {
        return(
            <tr id={this.props.id}>
                <td>{this.props.name}</td>
                <td>{this.props.description}</td>
                <td>{parseFloat(this.props.price).toFixed(2)}</td>
                <td><button onClick={this.purchase}>Purchase</button></td>
            </tr>
        )
    }
}