import React, { useContext, useEffect } from "react";
import BusSideBar from "../../components/BusSideBar";
import { Context as BusContext } from "../../redux/context/BusContext";
import "../../Style/busPagesStyles.css";

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
            <div id="busImage"></div>
          </div>
      </div>
    </div>
  );
};

export default Overview;