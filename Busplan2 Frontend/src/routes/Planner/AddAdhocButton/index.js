import React, { useContext, useEffect, useState } from 'react';
import AdhocPopup from '../AdhocPopup';
import { Context as BusContext } from '../../../redux/context/BusContext';

const AddAdhocButton = ({ text }) => {
    const { GetAllBusses, BusState } = useContext(BusContext);
    const [openPopup, setOpenPopup] = useState(false);

    useEffect(() => {
        GetAllBusses();
    }, [])

    const optionsMaintenance = [
        {
            name: "Motor problemen",
            number: 0,
        },
        {
            name: "Exterieur schade",
            number: 1,
        },
        {
            name: "Interieur schade",
            number: 2,
        },
    ];

    const optionsCleaning = [
        {
            name: "Exterieur schoonmaak",
            number: 3,
        },
        {
            name: "interieur schoonmaak",
            number: 4,
        },
        {
            name: "vloer schoonmaak",
            number: 5,
        },
    ];

    function closePopup() {
        setOpenPopup(false);
    }

    return (
        <div>
            {openPopup && text == "onderhoud" && <AdhocPopup text={text} options={optionsMaintenance} busses={BusState.busses} closePopup={() => closePopup()} />}
            {openPopup && text == "schoonmaak" && <AdhocPopup text={text} options={optionsCleaning} busses={BusState.busses} closePopup={() => closePopup()} />}
            <div className="addAdhoc-button" onClick={() => setOpenPopup(!openPopup)}>
                {text} toevoegen
            </div>
        </div>
    )
}

export default AddAdhocButton;