

USE [DB_TRUONG_HOSP_V01]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--CREATE PROCEDURE [dbo].[GetSP_InventoryBySchema]
-- (@mmyynames nvarchar(8))
--AS
--BEGIN
--	SET NOCOUNT ON;
--  BEGIN
--    SELECT * FROM [dbo].PHA_inventoryl WHERE active = 1;
--  END;
--END


--CREATE PROCEDURE [dbo].[GetSP_InventoryBySchemaFinal]
--(@mmyynames varchar(50))
--AS
--BEGIN
--	DECLARE tbl_cursor CURSOR FOR 
--	SELECT name from dbo.sysschema WHERE mmyy in (@mmyynames);

--	OPEN tbl_cursor
--	--Định nghĩa CURSOR
--	DECLARE @schemaname varchar(8)
--	DECLARE @cmd VARCHAR(1000)
--	CREATE TABLE #temp_test
--(
--    drugcode VARCHAR(30),
--    mmyy VARCHAR(4) 
--)
	
--	FETCH NEXT from tbl_cursor INTO @schemaname
--	WHILE @@FETCH_STATUS = 0 
--	BEGIN
--	--IF EXISTS (#temp_test) then drop table #temp_test 
--	--BEGIN
--	 set @cmd='INSERT INTO #temp_test SELECT drugcode,mmyy from '+@schemaname +'.PHA_inventoryl';
--   exec (@cmd);
--	 --END
	 
--	 FETCH NEXT from tbl_cursor INTO @schemaname
--END
--CLOSE tbl_cursor --đóng con trỏ
--DEALLOCATE tbl_cursor-- giải phóng con trỏ
--BEGIN
--SELECT * from #temp_test
--drop table #temp_test
--END
--END


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_create_schema_mmyy
 (@SchemaCurent nvarchar(8),
 @SchemaNew nvarchar(8))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DECLARE @mmyyCurent  VARCHAR(4) = (SELECT SUBSTRING( @SchemaCurent, 5, 4))
	DECLARE @mmyyNew  VARCHAR(4) = (SELECT SUBSTRING( @SchemaNew, 5, 4))
	DECLARE @cmd varchar(1000)
IF NOT EXISTS (SELECT * FROM dbo.sysschema WHERE mmyy = @mmyyNew and name = @SchemaNew and active = 1)
  BEGIN
	INSERT INTO dbo.sysschema (mmyy,name,siterf,active,timecr,timeup) VALUES (@mmyyNew,@SchemaNew,1,1,GETDATE(),GETDATE());
	update dbo.sysschema  set active = 0 where mmyy = @mmyyCurent and name = @schemacurent and active = 1;
  set @cmd='create schema '+@SchemaNew;
  exec (@cmd);
  END;
END


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_create_structure_table]
 (@schemaole nvarchar(8),
 @schemanew nvarchar(8),
 @mmyynew nvarchar(4),
 @tblname nvarchar(255))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DECLARE @cmd varchar(1000)

IF NOT EXISTS (SELECT * FROM  dbo.systable  WHERE active = 1 and mmyy = @mmyynew and code =  @tblname)
/*IF NOT EXISTS (SELECT * FROM  +@schemanew+'.'+@tblname)*/
  BEGIN
    SET @cmd='Select Top 0 * into '+@schemanew+'.'+@tblname+ ' from '+@schemaole+'.'+@tblname;
    EXEC (@cmd);
  END;
END


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_create_structure_table_final]
 (@mmyycurent nvarchar(4),
 @mmyynew nvarchar(4)
)
AS
    -- Insert statements for procedure here
	DECLARE @cmdClone varchar(1000)
	DECLARE @cmdInsert varchar(1000)
	--Định nghĩa CURSOR
	DECLARE @tablename varchar(1000)
	DECLARE @schemacurrent varchar(1000)
	
	/*IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = @mmyynew)
	BEGIN
	EXEC sp_create_schema_mmyy(@mmyynew) 
	END*/

	DECLARE tbl_cursor CURSOR FOR
	SELECT mmyy,code from dbo.systable WHERE active = 1 AND mmyy = @mmyycurent
	OPEN tbl_cursor
	FETCH NEXT from tbl_cursor INTO @schemacurrent,@tablename

	WHILE @@FETCH_STATUS = 0 BEGIN
	--SET @cmdInsert='INSERT INTO  '+@tablename+ '( mmyy,code ) VALUES (' +@mmyynew+','+@tablename+')';
	IF NOT EXISTS (SELECT * FROM  dbo.systable WHERE mmyy = @mmyynew and active = 1 and code = @tablename)
	BEGIN
	INSERT INTO systable (mmyy,code,active,timecr) VALUES (@mmyynew,@tablename,1,GETDATE())
	 --EXEC (@cmdInsert);
	 SET @cmdClone=' Select Top 0 * into mmyy'+@mmyynew +'.'+@tablename+ ' from mmyy'+@schemacurrent+'.'+@tablename;
   EXEC (@cmdClone);
	END
	 FETCH NEXT from tbl_cursor INTO @schemacurrent,@tablename --duyet record kế tiếp
END;
CLOSE tbl_cursor --đóng con trỏ
DEALLOCATE tbl_cursor-- giải phóng con trỏ


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--CREATE PROCEDURE sp_get_schema_mmyy
--AS
--BEGIN
--	-- SET NOCOUNT ON added to prevent extra result sets from
--	-- interfering with SELECT statements.
--	SET NOCOUNT ON;
--	SELECT * FROM dbo.sysschema
--END

--transaction---
-- BEGIN  
    -- SET new.idline = uuid();  
		-- Set new.`year` = YEAR(NOW());
-- END

-- BEGIN	 	 	

	-- IF new.type = 'Update' then		
		-- UPDATE phainventoryl a	
		-- set  a.qtyt = a.qtyt + new.qtyt, a.qtyimp = a.qtyimp + new.qtyimp, a.qtyexp = a.qtyexp + new.qtyexp, a.qtyrep = a.qtyrep + new.qtyrep, a.userup = new.userup
		-- WHERE a.siterf = new.siterf and a.storeid = new.storeid and a.mmyy = new.mmyy and a.drugid = new.drugid and a.drugcode = new.drugcode
		-- and a.followid = new.followid;
		
		-- UPDATE phainventoryh a	
		-- set  a.qtyt = a.qtyt + new.qtyt, a.qtyimp = a.qtyimp + new.qtyimp, a.qtyexp = a.qtyexp + new.qtyexp, a.qtyrep = a.qtyrep + new.qtyrep, a.userup = new.userup
		-- WHERE a.siterf = new.siterf and a.storeid = new.storeid and a.mmyy = new.mmyy and a.drugid = new.drugid and a.drugcode = new.drugcode;
	-- ELSEIF new.type = 'Insert' then		
		-- UPDATE phainventoryh a	
		-- set  a.qtyt = a.qtyt + new.qtyt, a.qtyimp = a.qtyimp + new.qtyimp, a.qtyexp = a.qtyexp + new.qtyexp, a.qtyrep = a.qtyrep + new.qtyrep, a.userup = new.userup
		-- WHERE a.siterf = new.siterf and a.storeid = new.storeid and a.mmyy = new.mmyy and a.drugid = new.drugid and a.drugcode = new.drugcode;	
	-- End IF;
-- END
-- --invenl--
-- BEGIN	 	 	
	-- IF (new.qtyt < 0 or new.qtyimp < 0 or new.qtyexp < 0 or new.qtyrep < 0 or (new.qtyt + new.qtyimp - new.qtyexp - new.qtyrep < 0)) then
		-- -- thong tin hien thi theo thu tu: storeid, mmyy, drugid, qtyt, qtyimp, qtyexp, qtyrep
		-- set @msg := concat('phainventoryl: ', new.storeid, ', ', new.mmyy, ', ', new.drugid, ', ', cast(new.qtyt as DECIMAL(24,3)), ', ', cast(new.qtyimp as DECIMAL(24,3)), ', ', cast(new.qtyexp as DECIMAL(24,3)), ', ', cast(new.qtyrep as DECIMAL(24,3)));
		-- SIGNAL SQLSTATE '45000' set message_text = @msg;
	-- End IF;
-- END
