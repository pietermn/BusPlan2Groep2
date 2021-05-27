import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetMaintenance":
      return { ...state, maintenance: action.payload }
    case "GetAllMaintenance":
      return { ...state, maintenanceList: action.payload }
    case "GetAllAdhocMaintenance":
      return { ...state, adhoc: action.payload }
    default:
      return state;
  }
};

function fixTime(time) {
  const timeArr = time.split("T");
  const date = timeArr[0] + " " + timeArr[1];
  return date;
}

const CreateMaintenance = (dispatch) => async (maintenance) => {
  try {
    const response = await BackendApi.get("/maintenance/create", maintenance)
  } catch {
    console.log("Something went wrong")
  }
};

const GetMaintenance = (dispatch) => async (maintenanceID) => {
  try {
    const response = await BackendApi.get("/maintenance/read", maintenanceID)
    const maintenance = response.data;
    maintenance.TimeCleaned = fixTime(maintenance.TimeCleaned);

    dispatch({ type: "GetMaintenance", payload: maintenance })
  } catch {
    console.log("Something went wrong")
  }
};

const GetAllMaintenance = (dispatch) => async () => {
  try {
    const response = await BackendApi.get("/maintenance/readall")
    const maintenanceList = response.data;
    maintenanceList.forEach(maintenance => {
      maintenance.TimeCleaned = fixTime(maintenance.TimeCleaned);
    });

    dispatch({ type: "GetAllMaintenance", payload: maintenanceList })
  } catch {
    console.log("Something went wrong")
  }
};

const UpdateMaintenance = (dispatch) => async (maintenance) => {
  try {
    const response = await BackendApi.post("/maintenance/update", maintenance)
  } catch {
    console.log("Something went wrong");
  }
}

const DeleteMaintenance = (dispatch) => async (maintenanceID) => {
  try {
    const response = await BackendApi.post("/maintenance/delete", maintenanceID)
  } catch {
    console.log("Something went wrong");
  }
}

const GetAllAdhocMaintenance = (dispatch) => async () => {
  const response = await BackendApi.get("/adhoc/readall");

  var maintenanceAdhoc = [];
  response.data.forEach(adhoc => {
    if (adhoc.team == 2) maintenanceAdhoc.push(adhoc);
  })

  dispatch({ type: "GetAllAdhocMaintenance", payload: maintenanceAdhoc });
}

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    CreateMaintenance,
    GetMaintenance,
    GetAllMaintenance,
    UpdateMaintenance,
    DeleteMaintenance,
    GetAllAdhocMaintenance
  },
  []
);
