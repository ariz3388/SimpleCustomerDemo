CREATE TABLE Customers
(
	Id int Identity(1, 1) Primary Key
	, FirstName varchar(50) null
	, LastName varchar(50) null
	, DateOfBirth DATE NOT NULL
	, Address1 varchar(100) NOT NULL
	, Address2 varchar(100) NULL
	, City varchar(50) null
	, StateCode varchar(2) NOT NULL
	, ZipCode varchar(10) NOT NULL
	, Phone varchar(10) NOT NULL
	, Email varchar(100) NOT NULL
)

CREATE TABLE EventLogs
(
	Id int Identity(1, 1) Primary Key
	, LogType varchar(10) null
	, LogMessage varchar(250) null
	, LogDetails varchar(8000) null
	, LogTimeStamp DateTime null DEFAULT GETDATE()
)

-- This is a pre-existing table that is not used in demo
-- was imported with the database setup.
CREATE TABLE PostalStates
(
	Id int Identity(1, 1) Primary Key
	, StateCode varchar(5) not null
	, StateFullName varchar(100) not null
	, IsCanadian bit not null
)

INSERT INTO Customers
(FirstName, LastName, DateOfBirth, Address1, Address2, City, StateCode, ZipCode, Phone, Email)
VALUES
('Homer', 'Simpson', CAST('8/7/1958' as DATE), '1234 Evergreen Terrace', '', 'Springfield', 'IL', '62704', '8475655563', 'hsimpson@sfnpp.com'),
('John', 'Doe', CAST('8/5/1980' as DATE), '8925 W Meadowbrook Ave', '', 'Phoenix', 'AZ', '85037', '6028721843', 'jdoe@test.com'),
('Sylvia', 'Campos', CAST('7/7/1996' as DATE), '11934 N 68 Dr', '', 'Peoria', 'AZ', '85345', '6239790805', 'madbabysister@aol.com'),
('Melissa', 'Thompson', CAST('8/8/2000' as DATE), '8111 W Wacker Rd', 'Unit 81', 'Peoria', 'AZ', '85381', '4805856593', 'crazyexes@hotmail.com')