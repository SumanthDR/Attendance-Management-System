USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Prc_InsertClass]    Script Date: 29-06-2021 19:34:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Prc_InsertClass]
(
	@class_crsid int,
	@class_subid int,
	@class_batch int,
	@class_totalhrs int,
	@class_hrstaken int,
	@class_date datetime,
	@ERROR varchar(50) out
)
as
begin
if exists (
			select Class_Batch,Class_CrsId,Class_Date
			from Tbl_Class 
			where Class_SubId=@class_subid
			and @class_batch=Class_Batch
			and @class_date=Class_Date
		  )
begin	
	set @ERROR='Take tomorrow, class already taken!';
end
/*
else 
if exists (
			select distinct Class_TotalHrs 
			from Tbl_Class
			where Class_SubId=@class_subid
			and Class_Batch=@class_batch
			and	Class_TotalHrs
			>=(select sum(Class_HrsTaken)
			from Tbl_Class
			where Class_SubId=@class_subid
			and Class_Batch=@class_batch)
		  )
begin
	set @ERROR='All classes already taken!';
end
*/
else
begin
	insert into Tbl_Class
	(
		Class_CrsId,Class_SubId,Class_Batch,
		Class_TotalHrs,Class_HrsTaken,Class_Date
	)
	values
	(
		@class_crsid,@class_subid,@class_batch,
		@class_totalhrs,@class_hrstaken,@class_date
	);
	set @ERROR='Saved Successfully';
end
end