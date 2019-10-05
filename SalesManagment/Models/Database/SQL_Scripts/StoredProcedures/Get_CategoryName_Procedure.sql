Create proc Get_CategoryName_Procedure
@Category_ID int
as
Select Description from Categories
where Category_ID = @Category_ID