import React, {useContext, useEffect} from 'react';
import BusSideBar from '../../components/BusSideBar';
import Popup from '../../components/Popup';
import {Context as BusContext} from '../../redux/context/BusContext';
import '../../Style/cleaningstyles.css'

const Cleaning = () => {
    const {state, GetAllBusses} = useContext(BusContext);

    useEffect(() => {
        GetAllBusses();
    }, [])

    return (
        <div className="cleaning_full_page">
            {state.busses && <BusSideBar Busses={state.busses}/>}
            {state.bus &&
                <Popup bus={state.bus} />
            }
        </div>
    )
}

export default Cleaning;