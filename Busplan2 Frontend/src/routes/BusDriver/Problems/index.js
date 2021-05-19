import React from 'react';
import { useHistory, useLocation } from 'react-router-dom';

const Problems = () => {
    const history = useHistory();
    const location = useLocation();
    const AdhocObj = location.state.AdhocObj

    const handleButton = (option) => {
        if (option == "cleaning") {
            AdhocObj.team = 1;
            history.push("cleaning", { AdhocObj })
        }

        if (option == "maintenance") {
            AdhocObj.team = 2;
            history.push("maintenance", { AdhocObj })
        }

        if (option == "other") {
            AdhocObj.team = 3;
            history.push("other", {AdhocObj})
        }
    }

    return (
        <div className="problems">
            <button onClick={() => handleButton("maintenance")}>Heeft reparatie nodig</button>
            <button onClick={() => handleButton("cleaning")} id="button-2">Heeft schoonmaak nodig</button>
            <button onClick={() => handleButton("other")}>Anders...</button>
        </div>
    )
}

export default Problems;