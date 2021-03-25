import React, {useContext, useState} from 'react';

const Login = () => {
    const [loginNumber, setLoginNumber] = useState();
    const [password, setPassword] = useState('');

    return (
        <div className="login-container">
            <input id="loginnumber" type="number" placeholder="Login number" value={loginNumber} onChange={(e) => setLoginNumber(e.target.value)}/>
            <input id="password" type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)}/>
            <button onClick={() => {console.log({loginNumber, password})}}>Login</button>
            <p id="loginasbus">Login as bus</p>
        </div>
    )
}

export default Login;