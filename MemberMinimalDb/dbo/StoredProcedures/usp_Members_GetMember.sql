CREATE PROCEDURE [dbo].[usp_Members_GetMember]
	@Id int
AS
BEGIN
	SELECT *
	FROM dbo.[Members]
	WHERE Id = @Id;
END
