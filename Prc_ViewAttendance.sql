USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_ViewAttendance]    Script Date: 30-06-2021 17:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_ViewAttendance]
(
	@class_batch int,
	@class_date varchar(50),
	@class_subid int
)
as
begin
select	stu.Student_USN,stu.Student_Name,
		crs.Course_Code,sub.Subject_Code,
		stu.Student_Batch,a.Attendance_Absent
		from 
		Tbl_Attendance a join Tbl_Class cls
		on a.Attendance_ClassId=cls.Class_Id
		join Tbl_Student stu
		on stu.Student_Id=a.Attendance_StuId
		join Tbl_Course crs 
		on crs.Course_Id=stu.Student_CrsId
		join Tbl_Subject sub
		on sub.Subject_CrsId=crs.Course_Id
		where sub.Subject_Id=@class_subid
		and cls.Class_Batch=@class_batch
		and cls.Class_Date=@class_date;
end