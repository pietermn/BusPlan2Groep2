import React, { useReducer } from "react";

export default (reducer, actions, defaultValue) => {
  const Context = React.createContext();

  const Provider = ({ children, namestate }) => {
    const [state, dispatch] = useReducer(reducer, defaultValue);

    const boundActions = {};
    for (let key in actions) {
      boundActions[key] = actions[key](dispatch);
    }

    if (namestate == "BusContext") {
      return (
        <Context.Provider value={{ BusState: state, ...boundActions }}>
          {children}
        </Context.Provider>
      );
    } else if (namestate == "AuthContext") {
      return (
        <Context.Provider value={{ AuthState: state, ...boundActions }}>
          {children}
        </Context.Provider>
      );
    } else if (namestate == "ParkingSpaceContext") {
      return (
        <Context.Provider value={{ ParkingSpaceState: state, ...boundActions }}>
          {children}
        </Context.Provider>
      );
    } else {
      return (
        <Context.Provider value={{ state, ...boundActions }}>
          {children}
        </Context.Provider>
      );
    }
  };

  return { Context, Provider };
};
