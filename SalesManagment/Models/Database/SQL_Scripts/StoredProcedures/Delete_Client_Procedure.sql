Create proc Delete_Client_Procedure
@Customer_ID int
as 
Delete from Customers
where Customer_ID = @Customer_ID