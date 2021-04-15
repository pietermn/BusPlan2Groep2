import React from 'react';
import {useLocation, useHistory} from 'react-router-dom';

const Maintenance = () => {
    const location = useLocation();
    const busID = location.state.busID;
    const team = location.state.team;

    return (
        <div className="maintenance">
            <select>
                <option value={0}>Motor problemen</option>
                <option value={1}>Exterieur schade</option>
                <option value={2}>Interieur schade</option>
            </select>
            <textarea placeholder="Omschrijving..." />
            <button>volgende</button>
        </div>
    )
}

export default Maintenance;