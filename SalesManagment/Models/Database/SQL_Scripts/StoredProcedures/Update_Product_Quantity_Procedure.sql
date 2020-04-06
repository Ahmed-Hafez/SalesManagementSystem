Create proc Update_Product_Quantity_Procedure
@Product_ID varchar(50),
@Quantity int
As
update Products
set Quantity_in_Stock -= @Quantity
where Product_ID = @Product_ID