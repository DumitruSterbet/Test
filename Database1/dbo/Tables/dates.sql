CREATE TABLE [dbo].[dates] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [DayOfWeek] INT NOT NULL,
    [Day]       INT NOT NULL,
    [Month]     INT NOT NULL,
    [Year]      INT NOT NULL,
    CONSTRAINT [PK_dates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

