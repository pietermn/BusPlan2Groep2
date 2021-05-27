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
    case "GetParkingSpace":
      return { ...state, DriveTo: action.payload };
    default:
      return state;
  }
};

function fixTime(time) {
  const timeArr = time.split("T");
  const date = timeArr[0] + " " + timeArr[1];
  return date;
}

function changeTimeBack(time) {
  const timeArr = time.split(" ");
  const date = timeArr[0] + "T" + timeArr[1];
  console.log(date);
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
    var busses = response.data;
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
    const response = await BackendApi.get("/bus/readcleaning");

    var busses = response.data;
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
    var busses = response.data;
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
    const response = await BackendApi.get(`bus/read?busID=${busID}`)

    var bus = response.data;
    bus.periodicCleaning = fixTime(bus.periodicCleaning);
    bus.periodicMaintenance = fixTime(bus.periodicMaintenance);

    dispatch({ type: "GetPopup", payload: bus });
  } catch {
    console.log("Something went wrong")
  }
}

const CreateAdhoc = (dispatch) => async (Adhoc, history) => {
  try {
    // Create Adhoc
    await BackendApi.post("/adhoc/create", Adhoc);

    const parkingspace = await GetParkingSpaceAndMoveBus(Adhoc.busID);

    dispatch({ type: "GetParkingSpace", payload: parkingspace });
    history.push("driveto");
  } catch {
    console.log("Something went wrong");
  }
}

const PlannerCreateAdhoc = () => async (Adhoc) => {
  console.log(Adhoc);
  try {
    await BackendApi.post("/adhoc/create", Adhoc);
  } catch {

  }
}

async function GetParkingSpaceAndMoveBus(busID) {
  try {
    // Get Parkingspace algorithm
    const response = await BackendApi.post(`bus/giveparkingspace?id=${busID}`);

    // Get Current parkingspace
    const responseBus = await BackendApi.get(`bus/read?busID=${busID}`);
    const oldParkingSpaceID = responseBus.data.parkingSpace;

    const parkingspace = response.data;
    parkingspace.occupied = true;

    // Move bus to new parkingspace
    await BackendApi.post("parkingspace/updateoccupied", {
      parkingSpaceID: parkingspace.parkingSpaceID,
      busID: busID,
      occupied: true
    })

    // Remove old parkingspace;
    await BackendApi.post("parkingspace/updateoccupied", {
      parkingSpaceID: oldParkingSpaceID,
      busID: 0,
      occupied: false
    })

    return parkingspace;
  } catch {
    console.log("Something went wrong");
  }
}

const GiveParkingSpaceWithoutAdhoc = (dispatch) => async (busID, history) => {
  try {
    const parkingspace = await GetParkingSpaceAndMoveBus(busID);

    dispatch({ type: "GetParkingSpace", payload: parkingspace });
    history.push("driveto");
  } catch {
    console.log("Something went wrong");
  }
}

const UpdateBus = (dispatch) => async (busParam) => {

  var bus = busParam;
  bus.status = parseInt(bus.status);
  const periodicCleaning = changeTimeBack(bus.periodicCleaning);
  const periodicMaintenance = changeTimeBack(bus.periodicMaintenance);

  bus.periodicCleaning = periodicCleaning;
  bus.periodicMaintenance = periodicMaintenance;

  BackendApi.post("/bus/update", bus)
    .then(function (response) {

    })
    .catch(function (error) {
      console.log(error);
    })
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
    GiveParkingSpaceWithoutAdhoc,
    UpdateBus,
    PlannerCreateAdhoc
  },
  []
);
