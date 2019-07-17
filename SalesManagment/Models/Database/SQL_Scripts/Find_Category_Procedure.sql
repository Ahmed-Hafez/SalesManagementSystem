create proc Find_Category_Procedure
@Category_ID int
as 
Select * from Categories
where Category_ID = @Category_ID