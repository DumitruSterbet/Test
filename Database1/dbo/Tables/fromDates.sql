CREATE TABLE [dbo].[fromDates] (
    [Id]    INT IDENTITY (1, 1) NOT NULL,
    [Day]   INT NOT NULL,
    [Month] INT NOT NULL,
    [Year]  INT NOT NULL,
    CONSTRAINT [PK_fromDates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

