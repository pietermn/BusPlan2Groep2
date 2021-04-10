import React, { useContext, useEffect } from "react";
import { useLocation } from "react-router";
import BusSideBar from "../../components/BusSideBar";
import Popup from "../../components/Popup";
import { Context as BusContext } from "../../redux/context/BusContext";
import "../../Style/busPagesStyles.css";

const Cleaning = () => {
  const { BusState, GetAllBusses } = useContext(BusContext);
  const location = useLocation();

  useEffect(() => {
    GetAllBusses();
  }, []);

  return (
    <div className="cleaning_full_page">
      {BusState.busses && <BusSideBar Busses={BusState.busses} />}
      {BusState.buspopup && <Popup bus={BusState.buspopup} path={location.pathname} />}
      <div className="busmap"></div>
    </div>
  );
};

export default Cleaning;
