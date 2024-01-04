CREATE DATABASE [VOVO]; 


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Customer Information]
(
   [ID] VARCHAR(20) PRIMARY KEY,
   [Picture] IMAGE,
   [Name] VARCHAR(MAX) NOT NULL,
   [Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
   [Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
   [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
   [Gender] INT NOT NULL CHECK (Gender IN (0, 1, 2, 3)),
   [Password] VARCHAR(MAX) NOT NULL,
   [Date] DATE NOT NULL,
   [Time] TIME NOT NULL
);


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------
GO 
CREATE TABLE [Customer Verify Information]
(
   [Customer ID] VARCHAR(20) PRIMARY KEY,
   [Email Verified] INT NOT NULL DEFAULT 0,
   [Phone Number Verified] INT NOT NULL DEFAULT 0,
   FOREIGN KEY([Customer ID]) REFERENCES [Customer Information](ID) 
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------  

CREATE VIEW [Customer All Information View] AS
SELECT
    CI.[ID] AS [Customer ID],
    CI.[Picture],
    CI.[Name],
    CI.[Email],
    CI.[Country Code],
    CI.[Phone Number],
    CI.[Gender],
    CI.[Password],
    CV.[Email Verified],
    CV.[Phone Number Verified]
FROM
    [Customer Information] CI, [Customer Verify Information] CV
WHERE
    CI.[ID] = CV.[Customer ID];

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------
 
USE VOVO;
GO 
CREATE TABLE [Admin Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Picture] IMAGE, 
	[Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[Gender] INT NOT NULL CHECK (Gender IN (1, 2, 3)),
	[Date Of Birth] DATE NOT NULL,
	[Nationality] VARCHAR(20) NOT NULL,
	[NID Number] NUMERIC(30) NOT NULL,
	[Experience] NUMERIC(2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15),
	FOREIGN KEY([Added By]) REFERENCES [Admin Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Company Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Name] VARCHAR(MAX) NOT NULL,
	[Legal Structure] VARBINARY(MAX) NOT NULL,
	[Business Structure] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(300) NOT NULL,
	[Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
	[Ownership] VARCHAR(100) NOT NULL,
	[Licenses Number] VARCHAR(30) NOT NULL,
	[Permit Number] VARCHAR(30) NOT NULL,
	[Date] VARCHAR(10) NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15),
	FOREIGN KEY([Added By]) REFERENCES [Admin Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

GO
CREATE TABLE [Admin Login Information]
(
	[Admin ID] VARCHAR(15) PRIMARY KEY,
	[Company ID] VARCHAR(15),
	[Password] VARCHAR(30) NOT NULL,
	FOREIGN KEY ([Admin ID]) REFERENCES [Admin Information] (ID),
	FOREIGN KEY ([Company ID]) REFERENCES [Company Information] (ID)
);





-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------


USE VOVO;
GO 
CREATE TABLE [Employee Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Picture] IMAGE NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[Gender] INT NOT NULL CHECK (Gender IN (1, 2, 3)),
	[Date Of Birth] DATE NOT NULL,
	[Nationality] VARCHAR(20) NOT NULL,
	[NID Number] NUMERIC(30) NOT NULL,
	[Experience] NUMERIC(2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15),
	FOREIGN KEY([Added By]) REFERENCES [Admin Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO 
CREATE TABLE [Office Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Brunch Name] VARCHAR(100) NOT NULL, 
	[Address] VARCHAR(MAX) NOT NULL,
	[Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL, 
	[Admin ID] VARCHAR(15) DEFAULT NULL,
	[Employee ID] VARCHAR(15) DEFAULT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	FOREIGN KEY([Admin ID]) REFERENCES [Admin Information] (ID),
	FOREIGN KEY([Employee ID]) REFERENCES [Employee Information] (ID)
);




-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

GO
CREATE TABLE [Employee Login Information]
(
	[Employee ID] VARCHAR(15) PRIMARY KEY,
	[Company ID] VARCHAR(15) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[Brunch ID] VARCHAR(15) NOT NUll,
	FOREIGN KEY ([Employee ID]) REFERENCES [Employee Information] (ID),
	FOREIGN KEY ([Company ID]) REFERENCES [Company Information] (ID),
	FOREIGN KEY ([Brunch ID]) REFERENCES [Office Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO 
CREATE TABLE [Supervisor Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Picture] IMAGE NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[Gender] INT NOT NULL CHECK (Gender IN (1, 2, 3)),
	[Date Of Birth] DATE NOT NULL,
	[Nationality] VARCHAR(20) NOT NULL,
	[NID Number] NUMERIC(30) NOT NULL,
	[Experience] NUMERIC(2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15),
	FOREIGN KEY([Added By]) REFERENCES [Admin Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

CREATE TABLE [Supervisor Login Information]
(
	[Supervisor ID] VARCHAR(15) PRIMARY KEY,
	[Company ID] VARCHAR(15) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	FOREIGN KEY ([Supervisor ID]) REFERENCES [Supervisor Information] (ID),
	FOREIGN KEY ([Company ID]) REFERENCES [Company Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO 
CREATE TABLE [Driver Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Picture] IMAGE NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[Gender] INT NOT NULL CHECK (Gender IN (1, 2, 3)),
	[Date Of Birth] DATE NOT NULL,
	[Nationality] VARCHAR(20) NOT NULL,
	[NID Number] NUMERIC(30) NOT NULL,
	[Experience] NUMERIC(2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15),
	FOREIGN KEY([Added By]) REFERENCES [Admin Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

CREATE TABLE [Driver Login Information]
(
	[Driver ID] VARCHAR(15) PRIMARY KEY,
	[Company ID] VARCHAR(15) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	FOREIGN KEY ([Driver ID]) REFERENCES [Driver Information] (ID),
	FOREIGN KEY ([Company ID]) REFERENCES [Company Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO 
CREATE TABLE [Conductor Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[Picture] IMAGE NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) CHECK (Email LIKE '%@%' AND Email LIKE '%.%') NOT NULL,
	[Country Code] VARCHAR(4) CHECK ([Country Code] LIKE '+%[0-9]%') NOT NULL,
    [Phone Number] VARCHAR(15) CHECK ([Phone Number] LIKE '%[0-9]%') NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[Gender] INT NOT NULL CHECK (Gender IN (1, 2, 3)),
	[Date Of Birth] DATE NOT NULL,
	[Nationality] VARCHAR(20) NOT NULL,
	[NID Number] NUMERIC(30) NOT NULL,
	[Experience] NUMERIC(2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15),
	FOREIGN KEY([Added By]) REFERENCES [Admin Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

GO
CREATE TABLE [Conductor Login Information]
(
	[Conductor ID] VARCHAR(15) PRIMARY KEY,
	[Company ID] VARCHAR(15) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	FOREIGN KEY ([Conductor ID]) REFERENCES [Conductor Information] (ID),
	FOREIGN KEY ([Company ID]) REFERENCES [Company Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------



USE VOVO;
GO
CREATE TABLE [Admin Exam-1 Information]
(
	[Admin ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Admin ID]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Employee Exam-1 Information]
(
	[Employee ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Employee ID]) REFERENCES [Employee Information] (ID)
);


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Supervisor Exam-1 Information]
(
	[Supervisor ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Supervisor ID]) REFERENCES [Supervisor Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Driver Exam-1 Information]
(
	[Driver ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Driver ID]) REFERENCES [Driver Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Admin Exam-2 Information]
(
	[Admin ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Admin ID]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Employee Exam-2 Information]
(
	[Employee ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Employee ID]) REFERENCES [Employee Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Supervisor Exam-2 Information]
(
	[Supervisor ID] VARCHAR(15) PRIMARY KEY,
	[Exam Name] VARCHAR(10) NOT NULL,
	[Board Name] VARCHAR(50) NOT NULL,
	[Registration Number] NUMERIC(20) NOT NULL,
	[Roll Number] NUMERIC(20) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 5.00),
	FOREIGN KEY([Supervisor ID]) REFERENCES [Supervisor Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Admin Degree Information]
(
	[Admin ID] VARCHAR(15) PRIMARY KEY,
	[Institution Name] VARCHAR(200) NOT NULL,
	[Roll Number] VARCHAR(20) NOT NULL,
	[Degree Name] VARCHAR(300) NOT NULL,
	[Subject] VARCHAR(300) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 4.00),
	FOREIGN KEY([Admin ID]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Employee Degree Information]
(
	[Employee ID] VARCHAR(15) PRIMARY KEY,
	[Institution Name] VARCHAR(200) NOT NULL,
	[Roll Number] VARCHAR(20) NOT NULL,
	[Degree Name] VARCHAR(300) NOT NULL,
	[Subject] VARCHAR(300) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 4.00),
	FOREIGN KEY([Employee ID]) REFERENCES [Employee Information] (ID)
);


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Admin Diploma Information]
(
	[Admin ID] VARCHAR(15) PRIMARY KEY,
	[Institution Name] VARCHAR(200) NOT NULL,
	[Roll Number] VARCHAR(20) NOT NULL,
	[Degree Name] VARCHAR(300) NOT NULL,
	[Subject] VARCHAR(300) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 4.00),
	FOREIGN KEY([Admin ID]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Employee Diploma Information]
(
	[Employee ID] VARCHAR(15) PRIMARY KEY,
	[Institution Name] VARCHAR(200) NOT NULL,
	[Roll Number] VARCHAR(20) NOT NULL,
	[Degree Name] VARCHAR(300) NOT NULL,
	[Subject] VARCHAR(300) NOT NULL,
	[Result] DECIMAL(3, 2) NOT NULL CHECK ([Result] >= 0.00 AND [Result] <= 4.00),
	FOREIGN KEY([Employee ID]) REFERENCES [Employee Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Driver Driving License Information]
(
	[Driver ID] VARCHAR(15) PRIMARY KEY,
	[License Number] VARCHAR(20) UNIQUE NOT NULL,
	[License Type] VARCHAR(100) NOT NULL,
	[Expiration Date] DATE NOT NULL,
	FOREIGN KEY([Driver ID]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Driver Driving History Information]
(
	[Driver ID] VARCHAR(15) PRIMARY KEY,
	[Vehicle Type] VARCHAR(100) UNIQUE NOT NULL,
	[Registration Number] VARCHAR(100) NOT NULL,
	[Number Of Compliances] DECIMAL(3) NOT NULL,
	FOREIGN KEY([Driver ID]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Bus Information]
(
	[Bus Number] VARCHAR(20) PRIMARY KEY,
	[Bus Name] VARCHAR(50) NOT NULL,
	[Bus Type] VARCHAR(20) NOT NULL,
	[Chassis Number] VARCHAR (30) NOT NULL,
	[Engine Number] VARCHAR(17) NOT NULL,
	[Enginee Type] VARCHAR(50) NOT NULL,
	[Company Name] VARCHAR(100) NOT NULL,
	[Number Of Seats] DECIMAL(3) NOT NULL,
	[Owner ID] VARCHAR(15) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	[Added By] VARCHAR(15) NOT NULL,
	FOREIGN KEY ([Owner ID]) REFERENCES [Company Information] (ID),
	FOREIGN KEY ([Added By]) REFERENCES [Admin Information] (ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------
USE VOVO;
GO
CREATE TABLE [Route Information]
(
	[ID] VARCHAR(15) PRIMARY KEY,
	[From] VARCHAR(100) NOT NULL,
	[To] VARCHAR(100) NOT NUll,
	[Date] DATE NOT NULL,
	[TIme] TIME NOT NULL,
	[Create Employee ID] VARCHAR(15) NOT NULL,
	FOREIGN KEY ([Create Employee ID]) REFERENCES [Employee Information](ID)
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Arrival Points Information]
(
	[ID] INT IDENTITY PRIMARY KEY,
	[Point Name] VARCHAR(100) NOT NULL,
	[TIME] TIME NOT NULL,
	[Route ID] VARCHAR(15) NOT NULL,
	FOREIGN KEY ([Route ID]) REFERENCES [Route Information] ([ID])
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

USE VOVO;
GO
CREATE TABLE [Boarding Points Information]
(
	[ID] INT IDENTITY PRIMARY KEY,
	[Point Name] VARCHAR(100) NOT NULL,
	[TIME] TIME NOT NULL,
	[Route ID] VARCHAR(15) NOT NULL,
	FOREIGN KEY ([Route ID]) REFERENCES [Route Information] ([ID])
);


+++++++++++++++++++++++Execute++++++++++++++++++++++++++++ 


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

Go
CREATE TABLE [Travel Information] 
(
    [Travel Number] VARCHAR(15) PRIMARY KEY,
    [Departure Date] DATE NOT NULL,
    [Departure Time] TIME NOT NULL,
	[Supervisor ID] VARCHAR(15) NOT NULL,
    [Driver ID] VARCHAR(15) NOT NULL,
    [Conductor ID] VARCHAR(15) NOT NULL,
	[Created Employee ID] VARCHAR(15) NOT NULL, 
	[Date] Date NOT NULL,
	[Time] TIME NOT NULL,
    FOREIGN KEY([Supervisor ID]) REFERENCES [Supervisor Information] ([ID]),
    FOREIGN KEY([Driver ID]) REFERENCES [Driver Information] ([ID]),
    FOREIGN KEY([Conductor ID]) REFERENCES [Conductor Information] ([ID]),
    FOREIGN KEY([Created Employee ID]) REFERENCES [Employee Information] ([ID])
);


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

DROP TABLE [Ticket Seat] 
(
    [ID] INT IDENTITY PRIMARY KEY,
    [Seat Number] VARCHAR(2),
    [Seat Price] INT NOT NULL,
    [Bus Number] VARCHAR(20) NOT NULL,
    [Status] INT CHECK (Status IN (0, 1)),
    [Ticket Information Number] VARCHAR(15) NOT NULL, 
    FOREIGN KEY([Ticket Information Number]) REFERENCES [Travel Information] ([Travel Number]),
    FOREIGN KEY([Bus Number]) REFERENCES [Bus Information] ([Bus Number]),
);


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------


GO 
CREATE TABLE [Ticket Information]
(
    [Ticket Number] VARCHAR(15),
    [Bus Seat ID] INT,
    [Buyer ID] VARCHAR(20),
    PRIMARY KEY([Ticket Number], [Bus Seat ID]),
    FOREIGN KEY([Bus Seat ID]) REFERENCES [Ticket Seat] (ID),
    FOREIGN KEY([Buyer ID]) REFERENCES [Customer Information] ([ID]),
);
    
-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------


-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

CREATE TABLE [Bus Reporting Information] 
(
    [Reporting ID] VARCHAR(15) PRIMARY KEY,
    [Travel Number] VARCHAR(15),
    [Supervisor ID] VARCHAR(15) NOT NULL,
    [Driver ID] VARCHAR(15) NOT NULL,
    [Conductor ID] VARCHAR(15) NOT NULL,
	[Branch ID] VARCHAR(15) NOT NULL,
    [Date] DATE NOT NULL,
    [Time] TIME NOT NULL,
    FOREIGN KEY([Travel Number]) REFERENCES [Travel Information] ([Travel Number]),
    FOREIGN KEY ([Branch ID]) REFERENCES [Office Information] (ID)
);



-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------
USE VOVO
GO
CREATE TABLE [Waiting Zone Bus]
(
   ID INT IDENTITY PRIMARY KEY,
   [Bus Number] VARCHAR(20) DEFAULT NULL,
   [Branch ID] VARCHAR(15) DEFAULT NULL,
   [Date] DATE NOT NULL,
   [Time] TIME NOT NULL,
   FOREIGN KEY([Bus Number]) REFERENCES [Bus Information] ([Bus Number]),
   FOREIGN KEY ([Branch ID]) REFERENCES [Office Information] (ID)
);



GO
CREATE TABLE [Waiting Zone Conductor]
(
   ID INT IDENTITY PRIMARY KEY,
   [Conductor ID] VARCHAR(15) DEFAULT NULL,
   [Branch ID] VARCHAR(15) DEFAULT NULL,
   [Date] DATE NOT NULL,
   [Time] TIME NOT NULL,
   FOREIGN KEY([Conductor ID]) REFERENCES [Conductor Information] ([ID]),
   FOREIGN KEY ([Branch ID]) REFERENCES [Office Information] (ID)
);

GO
CREATE TABLE [Waiting Zone Supervisor]
(
   ID INT IDENTITY PRIMARY KEY,
   [Supervisor ID] VARCHAR(15) DEFAULT NULL,
   [Branch ID] VARCHAR(15) DEFAULT NULL,
   [Date] DATE NOT NULL,
   [Time] TIME NOT NULL,
   FOREIGN KEY([Supervisor ID]) REFERENCES [Supervisor Information] ([ID]),
   FOREIGN KEY ([Branch ID]) REFERENCES [Office Information] (ID)
);

GO
CREATE TABLE [Waiting Zone Driver]
(
   ID INT IDENTITY PRIMARY KEY,
   [Driver ID] VARCHAR(15) DEFAULT NULL,
   [Branch ID] VARCHAR(15) DEFAULT NULL,
   [Date] DATE NOT NULL,
   [Time] TIME NOT NULL,
   FOREIGN KEY([Driver ID]) REFERENCES [Driver Information] ([ID]),
   FOREIGN KEY ([Branch ID]) REFERENCES [Office Information] (ID)
);
-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

GO
CREATE TABLE [Advantagement Information]
(
	ID INT PRIMARY KEY,
	Advantagement IMAGE NOT NULL,
	[Employee ID] VARCHAR(15) NOT NULL,
	FOREIGN KEY ([Employee ID]) REFERENCES [Employee Information] ([ID])
);

-------------
--------------------------------------------------------------------------------------------------------------------------------
-------------

CREATE VIEW [Bus Reporting View] AS
SELECT
   B.[Bus Number],
   B.[Bus Name],
   B.[Bus Type],
   R.[Date],
   R.[Time]
FROM 
   [Bus Information] B,  
   [Bus Reporting Information] R, 
   [Bus Seat] S
WHERE 
   R.[Ticket Number] = S.[Ticket Number] AND S.[Bus Number] = B.[Bus Number]
ORDER BY 
 R.[DATE] DESC,  R[Time] DESC;

------------------------------------------------------------------------------------------------------------------
-------------------------------
-------------------------------
------------------------------------------------------------------------------------------------------------------
INSERT INTO [Admin Information] (ID, Picture, Name, Email, [Country Code], [Phone Number], [Address], Gender, [Date Of Birth], Nationality, [NID Number], Experience, [Date], [Time], [Added By])
VALUES ('ADM-230001-2', null, 'Admin', 'admin.admin@.support.com', '+880', '1813890622', 'Dhaka, Bangladesh', 1, '2006-01-06', 'Bangladesh', 1234890, 10,'2023-07-27', '14:30:00', null);

USE VOVO;
INSERT INTO [Admin Login Information] VALUES ('ADM-230001-2', null, 'admin')
select * from [Customer Verify Information]
DELETE [Admin Information]
select * from [Company Information]
SELECT * FROM [Employee Login Information]
SELECT * FROm [Bus Information]
SELECT * FROM [Driver Information]
SELECT * FROM [Supervisor Information]
SELECT * FROM [Conductor Information]
SELECT * FROM [Bus Reporting Information]
SELECT * FROM [Waiting Zone Bus]
SELECT * FROM [Waiting Zone Driver]



SELECT TOP 1 * FROM [Office Information] ORDER BY [Date] DESC, [Time] DESC;
SELECT [ID], [Brunch Name] FROM [Office Information]




SELECT [Bus Number], [Bus Type], [Bus Name] FROM [Bus Information] WHERE [Bus Number] = (SELECT [Bus Number] FROM [Waiting Zone Bus] ORDER BY [Date] ASC, [Time] ASC);

SELECT b.[Bus Number], b.[Bus Type], b.[Bus Name], wzb.[Date], wzb.[Time] 
FROM [Bus Information] b, [Waiting Zone Bus] wzb
WHERE b.[Bus Number] = wzb.[Bus Number]
ORDER BY wzb.Date ASC, wzb.Time ASC;




------------------------------------------------
----------Testing------------------------------
-----------------------------------------------


SELECT 
	R.[ID], R.[From], R.[To], 
	BPI.[Point Name] AS [Boarding Point], 
    API.[Point Name] AS [Arrival Point],
    (SELECT COUNT(*) FROM [Route Information] AS [Route Count]),
    (SELECT COUNT(*) FROM [Boarding Points Information] WHERE [Route ID] = R.ID) AS [Boarding Point Count]),
    (SELECT COUNT(*) FROM [Arrival Points Information] WHERE [Route ID] = R.ID) AS [Arrival Point Count])
FROM 
    [Route Information] R, [Boarding Points Information] BPI, [Arrival Points Information] API 
WHERE 
    R.ID = BPI.[Route ID] AND R.ID = API.[Route ID]

	SELECT 
    R.[ID], R.[From], R.[To], 
    BPI.[Point Name] AS [Boarding Point], 
    API.[Point Name] AS [Arrival Point],
    (SELECT COUNT(*) FROM [Route Information]) AS [Route Count],
    (SELECT COUNT(*) FROM [Boarding Points Information] WHERE [Route ID] = R.ID) AS [Boarding Point Count],
    (SELECT COUNT(*) FROM [Arrival Points Information] WHERE [Route ID] = R.ID) AS [Arrival Point Count]
FROM 
    [Route Information] R
INNER JOIN 
    [Boarding Points Information] BPI ON R.ID = BPI.[Route ID]
INNER JOIN 
    [Arrival Points Information] API ON R.ID = API.[Route ID];


