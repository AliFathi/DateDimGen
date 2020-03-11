SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DateDimension](
	[Date] [DATE] NOT NULL,
	[LongDate] [NVARCHAR](100) NOT NULL,
	[DayOfWeek] [INT] NOT NULL,
	[DayOfWeekName] [NVARCHAR](50) NOT NULL,
	[DayOfMonth] [INT] NOT NULL,
	[DayOfYear] [INT] NOT NULL,
	[Month] [INT] NOT NULL,
	[MonthName] [NVARCHAR](50) NOT NULL,
	[Year] [INT] NOT NULL,
	[PersianDate] [NVARCHAR](50) NOT NULL,
	[PersianDateInt] [INT] NOT NULL,
	[PersianLongDate] [NVARCHAR](100) NOT NULL,
	[PersianDayOfWeek] [INT] NOT NULL,
	[PersianDayOfWeekName] [NVARCHAR](50) NOT NULL,
	[PersianDayOfMonth] [INT] NOT NULL,
	[PersianDayOfYear] [INT] NOT NULL,
	[PersianWeekOfMonth] [INT] NOT NULL,
	[PersianWeekOfYear] [INT] NOT NULL,
	[PersianMonth] [INT] NOT NULL,
	[PersianMonthName] [NVARCHAR](50) NOT NULL,
	[PersianQuarter] [INT] NOT NULL,
	[PersianQuarterName] [NVARCHAR](50) NOT NULL,
	[PersianHalfYear] [INT] NOT NULL,
	[PersianHalfYearName] [NVARCHAR](50) NOT NULL,
	[PersianYear] [INT] NOT NULL,
	[PersianIsLeapYear] [BIT] NOT NULL,
 CONSTRAINT [PK_DateDimension] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


