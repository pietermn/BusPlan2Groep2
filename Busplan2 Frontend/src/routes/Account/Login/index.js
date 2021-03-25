import React, {useContext, useState} from 'react';
import {Context as AuthContext} from '../../../redux/context/Authcontext';

const Login = () => {
    const [loginNumber, setLoginNumber] = useState(0);
    const [password, setPassword] = useState('');

    const {signin} = useContext(AuthContext);

    return (
        <div className="login-container">
            <input id="loginnumber" type="number" placeholder="Login number" value={loginNumber} onChange={(e) => setLoginNumber(e.target.value)}/>
            <input id="password" type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)}/>
            <button onClick={() => signin(loginNumber, password)}>Login</button>
            <p id="loginasbus">Login as bus</p>
        </div>
    )
}

export default Login;