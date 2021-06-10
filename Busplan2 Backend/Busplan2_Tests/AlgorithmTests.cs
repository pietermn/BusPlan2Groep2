using BusPlan2_DAL.DTOs;
using BusPlan2_DAL.Handlers;
using BusPlan2_Logic;
using BusPlan2_Logic.Containers;
using BusPlan2_Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Busplan2_Tests
{
    [TestClass]
    public class AlgorithmTests
    {

        //In de containers heb ik de handlers veranderd.
        [TestMethod]
        public void If_Bus_Needs_Repair_Go_To_Workplace()
        {
            //Arrange
            BusContainer busContainer = new BusContainer();
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(7);
            //Assert
            Assert.AreEqual(6, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_Free_Fastcharger_Send_To_Fastcharger()
        {
            //Arrange
            BusContainer busContainer = new BusContainer();
            ParkingSpaceTestHandler handler = new ParkingSpaceTestHandler();
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(1);
           
            //Assert
            Assert.AreEqual(2, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_No_Free_Fastcharger_Send_To_Parkinglot()
        {
            //Arrange
            List<ParkingSpaceDTO> parkingLots = new List<ParkingSpaceDTO>();
            parkingLots.Add(new ParkingSpaceDTO(1, 1, 322, 2, true));
            parkingLots.Add(new ParkingSpaceDTO(2, 0, 0, 2, true));
            parkingLots.Add(new ParkingSpaceDTO(3, 0, 0, 0, false));
            parkingLots.Add(new ParkingSpaceDTO(4, 0, 0, 1, false));
            parkingLots.Add(new ParkingSpaceDTO(5, 0, 0, 4, false));
            parkingLots.Add(new ParkingSpaceDTO(6, 0, 0, 3, false));
            parkingLots.Add(new ParkingSpaceDTO(7, 0, 0, 5, false));

            BusContainer busContainer= new BusContainer();
            busContainer.UpdateParkingSpace(parkingLots);
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(2);
            //Assert
            Assert.AreEqual(3, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Bus_Needs_Repair_Adhoc_With_Free_Workspace_Send_To_Workspace()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(3);
            //Assert
            Assert.AreEqual(6, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Bus_Needs_Repair_Adhoc_With_No_Free_Workspace_Remove_From_Rotation()
        {
            //Arrange
            List<ParkingSpaceDTO> parkingLots = new List<ParkingSpaceDTO>();
            parkingLots.Add(new ParkingSpaceDTO(1, 1, 322, 2, true));
            parkingLots.Add(new ParkingSpaceDTO(2, 0, 0, 2, false));
            parkingLots.Add(new ParkingSpaceDTO(3, 0, 0, 0, false));
            parkingLots.Add(new ParkingSpaceDTO(4, 0, 0, 1, false));
            parkingLots.Add(new ParkingSpaceDTO(5, 0, 0, 4, false));
            parkingLots.Add(new ParkingSpaceDTO(6, 0, 0, 3, true));
            parkingLots.Add(new ParkingSpaceDTO(7, 0, 0, 5, false));

            BusContainer busContainer= new BusContainer();
            busContainer.UpdateParkingSpace(parkingLots);
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(3);
            //Assert
            Assert.AreEqual(7, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_With_Planned_Cleaning_Send_To_Slowcharger()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            busContainer.after11oClock = new DateTime(2021, 8, 2, 12, 00, 00);
            busContainer.before5oClock = new DateTime(2021, 8, 2, 18, 00, 00);
            //Act

            //datetime staat op 01/01/0001
            ParkingSpace p1 = busContainer.GiveParkingSpace(4);

            //Assert
            Assert.AreEqual(4, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_Slowcharger_Free_Send_To_Slowcharger()
        {
            //Arrange
            BusContainer busContainer = new BusContainer();
            busContainer.after11oClock = new DateTime(2021, 8, 2, 12, 00, 00);
            busContainer.before5oClock = new DateTime(2021, 8, 2, 18, 00, 00);
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(5);

            //Assert
             Assert.AreEqual(4, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_No_Slowcharger_Free_Send_To_Parkinglot()
        {
            //Arrange
            List<ParkingSpaceDTO> parkingLots = new List<ParkingSpaceDTO>();
            parkingLots.Add(new ParkingSpaceDTO(1, 1, 322, 2, true));
            parkingLots.Add(new ParkingSpaceDTO(2, 0, 0, 2, false));
            parkingLots.Add(new ParkingSpaceDTO(3, 0, 0, 0, false));
            parkingLots.Add(new ParkingSpaceDTO(4, 0, 0, 1, true));
            parkingLots.Add(new ParkingSpaceDTO(5, 0, 0, 4, false));
            parkingLots.Add(new ParkingSpaceDTO(6, 0, 0, 3, false));
            parkingLots.Add(new ParkingSpaceDTO(7, 0, 0, 5, false));

            BusContainer busContainer= new BusContainer();
            busContainer.UpdateParkingSpace(parkingLots);
            
            busContainer.after11oClock = new DateTime(2021, 8, 2, 12, 00, 00);
            busContainer.before5oClock = new DateTime(2021, 8, 2, 18, 00, 00);
            
            //Act
            
            ParkingSpace p1 = busContainer.GiveParkingSpace(5);

            //Assert
            Assert.AreEqual(3, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_No_Low_Battery_Parkinglot_Free_Send_To_Parkinglot()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            busContainer.after11oClock = new DateTime(2021, 8, 2, 12, 00, 00);
            busContainer.before5oClock = new DateTime(2021, 8, 2, 18, 00, 00);
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(6);

            //Assert
            Assert.AreEqual(3, p1.ParkingSpaceID);
        }
    }
}
