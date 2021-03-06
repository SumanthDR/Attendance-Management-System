USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_InsertAttendance]    Script Date: 30-06-2021 08:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_InsertAttendance]
(
	@attendance_stuid int,
	@attendance_classid int,
	@attendance_absent int,
	@ERROR varchar(50) out
)
as
begin
if exists(select Attendance_StuId,
				Attendance_ClassId
				from Tbl_Attendance
				where 
				Attendance_StuId=@attendance_stuid
				and 
				Attendance_ClassId=@attendance_classid)
begin
 set @ERROR='Attendance already taken, data not saved!';
end
else
	begin
		insert into Tbl_Attendance
		(Attendance_StuId,Attendance_ClassId,Attendance_Absent)
		values
		(@attendance_stuid,@attendance_classid,@attendance_absent)

		set @ERROR='Attendance taken Successfully';
	end
end