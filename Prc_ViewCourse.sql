USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_ViewCourse]    Script Date: 06-06-2021 20:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_ViewCourse]
(
	@flag int,
	@para varchar(50)
)
as
begin
if @flag=1
select Course_Id,Course_Code,
		Course_Name,Course_Desc
		from Tbl_Course;
else if @flag=2
select Course_Id,Course_Code,
		Course_Name,Course_Desc
		from Tbl_Course where Course_Code like ('%'+@para+'%')
		or Course_Name like ('%'+@para+'%');
else if @flag=3
select Course_Id,Course_Code,
		Course_Name,Course_Desc
		from Tbl_Course where Course_Id=@para;
end