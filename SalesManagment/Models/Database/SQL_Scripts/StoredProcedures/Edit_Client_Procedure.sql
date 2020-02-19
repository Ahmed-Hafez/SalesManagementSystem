Create proc Edit_Client_Procedure
@Customer_ID int,
@First_Name varchar(50),
@Last_Name varchar(50),
@Gender varchar(50),
@Telephone nchar(50),
@Email varchar(25),
@Image image
as
Update Customers
Set Customer_ID = @Customer_ID,
First_Name = @First_Name,
Last_Name = @Last_Name , 
Gender = @Gender,
Telephone = @Telephone, 
Email = @Email,
Image = @Image
Where 
Customer_ID = @Customer_ID