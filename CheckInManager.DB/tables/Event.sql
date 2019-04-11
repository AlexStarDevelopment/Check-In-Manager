CREATE TABLE [dbo].[tblEvent]
(
	[EventID] INT NOT NULL PRIMARY KEY,
	[Date] DATETIME NOT NULL,
	[MealCount] INT NULL,
	[VolunteerCount] INT NULL,
	[SiteID] INT NOT NULL,
	[WeatherDesc] VARCHAR(64) NULL,
	[Temp] DECIMAL(5, 2) NULL,
	[ChildTray] INT NULL,
	[AdultTray] INT NULL,
	[IsActive] BIT NULL
)
