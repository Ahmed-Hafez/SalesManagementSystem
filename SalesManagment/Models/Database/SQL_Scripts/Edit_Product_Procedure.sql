Create proc Edit_Product_Procedure
@Product_ID varchar(50),
@Product_Label varchar(50),
@Quantity_in_Stock int,
@Price varchar(50),
@Product_Image image,
@Category_ID int,
@Product_Description varchar(max)
as
Update Products
Set Product_ID = @Product_ID,
Product_Label = @Product_Label,
Quantity_in_Stock = @Quantity_in_Stock , 
Price = @Price,
Product_Image = @Product_Image, 
Category_ID = @Category_ID,
Product_Description = @Product_Description
Where 
Product_ID = @Product_ID