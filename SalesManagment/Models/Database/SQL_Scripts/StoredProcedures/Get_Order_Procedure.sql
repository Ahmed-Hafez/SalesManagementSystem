Create proc Get_Order_Procedure
@Order_ID int
As
Select * from Orders
Where Order_ID = @Order_ID