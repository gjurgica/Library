-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
CREATE PROCEDURE [dbo].[AddAuthor]
	@Id INT = NULL OUTPUT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Author
	VALUES
	(
		@FirstName,
		@LastName
	);
	SELECT @Id = SCOPE_IDENTITY();
END
