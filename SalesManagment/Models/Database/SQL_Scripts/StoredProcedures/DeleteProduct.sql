Create proc DeleteProduct
@Product_ID varchar(50)
as 
Delete from Products
where Product_ID = @Product_ID