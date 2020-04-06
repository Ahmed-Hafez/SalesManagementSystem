Create Proc Get_Current_OrderID_Procedure
As
Select max(Order_ID)+1 as Max_ID from Orders