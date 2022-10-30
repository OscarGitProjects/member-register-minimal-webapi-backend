CREATE PROCEDURE [dbo].[usp_Members_DeleteMember]
	@Id int
AS
BEGIN
	DELETE FROM dbo.[Members]
	WHERE Id = @Id;
END
