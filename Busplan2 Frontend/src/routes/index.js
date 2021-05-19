import React, { lazy, Suspense } from "react";
import { Redirect, Route, Switch } from "react-router";
import { useLocation } from "react-router-dom";
import PageLoader from "../Layout/PageLoader";
import Account from "./Account";
import BusDriver from "./BusDriver";
import Cleaning from "./Cleaning";
import Maintenance from "./Maintenance";
import Overview from "./Overview";
import Planner from "./Planner";

const Routes = () => {
  const location = useLocation();

  const account_id = localStorage.getItem('account_id');
  const team = localStorage.getItem('team');

  if (location.pathname === "" || location.pathname === "/") {
    console.log({team, account_id});
    if (!account_id) {
      return <Redirect to={"/account"} />;
    }

    switch(team) {
      case "0":
        return <Redirect to={"/bus"} />;
      case "1":
        return <Redirect to={"/schoonmaak"} />;
      case "2":
        return <Redirect to={"/monteur"} />;
      case "3":
        return <Redirect to={"/planner"} />;
      case "4":
        return <Redirect to={"/overzicht"} />;
    }
  }

  return (
    <div>
      <Suspense fallback={<PageLoader />}>
        <Switch>
          <Route path="/account" component={Account} />
          <Route path="/schoonmaak" component={Cleaning} />
          <Route path="/overzicht" component={Overview} />
          <Route path="/monteur" component={Maintenance} />
          <Route path="/bus" component={BusDriver} />
          <Route path="/planner" component={Planner} />
          <Route component={lazy(() => import("./ExtraPages/404"))} />
        </Switch>
      </Suspense>
    </div>
  );
};

export default Routes;
