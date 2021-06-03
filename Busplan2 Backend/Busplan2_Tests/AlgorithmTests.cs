using BusPlan2_DAL.Handlers;
using BusPlan2_Logic;
using BusPlan2_Logic.Containers;
using BusPlan2_Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            ParkingSpace p1 = busContainer.GiveParkingSpace(1);
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
            Assert.AreEqual(6, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_No_Free_Fastcharger_Send_To_Parkinglot()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
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
            BusContainer busContainer= new BusContainer();
            //Act
            //update nog implementen hiervoor
            ParkingSpace p1 = busContainer.GiveParkingSpace(3);
            //Assert
            Assert.AreEqual(7, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_With_Planned_Cleaning_Send_To_Slowcharger()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            //Act

            //datetime staat op 01/01/0001
            ParkingSpace p1 = busContainer.GiveParkingSpace(4);

            //Assert
            Assert.AreEqual(2, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_Slowcharger_Free_Send_To_Slowcharger()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(5);

            //Assert
             Assert.AreEqual(4, p1.ParkingSpaceID);
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_No_Slowcharger_Free_Send_To_Parkinglot()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            //Act

            //update nog implementen hiervoor
            ParkingSpace p1 = busContainer.GiveParkingSpace(5);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_No_Low_Battery_Parkinglot_Free_Send_To_Parkinglot()
        {
            //Arrange
            BusContainer busContainer= new BusContainer();
            //Act
            ParkingSpace p1 = busContainer.GiveParkingSpace(6);

            //Assert
            Assert.AreEqual(4, p1.ParkingSpaceID);
        }
    }
}
