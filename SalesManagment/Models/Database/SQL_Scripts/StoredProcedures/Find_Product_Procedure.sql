Create proc Find_Product_Procedure
@Product_ID varchar(50)
as
Select * from Products
where Product_ID = @Product_ID