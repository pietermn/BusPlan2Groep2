import React, { useState, useContext } from "react";
import { BsThreeDotsVertical } from "react-icons/bs";
import { GoPrimitiveDot } from "react-icons/go";
import {Context as BusContext} from '../redux/context/BusContext';
import "../Style/componentstyles.css";

const BusSideBar = ({ Busses }) => {
  const {GetPopup} = useContext(BusContext);

  const BusItem = ({ bus }) => {
    const [openExtended, setOpenExtended] = useState(false);

    // Converts number to color
    const colorFunction = (status) => {
      if (status === 0) return "redBackground";
      else if (status === 1) return "yellowBackground";
      else if (status === 2) return "greenBackground";
      else return "blackBackground";
    };

    const BusExtendedItem = () => {
      return (
        <div className="bus-extended">
          <span id="text-container">
            <p>Batterij niveau</p>
            <p>{bus.batteryLevel}</p>
          </span>
          <span id="text-container">
            <p>Parkeerplaats</p>
            <p>{bus.parkingSpace}</p>
          </span>
          <span id="text-container">
            <p>Type schoonmaak</p>
            <p>Periodiek (test data)</p>
          </span>
        </div>
      );
    };

    return (
      <div className="bus-container">
        <div
          className="bus-item"
          onClick={() => setOpenExtended(!openExtended)}
        >
          <h1>Bus {bus.busNumber}</h1>
          <GoPrimitiveDot
            id="statusIcon"
            className={colorFunction(bus.status)}
          />
          <BsThreeDotsVertical id="dotsIcon" onClick={() => GetPopup(bus)}/>
        </div>
        {openExtended && <BusExtendedItem />}
      </div>
    );
  };

  return (
    <div className="sidebar-container">
      {Busses && Busses.map((value, index) => {
        return <BusItem bus={value} key={index} />;
      })}
    </div>
  );
};

export default BusSideBar;
