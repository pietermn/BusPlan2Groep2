import React, { useState, useContext } from 'react';
import { Context as BusContext } from '../../../redux/context/BusContext';
import { ImCross } from 'react-icons/im';

const AdhocPopup = ({ options, busses, text, closePopup }) => {
    const { PlannerCreateAdhoc } = useContext(BusContext);

    const [busID, setBusID] = useState(busses[0].busID);
    const [type, setType] = useState(options[0].number);
    const [description, setDescription] = useState("");

    function handleAddAdhoc() {
        var team;
        if (text == "schoonmaak") team = 1;
        if (text == "onderhoud") team = 2;

        var adhoc = {
            busID: parseInt(busID),
            type: parseInt(type),
            team,
            description: description
        }
        PlannerCreateAdhoc(adhoc);
        window.location.reload();
        closePopup();
    }

    return (
        <div className="adhoc-popup">
            <div onClick={() => closePopup()}><ImCross id="close-icon"  /></div>
            <span className="busid-container">
                <h4>Selecteer bus om {text} aan toe te voegen</h4>
                <select value={busID} onChange={(e) => setBusID(e.target.value)}>
                    {busses && busses.map((bus) => {
                        return (
                            <option key={bus.busID} value={bus.busID}>Bus ID: {bus.busID}, Bus Nummber: {bus.busNumber}</option>
                        )
                    })}
                </select>
            </span>
            <span className="type-container">
                <h4>Selecteer soort {text}</h4>
                <select value={type} onChange={(e) => setType(e.target.value)}>
                    {options.map(option => {
                        return (
                            <option key={option.number} value={option.number}>{option.name}</option>
                        )
                    })}
                </select>
            </span>
            <span className="description-container">
                <h4>Uitleg over het soort {text}</h4>
                <textarea onChange={(e) => setDescription(e.target.value)} />
            </span>
            <button onClick={() => handleAddAdhoc()}>Voeg {text} toe</button>
        </div >
    )
}

export default AdhocPopup;