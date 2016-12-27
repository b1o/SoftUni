import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import {IndexRoute, Router, Route, browserHistory} from 'react-router';
import Home from "./components/Home/HomeController"
import Login from "./components/Login/LoginController"
import Register from "./components/Register/RegisterController"
import Logout from './components/Logout/LogoutController'
import ShopController from './components/Shop/ShopController'
import CartController from './components/Cart/CartController'

ReactDOM.render(
    <Router history={browserHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={Home}/>
            <Route path="/register" component={Register} />
            <Route path="/login" component={Login} />
            <Route path="/logout" component={Logout}/>
            <Route path="/shop" component={ShopController}/>
            <Route path="/cart" component={CartController}/>

        </Route>
    </Router>,
    document.getElementById('root')
);
