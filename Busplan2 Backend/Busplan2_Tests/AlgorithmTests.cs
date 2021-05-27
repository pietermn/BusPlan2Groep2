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
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(1);
            ParkingSpace parkingCheck = container.Read(5);
            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_Free_Fastcharger_Send_To_Fastcharger()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(1);
            ParkingSpace parkingCheck = container.Read(5);
            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_No_Free_Fastcharger_Send_To_Parkinglot()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(2);
            ParkingSpace parkingCheck = container.Read(3);
            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [TestMethod]
        public void If_Bus_Needs_Repair_Adhoc_With_Free_Workspace_Send_To_Workspace()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(3);
            ParkingSpace parkingCheck = container.Read(3);
            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void If_Bus_Needs_Repair_Adhoc_With_No_Free_Workspace_Remove_From_Rotation()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            //update nog implementen hiervoor
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(3);
            ParkingSpace parkingCheck = container.Read(3);
            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void If_Last_Ride_With_Planned_Cleaning_Send_To_Slowcharger()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act

            //datetime staat op 01/01/0001
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(4);
            ParkingSpace parkingCheck = container.Read(4);

            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_Slowcharger_Free_Send_To_Slowcharger()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(5);
            ParkingSpace parkingCheck = container.Read(4);

            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_No_Slowcharger_Free_Send_To_Parkinglot()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act

            //update nog implementen hiervoor
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(5);
            ParkingSpace parkingCheck = container.Read(4);

            //Assert
            try
            {
                Assert.Fail();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_No_Low_Battery_Parkinglot_Free_Send_To_Parkinglot()
        {
            //Arrange
            Algoritmiek algoritmiek = new Algoritmiek();
            ParkingSpaceContainer container = new ParkingSpaceContainer();
            //Act
            ParkingSpace p1 = algoritmiek.GeefParkeerPlaats(6);
            ParkingSpace parkingCheck = container.Read(4);

            //Assert
            try
            {
                Assert.AreEqual(p1, parkingCheck);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
