CREATE TABLE [dbo].[names] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Lang] NVARCHAR (MAX) NULL,
    [Text] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_names] PRIMARY KEY CLUSTERED ([Id] ASC)
);

