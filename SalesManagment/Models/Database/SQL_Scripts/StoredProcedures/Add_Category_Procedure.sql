Create proc Add_Category_Procedure
@Category_ID int,
@Description varchar(50)
as
Insert into Categories
(Category_ID,[Description])
Values
(@Category_ID,@Description)
