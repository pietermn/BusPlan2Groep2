import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetPopup":
      return { ...state, buspopup: action.payload };
    case "DeletePopup":
      return { ...state, buspopup: "" };
    case "GetAllBusses":
      return { ...state, busses: action.payload };
    case "GetOneBus":
      return { ...state, bus: action.payload };
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

    dispatch({ type: "GetAllBusses", payload: busses })
  } catch {
    console.log("Something went wrong")
  }
};

const GetAllCleaningBusses = (dispatch) => async () => {
  try {
    const response = await BackendApi.get("/bus/readcleaning")
    const busses = response.data;
    busses.forEach(bus => {
      bus.periodicCleaning = fixTime(bus.periodicCleaning);
      bus.periodicMaintenance = fixTime(bus.periodicMaintenance);
    });

    dispatch({ type: "GetAllBusses", payload: busses })
  } catch {
    console.log("Something went wrong")
  }
}

const GetAllMaintenanceBusses = (dispatch) => async () => {
  try {
    const response = await BackendApi.get("/bus/readmaintenance")
    const busses = response.data;
    busses.forEach(bus => {
      bus.periodicCleaning = fixTime(bus.periodicCleaning);
      bus.periodicMaintenance = fixTime(bus.periodicMaintenance);
    });

    dispatch({ type: "GetAllBusses", payload: busses })
  } catch {
    console.log("Something went wrong")
  }
}

const GetOneBusPopup = (dispatch) => async (busID) => {
  try {
    const response = await BackendApi.get(`/bus/read?BusID=${busID}`)
    dispatch({ type: "GetPopup", payload: response.data });
  } catch {
    console.log("Something went wrong")
  }
}

const CreateAdhoc = (dispatch) => async (Adhoc) => {
  try {
    const response = await BackendApi.post("/adhoc/create", Adhoc)
  } catch {
    console.log("Something went wrong");
  }
}

const GetDriveToParkingSpace = (dispatch) => async (BusID) => {
  try {
    const response = await BackendApi.get("/adhoc/get", BusID);
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
    CreateAdhoc,
    GetAllCleaningBusses,
    GetAllMaintenanceBusses,
    GetDriveToParkingSpace
  },
  {
    DriveTo: {
      "parkingSpaceID": 23,
      "busID": 7,
      "number": 20,
      "type": 0,
      "occupied": true
    }
  },
  []
);
