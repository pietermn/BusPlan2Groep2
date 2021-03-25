import React from 'react';
import {Redirect, Route, Switch} from 'react-router';
import {useLocation} from 'react-router-dom';
import Home from './Home';
import Account from './Account';
import Cleaning from './Cleaning';

const Routes = () => {
    const location = useLocation();

    if (location.pathname === "" || location.pathname === '/') return <Redirect to={'/cleaning'} />;

    return (
        <div>
            <Switch>
                <Route path="/home" component={Home} />
                <Route path="/account" component={Account} />
                <Route path="/cleaning" component={Cleaning} />
            </Switch>
        </div>
    )
}

export default Routes;