import React, {useContext} from 'react';
import {Context as BusContext} from '../redux/context/BusContext';
import { ImCross } from 'react-icons/im';

const Popup = ({bus}) => {
    const {DeletePopup} = useContext(BusContext)

    return (
        <div className="popup-container">
            <ImCross id="delete-icon" onClick={() => DeletePopup()}/>
            <h1>Bus {bus.number}</h1>
            <span id="doneby">
                <p id="title-text">Schoongemaakt door</p>
                <p id="info-text">{bus.extendedInfo.cleanedby}</p>
            </span>
            <span id="status">
                <p id="title-text">Status:</p>
                <p id="info-text">{bus.status}</p>
            </span>
            <span id="date">
                <p id="title-text">Schoongemaakt op:</p>
                <p id="info-text">{bus.date}</p>
            </span>
        </div>
    )
}

export default Popup;