USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_InsertCourse]    Script Date: 20-06-2021 17:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_InsertCourse]
(
	@flag int,
	@Course_Id int,
	@course_code varchar(50),
	@course_name text,
	@course_desc text,
	@ERROR varchar(50) out
)
as
begin
if exists(select Course_Code,Course_Name from Tbl_Course where
			Course_Code like @course_code or Course_Name like @course_name)
begin
	set @ERROR='Course Name or Code already exists';
end
else if @flag=1
begin
	insert into
	Tbl_Course (Course_Code,Course_Name,Course_Desc)values(@course_code,@course_name,@course_desc);
	set @ERROR='Saved Successfully';
end
else if @flag=2
	begin
	update Tbl_Course
	set Course_Code=@course_code,
		Course_Name=@course_name,
		Course_Desc=@course_desc
	where Course_Id=@Course_Id;
	set @ERROR='Updated Successfully';
	end
end
