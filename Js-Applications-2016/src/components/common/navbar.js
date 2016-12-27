import React, {Component} from 'react';
import {Link} from 'react-router';

export default class Navbar extends Component {
    render() {
        if(this.props.isLogged) {
            return (
                <header id="menu">
                    <Link to="/" className="useronly" id="linkMenuUserHome">Home</Link>
                    <Link to="/shop" className="useronly" id="linkMenuShop">Shop</Link>
                    <Link to="/cart" className="useronly" id="linkMenuCart">Cart</Link>
                    <Link to="/logout" className="useronly" id="linkMenuLogout">Logout</Link>

                    <span className="useronly" id="spanMenuLoggedInUser">Welcome, {this.props.username}!</span>
                </header>

            )
        }

        return(
            <header id="menu">
                <Link to="/" className="anonymous" id="linkMenuAppHome">Home</Link>
                <Link to="/login" className="anonymous" id="linkMenuLogin">Login</Link>
                <Link to="/register" className="anonymous" id="linkMenuRegister">Register</Link>
            </header>
        )
    }
}