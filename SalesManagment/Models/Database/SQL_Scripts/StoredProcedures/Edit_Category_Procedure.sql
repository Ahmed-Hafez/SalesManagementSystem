Create proc Edit_Category_Procedure
@Category_ID int,
@Description varchar(50)
as
Update Categories
Set [Description] = @Description
Where Category_ID = @Category_ID