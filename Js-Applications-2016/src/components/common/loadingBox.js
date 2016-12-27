import React, {Component} from 'react';
import observer from '../../models/observer'
import $ from 'jquery'

export  default class InfoBox extends Component {
    constructor(props) {
        super(props);
        this.state = {visible: false, message: '', id: ''};

        this.ajaxStart = this.ajaxStart.bind(this);
        this.hide = this.hide.bind(this)
    }

    componentDidMount() {
        $(document).on({
            ajaxStart: this.ajaxStart,
            ajaxStop: this.hide
        });
    }

    ajaxStart() {
        this.setState({ message: 'Loading...', id: 'loadingBox', visible: true });
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