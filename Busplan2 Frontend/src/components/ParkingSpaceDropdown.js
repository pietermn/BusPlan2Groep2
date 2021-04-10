import React from 'react';
const Coords = require("../components/ParkingSpaceCoords.json");

const ParkingSpaceDropdown = ({ spaces }) => {

    const SelectDecider = ({ space }) => {
        if (space.type == 0)
            return <option value={space.parkingSpaceID}>Normaal P{space.number}</option>
        if (space.type == 1)
            return <option value={space.parkingSpaceID}>Snellader P{space.number}</option>
        if (space.type == 2)
            return <option value={space.parkingSpaceID}>Langzaamlader P{space.number}</option>
        if (space.type == 3)
            return <option value={space.parkingSpaceID}>Onderhoud P{space.number}</option>
        if (space.type == 4)
            return <option value={space.parkingSpaceID}>Wasstraat P{space.number}</option>
        if (space.type == 5)
            return <option value={space.parkingSpaceID}>Buitengebruik P{space.number}</option>
        if (space.type == 6)
            return <option value={space.parkingSpaceID}>Reservemateriaal P{space.number}</option>
    }

    return (
        <select>
            {
                spaces.map((value, index) => {
                    return (
                        <SelectDecider key={index} space={value} />
                    )
                })
            }
        </select>
    )
}

export default ParkingSpaceDropdown;