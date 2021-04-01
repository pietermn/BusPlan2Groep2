SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE Account;
TRUNCATE TABLE Bus;
TRUNCATE TABLE ParkingSpace;
TRUNCATE TABLE Cleaning;
TRUNCATE TABLE AdHoc;
SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO Account (AccountID, LoginCode, Password, Team, Name) VALUES
(1, 12345, 'TestWachtwoord12!', 4, 'Barry Bus');

INSERT INTO Bus VALUES
(1, 999, 85, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00'), 
(2, 114, 15, 1, '2021-06-19 12:50:00', '2021-04-19 12:50:00'), 
(3, 141, 24, 0, '2021-01-19 12:50:00', '2021-04-19 12:50:00'), 
(4, 201, 4, 1, '2021-02-19 12:50:00', '2021-04-19 12:50:00'),
(5, 702, 100, 2, '2021-06-21 12:50:00', '2021-04-19 12:50:00'),
(6, 111, 98, 0, '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(7, 002, 56, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(8, 333, 34, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(9, 444, 52, 0, '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(10, 788, 13, 2, '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(11, 812, 91, 2, '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(12, 091, 82, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00');

INSERT INTO ParkingSpace VALUES
(1, 1, 1, 0, true),
(2, 2, 18, 2, true),
(3, 3, 2, 1, true),
(4, 4, 14, 1, true),
(5, 5, 12, 2, true),
(6, 6, 36, 2, true),
(7, 7, 11, 0, true),
(8, 8, 3, 0, true),
(9, 9, 4, 1, true),
(10, 10, 8, 1, true),
(11, 11, 6, 2, true),
(12, 12, 34, 2, true);

INSERT INTO Cleaning (CleaningID, BusID, CleanedBy, Timecleaned, Status) VALUES
(1, 1, 1, '2021-04-19 12:50:00', 2);

INSERT INTO AdHoc (AdHocID, BusID, Type, Team, Description, TimeDone) VALUES
(1, 1, 3, 1, 'Graffiti op de linker zijkant', '2021-04-19 12:50:00');