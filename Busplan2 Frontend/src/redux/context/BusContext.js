import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetPopup":
      return { ...state, bus: action.payload };
    case "DeletePopup":
      return { ...state, bus: "" };
    case "GetAllBusses":
      return {...state, busses: action.payload}
    default:
      return state;
  }
};

function fixTime(time) {
  const timeArr = time.split("T");
  const date = timeArr[0] + " " + timeArr[1];
  return date;
}

const GetPopup = (dispatch) => async (bus) => {
  dispatch({ type: "GetPopup", payload: bus });
};

const DeletePopup = (dispatch) => async () => {
  dispatch({ type: "DeletePopup" });
};

const GetAllBusses = (dispatch) => async () => {
  try {
    const response = await BackendApi.get("/bus/readall")
    const busses = response.data;
    busses.forEach(bus => {
      bus.periodicCleaning = fixTime(bus.periodicCleaning);
      bus.periodicMaintenance = fixTime(bus.periodicMaintenance);
    });

    dispatch({type: "GetAllBusses", payload: busses})
  } catch {
    console.log("Something went wrong")
  }
};

const UpdateBus = (dispatch) => async (bus) => {
  try {
    const response = await BackendApi.post("/bus/update", bus)
  } catch {
    console.log("Something went wrong");
  }
}

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    GetPopup,
    DeletePopup,
    GetAllBusses,
    UpdateBus
  },
  []
);
