USE [controlcasa]
GO

CREATE TABLE [dbo].[users](
	[username] [varchar](100) NOT NULL PRIMARY KEY,
	[password] [nvarchar](1000) NULL
)

GO

insert into users
(username,password)
values('francisco',N'옛㢕੭቏擆૎㬃Ϋᙛ')