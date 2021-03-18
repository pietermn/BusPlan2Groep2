import React from 'react';
import {Redirect, Route, Switch} from 'react-router';
import {useLocation} from 'react-router-dom';
import Home from './Home';

const Routes = () => {
    const location = useLocation();

    if (location.pathname === "" || location.pathname === '/') return <Redirect to={'/home'} />;

    return (
        <div>
            <Switch>
                <Route path="/home" component={Home} />
            </Switch>
        </div>
    )
}

export default Routes;