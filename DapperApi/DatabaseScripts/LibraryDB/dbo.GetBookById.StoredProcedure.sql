USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 20/06/2025 2:05:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBookById]
(
    @pId      INT
)
AS 
BEGIN 
	SELECT Id, Name, Published, AuthorId FROM Books where Id = @pId
END

GO
