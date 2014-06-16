CREATE DATABASE [mPort]
GO

USE [mPort]
GO
/****** Object:  Table [dbo].[members]    Script Date: 06/16/2014 15:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](255) NOT NULL,
 CONSTRAINT [PK_members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[booths]    Script Date: 06/16/2014 15:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booths](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_booths] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_name] UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[scans]    Script Date: 06/16/2014 15:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[scans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[booth_id] [int] NOT NULL,
	[member_id] [int] NOT NULL,
	[height] [float] NOT NULL,
	[weight] [float] NOT NULL,
	[waist] [float] NOT NULL,
 CONSTRAINT [PK_scans] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_scans_booths]    Script Date: 06/16/2014 15:19:54 ******/
ALTER TABLE [dbo].[scans]  WITH CHECK ADD  CONSTRAINT [FK_scans_booths] FOREIGN KEY([booth_id])
REFERENCES [dbo].[booths] ([id])
GO
ALTER TABLE [dbo].[scans] CHECK CONSTRAINT [FK_scans_booths]
GO
/****** Object:  ForeignKey [FK_scans_members]    Script Date: 06/16/2014 15:19:54 ******/
ALTER TABLE [dbo].[scans]  WITH CHECK ADD  CONSTRAINT [FK_scans_members] FOREIGN KEY([member_id])
REFERENCES [dbo].[members] ([id])
GO
ALTER TABLE [dbo].[scans] CHECK CONSTRAINT [FK_scans_members]
GO