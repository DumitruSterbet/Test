CREATE TABLE [dbo].[Countries] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CountryCode]  NVARCHAR (MAX) NULL,
    [Regions]      NVARCHAR (MAX) NULL,
    [HolidayTypes] NVARCHAR (MAX) NULL,
    [FullName]     NVARCHAR (MAX) NULL,
    [FromDateId]   INT            NOT NULL,
    [ToDateId]     INT            NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Countries_fromDates_FromDateId] FOREIGN KEY ([FromDateId]) REFERENCES [dbo].[fromDates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Countries_toDates_ToDateId] FOREIGN KEY ([ToDateId]) REFERENCES [dbo].[toDates] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Countries_FromDateId]
    ON [dbo].[Countries]([FromDateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Countries_ToDateId]
    ON [dbo].[Countries]([ToDateId] ASC);

