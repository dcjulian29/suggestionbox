CREATE TABLE [dbo].[Questions]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NULL,
    [Subject] [nvarchar](100) NULL,
    [Body] [nvarchar](max) NULL,
    [Liked] [integer] NULL,
    [WhenPosted] [datetime] NULL
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
