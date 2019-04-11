CREATE TABLE [dbo].[tblGuest]
(
	[GuestID] INT NOT NULL PRIMARY KEY,
	[Gender] VARCHAR(8) NULL,
	[AgeGroup] VARCHAR(8) NULL,
	[City] VARCHAR(64) NULL,
	[Ethnicity] VARCHAR(64) NULL,
	[RepeatVisitor] BIT NULL,
	[EventID] INT NOT NULL
)
