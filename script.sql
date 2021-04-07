USE [QuanLyKhoNhapMon]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 4/4/2021 7:45:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[username] [nvarchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[code] [varchar](10) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[dob] [datetime] NULL,
	[gender] [bit] NULL,
	[phoneNumber] [varchar](11) NULL,
	[dayOne] [datetime] NULL,
	[identify] [varchar](15) NOT NULL,
	[flag] [bit] NULL, -- 0: lock, 1:active
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


create PROC [dbo].[SP_Login]
@username nvarchar(20), @password nvarchar(20)
AS
BEGIN
	SELECT * FROM employee WHERE username = @username AND password = @password
END

create PROC [dbo].[SP_CheckAcc]
@username nvarchar(20), @password nvarchar(20)
AS
BEGIN
	SELECT * FROM employee WHERE username = @username AND password = @password
	and flag = 1
END

