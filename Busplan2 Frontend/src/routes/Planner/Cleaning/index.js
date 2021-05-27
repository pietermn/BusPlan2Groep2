import React, { useContext, useEffect } from 'react';
import Table from '../Table';
import { Context as CleaningContext } from '../../../redux/context/CleaningContext';
import AddAdhocButton from '../AddAdhocButton';

const Cleaning = () => {
    const { GetAllAdhocCleaning, CleaningState } = useContext(CleaningContext);

    useEffect(() => {
        GetAllAdhocCleaning();
    }, [])

    return (
        <div className="cleaning-page">
            <AddAdhocButton text="schoonmaak"/>
            {CleaningState.adhoc && <Table type="Schoongemaakt" data={CleaningState.adhoc} />}
        </div>
    )
}

export default Cleaning;