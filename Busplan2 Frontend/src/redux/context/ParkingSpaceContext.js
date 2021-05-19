import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetParkingSpaces":
      return { ...state, parkingspaces: action.payload };
    case "GetAvailable":
      return { ...state, available: action.payload };
    default:
      return state;
  }
};

const GetOverviewSpaces = (dispatch) => async () => {
  const response = await BackendApi.get("/parkingspace/readall");

  dispatch({ type: "GetParkingSpaces", payload: response.data });
};

const GetCleaningSpaces = (dispatch) => async () => {
  const response = await BackendApi.get("/parkingspace/readcleaning");

  dispatch({ type: "GetParkingSpaces", payload: response.data });
}

const GetMaintenanceSpaces = (dispatch) => async () => {
  const response = await BackendApi.get("/parkingspace/readmaintenance");

  dispatch({ type: "GetParkingSpaces", payload: response.data });
};

const GetAvailableSpaces = (dispatch) => async () => {
  const response = await BackendApi.get("/parkingspace/readavailable");

  dispatch({ type: "GetAvailable", payload: response.data });
}

const MoveBus = () => async (MoveBusInfo) => {
  console.log(MoveBusInfo);
  try {
    await BackendApi.post("/parkingspace/updateoccupied", {
      parkingSpaceID: MoveBusInfo.newParkingID,
      busID: MoveBusInfo.BusID,
      occupied: true
    })

    await BackendApi.post("/parkingspace/updateoccupied", {
      parkingSpaceID: MoveBusInfo.currentParkingID,
      busID: MoveBusInfo.BusID,
      occupied: false
    })
  } catch {
    console.log("Something went wrong")
  }
}

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    GetOverviewSpaces,
    GetCleaningSpaces,
    GetMaintenanceSpaces,
    GetAvailableSpaces,
    MoveBus
  },
  []
);
