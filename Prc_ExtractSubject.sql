USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_ExtractSubject]    Script Date: 21-06-2021 15:09:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_ExtractSubject]
(
	@Para int,
	@flag int
)
as
begin
if @flag=1
begin
	select Subject_Id as id_key,Subject_Code as id_value,Subject_Name	
	from Tbl_Subject s join Tbl_Course c on 
	s.Subject_CrsId=c.Course_Id where
	c.Course_Id=@Para;
end
else if @flag=2
begin
	select Subject_TotalHrs
	from Tbl_Subject s join Tbl_Course c on 
	s.Subject_CrsId=c.Course_Id where
	s.Subject_Id=@Para;
end
else if @flag=3
begin
	select Subject_Id as id_key,Subject_Code as id_value,Subject_Name	
	from Tbl_Subject s join Tbl_Course c on 
	s.Subject_CrsId=c.Course_Id;
end
end
