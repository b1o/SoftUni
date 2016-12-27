import React, { Component } from 'react';
import './App.css';
import Navbar from './components/common/navbar'
import observer from './models/observer'
import Notifications from './components/common/infoBox'
import Footer from './components/common/footer'
import Loading from './components/common/loadingBox'

class App extends Component {

    constructor(props) {
        super(props);

        this.state = {isLogged: false, username: ''};
        observer.onSessionUpdate = this.onSessionUpdate.bind(this);
    }

    componentDidMount() {
        this.onSessionUpdate();
    }

    onSessionUpdate() {
        let name = sessionStorage.getItem('username');
        if (name) {
            this.setState({isLogged: true, username: name});
        } else {
            this.setState({isLogged: false, username: ''});
        }
    }

    render() {
        let self = this;
        let children = React.Children.map(this.props.children, function (child) {
            return React.cloneElement(child, {
                isLogged: self.state.isLogged,
                username: self.state.username
            })
        });

        return(
            <div id="app">
                <Navbar isLogged={this.state.isLogged} username={this.state.username}/>
                <Loading />
                <Notifications/>
                <main>
                    {children}
                </main>
                <Footer/>
            </div>
        );
    }
}


export default App;

