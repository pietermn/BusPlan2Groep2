import React, { useState, useContext } from "react";
import { BsThreeDotsVertical } from "react-icons/bs";
import { GoPrimitiveDot } from "react-icons/go";
import {Context as BusContext} from '../redux/context/BusContext';
import "../Style/componentstyles.css";

const BusSideBar = ({ Bus }) => {
  const Busses = [
    {
      number: 14,
      status: 1,
      date: '3-25-2021',
      extendedInfo: {
        cleanedby: "Noah",
        parkingplace: 12,
        kindOfCleaning: "Periodiek",
      },
    },
    {
      number: 11,
      status: 3,
      date: '3-25-2021',
      extendedInfo: {
        cleanedby: "Noah",
        parkingplace: 15,
        kindOfCleaning: "Periodiek",
      },
    },
    {
      number: 19,
      status: 2,
      date: '3-25-2021',
      extendedInfo: {
        cleanedby: "Noah",
        parkingplace: 15,
        kindOfCleaning: "Periodiek",
      },
    },
  ];

  const {GetPopup} = useContext(BusContext);

  const BusItem = ({ bus }) => {
    const [openExtended, setOpenExtended] = useState(false);

    // Converts number to color
    const colorFunction = (status) => {
      if (status === 1) return "greenBackground";
      else if (status === 2) return "yellowBackground";
      else if (status === 3) return "redBackground";
      else return "blackBackground";
    };

    const BusExtendedItem = () => {
      return (
        <div className="bus-extended">
          <span id="text-container">
            <p>Schoongemaakt</p>
            <p>{bus.extendedInfo.cleanedby}</p>
          </span>
          <span id="text-container">
            <p>Parkeerplaats</p>
            <p>{bus.extendedInfo.parkingplace}</p>
          </span>
          <span id="text-container">
            <p>Type schoonmaak</p>
            <p>{bus.extendedInfo.kindOfCleaning}</p>
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
          <h1>Bus {bus.number}</h1>
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
      {Busses.map((value, index) => {
        return <BusItem bus={value} key={index} />;
      })}
    </div>
  );
};

export default BusSideBar;
