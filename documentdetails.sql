USE [ccis]
GO
/****** Object:  Table [dbo].[documentdetails]    Script Date: 05/23/2012 05:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documentdetails](
	[Signatory] [nvarchar](250) NULL,
	[SignatoryDesignation] [nvarchar](250) NULL,
	[Evaluator] [nvarchar](250) NULL,
	[EvaluatorDesignation] [nvarchar](250) NULL,
	[NotedBy] [nvarchar](250) NULL,
	[NoterDesignation] [nvarchar](250) NULL
) ON [PRIMARY]
