import React from 'react';
import {Redirect, Route, Switch} from 'react-router';
import {useLocation} from 'react-router-dom';
import Account from './Account';
import Cleaning from './Cleaning';

const Routes = () => {
    const location = useLocation();

    if (location.pathname === "" || location.pathname === '/') return <Redirect to={'/schoonmaak'} />;

    return (
        <div>
            <Switch>
                <Route path="/account" component={Account} />
                <Route path="/schoonmaak" component={Cleaning} />
            </Switch>
        </div>
    )
}

export default Routes;