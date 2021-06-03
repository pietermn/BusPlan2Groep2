import React from 'react';
import {useHistory} from 'react-router-dom';

const Navbar = () => {
    const history = useHistory();

    return (
        <div className="planner-navbar">
            <ul>
                <li onClick={() => history.push("schoonmaak")}>Schoonmaak</li>
                <li onClick={() => history.push("onderhoud")}>Onderhoud</li>
            </ul>
        </div>
    )
}

export default Navbar