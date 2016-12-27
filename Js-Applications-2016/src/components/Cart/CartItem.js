import React, {Component} from 'react';
import {discardItem} from '../../models/cartModel'
import observer from '../../models/observer'

export default class CartItem extends Component {
    constructor(props) {
        super(props);
        this.state ={}
        this.discard = this.discard.bind(this);
    }

    discard() {

        discardItem(this.props)
            .then(observer.onDiscard).then(() => observer.showInfo("Product discarded"))

    }

    render() {
        if (this.state.quantity === 0) return null;

        return(
            <tr id={this.props.id}>
                <td>{this.props.name}</td>
                <td>{this.props.description}</td>
                <td>{this.props.quantity}</td>
                <td>{parseFloat(this.props.price * Number(this.props.quantity)).toFixed(2)}</td>
                <td><button onClick={this.discard}>Discard</button></td>
            </tr>
        )
    }
}

CartItem.contextTypes = {
    router: React.PropTypes.object
};