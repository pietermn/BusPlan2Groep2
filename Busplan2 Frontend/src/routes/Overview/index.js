import React, { useContext, useEffect } from "react";
import BusSideBar from "../../components/BusSideBar";
import { Context as ParkingSpaceContext } from "../../redux/context/ParkingSpaceContext";
import { Context as BusContext } from "../../redux/context/BusContext";
import "../../Style/busPagesStyles.css";
import Popup from "../../components/Popup";
import { useLocation } from "react-router";
import PlaceBus from '../../components/PlaceBus';

const Overview = () => {
  const { ParkingSpaceState, GetOverviewSpaces } = useContext(
    ParkingSpaceContext
  );
  const { GetOneBusPopup, BusState, GetAllBusses } = useContext(BusContext);

  const location = useLocation();

  useEffect(() => {
    GetOverviewSpaces();
    GetAllBusses();
  }, []);

  return (
    <div className="overview_full_page">
      {BusState.busses && <BusSideBar Busses={BusState.busses} />}
      {BusState.buspopup && <Popup path={location.pathname} bus={BusState.buspopup} />}
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

export default Overview;
