CREATE TABLE [dbo].[UsedUrls] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UsedUrls] PRIMARY KEY CLUSTERED ([Id] ASC)
);

