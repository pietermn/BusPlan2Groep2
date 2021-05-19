import React from 'react';

const Navbar = ({func}) => {
    return (
        <div className="planner-navbar">
            <ul>
                <li onClick={() => func(0)}>Schoonmaak</li>
                <li onClick={() => func(1)}>Onderhoud</li>
            </ul>
        </div>
    )
}

export default Navbar