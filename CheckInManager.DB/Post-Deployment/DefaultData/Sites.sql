BEGIN

INSERT INTO [dbo].[tblSite] ([SiteID], [SiteName], [Street], [City], [State], [ZipCode])
     VALUES
           (1, 'St. Therese Activity Center', '213 E. Wisconsin Avenue', 'Appleton', 'WI', '54911'),
		   (2, 'TestSite0', '111 Anywhere Avenue', 'Appleton', 'WI', '54911'),
		   (3, 'TestSite1', '1432 N Main St.', 'Belvidere', 'IL', '61008')
END