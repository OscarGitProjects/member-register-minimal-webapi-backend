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
