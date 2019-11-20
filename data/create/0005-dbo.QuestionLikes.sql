CREATE TABLE [dbo].[QuestionLikes]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HashedIpAddress] [nvarchar](255) NOT NULL,
    [LastTimeLiked] [datetime] NOT NULL,
    [QuestionId] [int] NULL
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
