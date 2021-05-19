import React, { useState } from 'react';
import GreyBus from '../Images/GreyBus.png';
import BackendApi from '../redux/api/BackendApi';
const Coords = require('../components/ParkingSpaceCoords.json');

const PlaceBus = ({ parkingspace }) => {
    const [busNumber, setBusNumber] = useState(0);

    async function GetBusNumber() {
        const response = await BackendApi.get(`/bus/read?busID=${parkingspace.busID}`)
        setBusNumber(response.data.busNumber);
    }
    GetBusNumber();

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
        if (type == 3)
            return FindParkingSpace(4);
        if (type == 4)
            return FindParkingSpace(5);
        if (type == 5 && parkingnumber == 1 || type == 5 && parkingnumber == 2)
            return FindParkingSpace(7)
        if (type == 5)
            return FindParkingSpace(6);
        if (type == 6)
            return FindParkingSpace(8);
        else return FindParkingSpace(type);
    }

    const data = GetCoords(parkingspace.type, parkingspace.number);

    if (parkingspace.type == 0) {
        return (
            <span>
                <img
                    id="left30deg"
                    src={GreyBus}
                    style={{ left: data.x, top: data.y }}
                />
                <p id="left30deg" style={{ left: data.x + 10, top: data.y + 20 }}>{busNumber}</p>
            </span>
        );
    } else if (parkingspace.type == 2 && parkingspace.number == 17 || parkingspace.type == 2 && parkingspace.number == 18 || parkingspace.type == 2 && parkingspace.number == 19 || parkingspace.type == 2 && parkingspace.number == 20 || parkingspace.type == 6) {
        return (
            <span>
                <img
                    id="sideways"
                    src={GreyBus}
                    style={{ left: data.x, top: data.y }}
                />
                <p style={{ left: data.x + 15, top: data.y + 39 }}>{busNumber}</p>
            </span>
        );
    } else if (parkingspace.type == 2) {
        return (
            <span>
                <img
                className="smallerbus"
                    id="right27deg"
                    src={GreyBus}
                    style={{ left: data.x, top: data.y }}
                />
                <p id="right27deg" style={{ left: data.x + 10, top: data.y + 10 }}>{busNumber}</p>
            </span>
        );
    }
    return <span>
        <img src={GreyBus} style={{ left: data.x, top: data.y }} />
        <p style={{ left: data.x + 22, top: data.y + 38 }}>{busNumber}</p>
    </span>;
};

export default PlaceBus;