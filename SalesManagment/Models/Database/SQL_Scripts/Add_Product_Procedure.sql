Create proc Add_Product_Procedure
@Product_ID varchar(50),
@Product_Label varchar(50),
@Quantity_in_Stock int,
@Price varchar(50),
@Product_Image image,
@Category_ID int
as
Insert into Products
(Product_ID,
Product_Label,
Quantity_in_Stock,
Price,
Product_Image,
Category_ID)
Values
(@Product_ID,
@Product_Label,
@Quantity_in_Stock,
@Price,
@Product_Image,
@Category_ID)
