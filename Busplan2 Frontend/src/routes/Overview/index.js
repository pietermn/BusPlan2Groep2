import React, { useContext, useEffect } from "react";
import BusSideBar from "../../components/BusSideBar";
import { Context as BusContext } from "../../redux/context/BusContext";
import GreyBus from "../../Images/GreyBus.png";
import "../../Style/busPagesStyles.css";
const Coords = require("../../components/ParkingSpaceCoords.json");

const Overview = () => {
  const { state, GetAllBusses } = useContext(BusContext);
  useEffect(() => {
    GetAllBusses();
  }, []);

  return (
    <div className="overview_full_page">
      {state.busses && <BusSideBar Busses={state.busses} />}
      <div className="busmap">
        <div className="grid">
          <div id="busImage">
            {Coords[0].parkingspaces.map((value, index) => {
              return (
                <img
                  key={index}
                  id="normal"
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[1].parkingspaces.map((value, index) => {
              return (
                <img
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[2].parkingspaces.map((value, index) => {
              return (
                <img
                  id="slow"
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[3].parkingspaces.map((value, index) => {
              return (
                <img
                  id="sideways"
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[4].parkingspaces.map((value, index) => {
              return (
                <img
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[5].parkingspaces.map((value, index) => {
              return (
                <img
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[6].parkingspaces.map((value, index) => {
              return (
                <img
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[7].parkingspaces.map((value, index) => {
              return (
                <img
                id="sideways"
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
            {Coords[8].parkingspaces.map((value, index) => {
              return (
                <img
                id="sideways"
                  key={index}
                  src={GreyBus}
                  style={{ left: value.x, top: value.y }}
                />
              );
            })}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Overview;
