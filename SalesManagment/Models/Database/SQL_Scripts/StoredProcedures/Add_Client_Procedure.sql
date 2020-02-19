Create proc Add_Client_Procedure
@First_Name varchar(50),
@Last_Name varchar(50),
@Gender varchar(50),
@Telephone nchar(50),
@Email varchar(25),
@Image image
as
Insert into Customers
(First_Name,
Last_Name,
Gender,
Telephone,
Email,
[Image])
Values
(@First_Name,
@Last_Name,
@Gender,
@Telephone,
@Email,
@Image)
