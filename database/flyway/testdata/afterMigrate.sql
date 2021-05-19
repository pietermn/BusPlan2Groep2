SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE Account;
TRUNCATE TABLE Bus;
TRUNCATE TABLE ParkingSpace;
TRUNCATE TABLE Cleaning;
TRUNCATE TABLE Maintenance;
TRUNCATE TABLE AdHoc;
SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO Account (AccountID, LoginCode, Password, Team, Name) VALUES
(1, 11111, 'Busdriver', 0, 'Barry Bus'),
(2, 22222, 'Cleaner', 1, 'Polly Poets'),
(3, 33333, 'Mechanic', 2, 'Miel Monteur'),
(4, 44444, 'Planner', 3, 'Plien Planner'),
(5, 55555, 'Admin', 4, 'Ad Admin');

INSERT INTO Bus VALUES
(1, 999, 85, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'), 
(2, 114, 15, 1, '2021-06-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'), 
(3, 141, 24, 0, '2021-01-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'), 
(4, 201, 4, 1, '2021-02-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(5, 702, 100, 2, '2021-06-21 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(6, 111, 98, 0, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(7, 002, 56, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(8, 333, 34, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(9, 444, 52, 0, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(10, 788, 13, 2, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(11, 812, 91, 2, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00'),
(12, 091, 82, 1, '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00', '2021-04-19 12:50:00');

INSERT INTO ParkingSpace (BusID, Number, Type, Occupied) VALUES
(1, 1, 0, true),
(2, 2, 0, true),
(3, 3, 0, true),
(4, 4, 0, true),
(5, 5, 0, true),
(6, 6, 0, true),
(7, 7, 0, true),
(8, 8, 0, true),
(9, 9, 0, true),
(10, 10, 0, true),
(11, 11, 0, true),
(12, 12, 0, true),
(0, 13, 0, false),
(0, 14, 0, false),
(0, 15, 0, false),
(0, 16, 0, false),
(0, 17, 0, false),
(0, 18, 0, false),
(0, 19, 0, false),
(0, 20, 0, false),
(0, 21, 0, false),
(0, 22, 0, false),
(0, 23, 0, false),
(0, 24, 0, false),
(0, 25, 0, false),
(0, 26, 0, false),
(0, 27, 0, false),
(0, 28, 0, false),
(0, 1, 1, false),
(0, 2, 1, false),
(0, 3, 1, false),
(0, 4, 1, false),
(0, 5, 1, false),
(0, 6, 1, false),
(0, 7, 1, false),
(0, 8, 1, false),
(0, 9, 1, false),
(0, 10, 1, false),
(0, 11, 1, false),
(0, 12, 1, false),
(0, 13, 1, false),
(0, 14, 1, false),
(0, 15, 1, false),
(0, 16, 1, false),
(0, 17, 1, false),
(0, 18, 1, false),
(0, 19, 1, false),
(0, 20, 1, false),
(0, 1, 2, false),
(0, 2, 2, false),
(0, 3, 2, false),
(0, 4, 2, false),
(0, 5, 2, false),
(0, 6, 2, false),
(0, 7, 2, false),
(0, 8, 2, false),
(0, 9, 2, false),
(0, 10, 2, false),
(0, 11, 2, false),
(0, 12, 2, false),
(0, 13, 2, false),
(0, 14, 2, false),
(0, 15, 2, false),
(0, 16, 2, false),
(0, 17, 2, false),
(0, 18, 2, false),
(0, 19, 2, false),
(0, 20, 2, false),
(0, 1, 3, false),
(0, 2, 3, false),
(0, 1, 4, false),
(0, 2, 4, false),
(0, 1, 5, false),
(0, 2, 5, false),
(0, 3, 5, false),
(0, 4, 5, false),
(0, 1, 6, false),
(0, 2, 6, false);

INSERT INTO Cleaning (CleaningID, BusID, CleanedBy, TimeCleaned, Type, Status) VALUES
(1, 1, 1, '2021-04-19 12:50:00', 1, 2);

INSERT INTO Maintenance (MaintenanceID, BusID, RepairedBy, TimeRepaired, Type, Status) VALUES
(1, 1, 1, '2021-04-19 12:50:00', 1, 2);

INSERT INTO AdHoc (AdHocID, BusID, Type, Team, Description, TimeSubmitted) VALUES
(1, 1, 3, 1, 'Graffiti op de linker zijkant', '2021-04-17 12:50:00');