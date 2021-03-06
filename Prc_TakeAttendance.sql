USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_TakeAttendance]    Script Date: 27-06-2021 10:14:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_TakeAttendance]
(
	@class_id int
)
as
begin
select cls.Class_Id,stu.Student_Id,stu.Student_USN,
				stu.Student_Name,crs.Course_Id,
				crs.Course_Code,sub.Subject_Id,
				sub.Subject_Code,cls.Class_Batch,
				cls.Class_Date,cls.Class_HrsTaken
from Tbl_Student stu,Tbl_Course crs,Tbl_Subject sub,
		Tbl_Class cls
where stu.Student_CrsId=crs.Course_Id
	and sub.Subject_CrsId=crs.Course_Id
	and cls.Class_CrsId=stu.Student_CrsId
	and cls.Class_SubId=sub.Subject_Id
	and cls.Class_Batch=stu.Student_Batch
	and cls.Class_Id=@class_id;
end