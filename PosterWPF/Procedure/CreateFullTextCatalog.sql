use Poster
CREATE FULLTEXT CATALOG SearchCatalog
     WITH ACCENT_SENSITIVITY = ON
     AS DEFAULT
     AUTHORIZATION dbo
   GO
   CREATE FULLTEXT INDEX ON TestTable(TextData)
     KEY INDEX PK_TestTable ON (SearchCatalog)
     WITH (CHANGE_TRACKING AUTO)
   GO
   go
   use Poster
    CREATE TABLE TestTable(
     Id INT IDENTITY(1,1) NOT NULL,
     TextData VARCHAR(1000) NULL,
     CONSTRAINT PK_TestTable PRIMARY KEY CLUSTERED (Id ASC)
   );
   GO
   --ƒобавление данных в таблицу
   INSERT INTO TestTable(TextData)
     VALUES (' омпонент Database Engine Ц основна€ служба дл€ хранени€, обработки и защиты данных'),
            ('—лужбы Integration Services Ц это платформа дл€ построени€ решений по интеграции и преобразованию данных уровн€ предпри€ти€.'),
            ('—лужбы Reporting Services Ц это серверна€ платформа отчетов, предоставл€юща€ возможности дл€ удобной работы с отчетами дл€ разнообразных источников данных.'),
            ('–епликаци€ представл€ет собой набор технологий копировани€ и распространени€ данных и объектов баз данных между базами данных, а также синхронизации баз данных дл€ поддержани€ согласованности.'),
            (' омпонент SQL Server Service Broker обеспечивает собственную поддержку компонента SQL Server Database Engine дл€ приложений обмена сообщени€ми и приложений с очеред€ми сообщений.'),
            ('SQL Ц €зык структурированных запросов, примен€емый дл€ создани€, модификации и управлени€ данными в произвольной рел€ционной базе данных.'),
            ('C++ Ц €зык программировани€ общего назначени€, который поддерживает как процедурное, так и объектно-ориентированное программирование.'),
            ('Transact-SQL Ц €зык программировани€, процедурное расширение €зыка SQL, разработанное компанией Microsoft.'),
            ('PL/SQL Ц €зык программировани€, процедурное расширение €зыка SQL, разработанное корпорацией Oracle.'),
            ('Microsoft Visual Basic Ц интегрированна€ среда разработки программного обеспечени€, разработанна€ корпорацией Microsoft.'),
            ('C# Ц объектно-ориентированный €зык программировани€. –азработанный компанией Microsoft как €зык разработки приложений дл€ платформы Microsoft .NET Framework.');
   GO