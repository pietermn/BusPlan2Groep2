import React, {useState, useContext} from 'react';
import {useLocation, useHistory} from 'react-router-dom';
import {Context as BusContext} from '../../../redux/context/BusContext';

const Cleaning = () => {
    const location = useLocation();
    const history = useHistory();
    const AdhocObj = location.state.AdhocObj;
    const [currentSelected, setCurrentSelected] = useState(3);
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
                <option value={3}>Exterieur Schoonmaak</option>
                <option value={4}>Interieur Schoonmaak</option>
                <option value={5}>Vloer Schoonmaak</option>
            </select>
            <textarea  onChange={(e) => setDescription(e.target.value)} placeholder="Omschrijving..." />
            <button onClick={() => handleButton()}>volgende</button>
        </div>
    )
}

export default Cleaning;