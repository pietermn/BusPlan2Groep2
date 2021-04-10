import createDataContext from "./createDataContext";
import jwt_decode from "jwt-decode";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "login":
      return { ...state, jwt: action.payload };
    case "register":
      return { ...state };
    case "Authorization":
      return {
        ...state,
        logincode: action.payload.logincode,
        accountID: action.payload.accountID,
        team: action.payload.team,
      };
    case "localSignin":
      return {
        ...state,
        logincode: action.payload.logincode,
        accountID: action.payload.accountID,
        team: action.payload.team,
      };
    case "signout":
      return { ...state, logincode: "", accountID: "", team: 0 };
    default:
      return state;
  }
};

const localSignin = (dispatch) => async () => {
  const data = {
    logincode: localStorage.getItem("logincode"),
    accountID: localStorage.getItem("account_id"),
    team: localStorage.getItem("team")
  };
  if (data) {
    dispatch({ type: "localSignin", payload: data });
  }
};

const signin = (dispatch) => async (logincodeString, password, history) => {
  try {
    const logincode = parseInt(logincodeString);
    const response = await BackendApi.post("/account/login", {
      logincode,
      password,
    });

    var decoded = jwt_decode(response.data);
    console.log(decoded);
    localStorage.setItem("jwt-token", response.data);
    localStorage.setItem("logincode", decoded.email);
    localStorage.setItem("account_id", decoded.name);
    localStorage.setItem("team", decoded.actort);

    const data = {
      logincode: decoded.email,
      acountID: decoded.unique_name,
      team: decoded.actort,
    };
    dispatch({ type: "Authorization", payload: data });
    history.push("/");
  } catch (e) {
    console.log("Wrong email or password");
  }
};

const signout = (dispatch) => async () => {
  localStorage.removeItem("jwt-token");
  localStorage.removeItem("account_id");
  localStorage.removeItem("logincode");
  localStorage.removeItem("team");

  dispatch({ type: "signout" });
};

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    signin,
    localSignin,
    signout,
  },
  []
);
