import React, { useState, useContext } from 'react';
import {useLocation, useHistory} from 'react-router-dom';
import {Context as BusContext} from '../../../redux/context/BusContext';

const Maintenance = () => {
    const location = useLocation();
    const history = useHistory();
    const AdhocObj = location.state.AdhocObj;
    const [currentSelected, setCurrentSelected] = useState(0);
    const [description, setDescription] = useState('');
    const {CreateAdhoc} = useContext(BusContext);

    const handleButton = () => {
        AdhocObj.type = parseInt(currentSelected);
        AdhocObj.description = description;

        CreateAdhoc(AdhocObj, history);
    }

    return (
        <div className="Dropdown-page">
            <select onChange={(e) => setCurrentSelected(e.target.value)}>
                <option value={0}>Motor problemen</option>
                <option value={1}>Exterieur schade</option>
                <option value={2}>Interieur schade</option>
            </select>
            <textarea onChange={(e) => setDescription(e.target.value)} placeholder="Omschrijving..." />
            <button onClick={() => handleButton()}>volgende</button>
        </div>
    )
}

export default Maintenance;