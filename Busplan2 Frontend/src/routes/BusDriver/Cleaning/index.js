import React from 'react';
import {useLocation, useHistory} from 'react-router-dom';

const Cleaning = () => {
    const location = useLocation();
    const busID = location.state.busID;
    const team = location.state.team;

    return (
        <div className="cleaning">
            <select>
                <option value={3}>Motor problemen</option>
                <option value={4}>Exterieur schade</option>
                <option value={5}>Interieur schade</option>
            </select>
            <textarea placeholder="Omschrijving..." />
            <button>volgende</button>
        </div>
    )
}

export default Cleaning;