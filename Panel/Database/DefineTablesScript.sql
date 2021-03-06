USE [GeneratorSurveillanceDB]
GO
/****** Object:  Table [dbo].[ActionPartySettings]    Script Date: 03/17/2019 3:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionPartySettings](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[FirstNameActionParty] [nvarchar](50) NOT NULL,
	[LastNameActionParty] [nvarchar](50) NOT NULL,
	[EmailActionParty] [nvarchar](70) NOT NULL,
	[PhoneNumberActionParty] [nvarchar](20) NOT NULL,
	[JobTitleActionParty] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthoriserSettings]    Script Date: 03/17/2019 3:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthoriserSettings](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[FirstNameAuthoriser] [nvarchar](50) NOT NULL,
	[LastNameAuthoriser] [nvarchar](50) NOT NULL,
	[EmailAuthoriser] [nvarchar](70) NOT NULL,
	[PhoneNumberAuthoriser] [nvarchar](20) NOT NULL,
	[JobTitleAuthoriser] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsumptionSettings]    Script Date: 03/17/2019 3:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsumptionSettings](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[GeneratorName] [nvarchar](50) NOT NULL,
	[CurrentConsumption] [float] NOT NULL,
	[TestConsumption] [float] NOT NULL,
	[StandardConsumption] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneratorFuelling]    Script Date: 03/17/2019 3:56:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneratorFuelling](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[Vendor] [varchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[VolumeOfDiesel] [float] NOT NULL,
	[CostOfDiesel] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneratorMaintenance]    Script Date: 03/17/2019 3:56:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneratorMaintenance](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[GeneratorName] [varchar](100) NOT NULL,
	[MaintenanceType] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[Comments] [varchar](2000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneratorRunningHrs]    Script Date: 03/17/2019 3:56:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneratorRunningHrs](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[Generator] [varchar](100) NOT NULL,
	[Date] [datetime] NOT NULL,
	[RunningHours] [float] NOT NULL,
	[CumFuelVolumeSinceLastReading] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneratorScheduler]    Script Date: 03/17/2019 3:56:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneratorScheduler](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[GeneratorName] [varchar](100) NOT NULL,
	[Starts] [datetime2](7) NOT NULL,
	[Every] [float] NOT NULL,
	[ReminderLevel] [varchar](20) NOT NULL,
	[Authoriser] [varchar](100) NOT NULL,
	[ReminderHoursProfile] [float] NOT NULL,
	[ReminderDateTimeProfile] [datetime2](7) NOT NULL,
	[IsActive] [varchar](4) NOT NULL,
	[IsRepetitive] [varchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneratorUsage]    Script Date: 03/17/2019 3:56:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneratorUsage](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[GeneratorName] [varchar](100) NOT NULL,
	[GeneratorStarted] [datetime2](7) NOT NULL,
	[GeneratorStopped] [datetime2](7) NOT NULL,
	[IsArchived] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passwords]    Script Date: 03/17/2019 3:56:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passwords](
	[Id] [int] NOT NULL,
	[SN] [int] NOT NULL,
	[ReminderPassword] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActionPartySettings] ADD  DEFAULT ('') FOR [FirstNameActionParty]
GO
ALTER TABLE [dbo].[ActionPartySettings] ADD  DEFAULT ('') FOR [LastNameActionParty]
GO
ALTER TABLE [dbo].[ActionPartySettings] ADD  DEFAULT ('') FOR [EmailActionParty]
GO
ALTER TABLE [dbo].[ActionPartySettings] ADD  DEFAULT ('') FOR [PhoneNumberActionParty]
GO
ALTER TABLE [dbo].[ActionPartySettings] ADD  DEFAULT ('') FOR [JobTitleActionParty]
GO
ALTER TABLE [dbo].[AuthoriserSettings] ADD  DEFAULT ('') FOR [FirstNameAuthoriser]
GO
ALTER TABLE [dbo].[AuthoriserSettings] ADD  DEFAULT ('') FOR [LastNameAuthoriser]
GO
ALTER TABLE [dbo].[AuthoriserSettings] ADD  DEFAULT ('') FOR [EmailAuthoriser]
GO
ALTER TABLE [dbo].[AuthoriserSettings] ADD  DEFAULT ('') FOR [PhoneNumberAuthoriser]
GO
ALTER TABLE [dbo].[AuthoriserSettings] ADD  DEFAULT ('') FOR [JobTitleAuthoriser]
GO
ALTER TABLE [dbo].[GeneratorRunningHrs] ADD  DEFAULT ((0.0)) FOR [RunningHours]
GO
ALTER TABLE [dbo].[GeneratorRunningHrs] ADD  DEFAULT ((0.0)) FOR [CumFuelVolumeSinceLastReading]
GO
ALTER TABLE [dbo].[GeneratorScheduler] ADD  DEFAULT ((0.0)) FOR [Every]
GO
ALTER TABLE [dbo].[GeneratorScheduler] ADD  DEFAULT ((0.0)) FOR [ReminderHoursProfile]
GO
ALTER TABLE [dbo].[GeneratorScheduler] ADD  DEFAULT ('No') FOR [IsActive]
GO
ALTER TABLE [dbo].[GeneratorScheduler] ADD  DEFAULT ('No') FOR [IsRepetitive]
GO
USE [master]
GO
ALTER DATABASE [GeneratorSurveillanceDB] SET  READ_WRITE 
GO