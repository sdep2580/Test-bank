/*
LeeCustomerData 的部署指令碼

這段程式碼由工具產生。
變更這個檔案可能導致不正確的行為，而且如果重新產生程式碼，
變更將會遺失。
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "LeeCustomerData"
:setvar DefaultFilePrefix "LeeCustomerData"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
偵測 SQLCMD 模式，如果不支援 SQLCMD 模式，則停用指令碼執行。
若要在啟用 SQLCMD 模式後重新啟用指令碼，請執行以下:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'必須啟用 SQLCMD 模式才能成功執行此指令碼。';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'已略過索引鍵為 66961062-a4b5-4e0a-8970-a69835f0b8c9 的重新命名重構作業，項目 [dbo].[FCustomerData].[Company] (SqlSimpleColumn) 將不會重新命名為 Company_yn';


GO
PRINT N'正在建立 [dbo].[CustomerData]...';


GO
CREATE TABLE [dbo].[CustomerData] (
    [CustomerId] INT           IDENTITY (1, 1) NOT NULL,
    [CustomerNo] NCHAR (10)    NULL,
    [LastName]   NVARCHAR (50) NULL,
    [FirstName]  NVARCHAR (50) NULL,
    [Age]        INT           NULL,
    [Sex]        CHAR (2)      NULL,
    [AMT]        DECIMAL (18)  NOT NULL,
    [SignUpDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);


GO
PRINT N'正在建立 [dbo].[FCustomerData]...';


GO
CREATE TABLE [dbo].[FCustomerData] (
    [Id]         INT            NOT NULL,
    [CustomerNo] NCHAR (10)     NOT NULL,
    [LastName]   NVARCHAR (50)  NULL,
    [FirstName]  NVARCHAR (50)  NULL,
    [Curcd]      CHAR (3)       NULL,
    [Rate]       DECIMAL (6, 4) NULL,
    [Amt]        DECIMAL (18)   NULL,
    [Company_yn] CHAR (1)       NULL,
    [Freeze_yn]  CHAR (1)       NULL,
    [Obu]        CHAR (1)       NULL,
    [ModifyDate] DATE           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- 用於更新含有部署交易記錄之目標伺服器的重構步驟

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '66961062-a4b5-4e0a-8970-a69835f0b8c9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('66961062-a4b5-4e0a-8970-a69835f0b8c9')

GO

GO
PRINT N'更新完成。';


GO
