use Poster
go
create function ExportToXMLFIlms(@path nvarchar(500))
returns int as 
begin
	declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'Films'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLCinemas(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'Cinemas'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;

go
create function ExportToXMLMIC(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'MoviesInCinemas'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLConcerts(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'Concerts'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLConcertHalls(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'ConcertHalls'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLCICH(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'ConcertsInConcertHalls'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLExhibitions(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'Exhibitions'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLExhibitionCenters(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'ExhibitionCenters'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLEIEC(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'ExhibitionsInExhibitionCenters'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLCalendar(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'Calendar'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLBM(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'BookedMovies'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLBC(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'BookedConcerts'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLBE(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'BookedExhibitions'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;
go
create function ExportToXMLUsers(@path nvarchar(500))
returns int as 
begin
declare @sql nvarchar(500)=
				  'bcp "SELECT	*	'+							
		'FROM	'+  'Users'  + 																							
		 ' FOR XML PATH(''Order''), ROOT(''Root'')" queryout "'+@path+'"  -S DESKTOP-5220QSD  -d Poster   -w -T '; 
		EXEC xp_cmdshell @sql;
	return 1;
end;


go
create procedure ExportToXML
@path nvarchar(400) as
begin
  declare @film int
  declare @cinema int
  declare @MIC int
  declare @concerts int
  declare @concertHalls int
  declare @CICH int
  declare @exhibitions int
  declare @exhibitionCenters int
  declare @EIEC int
  declare @calendar int
  declare @BM int
  declare @BC int
  declare @BE int
  declare @users int
  set @film = dbo.ExportToXMLFIlms(@path + '\Films.xml' )
  set @cinema = dbo.ExportToXMLCinemas(@path + '\Cinemas.xml')
  set @MIC = dbo.ExportToXMLMIC(@path + '\MIC.xml')
  set @concerts = dbo.ExportToXMLConcerts(@path + '\Concerts.xml')
  set @concertHalls = dbo.ExportToXMLConcertHalls(@path + '\ConcertHalls.xml')
  set @CICH = dbo.ExportToXMLCICH(@path + '\CICH.xml')
  set @exhibitions = dbo.ExportToXMLExhibitions(@path + '\Exhibitions.xml')
  set @exhibitionCenters = dbo.ExportToXMLExhibitionCenters(@path + '\ExhibitionCenters.xml')
  set @EIEC = dbo.ExportToXMLEIEC(@path + '\EIEC.xml')
  set @calendar = dbo.ExportToXMLCalendar(@path + '\Calendar.xml')
  set @BM = dbo.ExportToXMLBM(@path + '\BM.xml')
  set @BC = dbo.ExportToXMLBC(@path + '\BC.xml')
  set @BE = dbo.ExportToXMLBE(@path + '\BE.xml')
  set @users = dbo.ExportToXMLUsers(@path + '\Users.xml')
end;