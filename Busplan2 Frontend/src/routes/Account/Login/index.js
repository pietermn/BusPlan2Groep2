import React, {useContext, useState} from 'react';
import {Context as AuthContext} from '../../../redux/context/Authcontext';
import {useHistory} from 'react-router-dom';

const Login = () => {
    const history = useHistory();

    const [loginNumber, setLoginNumber] = useState("");
    const [password, setPassword] = useState('');

    const {signin} = useContext(AuthContext);

    return (
        <div className="login-container">
            <input id="loginnumber" type="number" placeholder="Login number" value={loginNumber} onChange={(e) => setLoginNumber(e.target.value)}/>
            <input id="password" type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)}/>
            <button onClick={() => signin(loginNumber, password, history)}>Login</button>
            <p id="loginasbus">Login as bus</p>
        </div>
    )
}

export default Login;