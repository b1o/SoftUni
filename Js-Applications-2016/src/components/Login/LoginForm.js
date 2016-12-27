import React, {Component} from 'react';

export default class LoginForm extends Component {
    render() {
        return (
            <section id="viewLogin">
                <h1>Please login</h1>
                <form id="formLogin" onSubmit={this.props.onSubmit}>
                    <label>
                        <div>Username:</div>
                        <input type="text" name="username" id="loginUsername" required onChange={this.props.onChange}/>
                    </label>
                    <label>
                        <div>Password:</div>
                        <input type="password" name="password" id="loginPasswd" required onChange={this.props.onChange}/>
                    </label>
                    <div>
                        <input type="submit" value="Login" />
                    </div>
                </form>
            </section>
        )
    }
}