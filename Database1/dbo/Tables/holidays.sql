CREATE TABLE [dbo].[holidays] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DateId]      INT            NOT NULL,
    [NameIds]     NVARCHAR (MAX) NULL,
    [HolidayType] NVARCHAR (MAX) NULL,
    [Country]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_holidays] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_holidays_dates_DateId] FOREIGN KEY ([DateId]) REFERENCES [dbo].[dates] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_holidays_DateId]
    ON [dbo].[holidays]([DateId] ASC);

