﻿/*
Deployment script for MemberMinimalDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MemberMinimalDb"
:setvar DefaultFilePrefix "MemberMinimalDb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
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

if not exists (SELECT 1 FROM dbo.[Members])
BEGIN
    /* Insert 3 members into the Members table */
    INSERT INTO dbo.[Members] (Fornamn, Efternamn, Adress, Postnummer, Postort, Skapatdatum, Senastuppdateraddatum)
    VALUES ('Förnamn 1', 'Efternamn 1', 'Adress 1', '11111', 'Postort 1', '2022-10-30', '2022-10-30'),
    ('Förnamn 2', 'Efternamn 2', 'Adress 2', '22222', 'Postort 2', '2022-10-30', '2022-10-30'),
    ('Förnamn 3', 'Efternamn 3', 'Adress 3', '33333', 'Postort 3', '2022-10-30', '2022-10-30');
END
GO

GO
PRINT N'Update complete.';


GO