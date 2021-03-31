import React, {useContext, useEffect} from "react";
import { Context as AuthContext } from '../redux/context/Authcontext';
import { useLocation, useHistory } from "react-router-dom";
import "../Style/Navbar.css";

const NavigationBar = () => {

  const {localSignin, state, signout} = useContext(AuthContext);
  //const location = useLocation();
  const history = useHistory();

  useEffect(() => {
    localSignin();
  }, []);

  // Gets li text and redirects to this url
  function handleRedirect(e) {
    // If there is no event handler in the param it redirects to this param
    if (e.target) {
      const param = e.target.innerText.toLowerCase();
      history.push(`/${param}`);
    } else {
      const param = e.toLowerCase();
      history.push(`/${param}`);
    }
  }

  //html
  return (
    <div className="full-navbar">
      <div className="navbar">
        <ul>
          <li id="li_logotext">Hermes</li>
          <li onClick={handleRedirect}>Home</li>
          <li onClick={() => handleRedirect("account")}>Login</li>
          <li onClick={handleRedirect}>Cleaning</li>
          {state.logincode && <li>{state.logincode}</li>}
          {state.logincode && <li onClick={() => signout()}>Signout</li>}
        </ul>
      </div>
    </div>
  );
};

export default NavigationBar;
