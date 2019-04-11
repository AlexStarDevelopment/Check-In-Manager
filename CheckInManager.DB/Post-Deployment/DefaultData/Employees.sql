BEGIN

INSERT INTO [dbo].[tblEmployee] ([EmployeeID], [FirstName], [LastName], [DOB], [Street], [City], [State], [ZipCode], [Phone], [Email], [UserName], [Password], [Key], [RoleID])
     VALUES
	 (1, 'IT', 'Support', '1/1/2018', '1825 N Bluemound Dr', 'Appleton', 'WI', '54952', '920-735-5600', '500153612@fvtc.edu', 'Support', 'password', '1', 1),
	 (2, 'Shannon', 'Krahn', '8/27/1970', '728 Kensington Rd', 'Neenah', 'WI', '54956', '815-814-3654', 'lf@loavesandfishesfv.com', 'Exec', 'password', '1', 1),
	 (3, 'John', 'Smith', '9/1/1998', '123 Anywhere St', 'Appleton', 'WI', '54952', '920-111-5555', '500153612@fvtc.edu', 'testuser', 'password', '2', 1)

END