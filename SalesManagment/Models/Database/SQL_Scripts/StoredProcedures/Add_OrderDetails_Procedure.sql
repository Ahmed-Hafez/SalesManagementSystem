Create proc Add_OrderDetails_Procedure
@Product_Name varchar(100),
@Product_Price decimal,
@Order_ID int,
@Quantity int,
@Discount decimal,
@Row_Number int
As 
Insert into Orders_Details
(
Product_Name,
Product_Price,
Order_ID,
Quantity,
Discount,
Row_Number
)
values
(
@Product_Name,
@Product_Price,
@Order_ID,
@Quantity,
@Discount,
@Row_Number
)