import React from 'react';
import { useHistory, useLocation } from 'react-router-dom';

const Problems = () => {
    const history = useHistory();
    const location = useLocation();
    const busID = location.state.busID

    const handleButton = (option) => {
        if (option == "cleaning") {
            history.push("cleaning", { busID, team: 1 })
        }

        if (option == "maintenance") {
            history.push("maintenance", { busID, team: 2 })
        }

        if (option == "other") {
            history.push("other", {busID, team: 3})
        }
    }

    return (
        <div className="problems">
            <button onClick={() => handleButton("maintenance")}>Heeft reparatie nodig</button>
            <button onClick={() => handleButton("cleaning")} id="button-2">Heeft schoonmaak nodig</button>
            <button>Anders...</button>
        </div>
    )
}

export default Problems;