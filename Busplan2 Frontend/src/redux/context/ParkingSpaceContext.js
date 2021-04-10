import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetParkingSpaces":
      return { ...state, parkingspaces: action.payload };
    default:
      return state;
  }
};

const GetParkingSpaces = (dispatch) => async () => {
  const response = await BackendApi.get("/parkingspace/readall");

  dispatch({ type: "GetParkingSpaces", payload: response.data });
};

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    GetParkingSpaces,
  },
  []
);
