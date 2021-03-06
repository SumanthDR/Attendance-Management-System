USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_InsertStudent]    Script Date: 06-06-2021 21:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_InsertStudent]
(
	@flag int,
	@student_id int,
	@student_usn varchar(50),
	@student_name text,
	@student_crsid int,
	@student_sem varchar(50),
	@student_batch int
)
as
begin

if @flag=1
insert into Tbl_Student 
(Student_USN,Student_Name,Student_CrsId,
Student_Sem,Student_Batch)
values
(@student_usn,@student_name,@student_crsid,
	@student_sem,@student_batch);

else if @flag=2
update Tbl_Student
	set Student_USN=@student_usn,
		Student_Name=@student_name,
		Student_CrsId=@student_crsid,
		Student_Sem=@student_sem,
		Student_Batch=@student_batch
	where Student_Id=@student_id;
end