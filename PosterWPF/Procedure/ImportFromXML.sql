use Poster
go
create procedure ImportFromXmlFilms
@path nvarchar(500) as
begin
	delete from Films

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into [Films]([Id],Name,DescriptionAndActors,Photo,Genre, Country, Duration)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('DescriptionAndActors[1]', 'varchar(50)') AS DescriptionAndActors,
		P.value('Photo[1]', 'varbinary(max)') AS Photo,
		P.value('Genre[1]', 'varchar(50)') AS Genre,
		P.value('Country[1]', 'varchar(50)') AS Country,
		P.value('Duration[1]', 'varchar(30)') AS Duration
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlCinemas
@path nvarchar(500) as
begin
	delete from Cinemas

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into [Cinemas]([Id],[Name],[Adress],[Photo])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Adress[1]', 'varchar(70)') AS [Adress],
		P.value('Photo[1]', 'varbinary(max)') AS Photo
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlMIC
@path nvarchar(500) as
begin
	delete from MoviesInCinemas

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into MoviesInCinemas([Id],DateID,FilmsId,CinemasId,Price,[Time],[FreeSpaces],[ReservedSpaces])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('DateID[1]', 'int') AS DateID,
		P.value('FilmsId[1]', 'int') AS FilmsId,
		P.value('CinemasId[1]', 'int') AS CinemasId,
		P.value('Price[1]', 'int') AS Price,
		P.value('Time[1]', 'varchar(50)') AS [Time],
		P.value('FreeSpaces[1]', 'int') AS [FreeSpaces],
		P.value('ReservedSpaces[1]', 'int') AS [ReservedSpaces]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlCalendar
@path nvarchar(500) as
begin
	delete from Calendar

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into Calendar([Id],[Date])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Date[1]', 'date') AS [Date]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlConcerts
@path nvarchar(500) as
begin
	delete from Concerts

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into Concerts([Id],[Name],[Description],[Time],Photo,Genre)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Description[1]', 'varchar(70)') AS [Description],
		P.value('Time[1]', 'varchar(50)') AS [Time],
		P.value('Photo[1]', 'varbinary(max)') AS Photo,
		P.value('Genre[1]', 'varchar(50)') AS Genre	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlConcertHalls
@path nvarchar(500) as
begin
	delete from ConcertHalls

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into ConcertHalls([Id],[Name],[Adress],[Photo])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Adress[1]', 'varchar(70)') AS [Adress],
		P.value('Photo[1]', 'varbinary(max)') AS Photo	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlExhibitionCenters
@path nvarchar(500) as
begin
	delete from ExhibitionCenters

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into ExhibitionCenters([Id],[Name],[Adress],[Photo])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Adress[1]', 'varchar(70)') AS [Adress],
		P.value('Photo[1]', 'varbinary(max)') AS Photo	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlCICH
@path nvarchar(500) as
begin
	delete from ConcertsInConcertHalls

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into ConcertsInConcertHalls([Id],DateID,ConcertsId,ConcertsHallsId,Price,[FreeSpaces],[ReservedSpaces])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('DateID[1]', 'int') AS DateID,
		P.value('ConcertsId[1]', 'int') AS ConcertsId,
		P.value('ConcertsHallsId[1]', 'int') AS ConcertsHallsId,
		P.value('Price[1]', 'int') AS Price,
		P.value('FreeSpaces[1]', 'int') AS [FreeSpaces],
		P.value('ReservedSpaces[1]', 'int') AS [ReservedSpaces]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlExhibitions
@path nvarchar(500) as
begin
	delete from Exhibitions

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into Exhibitions([Id],[Name],[DescriptionAndActors],Photo,[Time],Genre)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('DescriptionAndActors[1]', 'varchar(70)') AS [DescriptionAndActors],
		P.value('Photo[1]', 'varbinary(max)') AS Photo,
		P.value('Time[1]', 'varchar(50)') AS [Time],
		P.value('Genre[1]', 'varchar(50)') AS Genre	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlEIEC
@path nvarchar(500) as
begin
	delete from ExhibitionsInExhibitionCenters

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into ExhibitionsInExhibitionCenters([Id],DateID,ExhibitionsId,ExhibitionCentersId,Price,[FreeSpaces],[ReservedSpaces])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('DateID[1]', 'int') AS DateID,
		P.value('ExhibitionsId[1]', 'int') AS ExhibitionsId,
		P.value('ExhibitionCentersId[1]', 'int') AS ExhibitionCentersId,
		P.value('Price[1]', 'int') AS Price,
		P.value('FreeSpaces[1]', 'int') AS [FreeSpaces],
		P.value('ReservedSpaces[1]', 'int') AS [ReservedSpaces]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlBM
@path nvarchar(500) as
begin
	delete from BookedMovies

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into BookedMovies([Id],UserId,FilmId,DateId)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('UserId[1]', 'int') AS UserId,
		P.value('FilmId[1]', 'int') AS FilmId,
		P.value('DateId[1]', 'int') AS DateId	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlBC
@path nvarchar(500) as
begin
	delete from BookedConcerts

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into BookedConcerts([Id],UserId,ConcertId,DateId)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('UserId[1]', 'int') AS UserId,
		P.value('ConcertId[1]', 'int') AS ConcertId,
		P.value('DateId[1]', 'int') AS DateId	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXmlBE
@path nvarchar(500) as
begin
	delete from BookedExhibitions

	SET NOCOUNT ON  
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)=
               'SELECT 
		CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into BookedExhibitions([Id],UserId,ExhibitionId,DateId)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('UserId[1]', 'int') AS UserId,
		P.value('ExhibitionId[1]', 'int') AS ExhibitionId,
		P.value('DateId[1]', 'int') AS DateId	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go
create procedure ImportFromXML
as
begin
  exec dbo.ImportFromXmlFilms 'E:\Kirill\BackupKP\Films.xml'
  exec dbo.ImportFromXmlCinemas 'E:\Kirill\BackupKP\Cinemas.xml'
  exec dbo.ImportFromXmlCalendar 'E:\Kirill\BackupKP\Calendar.xml'
  exec dbo.ImportFromXmlMIC 'E:\Kirill\BackupKP\MIC.xml'
  exec dbo.ImportFromXmlConcerts 'E:\Kirill\BackupKP\Concerts.xml'
  exec dbo.ImportFromXmlConcertHalls 'E:\Kirill\BackupKP\ConcertHalls.xml'
  exec dbo.ImportFromXmlCICH 'E:\Kirill\BackupKP\CICH.xml'
  exec dbo.ImportFromXmlExhibitionCenters 'E:\Kirill\BackupKP\ExhibitionCenters.xml'
  exec dbo.ImportFromXmlExhibitions 'E:\Kirill\BackupKP\Exhibitions.xml'
  exec dbo.ImportFromXmlEIEC 'E:\Kirill\BackupKP\EIEC.xml'
  exec dbo.ImportFromXmlBM 'E:\Kirill\BackupKP\BM.xml'
  exec dbo.ImportFromXmlBC 'E:\Kirill\BackupKP\BC.xml'
  exec dbo.ImportFromXmlBE 'E:\Kirill\BackupKP\BE.xml'
end;