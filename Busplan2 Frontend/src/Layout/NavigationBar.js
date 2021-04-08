import React, { useContext, useEffect } from "react";
import { Context as AuthContext } from "../redux/context/Authcontext";
import { useHistory } from "react-router-dom";
import "../Style/Navbar.css";

const NavigationBar = () => {
  const { localSignin, state, signout } = useContext(AuthContext);
  //const location = useLocation();
  const history = useHistory();
  const team = state.team;

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

  function NavbarSelector() {
    switch (team) {
      case "0":
        return <li onClick={handleRedirect}>BusChauffeur</li>;
      case "1":
        return <li onClick={handleRedirect}>Schoonmaak</li>;
      case "2":
        return <li onClick={handleRedirect}>Monteur</li>;
      case "3":
        return <li onClick={handleRedirect}>Planner</li>;
      case "4":
        return (
          <span style={{display: "flex", flexDirection: "row"}}>
            <li onClick={handleRedirect}>Schoonmaak</li>
            <li onClick={handleRedirect}>Monteur</li>
            <li onClick={handleRedirect}>Planner</li>
            <li onClick={handleRedirect}>Overzicht</li>
          </span>
        );
      default:
        return <li>Something went wrong</li>
    }
  }

  //html
  return (
    <div className="full-navbar">
      <div className="navbar">
        <ul>
          <li id="li_logotext">Hermes</li>
          {state.team && <NavbarSelector />}
          {state.logincode ? (
            <span id="account">
              <li>{state.logincode}</li>
              <li onClick={() => signout()}>Signout</li>
            </span>
          ) : (
            <span id="account">
              <li onClick={() => handleRedirect("account")}>Login</li>
            </span>
          )}
        </ul>
      </div>
    </div>
  );
};

export default NavigationBar;
