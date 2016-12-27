import React, {Component} from 'react';
import {logout} from '../../models/userModel';
import observer from '../../models/observer'

export default class LogoutController extends Component {
    constructor(props) {
        super(props);
        this.logout();
    }

    logout() {
        logout(this.onSubmitResponse.bind(this));
    }

    onSubmitResponse(response) {
        if (response === true) {
            this.context.router.push('/');
            observer.showInfo("Logout successful")
        }
    }

    render() {
        return null;
    }
}

LogoutController.contextTypes = {
    router: React.PropTypes.object
};