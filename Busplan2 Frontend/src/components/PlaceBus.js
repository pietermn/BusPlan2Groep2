import React from 'react';
import GreyBus from '../Images/GreyBus.png';
const Coords = require('../components/ParkingSpaceCoords.json');

const PlaceBus = ({ parkingspace }) => {
    if (!parkingspace.occupied) return null;

    function GetCoords(type, parkingnumber) {

        function FindParkingSpace(jsontype) {
            for (var i = 0; i < Coords[jsontype].parkingspaces.length; i++) {
                if (parkingnumber == Coords[jsontype].parkingspaces[i].parkingNumber) {
                    const data = {
                        x: Coords[jsontype].parkingspaces[i].x,
                        y: Coords[jsontype].parkingspaces[i].y,
                    };
                    return data;
                }
            }
        }

        if (type == 2 && parkingnumber == 17 || type == 2 && parkingnumber == 18 || type == 2 && parkingnumber == 19 || type == 2 && parkingnumber == 20)
            return FindParkingSpace(3);
        if (type == 5 && parkingnumber == 1 || type == 5 && parkingnumber == 2)
            return FindParkingSpace(7)
        if (type == 6)
            return FindParkingSpace(8);
        else return FindParkingSpace(type);
    }

    const data = GetCoords(parkingspace.type, parkingspace.number);

    if (parkingspace.type == 0) {
        return (
            <img
                id="left30deg"
                src={GreyBus}
                style={{ left: data.x, top: data.y }}
            />
        );
    } else if (parkingspace.type == 2 && parkingspace.number == 17 || parkingspace.type == 2 && parkingspace.number == 18 || parkingspace.type == 2 && parkingspace.number == 19 || parkingspace.type == 2 && parkingspace.number == 20) {
        return (
            <img
                id="sideways"
                src={GreyBus}
                style={{ left: data.x, top: data.y }}
            />
        );
    } else if (parkingspace.type == 2) {
        return (
            <img
                id="right27deg"
                src={GreyBus}
                style={{ left: data.x, top: data.y }}
            />
        );
    }
    return <img src={GreyBus} style={{ left: data.x, top: data.y }} />;
};

export default PlaceBus;