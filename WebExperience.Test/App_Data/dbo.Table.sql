CREATE TABLE [dbo].[Table]
(
	[AssetId] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [file_name] VARCHAR(50) NULL, 
    [mime_type] VARCHAR(50) NULL, 
    [created_by] VARCHAR(50) NULL, 
    [email] NVARCHAR(50) NULL, 
    [country] VARCHAR(50) NULL, 
    [description] VARCHAR(500) NULL
)
