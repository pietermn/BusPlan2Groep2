import React, { useContext } from "react";
import { Context as BusContext } from "../redux/context/BusContext";
import { ImCross } from "react-icons/im";

const Popup = ({ bus, path }) => {
  const { DeletePopup } = useContext(BusContext);

  const CleaningPopup = () => {
    const options = [
      {
        name: "schoonmaak nodig",
        number: 0,
      },
      {
        name: "wordt schoongemaakt",
        number: 1,
      },
      {
        name: "schoongemaakt",
        number: 2,
      },
    ];

    return (
      <div className="popup-container">
        <ImCross id="delete-icon" onClick={() => DeletePopup()} />
        <h1>Bus {bus.number}</h1>
        <span id="doneby">
          <p id="title-text">Batterij niveau</p>
          <p id="info-text">{bus.batteryLevel}</p>
        </span>
        <span id="status">
          <p id="title-text">Status:</p>
          <select>
            {options.map((value, index) => {
              return (
                <option key={index} value={value.number}>
                  {value.name}
                </option>
              );
            })}
          </select>
        </span>
        <span id="date">
          <p id="title-text">Schoongemaakt op:</p>
          <p id="info-text">{bus.periodicCleaning}</p>
        </span>
      </div>
    );
  };

  const MaintenancePopup = () => {
    const options = [
      {
        name: "reparatie nodig",
        number: 0,
      },
      {
        name: "wordt gerepareerd",
        number: 1,
      },
      {
        name: "gerepareerd",
        number: 2,
      },
    ];

    return (
      <div className="popup-container">
        <ImCross id="delete-icon" onClick={() => DeletePopup()} />
        <h1>Bus {bus.number}</h1>
        <span id="doneby">
          <p id="title-text">Batterij niveau</p>
          <p id="info-text">{bus.batteryLevel}</p>
        </span>
        <span id="status">
          <p id="title-text">Status:</p>
          <select>
            {options.map((value, index) => {
              return (
                <option key={index} value={value.number}>
                  {value.name}
                </option>
              );
            })}
          </select>
        </span>
        <span id="date">
          <p id="title-text">Gerepareerd op:</p>
          <p id="info-text">{bus.periodicMaintenance}</p>
        </span>
      </div>
    );
  };

  const OverviewPopup = () => {
    return (
      <div className="popup-container">
        <ImCross id="delete-icon" onClick={() => DeletePopup()} />
        <h1>Bus {bus.busNumber}</h1>
        <span id="doneby">
          <p id="title-text">Batterij niveau</p>
          <p id="info-text">{bus.batteryLevel}</p>
        </span>
        <span id="date">
          <p id="title-text">Laatste Periodiek onderhoud</p>
          <p id="info-text">{bus.periodicMaintenance}</p>
        </span>
        <span id="date">
          <p id="title-text">Laatste Periodieke schoonmaak</p>
          <p id="info-text">{bus.periodicCleaning}</p>
        </span>
        <span id="date">
          <p id="title-text">Parkeerplaats:</p>
          <input />
        </span>
      </div>
    );
  }

  if (path == "/schoonmaak") return <CleaningPopup />;
  if (path == "/monteur") return <MaintenancePopup />;
  if (path == "/overzicht") return <OverviewPopup />;
};

export default Popup;
