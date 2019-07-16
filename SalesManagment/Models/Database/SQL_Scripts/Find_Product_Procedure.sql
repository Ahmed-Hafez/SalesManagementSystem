Create proc Find_Product_Procedure
@Product_ID varchar(50)
as
Select Product_ID from Products
where Product_ID = @Product_ID