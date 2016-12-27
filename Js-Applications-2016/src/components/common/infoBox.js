import React, {Component} from 'react';
import observer from '../../models/observer'
import $ from 'jquery'

export  default class InfoBox extends Component {
    constructor(props) {
        super(props);
        this.state = {visible: false, message: '', id: ''}

        this.hide = this.hide.bind(this);
        this.handleAjaxError = this.handleAjaxError.bind(this);

        observer.showInfo = this.showInfo.bind(this);
        observer.showError = this.showError.bind(this);
    }

    componentDidMount() {
        $(document).ajaxError(this.handleAjaxError);
    }

    showInfo(message) {
        this.setState({ message: message, id: 'infoBox', visible: true });
        setTimeout(this.hide, 3000);
    }

    showError(errorMsg) {
        this.setState({ message: errorMsg, id: 'errorBox', visible: true });
    }

    handleAjaxError(event, response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON && response.responseJSON.description)
            errorMsg = response.responseJSON.description;
        this.showError(errorMsg);
    }

    hide() {
        this.setState({ visible: false });
    }


    render() {
        if (!this.state.visible) return null;

        return(
            <div id={this.state.id} onClick={this.hide}>{this.state.message}</div>
        )
    }
}