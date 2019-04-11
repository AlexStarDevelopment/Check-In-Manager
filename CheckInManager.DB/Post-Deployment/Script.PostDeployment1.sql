/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\Employees.sql
:r .\DefaultData\Error_Logs.sql
:r .\DefaultData\Events.sql
:r .\DefaultData\Events_Employees.sql
:r .\DefaultData\Guests.sql
:r .\DefaultData\Reports.sql
:r .\DefaultData\Roles.sql
:r .\DefaultData\Sites.sql
