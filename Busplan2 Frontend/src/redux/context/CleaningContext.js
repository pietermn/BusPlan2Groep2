import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetCleaning":
        return {...state, cleaning: action.payload}
    case "GetAllCleaning":
      return {...state, cleaningList: action.payload}
    default:
      return state;
  }
};

function fixTime(time) {
  const timeArr = time.split("T");
  const date = timeArr[0] + " " + timeArr[1];
  return date;
}

const CreateCleaning = (dispatch) => async (cleaning) => {
    try {
      const response = await BackendApi.get("/cleaning/create", cleaning)
    } catch {
      console.log("Something went wrong")
    }
  };

const GetCleaning = (dispatch) => async (cleaningID) => {
    try {
      const response = await BackendApi.get("/cleaning/read", cleaningID)
      const cleaning = response.data;
      cleaning.TimeCleaned = fixTime(cleaning.TimeCleaned);
  
      dispatch({type: "GetCleaning", payload: cleaning})
    } catch {
      console.log("Something went wrong")
    }
  };

const GetAllCleaning = (dispatch) => async () => {
  try {
    const response = await BackendApi.get("/cleaning/readall")
    const cleaningList = response.data;
    cleaningList.forEach(cleaning => {
      cleaning.TimeCleaned = fixTime(cleaning.TimeCleaned);
    });

    dispatch({type: "GetAllCleaning", payload: cleaningList})
  } catch {
    console.log("Something went wrong")
  }
};

const UpdateCleaning = (dispatch) => async (cleaning) => {
  try {
    const response = await BackendApi.post("/cleaning/update", cleaning)
  } catch {
    console.log("Something went wrong");
  }
}

const DeleteCleaning = (dispatch) => async (cleaningID) => {
    try {
      const response = await BackendApi.post("/cleaning/delete", cleaningID)
    } catch {
      console.log("Something went wrong");
    }
  }

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    CreateCleaning,
    GetCleaning,
    GetAllCleaning,
    UpdateCleaning,
    DeleteCleaning
  },
  []
);
