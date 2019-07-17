Create Proc Login_Procedure

@ID varchar(50),
@Password varchar(50),
@UserType varchar(50)
AS
Select * From Users
Where ID=@ID AND Password=@Password AND UserType=@UserType