import React, { useEffect, useContext } from 'react';
import { Context as MaintenanceContext } from '../../../redux/context/MaintenanceContext';
import Table from '../Table';
import AddAdhocButton from '../AddAdhocButton';

const Maintenance = () => {

    const { MaintenanceState, GetAllAdhocMaintenance } = useContext(MaintenanceContext);

    useEffect(() => {
        GetAllAdhocMaintenance();
    }, [])

    return (
        <div className="cleaning-page">
            <AddAdhocButton text="onderhoud" />
            <Table type="Gerepareerd" data={MaintenanceState.adhoc} />
        </div>
    )
}

export default Maintenance;