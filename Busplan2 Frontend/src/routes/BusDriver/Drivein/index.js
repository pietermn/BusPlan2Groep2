import React, {useContext} from 'react';
import {useLocation, useHistory} from 'react-router-dom';
import {Context as BusContext} from "../../../redux/context/BusContext";

const Drivein = () => {
    const location = useLocation();
    const history = useHistory();
    const AdhocObj = location.state.AdhocObj;
    const {GiveParkingSpaceWithoutAdhoc} = useContext(BusContext);

    const handleNoProblems = () => {
        const busID = parseInt(AdhocObj.busID);

        GiveParkingSpaceWithoutAdhoc(busID, history);
    }

    return (
        <div className="drivein" >
            <h1>Welkom Bus {AdhocObj.busID}</h1>
            <button onClick={() => handleNoProblems()} id="no-problems">Geen problemen</button>
            <button onClick={() => history.push('problems', {AdhocObj})} id="problems">Problemen</button>
        </div>
    )
}

export default Drivein;