import React from "react";
import AppWrapper from "./Layout/AppWrapper";
import { Provider } from "react-redux";
import Routes from "./routes";
import { Switch } from "react-router-dom";
import { ConnectedRouter } from "connected-react-router";
import configureStore, { history } from "./redux/store";

export const store = configureStore();

export default function App() {
  return (
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <AppWrapper>
          <Switch>
            <Routes />
          </Switch>
        </AppWrapper>
      </ConnectedRouter>
    </Provider>
  );
}
