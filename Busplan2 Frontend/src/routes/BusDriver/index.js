import React, { lazy, Suspense } from "react";
import { Redirect, Route, Switch } from "react-router";
import PageLoader from "../../Layout/PageLoader";

const BusDriver = ({ match }) => {
    const requestedUrl = match.url.replace(/\/$/, "");

    return (
        <div className="bus_full_page">
            <Suspense fallback={<PageLoader />}>
                <Switch>
                    <Redirect
                        exact
                        from={`${requestedUrl}/`}
                        to={`${requestedUrl}/scanning`}
                    />
                    <Route
                        path={`${requestedUrl}/scanning`}
                        component={lazy(() => import("./Scanning"))}
                    />
                    <Route
                        path={`${requestedUrl}/manual`}
                        component={lazy(() => import("./Manual"))}
                    />
                    <Route
                        path={`${requestedUrl}/drivein`}
                        component={lazy(() => import("./Drivein"))}
                    />
                    <Route
                        path={`${requestedUrl}/problems`}
                        component={lazy(() => import("./Problems"))}
                    />
                    <Route
                        path={`${requestedUrl}/maintenance`}
                        component={lazy(() => import("./Maintenance"))}
                    />
                    <Route
                        path={`${requestedUrl}/cleaning`}
                        component={lazy(() => import("./Cleaning"))}
                    />
                    <Route
                        path={`${requestedUrl}/other`}
                        component={lazy(() => import("./Other"))}
                    />
                    <Route
                        path={`${requestedUrl}/driveto`}
                        component={lazy(() => import("./Driveto"))}
                    />
                </Switch>
            </Suspense>
        </div>
    )
}

export default BusDriver