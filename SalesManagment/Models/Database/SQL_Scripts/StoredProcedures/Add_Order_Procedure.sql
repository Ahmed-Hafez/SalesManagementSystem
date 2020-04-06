Create proc Add_Order_Procedure
@Order_Date datetime,
@Customer_Name varchar(100),
@Seller_Name varchar(50),
@TotalPrice decimal
AS
Insert into Orders
(
Order_Date,
Customer_Name,
Seller_Name,
TotalPrice
)
values
(
@Order_Date,
@Customer_Name,
@Seller_Name,
@TotalPrice
)