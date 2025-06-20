USE [People]
GO
/****** Object:  StoredProcedure [dbo].[GetAuthorById]    Script Date: 20/06/2025 2:07:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuthorById]
(
    @pAuthorId  UNIQUEIDENTIFIER
) 
AS 
BEGIN
    SELECT Id, Name, DateOfBirth FROM Authors where Id = @pAuthorId 
END
GO
