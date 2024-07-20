ALTER PROCEDURE [dbo].[sp_create_structure_table_final]
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
	
		DECLARE @name nvarchar(1000)
		DECLARE @usercr varchar(1000)
	
	/*IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = @mmyynew)
	BEGIN
	EXEC sp_create_schema_mmyy(@mmyynew) 
	END*/

	DECLARE tbl_cursor CURSOR FOR
	SELECT mmyy,code,name,usercr
 from dbo.systable WHERE active = 1 AND mmyy = @mmyycurent
	OPEN tbl_cursor
	FETCH NEXT from tbl_cursor INTO @schemacurrent,@tablename,@name,@usercr

	WHILE @@FETCH_STATUS = 0 BEGIN
	--SET @cmdInsert='INSERT INTO  '+@tablename+ '( mmyy,code ) VALUES (' +@mmyynew+','+@tablename+')';
	IF NOT EXISTS (SELECT * FROM  dbo.systable WHERE mmyy = @mmyynew and active = 1 and code = @tablename)
	BEGIN
	INSERT INTO systable (mmyy,code,name,siterf,isuser,active,usercr,timecr) VALUES (@mmyynew,@tablename,@name,1,1,1,@usercr,GETDATE())
	update dbo.systable  set isuser = 0 where mmyy = @mmyyCurent and active = 1;
	 --EXEC (@cmdInsert);
	 SET @cmdClone=' Select Top 0 * into mmyy'+@mmyynew +'.'+@tablename+ ' from mmyy'+@schemacurrent+'.'+@tablename;
   EXEC (@cmdClone);
	END
	 	FETCH NEXT from tbl_cursor INTO @schemacurrent,@tablename,@name,@usercr --duyet record kế tiếp
END;
CLOSE tbl_cursor --đóng con trỏ
DEALLOCATE tbl_cursor-- giải phóng con trỏ



ALTER PROCEDURE sp_create_schema_mmyy
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
--IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = @SchemaNew)
  BEGIN
	INSERT INTO dbo.sysschema (mmyy,name,siterf,active,timecr,timeup) VALUES (@mmyyNew,@SchemaNew,1,1,GETDATE(),GETDATE());
		update dbo.sysschema  set active = 0 where mmyy = @mmyyCurent and name = @schemacurent and active = 1;
  set @cmd='create schema '+@SchemaNew;
  exec (@cmd);
  END;
END


