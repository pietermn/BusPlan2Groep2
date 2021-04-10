import React, { useContext, useEffect } from "react";
import BusSideBar from "../../components/BusSideBar";
import { Context as ParkingSpaceContext } from "../../redux/context/ParkingSpaceContext";
import { Context as BusContext } from "../../redux/context/BusContext";
import GreyBus from "../../Images/GreyBus.png";
import "../../Style/busPagesStyles.css";
import Popup from "../../components/Popup";
import { useLocation } from "react-router";
const Coords = require("../../components/ParkingSpaceCoords.json");

const Overview = () => {
  const { ParkingSpaceState, GetParkingSpaces } = useContext(
    ParkingSpaceContext
  );
  const { GetOneBusPopup, BusState } = useContext(BusContext);

  const location = useLocation();

  useEffect(() => {
    GetParkingSpaces();
  }, []);

  const PlaceBus = ({ parkingspace }) => {
    function GetCoords(type, parkingnumber) {
      for (var i = 0; i < Coords[type].parkingspaces.length; i++) {
        if (parkingnumber == Coords[type].parkingspaces[i].parkingNumber) {
          const data = {
            x: Coords[type].parkingspaces[i].x,
            y: Coords[type].parkingspaces[i].y,
          };
          return data;
        }
      }
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

  return (
    <div className="overview_full_page">
      <BusSideBar />
      {BusState.buspopup && <Popup path={location.pathname} bus={BusState.buspopup}/>}
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
