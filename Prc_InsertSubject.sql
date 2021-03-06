USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_InsertSubject]    Script Date: 07-06-2021 11:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_InsertSubject]
(
	@flag int,
	@subject_id int,
	@subject_code varchar(50),
	@subject_name text,
	@subject_crsid int,
	@subject_sem varchar(50),
	@subject_totalhrs int
)
as
begin
if @flag=1
insert into Tbl_Subject 
(Subject_Code,Subject_Name,Subject_CrsId,Subject_Sem,
	Subject_TotalHrs)
values
(@subject_code,@subject_name,@subject_crsid,@subject_sem,
	@subject_totalhrs);

else if @flag=2
update Tbl_Subject set
	Subject_Code=@subject_code,
	Subject_Name=@subject_name,
	Subject_CrsId=@subject_crsid,
	Subject_Sem=@subject_sem,
	Subject_TotalHrs=@subject_totalhrs
	where Subject_Id=@subject_id;
end