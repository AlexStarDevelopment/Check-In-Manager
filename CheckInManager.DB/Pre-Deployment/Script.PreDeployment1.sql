/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
delete from [dbo].[tblEmployee]
delete from [dbo].[tblError_Log]
delete from [dbo].[tblEvent]
delete from [dbo].[tblEvents_Employee]
delete from [dbo].[tblGuest]
delete from [dbo].[tblReport]
delete from [dbo].[tblRole]
delete from [dbo].[tblSite]
