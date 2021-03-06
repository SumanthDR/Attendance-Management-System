USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_ViewStudent]    Script Date: 06-06-2021 21:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_ViewStudent]
(
	@flag int,
	@para varchar(50)
)  
as
begin
if @flag=1
select s.Student_Id,s.Student_USN,
		s.Student_Name,c.Course_Code,
		s.Student_Sem,s.Student_Batch,
		c.Course_Id
	from Tbl_Student s join Tbl_Course c
	on s.Student_CrsId=c.Course_Id;
else if @flag=2
select s.Student_Id,s.Student_USN,
		s.Student_Name,c.Course_Code,
		s.Student_Sem,s.Student_Batch,
		c.Course_Id
	from Tbl_Student s join Tbl_Course c
	on s.Student_CrsId=c.Course_Id
	where s.Student_USN like ('%'+@para+'%')
	or s.Student_Name like('%'+@para+'%');
else if @flag=3
select s.Student_Id,s.Student_USN,
		s.Student_Name,c.Course_Code,
		s.Student_Sem,s.Student_Batch,
		c.Course_Id
	from Tbl_Student s join Tbl_Course c
	on s.Student_CrsId=c.Course_Id
	where s.Student_Batch=@para;
else if @flag=4
select s.Student_Id,s.Student_USN,
		s.Student_Name,c.Course_Code,
		s.Student_Sem,s.Student_Batch,
		c.Course_Id
	from Tbl_Student s join Tbl_Course c
	on s.Student_CrsId=c.Course_Id
	where s.Student_CrsId=@para;
else if @flag=5
select s.Student_Id,s.Student_USN,
		s.Student_Name,c.Course_Code,
		s.Student_Sem,s.Student_Batch,
		c.Course_Id
	from Tbl_Student s join Tbl_Course c
	on s.Student_CrsId=c.Course_Id
	where s.Student_Id=@para;
end