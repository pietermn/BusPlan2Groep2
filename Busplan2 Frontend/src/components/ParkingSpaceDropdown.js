import React from 'react';
const Coords = require("../components/ParkingSpaceCoords.json");

const ParkingSpaceDropdown = ({ spaces }) => {

    const SelectDecider = ({ space }) => {
        if (space.type == 0) {
            for (var i = 0; i < Coords[space.type].parkingspaces.length; i++) {
                if (space.number == Coords[space.type].parkingspaces[i].parkingNumber) {
                    return <option value={space.parkingSpaceID}>Normaal P{space.number}</option>
                }
            }
        } else if (space.type == 1) {
            for (var i = 0; i < Coords[space.type].parkingspaces.length; i++) {
                if (space.number == Coords[space.type].parkingspaces[i].parkingNumber) {
                    return <option value={space.parkingSpaceID}>Snellader P{space.number}</option>
                }
            }
        } else if (space.type == 2) {
            for (var i = 0; i < Coords[space.type].parkingspaces.length; i++) {
                if (space.number == Coords[space.type].parkingspaces[i].parkingNumber) {
                    return <option value={space.parkingSpaceID}>Langzaamlader P{space.number}</option>
                }
            }
            for (var i = 0; i < Coords[3].parkingspaces.length; i++) {
                if (space.number == Coords[3].parkingspaces[i].parkingNumber) {
                    return <option value={space.parkingSpaceID}>Langzaamlader P{space.number}</option>
                }
            }
        }
        else return null;
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