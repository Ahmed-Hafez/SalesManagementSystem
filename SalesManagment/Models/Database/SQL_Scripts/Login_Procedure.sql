USE [ProductDB]
GO
/****** Object:  StoredProcedure [dbo].[Login_Procedure]    Script Date: 6/6/2019 10:27:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[Login_Procedure]

@ID varchar(50), @Password varchar(50)

AS

Select * From Users
Where ID=@ID AND Password=@Password