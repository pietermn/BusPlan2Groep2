import React, { useContext, useEffect } from "react";
import BusSideBar from "../../components/BusSideBar";
import { Context as BusContext } from "../../redux/context/BusContext";
import Draggable, { DraggableCore } from "react-draggable";
import "../../Style/busPagesStyles.css";

const Overview = () => {
  const { state, GetAllBusses } = useContext(BusContext);

  useEffect(() => {
    GetAllBusses();
  }, []);

  return (
    <div className="overview_full_page">
      {state.busses && <BusSideBar Busses={state.busses} />}
      <Draggable position={{ x: 0, y: 0 }}>
        <p style={{position: "absolute"}}>Drag</p>
      </Draggable>
      <div className="busmap"></div>
    </div>
  );
};

export default Overview;
