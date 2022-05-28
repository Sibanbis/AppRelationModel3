CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [CompanyName] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Companies_CompanyName] FOREIGN KEY ([CompanyName])
	REFERENCES [dbo].[Companies] ([Name]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_CompanyName]
    ON [dbo].[Users]([CompanyName] ASC);

