import React, { useContext } from 'react';
import { Context as ParkingSpaceContext } from '../redux/context/ParkingSpaceContext';
import { Context as BusContext } from '../redux/context/BusContext';

const ParkingSpaceDropdown = ({ spaces, BusID, currentParkingSpaceID }) => {

    
    const { MoveBus, GetOverviewSpaces } = useContext(ParkingSpaceContext)
    const {DeletePopup} = useContext(BusContext)
    
    async function UpdateBus(MoveInfo) {
        var UpdateInfo = MoveInfo;
        UpdateInfo.newParkingID = parseInt(UpdateInfo.newParkingID);
        await MoveBus(UpdateInfo);
        await GetOverviewSpaces();
        await DeletePopup();
    }

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
        <select onChange={(e) => { UpdateBus({ newParkingID: e.target.value, currentParkingID: currentParkingSpaceID, BusID }); GetOverviewSpaces() }}>
            <option></option>
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