create procedure Prc_ExtractTotalHours
( @subject_id varchar(10))
as
begin
	select Subject_TotalHrs from Tbl_Subject
	where Subject_Id=@subject_id;
end