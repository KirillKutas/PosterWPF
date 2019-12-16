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
   --���������� ������ � �������
   INSERT INTO TestTable(TextData)
     VALUES ('��������� Database Engine � �������� ������ ��� ��������, ��������� � ������ ������'),
            ('������ Integration Services � ��� ��������� ��� ���������� ������� �� ���������� � �������������� ������ ������ �����������.'),
            ('������ Reporting Services � ��� ��������� ��������� �������, ��������������� ����������� ��� ������� ������ � �������� ��� ������������� ���������� ������.'),
            ('���������� ������������ ����� ����� ���������� ����������� � ��������������� ������ � �������� ��� ������ ����� ������ ������, � ����� ������������� ��� ������ ��� ����������� ���������������.'),
            ('��������� SQL Server Service Broker ������������ ����������� ��������� ���������� SQL Server Database Engine ��� ���������� ������ ����������� � ���������� � ��������� ���������.'),
            ('SQL � ���� ����������������� ��������, ����������� ��� ��������, ����������� � ���������� ������� � ������������ ����������� ���� ������.'),
            ('C++ � ���� ���������������� ������ ����������, ������� ������������ ��� �����������, ��� � ��������-��������������� ����������������.'),
            ('Transact-SQL � ���� ����������������, ����������� ���������� ����� SQL, ������������� ��������� Microsoft.'),
            ('PL/SQL � ���� ����������������, ����������� ���������� ����� SQL, ������������� ����������� Oracle.'),
            ('Microsoft Visual Basic � ��������������� ����� ���������� ������������ �����������, ������������� ����������� Microsoft.'),
            ('C# � ��������-��������������� ���� ����������������. ������������� ��������� Microsoft ��� ���� ���������� ���������� ��� ��������� Microsoft .NET Framework.');
   GO