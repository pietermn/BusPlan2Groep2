import React from "react";
import "../Style/Navbar.css";
import { useLocation, useHistory } from "react-router-dom";

const NavigationBar = () => {
  var display_name = "Noah Koole"; // Hard coded as backend is not done yet
  //const location = useLocation();
  const history = useHistory();

  // Gets li text and redirects to this url
  function handleRedirect(e) {
    // If there is no event handler in the param it redirects to this param
    if (e.target) {
      const param = e.target.innerText.toLowerCase();
      history.push(`/${param}`);
    } else {
      history.push(`/${e}`);
    }
  }

  //html
  return (
    <div className="full-navbar">
      <div className="navbar">
        <ul>
          <li id="li_logotext">Hermes</li>
          <li onClick={handleRedirect}>Home</li>
        </ul>
      </div>
    </div>
  );
};

export default NavigationBar;
