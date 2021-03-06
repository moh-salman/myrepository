USE [PaymentDB]
GO
/****** Object:  Table [dbo].[Merchant]    Script Date: 23 Feb 2020 19:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Merchant](
	[merchantid] [int] NOT NULL,
	[apikey] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[merchantid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 23 Feb 2020 19:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[paymentid] [varchar](255) NOT NULL,
	[merchantid] [int] NULL,
	[cardnumber] [varchar](255) NULL,
	[cardholdername] [varchar](max) NULL,
	[cardtype] [varchar](max) NULL,
	[expirydate] [varchar](max) NULL,
	[status] [int] NULL,
	[amount] [float] NULL,
	[paymentdate] [datetime] NOT NULL,
	[currency] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[paymentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Merchant] ([merchantid], [apikey]) VALUES (1000, N'15f5d102-88c6-4b7a-a094-dc5a6cc270f4')
INSERT [dbo].[Merchant] ([merchantid], [apikey]) VALUES (1001, N'b4341c84-0e37-4496-9d7a-ab58a325051e')
INSERT [dbo].[Merchant] ([merchantid], [apikey]) VALUES (1002, N'11d22b6a-b777-433f-b1cd-9d1a1ee7177a')
INSERT [dbo].[Merchant] ([merchantid], [apikey]) VALUES (1003, N'd4fdc554-937f-4a44-bec6-6344bcd4efe9')
INSERT [dbo].[Merchant] ([merchantid], [apikey]) VALUES (1004, N'27f7225b-9ef6-4371-b1d4-fe8663c364c9')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'01137d08-d506-4c33-b9d8-d5247920ea6e', 1000, N'4547739567657049', N'Homer Simpsons', N'VISA', N'04/22', 2002, 5000, CAST(N'2020-02-23T11:28:54.320' AS DateTime), N'MUR')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'17acfc4c-b352-4deb-b3f7-2306a2f3137c', 1000, N'6759291632878588', N'Tom Hardy', N'MASTERCARD', N'12/22', 2001, 500, CAST(N'2020-02-23T19:05:14.120' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'27bdf0d9-9451-43d3-8b6b-85244fa3cb9b', 1000, N'6759291632878588', N'Tom Hardy', N'MASTERCARD', N'12/22', 2002, 15000, CAST(N'2020-02-23T19:06:08.237' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'5dfdcb14-21ee-460c-a5e7-e1ac5f8e7ed5', 1000, N'6759291632878588', N'Tom Hardy', N'MASTERCARD', N'12/22', 1000, 500, CAST(N'2020-02-22T10:50:01.660' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'64858238-fe89-42be-8fb9-ab0f21df31a2', 1000, N'6759291632878590', N'Tom Hardy', N'MASTERCARD', N'10/22', 2000, 500, CAST(N'2020-02-23T19:00:48.450' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'7cb2e855-ff8a-4a8b-ae72-b43dbee55f15', 1000, N'4547739567657049', N'Homer Simpsons', N'VISA', N'04/22', 2001, 5000, CAST(N'2020-02-23T11:28:15.640' AS DateTime), N'MUR')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'8508c84f-7f09-445c-84b9-fcfc1f3b7f46', 1000, N'6226323207911141', N'Micheal Sin', N'MASTERCARD', N'01/24', 2000, 200, CAST(N'2020-02-22T10:50:01.660' AS DateTime), N'GBP')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'88dc2109-cacf-4fad-babb-a929b202b409', 1000, N'2377054 08263528', N'Sarah Chu', N'VISA', N'10/22', 2003, 5000, CAST(N'2020-02-23T11:23:52.347' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'8c27f936-7f89-44c9-947f-5e2fb034148c', 1000, N'4547739567657049', N'Homer Simpsons', N'VISA', N'04/22', 2000, 5000, CAST(N'2020-02-23T11:31:24.033' AS DateTime), N'MUR')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'9d8a256b-66cc-425e-af45-86c6115880d8', 1000, N'6759291632878588', N'Tom Hardy', N'MASTERCARD', N'12/22', 1000, 500, CAST(N'2020-02-23T18:40:49.920' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'9f108b93-ca42-4fc2-89e0-a1adcd90e5d2', 1000, N'2377054708263528', N'Sarah Chu', N'VISA', N'12/22', 1000, 5000, CAST(N'2020-02-23T11:20:29.900' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'a3a070dd-b959-4d84-befa-1dd77ba98baf', 1000, N'6759291632878588', N'Tom Hardy', N'MASTERCARD', N'10/22', 2003, 500, CAST(N'2020-02-23T19:02:00.820' AS DateTime), N'USD')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'a7e36d8a-8b9d-49b4-b410-cf3f9a5ee4e3', 1002, N'6762476347202597', N'Billy Black', N'MASTERCARD', N'05/22', 3000, 1000, CAST(N'2020-02-22T10:50:01.660' AS DateTime), N'INR')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'c1be1a4a-ee6c-48d9-9e6a-5aaae11fb0c0', 1004, N'4547739567657049', N'Homer Simpsons', N'VISA', N'04/22', 1000, 5000, CAST(N'2020-02-22T10:50:01.660' AS DateTime), N'MUR')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'd7ca65ba-8f0e-469e-b637-24e7405f7bd1', 1003, N'2377054708263528', N'Sarah Chu', N'VISA', N'12/22', 1000, 400, CAST(N'2020-02-22T10:50:01.660' AS DateTime), N'EUR')
INSERT [dbo].[Payment] ([paymentid], [merchantid], [cardnumber], [cardholdername], [cardtype], [expirydate], [status], [amount], [paymentdate], [currency]) VALUES (N'dde5cb76-a264-4864-9beb-6d2c20d5c40a', 1000, N'6759291632878590', N'Tom Hardy', N'MASTERCARD', N'12/22', 2000, 500, CAST(N'2020-02-23T18:59:19.467' AS DateTime), N'USD')
ALTER TABLE [dbo].[Payment] ADD  DEFAULT (getdate()) FOR [paymentdate]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([merchantid])
REFERENCES [dbo].[Merchant] ([merchantid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
