CREATE TABLE [dbo].[Comments]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Blocked] [bit] NULL,
    [Text] [nvarchar](max) NULL,
    [Liked] [int] NULL,
    [WhenPosted] [datetime] NULL,
    [ParentQuestion] [int] NULL
    PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    ) WITH (
        PAD_INDEX = OFF, 
        STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, 
        ALLOW_ROW_LOCKS = ON, 
        ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT FK_Comments_Question_ParentQuestion
        FOREIGN KEY (ParentQuestion)
        REFERENCES Questions (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
