USE [db_Attendence]
GO
/****** Object:  StoredProcedure [dbo].[Extract_Course]    Script Date: 02-06-2021 08:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Prc_ExtractCourse]
as
begin
select course_id as keys,Course_Code as value,Course_Name
from Tbl_Course;
end