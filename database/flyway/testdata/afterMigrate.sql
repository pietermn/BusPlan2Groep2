SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE Account;
TRUNCATE TABLE Bus;
TRUNCATE TABLE ParkingSpace;
TRUNCATE TABLE Cleaning;
TRUNCATE TABLE AdHoc;
SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO Account (AccountID, LoginCode, Password, Team, Name) VALUES
(1, 12345, 'TestWachtwoord12!', 4, 'Barry Bus');

INSERT INTO Bus (BusID, BusNumber, BatteryLevel, Status, PeriodicCleaning, PeriodicMaintenance) VALUES
(1, 999, 85, 2, '2021-04-19 12:50:00', '2021-04-19 12:50:00');

INSERT INTO ParkingSpace (ParkingSpaceID, BusID, Number, Type, Occupied) VALUES
(1, 1, 1, 4, true);

INSERT INTO Cleaning (CleaningID, BusID, CleanedBy, Timecleaned, Status) VALUES
(1, 1, 1, '2021-04-19 12:50:00', 2);

INSERT INTO AdHoc (AdHocID, BusID, Type, Team, Description, TimeDone) VALUES
(1, 1, 3, 1, 'Graffiti op de linker zijkant', '2021-04-19 12:50:00');