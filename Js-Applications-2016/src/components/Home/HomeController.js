import React, {Component} from "react";
import {Link} from 'react-router';

export default class HomeController extends Component {
    render() {
        if(this.props.isLogged) {
            return(
                <section id="viewUserHome">
                    <h1 id="viewUserHomeHeading">Welcome, {this.props.username}!</h1>
                    <Link to="/shop" id="linkUserHomeShop">Shop</Link>
                    <Link to="/cart" id="linkUserHomeCart">Cart</Link>
                </section>
            )
        }

        return (
            <section id="viewAppHome">
                <h1>Welcome</h1>
                Welcome to our shopping system.
            </section>
        );
    }
}