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
      };
    case "localSignin":
      return {
        ...state,
        logincode: action.payload.logincode,
        accountID: action.payload.accountID,
      };
    case "signout":
      return { ...state, logincode: "", accountID: "" };
    default:
      return state;
  }
};

const localSignin = (dispatch) => async () => {
  const data = {
    logincode: localStorage.getItem("logincode"),
    accountID: localStorage.getItem("account_id"),
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
    localStorage.setItem("jwt-token", response.data);
    localStorage.setItem("logincode", decoded.email);
    localStorage.setItem("account_id", decoded.unique_name);

    const data = {
      logincode: decoded.email,
      acountID: decoded.unique_name,
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
