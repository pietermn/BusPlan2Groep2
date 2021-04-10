import React from "react";
import AppWrapper from "./Layout/AppWrapper";
import { Provider } from "react-redux";
import Routes from "./routes";
import { Switch } from "react-router-dom";
import { ConnectedRouter } from "connected-react-router";
import configureStore, { history } from "./redux/store";
import { Provider as AuthProvider } from "./redux/context/Authcontext";
import { Provider as BusProvider } from "./redux/context/BusContext";
<<<<<<< HEAD
import { Provider as ParkingSpaceProvider } from "./redux/context/ParkingSpaceContext";
=======
<<<<<<< HEAD
import { Provider as CleaningProvider } from "./redux/context/CleaningContext";
import { Provider as MaintenanceProvider } from "./redux/context/MaintenanceContext";

=======
import { Provider as ParkingSpaceProvider } from "./redux/context/ParkingSpaceContext";
>>>>>>> Frontend
>>>>>>> main

export const store = configureStore();

export default function App() {
  return (
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <BusProvider namestate="BusContext">
          <AuthProvider namestate="AuthContext">
            <ParkingSpaceProvider namestate="ParkingSpaceContext">
              <AppWrapper>
                <Switch>
                  <Routes />
                </Switch>
              </AppWrapper>
            </ParkingSpaceProvider>
          </AuthProvider>
        </BusProvider>
      </ConnectedRouter>
    </Provider>
  );
}
