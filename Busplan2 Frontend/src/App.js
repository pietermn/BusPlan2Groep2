import React from "react";
import AppWrapper from "./Layout/AppWrapper";
import { Provider } from "react-redux";
import Routes from "./routes";
import { Switch } from "react-router-dom";
import { ConnectedRouter } from "connected-react-router";
import configureStore, { history } from "./redux/store";
import { Provider as AuthProvider } from "./redux/context/Authcontext";
import { Provider as BusProvider } from "./redux/context/BusContext";

export const store = configureStore();

export default function App() {
  return (
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <BusProvider>
          <AuthProvider>
            <AppWrapper>
              <Switch>
                <Routes />
              </Switch>
            </AppWrapper>
          </AuthProvider>
        </BusProvider>
      </ConnectedRouter>
    </Provider>
  );
}
