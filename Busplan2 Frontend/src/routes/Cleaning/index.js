import React, {useContext} from 'react';
import BusSideBar from '../../components/BusSideBar';
import Popup from '../../components/Popup';
import {Context as BusContext} from '../../redux/context/BusContext';
import '../../Style/cleaningstyles.css'

const Cleaning = () => {
    const {state} = useContext(BusContext);

    return (
        <div className="cleaning_full_page">
            <BusSideBar />
            {state.bus &&
                <Popup bus={state.bus} />
            }
        </div>
    )
}

export default Cleaning;