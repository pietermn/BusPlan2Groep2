import React, { useState, useContext, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { BsThreeDotsVertical } from "react-icons/bs";
import { GoPrimitiveDot } from "react-icons/go";
import { Context as BusContext } from "../redux/context/BusContext";
import "../Style/componentstyles.css";
import Error404 from "../routes/ExtraPages/404";

const BusSideBar = ({ Busses }) => {
  const location = useLocation();
  const { BusState, GetAllBusses, GetPopup } = useContext(BusContext);

  useEffect(() => {
    GetAllBusses();
  }, []);

  const BusItemCleaning = ({ bus }) => {
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
          <BsThreeDotsVertical id="dotsIcon" onClick={() => GetPopup(bus)} />
        </div>
        {openExtended && <BusExtendedItem />}
      </div>
    );
  };

  const BusItemMaintenance = ({ bus }) => {
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
            <p>Type reparatie</p>
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
          <BsThreeDotsVertical id="dotsIcon" onClick={() => GetPopup(bus)} />
        </div>
        {openExtended && <BusExtendedItem />}
      </div>
    );
  };

  const BusItemOverview = ({ bus }) => {
    return (
      <div className="bus-container">
        <div className="bus-item">
          <h1>Bus {bus.busNumber}</h1>
          <h1 style={{ marginLeft: "auto", marginRight: 15 }}>
            P{bus.parkingSpace}
          </h1>
        </div>
      </div>
    );
  };

  const BusItemDecider = ({ bus }) => {
    switch (location.pathname) {
      case "/overzicht":
        return <BusItemOverview bus={bus} />;
      case "/schoonmaak":
        return <BusItemCleaning bus={bus} />;
      case "/monteur":
        return <BusItemMaintenance bus={bus} />;
      default:
        return <Error404 />;
    }
  };

  return (
    <div className="sidebar-container">
      {BusState.busses &&
        BusState.busses.map((value, index) => {
          return <BusItemDecider bus={value} key={index} />;
        })}
    </div>
  );
};

export default BusSideBar;
