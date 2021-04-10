import React, { lazy, Suspense } from "react";
import { Redirect, Route, Switch } from "react-router";
import { useLocation } from "react-router-dom";
import PageLoader from "../Layout/PageLoader";
import Account from "./Account";
import Cleaning from "./Cleaning";
import Maintenance from "./Maintenance";
import Overview from "./Overview";

const Routes = () => {
  const location = useLocation();

  if (location.pathname === "" || location.pathname === "/")
    return <Redirect to={"/schoonmaak"} />;

  return (
    <div>
      <Suspense fallback={<PageLoader />}>
        <Switch>
          <Route path="/account" component={Account} />
          <Route path="/schoonmaak" component={Cleaning} />
          <Route path="/overzicht" component={Overview} />
          <Route path="/monteur" component={Maintenance} />
          <Route component={lazy(() => import("./ExtraPages/404"))} />
        </Switch>
      </Suspense>
    </div>
  );
};

export default Routes;
