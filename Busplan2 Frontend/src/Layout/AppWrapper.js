import React from "react";
import Footer from "./Footer";
import NavigationBar from "./NavigationBar";

export default function AppWrapper({children}) {
  return (
    <React.Fragment>
      <NavigationBar />
      {children}
      <Footer />
    </React.Fragment>
  );
}
