import createDataContext from "./createDataContext";

import BackendApi from "../api/BackendApi";

const authReducer = (state, action) => {
  switch (action.type) {
    case "GetPopup":
      return { ...state, bus: action.payload };
    case "DeletePopup":
        return {...state, bus: ''}
    default:
      return state;
  }
};

const GetPopup = (dispatch) => async (bus) => {
    dispatch({type: "GetPopup", payload: bus})
};

const DeletePopup = (dispatch) => async () => {
    dispatch({type: 'DeletePopup'})
}

export const { Provider, Context } = createDataContext(
  authReducer,
  {
    GetPopup,
    DeletePopup
  },
  []
);
