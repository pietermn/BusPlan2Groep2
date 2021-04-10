import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetPopup":
      return { ...state, buspopup: action.payload };
    case "DeletePopup":
      return { ...state, buspopup: "" };
    case "GetAllBusses":
      return {...state, busses: action.payload};
    case "GetOneBus":
      return {...state, bus: action.payload };
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

const GetOneBusPopup = (dispatch) => async (busID) => {
  try {
    const response = await BackendApi.get(`/bus/read?BusID=${busID}`)
    dispatch({type: "GetPopup", payload: response.data});
  } catch {
    console.log("Something went wrong")
  }
}

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
    GetOneBusPopup,
    UpdateBus
  },
  []
);
