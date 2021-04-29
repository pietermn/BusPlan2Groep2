import React, { useEffect, useContext } from 'react';
import { useLocation, useHistory } from 'react-router-dom';
import PlaceBus from '../../../components/PlaceBus';
import { Context as BusContext } from '../../../redux/context/BusContext';


const Driveto = () => {

    const { BusState } = useContext(BusContext);
    useEffect(() => {

    })
    console.log(BusState.DriveTo);
    return (
        <div>
            <h1 style={{position: 'absolute', left: "50%"}}>Drive to P{BusState.DriveTo.number}</h1>
            <div className="busmap">
                <div className="grid">
                    <div id="busImage">
                        {BusState.DriveTo && <span>
                            <PlaceBus parkingspace={BusState.DriveTo} />
                        </span>}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Driveto;