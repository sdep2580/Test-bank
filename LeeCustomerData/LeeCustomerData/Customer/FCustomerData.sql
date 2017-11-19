CREATE TABLE [dbo].[FCustomerData]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[CustomerNo] NCHAR(10) NOT NULL, 
	[LastName] NVARCHAR(50) NULL, 
	[FirstName] NVARCHAR(50) NULL, 
	[Curcd] CHAR(3) NULL, 
	[Rate] DECIMAL(6,4) NULL,
	[Amt] DECIMAL NULL, 
	[Company_yn] CHAR(1) NULL,
	[Freeze_yn] CHAR(1) NULL, 
	[Obu] CHAR(1) NULL,
	[ModifyDate] DATE NULL
)
