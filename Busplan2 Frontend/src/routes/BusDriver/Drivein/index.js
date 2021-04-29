import React from 'react';
import {useLocation, useHistory} from 'react-router-dom';

const Drivein = () => {
    const location = useLocation();
    const history = useHistory();
    const AdhocObj = location.state.AdhocObj;

    return (
        <div className="drivein" >
            <h1>Welkom Bus {AdhocObj.busID}</h1>
            <button onClick={() => history.push('driveto', {AdhocObj})} id="no-problems">Geen problemen</button>
            <button onClick={() => history.push('problems', {AdhocObj})} id="problems">Problemen</button>
        </div>
    )
}

export default Drivein;