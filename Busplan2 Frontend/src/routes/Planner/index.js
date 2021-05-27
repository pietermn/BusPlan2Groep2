import React, { useState, lazy, Suspense } from 'react';
import { Redirect, Route, Switch } from "react-router";
import '../../Style/plannerStyles.css';
import Navbar from './Navbar';
import PageLoader from '../../Layout/PageLoader';

const Planner = ({ match }) => {
    const requestedUrl = match.url.replace(/\/$/, '');

    return (
        <div className="planner_full_page">
            <Navbar />
            <Suspense fallback={<PageLoader />}>
                <Switch>
                    <Redirect exact from={`${requestedUrl}/`} to={`${requestedUrl}/schoonmaak`} />
                    <Route path={`${requestedUrl}/schoonmaak`} component={lazy(() => import('./Cleaning'))} />
                    <Route path={`${requestedUrl}/onderhoud`} component={lazy(() => import('./Maintenance'))} />
                    <Route component={lazy(() => import("../ExtraPages/404"))} />
                </Switch>
            </Suspense>
        </div>
    )
}

export default Planner;