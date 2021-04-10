import React, { useContext, useEffect } from "react";
import { useLocation } from "react-router";
import BusSideBar from "../../components/BusSideBar";
import Popup from "../../components/Popup";
import { Context as BusContext } from "../../redux/context/BusContext";
import { Context as ParkingSpaceContext } from "../../redux/context/ParkingSpaceContext";
import PlaceBus from '../../components/PlaceBus';
import "../../Style/busPagesStyles.css";

const Maintenance = () => {
  const { BusState, GetAllMaintenanceBusses, GetOneBusPopup } = useContext(BusContext);
  const { ParkingSpaceState, GetMaintenanceSpaces } = useContext(
    ParkingSpaceContext
  );
  const location = useLocation();

  useEffect(() => {
    GetAllMaintenanceBusses();
    GetMaintenanceSpaces();
  }, []);

  return (
    <div className="cleaning_full_page">
      {BusState.busses && <BusSideBar Busses={BusState.busses} />}
      {BusState.buspopup && <Popup bus={BusState.buspopup} path={location.pathname} />}
      <div className="busmap">
        <div className="grid">
          <div id="busImage">
            {ParkingSpaceState.parkingspaces &&
              ParkingSpaceState.parkingspaces.map((value, index) => {
                return <span key={index} onClick={() => GetOneBusPopup(value.busID)}>
                  <PlaceBus parkingspace={value} />
                </span>
              })}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Maintenance;
