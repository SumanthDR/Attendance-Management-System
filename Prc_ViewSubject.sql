USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_ViewSubject]    Script Date: 07-06-2021 11:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_ViewSubject]
(
	@flag int,
	@para varchar(50)
)
as
begin
if @flag=1
select s.Subject_Id,s.Subject_Code,s.Subject_Name,
	s.Subject_CrsId,c.Course_Code,s.Subject_Sem
	from Tbl_Subject s
	join Tbl_Course c on c.Course_Id=s.Subject_CrsId;
else if @flag=2
select s.Subject_Id,s.Subject_Code,s.Subject_Name,
	s.Subject_CrsId,c.Course_Code,s.Subject_Sem
	from Tbl_Subject s
	join Tbl_Course c on c.Course_Id=s.Subject_CrsId
	where s.Subject_CrsId=@para;
else if @flag=3
select s.Subject_Id,s.Subject_Code,s.Subject_Name,
	s.Subject_CrsId,c.Course_Code,s.Subject_Sem
	from Tbl_Subject s
	join Tbl_Course c on c.Course_Id=s.Subject_CrsId
	where s.Subject_Code like ('%'+@para+'%')
	or s.Subject_Name like ('%'+@para+'%');
else if @flag=4
select s.Subject_Id,s.Subject_Code,s.Subject_Name,
	s.Subject_CrsId,c.Course_Code,s.Subject_Sem,
	s.Subject_TotalHrs
	from Tbl_Subject s
	join Tbl_Course c on c.Course_Id=s.Subject_CrsId
	where s.Subject_Id=@para;
end