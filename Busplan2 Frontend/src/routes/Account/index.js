import React, { lazy, Suspense } from 'react';
import { Redirect, Route, Switch } from 'react-router';
import PageLoader from '../../Layout/PageLoader';

const Account = ({ match }) => {
    const requestedUrl = match.url.replace(/\/$/, '');

  return <div className="account_full_page">
      <Suspense fallback={<PageLoader />}>
      <Switch>
        <Redirect exact from={`${requestedUrl}/`} to={`${requestedUrl}/login`} />
        <Route path={`${requestedUrl}/login`} component={lazy(() => import('./login'))} />
      </Switch>
    </Suspense>
  </div>;
};

export default Account;
