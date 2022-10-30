CREATE PROCEDURE [dbo].[usp_Members_UpdateMember]
	@Id int,
	@Fornamn nvarchar(max),
	@Efternamn nvarchar(max),
	@Adress nvarchar(max),
	@Postnummer nvarchar(max),
	@Postort nvarchar(max),
	@Skapatdatum datetime2(7),
	@Senastuppdateraddatum datetime2(7)
AS
BEGIN
	UPDATE dbo.[Members] 
		SET Fornamn = @Fornamn, Efternamn = @Efternamn, Adress = @Adress, Postnummer = @Postnummer, Postort = @Postort, Skapatdatum = @Skapatdatum, Senastuppdateraddatum = @Senastuppdateraddatum
	WHERE Id = @Id
END
