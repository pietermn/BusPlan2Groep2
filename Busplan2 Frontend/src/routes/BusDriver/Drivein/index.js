import React from 'react';
import {useLocation, useHistory} from 'react-router-dom';

const Drivein = () => {
    const location = useLocation();
    const history = useHistory();
    const busID = location.state.busID;

    return (
        <div className="drivein" >
            <h1>Welkom Bus {busID}</h1>
            <button onClick={() => history.push('driveto', {busID})} id="no-problems">Geen problemen</button>
            <button onClick={() => history.push('problems', {busID})} id="problems">Problemen</button>
        </div>
    )
}

export default Drivein;