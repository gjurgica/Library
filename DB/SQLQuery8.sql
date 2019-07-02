CREATE OR ALTER PROCEDURE [dbo].[EditBook]
	@Id INT,
	@Title NVARCHAR(50),
	@Genre NVARCHAR(50),
	@AuthorId INT
AS
BEGIN
	SET NOCOUNT ON;

	update dbo.Book 
	set Title = @Title,@Genre = @Genre,AuthorId = @AuthorId
	from Book 
	where Id = @Id

END
select * from Book
