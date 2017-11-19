CREATE TABLE [dbo].[CustomerData]
(
	[CustomerId] INT IDENTITY (1,1) NOT NULL,
	[CustomerNo]     NCHAR    (10)   NULL, 
	[LastName]       NVARCHAR (50)   NULL,
	[FirstName]      NVARCHAR (50)   NULL,
	[Age]            INT             NULL,
	[Sex]            CHAR     (02)   NULL,
	[AMT]            DECIMAL  (18)   NOT NULL,
	[SignUpDate]     DATETIME        NULL,
	PRIMARY KEY CLUSTERED ([CustomerId] ASC)
)
