Create proc Find_Client_Procedure
@Telephone nchar(15),
@Email varchar(25)
as
Select * from Customers
where Telephone = @Telephone or Email = @Email