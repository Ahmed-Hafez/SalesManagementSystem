Create proc Delete_Category_Procedure
@Category_ID int
as 
Delete from Categories
where Category_ID = @Category_ID