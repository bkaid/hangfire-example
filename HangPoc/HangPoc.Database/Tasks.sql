﻿CREATE TABLE [dbo].[Tasks]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CreatedUtc] DATETIME2 NOT NULL, 
    [ExpiresAtUtc] DATETIME2 NOT NULL, 
    [IsExpired] BIT NOT NULL DEFAULT 0
)
