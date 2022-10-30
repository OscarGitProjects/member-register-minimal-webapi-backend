CREATE PROCEDURE [dbo].[usp_Members_InsertMember]
	@Fornamn nvarchar(max),
	@Efternamn nvarchar(max),
	@Adress nvarchar(max),
	@Postnummer nvarchar(max),
	@Postort nvarchar(max),
	@Skapatdatum datetime2(7),
	@Senastuppdateraddatum datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Members] (Fornamn, Efternamn, Adress, Postnummer, Postort, Skapatdatum, Senastuppdateraddatum)
	VALUES (@Fornamn, @Efternamn, @Adress, @Postnummer, @Postort, @Skapatdatum, @Senastuppdateraddatum);
END
