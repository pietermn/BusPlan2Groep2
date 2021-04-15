import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

const Manual = () => {
    const [busID, setBusID] = useState('');
    const history = useHistory();

    const handleNumberButton = (char) => {
        if (char == "C") {
            setBusID("");
        }

        if (char == "->") {
            history.push('drivein', {busID: busID});
        }

        if (busID.length != 2) {
            setBusID(busID + char);
        }
    }

    const NumberButton = ({ number }) => {
        return (
            <div onClick={() => handleNumberButton(number)} className="numberbutton">
                {number}
            </div>
        )
    }

    var buttons = [1, 2, 3, 4, 5, 6, 7, 8, 9, "C", 0, "->"]

    return (
        <div className="manual">
            <h1 style={{color: "white"}}>Bus Identificatie nummer</h1>
            <input maxLength={2} value={busID} onChange={(e) => { setBusID(e.target.value) }} />
            <div className="number-container">
                {
                    buttons.map((value, index) => {
                        return <NumberButton number={value} key={index} />
                    })
                }
            </div>
        </div>
    )
}

export default Manual;