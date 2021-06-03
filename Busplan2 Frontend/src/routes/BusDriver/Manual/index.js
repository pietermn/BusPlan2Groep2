import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import BackendApi from "../../../redux/api/BackendApi";

const Manual = () => {
    const [busID, setBusID] = useState('');
    const history = useHistory();
    const [busExists, setBusExists] = useState('placeholder');

    const AdhocObj = {
        busID: "",
        type: "",
        team: "",
        description: "",
    }

    async function DoesBusExist() {
        try {
            const response = await BackendApi.get(`/bus/read?busID=${busID}`)
            if (!response.data) {
                return false;
            } else {
                return true;
            }
        } catch {
            console.log("Something went wrong")
        }
    }

    const handleNumberButton = async (char) => {
        if (char == "C") {
            setBusID("");
        }

        else if (char == "->") {
            AdhocObj.busID = parseInt(busID);
            var exists = await DoesBusExist(AdhocObj.busID)
            console.log(exists);
            setBusExists(exists);
            if (exists) {
                history.push('drivein', { AdhocObj });
            }

            setTimeout(() => {
                setBusExists("placeholder");
            }, 4000);
        }

        else if (busID.length != 2) {
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
            <h1 style={{ color: "white" }}>Bus Identificatie nummer</h1>
            <input maxLength={2} value={busID} onChange={(e) => { setBusID(e.target.value) }} />
            <div className="number-container">
                {
                    buttons.map((value, index) => {
                        return <NumberButton number={value} key={index} />
                    })
                }
            </div>
            {busExists == false && <p style={{marginTop: 80, fontSize: 22, fontWeight: 700, color: "red"}}>Ingevoerde bus bestaat niet</p>}
        </div>
    )
}

export default Manual;