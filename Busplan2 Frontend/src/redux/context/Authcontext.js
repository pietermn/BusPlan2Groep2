import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "login":
      return { ...state, jwt: action.payload };
    case "register":
      return { ...state };
    case "localSignin":
      return {
        ...state,
        name: action.payload.name,
        accountID: action.payload.accountID,
      };
    default:
      return state;
  }
};

const signin = (dispatch) => async (email, password, history) => {
  try {
    const response = await BackendApi.post("/accounts/login", {
      email,
      password,
    });
    console.log({email, password});
  } catch (e) {
    console.log("Wrong email or password");
  }
};

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    signin,
  },
  []
);
