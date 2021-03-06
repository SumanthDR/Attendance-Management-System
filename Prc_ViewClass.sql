USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_ViewClass]    Script Date: 21-06-2021 19:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_ViewClass]
(
	@flag int,
	@para varchar(50)
)
as
begin
if @flag=1
begin
select cl.Class_Id,cl.Class_CrsId,
		c.Course_Code,cl.Class_SubId,
		s.Subject_Code,s.Subject_TotalHrs,
		cl.Class_HrsTaken,cl.Class_Batch,
		cl.Class_Date
from 
	Tbl_Class cl join Tbl_Course c 
	on c.Course_Id=cl.Class_CrsId
	join Tbl_Subject s on s.Subject_Id=cl.Class_SubId
	where cl.Class_Date=@para;
end
if @flag=2
begin
select cl.Class_Id,cl.Class_CrsId,
		c.Course_Code,cl.Class_SubId,
		s.Subject_Code,s.Subject_TotalHrs,
		cl.Class_HrsTaken,cl.Class_Batch,
		cl.Class_Date
from 
	Tbl_Class cl join Tbl_Course c 
	on c.Course_Id=cl.Class_CrsId
	join Tbl_Subject s on s.Subject_Id=cl.Class_SubId
	where cl.Class_Batch=@para;
end
if @flag=3
begin
select cl.Class_Id,cl.Class_CrsId,
		c.Course_Code,cl.Class_SubId,
		s.Subject_Code,s.Subject_TotalHrs,
		cl.Class_HrsTaken,cl.Class_Batch,
		cl.Class_Date
from 
	Tbl_Class cl join Tbl_Course c 
	on c.Course_Id=cl.Class_CrsId
	join Tbl_Subject s on s.Subject_Id=cl.Class_SubId
	where cl.Class_SubId=@para;
end
end