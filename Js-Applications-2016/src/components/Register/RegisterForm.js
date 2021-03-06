import React, {Component} from 'react';

export default class RegisterForm extends Component {
    render() {
        return (
            <section id="viewRegister">
                <h1>Please register here</h1>
                <form id="formRegister" onSubmit={this.props.onSubmit}>
                    <label>
                        <div>Username:</div>
                        <input type="text" name="username" id="registerUsername" required onChange={this.props.onChange}/>
                    </label>
                    <label>
                        <div>Password:</div>
                        <input type="password" name="password" id="registerPasswd" required onChange={this.props.onChange}/>
                    </label>
                    <label>
                        <div>Name:</div>
                        <input type="name" name="name" id="registerName" onChange={this.props.onChange}/>
                    </label>
                    <div>
                        <input type="submit" value="Register" />
                    </div>
                </form>
            </section>
        )
    }
}