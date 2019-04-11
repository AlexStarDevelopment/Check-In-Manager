CREATE TABLE [dbo].[tblError_Log]
(
	[ErrorID] INT NOT NULL PRIMARY KEY,
	[Date] DATETIME NOT NULL,
	[Description] VARCHAR(256) NULL,
	[EmployeeID] INT NULL
)
