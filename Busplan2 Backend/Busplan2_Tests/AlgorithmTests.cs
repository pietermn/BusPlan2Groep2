using BusPlan2_Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Busplan2_Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void If_Bus_Needs_Repair_Go_To_Workplace()
        {
            //Arrange
            Bus bus = new Bus(1, new System.DateTime(), new System.DateTime(), new System.DateTime(), new System.DateTime(), 322, 1, BusPlan2_Logic.Enums.BusStatusEnum.NeedsMaintenance, 0);
            ParkingSpace p1 = new ParkingSpace(1, 1, 322, BusPlan2_Logic.Enums.ParkingTypeEnum.Maintenance, false);
            //Act

            //Assert
            Assert.AreEqual(p1.Number, bus.ParkingSpace);
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_Free_Fastcharger_Send_To_Fastcharger()
        {
            //Arrange
            Bus bus = new Bus(2, new System.DateTime(), new System.DateTime(), new System.DateTime(), new System.DateTime(), 406, 1, BusPlan2_Logic.Enums.BusStatusEnum.NeedsMaintenance, 0);
            AdHoc a = new AdHoc(1, 2, BusPlan2_Logic.Enums.AdHocTypeEnum.FloorCleaning, 2, "Spuug in het gangpad", new System.DateTime());
            ParkingSpace p1 = new ParkingSpace(1, 1, 322, BusPlan2_Logic.Enums.ParkingTypeEnum.FastCharging, true);
            ParkingSpace p2 = new ParkingSpace(2, 2, 0, BusPlan2_Logic.Enums.ParkingTypeEnum.FastCharging, false);
            //Act

            //Assert
            Assert.AreEqual(p2.Number, bus.ParkingSpace);
        }

        [TestMethod]
        public void If_Bus_Needs_Cleaning_Adhoc_With_No_Free_Fastcharger_Send_To_Parkinglot()
        {
            //Arrange
            Bus bus = new Bus(3, new System.DateTime(), new System.DateTime(), new System.DateTime(), new System.DateTime(), 406, 1, BusPlan2_Logic.Enums.BusStatusEnum.NeedsMaintenance, 0);
            AdHoc a = new AdHoc(1, 3, BusPlan2_Logic.Enums.AdHocTypeEnum.FloorCleaning, 2, "Spuug in het gangpad", new System.DateTime());
            ParkingSpace p1 = new ParkingSpace(1, 1, 322, BusPlan2_Logic.Enums.ParkingTypeEnum.FastCharging, true);
            ParkingSpace p2 = new ParkingSpace(2, 2, 405, BusPlan2_Logic.Enums.ParkingTypeEnum.FastCharging, true);
            ParkingSpace p3 = new ParkingSpace(3, 3, 0, BusPlan2_Logic.Enums.ParkingTypeEnum.Normal, false);
            //Act

            //Assert
            Assert.AreEqual(p3.Number, bus.ParkingSpace);
        }

        [TestMethod]
        public void If_Bus_Needs_Repair_Adhoc_With_Free_Workspace_Send_To_Workspace()
        {
            //Arrange
            Bus bus = new Bus(3, new System.DateTime(), new System.DateTime(), new System.DateTime(), new System.DateTime(), 406, 1, BusPlan2_Logic.Enums.BusStatusEnum.NeedsMaintenance, 0);
            AdHoc a = new AdHoc(1, 3, BusPlan2_Logic.Enums.AdHocTypeEnum.EngineProblems, 2, "Motor valt uit", new System.DateTime());
            ParkingSpace p1 = new ParkingSpace(1, 1, 322, BusPlan2_Logic.Enums.ParkingTypeEnum.FastCharging, true);
            ParkingSpace p2 = new ParkingSpace(2, 2, 405, BusPlan2_Logic.Enums.ParkingTypeEnum.FastCharging, true);
            ParkingSpace p3 = new ParkingSpace(3, 3, 0, BusPlan2_Logic.Enums.ParkingTypeEnum.Maintenance, false);
            //Act

            //Assert
            Assert.AreEqual(p3.Number, bus.ParkingSpace);
        }

        [TestMethod]
        public void If_Bus_Needs_Repair_Adhoc_With_No_Free_Workspace_Remove_From_Rotation()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Last_Ride_With_Planned_Cleaning_Send_To_Slowcharger()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_Slowcharger_Free_Send_To_Slowcharger()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_Low_Battery_No_Slowcharger_Free_Send_To_Parkinglot()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_No_Low_Battery_Parkinglot_Free_Send_To_Parkinglot()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Last_Ride_No_Planned_Cleaning_No_Low_Battery_No_Parkinglot_Free_Send_To_Slowcharger()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Battery_Low_Free_Fastcharger_Send_To_Fastcharger()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Battery_Low_No_Free_Fastcharger_Send_To_Parkinglot()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void If_Battery_Full_No_Free_Fastcharger_Send_To_Parkinglot()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
