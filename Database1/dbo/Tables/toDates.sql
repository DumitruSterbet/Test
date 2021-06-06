CREATE TABLE [dbo].[toDates] (
    [Id]    INT IDENTITY (1, 1) NOT NULL,
    [Day]   INT NOT NULL,
    [Month] INT NOT NULL,
    [Year]  INT NOT NULL,
    CONSTRAINT [PK_toDates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

