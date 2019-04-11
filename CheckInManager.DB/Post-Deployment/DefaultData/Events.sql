BEGIN

INSERT INTO [dbo].[tblEvent] ([EventID], [Date], [MealCount], [VolunteerCount], [SiteID], [WeatherDesc], [Temp], [ChildTray], [AdultTray])
     VALUES
	 (1, '1/1/2018', 80, 13, 1, 'Clear', 24.2, 22, 58),
	 (2, '1/1/2018', 78, 13, 1, 'Clear', 26.2, 22, 56),
	 (3, '1/1/2018', 94, 13, 1, 'Clear', 28.2, 26, 58)

END