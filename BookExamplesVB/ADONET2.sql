use [ADONET]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Customer_Invoice_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT Customer_Invoice_FK1


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Invoice_InvoiceItem_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[InvoiceItem] DROP CONSTRAINT Invoice_InvoiceItem_FK1


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Product_InvoiceItem_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[InvoiceItem] DROP CONSTRAINT Product_InvoiceItem_FK1


/****** Object:  Table [dbo].[Customer]    Script Date: 4/8/2002 11:18:02 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Customer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Customer]


/****** Object:  Table [dbo].[Invoice]    Script Date: 4/8/2002 11:18:02 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Invoice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Invoice]


/****** Object:  Table [dbo].[InvoiceItem]    Script Date: 4/8/2002 11:18:02 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InvoiceItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[InvoiceItem]


/****** Object:  Table [dbo].[Product]    Script Date: 4/8/2002 11:18:02 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Product]

/****** Object:  Table [dbo].[Customer]    Script Date: 4/12/2002 2:20:53 PM ******/
CREATE TABLE [dbo].[Customer] (
	[CustomerID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MiddleName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Address] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Apartment] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[City] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[State] [nchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Zip] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HomePhone] [nvarchar] (14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[BusinessPhone] [nvarchar] (14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DOB] [datetime] NULL ,
	[Discount] [float] NULL ,
	[Stamp] [timestamp] NOT NULL ,
	[CheckedOut] [bit] NOT NULL CONSTRAINT [DF_Customer_CheckedOut] DEFAULT (0)
) ON [PRIMARY]

/****** Object:  Table [dbo].[Invoice]    Script Date: 4/8/2002 11:18:07 PM ******/
CREATE TABLE [dbo].[Invoice] (
	[InvoiceID] [uniqueidentifier] NOT NULL ,
	[InvoiceNumber] [int] IDENTITY (100, 1) NOT NULL ,
	[InvoiceDate] [datetime] NOT NULL ,
	[Terms] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FOB] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PO] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CustomerID] [uniqueidentifier] NULL 
) ON [PRIMARY]


/****** Object:  Table [dbo].[InvoiceItem]    Script Date: 4/8/2002 11:18:07 PM ******/
CREATE TABLE [dbo].[InvoiceItem] (
	[InvoiceItemID] [uniqueidentifier] NOT NULL ,
	[InvoiceID] [uniqueidentifier] NOT NULL ,
	[ProductID] [int] NOT NULL ,
	[Quantity] [int] NOT NULL ,
	[Discount] [float] NOT NULL 
) ON [PRIMARY]


/****** Object:  Table [dbo].[Product]    Script Date: 4/8/2002 11:18:07 PM ******/
CREATE TABLE [dbo].[Product] (
	[ProductID]  [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Vendor] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Cost] [money] NOT NULL ,
	[InStock] [bit] NOT NULL,
	[Price] [money] NOT NULL 
) ON [PRIMARY]


ALTER TABLE [dbo].[Customer] WITH NOCHECK ADD 
	CONSTRAINT [Customer_PK] PRIMARY KEY  CLUSTERED 
	(
		[CustomerID]
	)  ON [PRIMARY] 


ALTER TABLE [dbo].[Invoice] WITH NOCHECK ADD 
	CONSTRAINT [Invoice_PK] PRIMARY KEY  CLUSTERED 
	(
		[InvoiceID]
	)  ON [PRIMARY] 


ALTER TABLE [dbo].[InvoiceItem] WITH NOCHECK ADD 
	CONSTRAINT [InvoiceItem_PK] PRIMARY KEY  CLUSTERED 
	(
		[InvoiceItemID]
	)  ON [PRIMARY] 


ALTER TABLE [dbo].[Product] WITH NOCHECK ADD 
	CONSTRAINT [Product_PK] PRIMARY KEY  CLUSTERED 
	(
		[ProductID]
	)  ON [PRIMARY] 

ALTER TABLE [dbo].[Product] WITH NOCHECK ADD 
	CONSTRAINT [DF_Product_InStock] DEFAULT (1) FOR [InStock]

ALTER TABLE [dbo].[Customer] WITH NOCHECK ADD 
	CONSTRAINT [DF_Customer_CustomerID] DEFAULT (newid()) FOR [CustomerID]


ALTER TABLE [dbo].[Invoice] WITH NOCHECK ADD 
	CONSTRAINT [DF_Invoice_InvoiceID] DEFAULT (newid()) FOR [InvoiceID]


ALTER TABLE [dbo].[InvoiceItem] WITH NOCHECK ADD 
	CONSTRAINT [DF_InvoiceItem_InvoiceItemID] DEFAULT (newid()) FOR [InvoiceItemID]


ALTER TABLE [dbo].[Invoice] ADD 
	CONSTRAINT [Customer_Invoice_FK1] FOREIGN KEY 
	(
		[CustomerID]
	) REFERENCES [dbo].[Customer] (
		[CustomerID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 


ALTER TABLE [dbo].[InvoiceItem] ADD 
	CONSTRAINT [Invoice_InvoiceItem_FK1] FOREIGN KEY 
	(
		[InvoiceID]
	) REFERENCES [dbo].[Invoice] (
		[InvoiceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [Product_InvoiceItem_FK1] FOREIGN KEY 
	(
		[ProductID]
	) REFERENCES [dbo].[Product] (
		[ProductID]
	)


/* ADD CUSTOMERS */

INSERT INTO ADONET.dbo.Customer
  (CustomerID, FirstName, LastName, Address, City, State, Zip, HomePhone)
  VALUES ('11D59CB7-BF61-4540-9317-4F154D717796', 'Greg', 'Maddux', '100 Henry Aaron Way', 'Atlanta', 'GA', '30307', '404-555-1234');

  
  
INSERT INTO ADONET.dbo.Customer
  (CustomerID, FirstName, LastName, Address, City, State, Zip, HomePhone)
  VALUES ('80FCE1C0-176F-4367-AEFA-66DEB58E6BED', 'Tom', 'Glavine', '100 Henry Aaron Way', 'Atlanta', 'GA', '30307', '404-555-1235');
  

  
INSERT INTO ADONET.dbo.Customer
  (CustomerID, FirstName, LastName, Address, City, State, Zip, HomePhone)
  VALUES ('2541729B-AFFF-482E-A4A9-A2E6BBCFEAB4', 'John', 'Smoltz', '100 Henry Aaron Way', 'Atlanta', 'GA', '30307', '404-555-1236');
  


/* ADD PRODUCTS */

INSERT INTO ADONET.dbo.Product ( Description, Vendor, Cost, Price)
VALUES ('Baseball Bat, Slugger','Louisville', 11.5000, 19.9900);



INSERT INTO ADONET.dbo.Product (Description, Vendor, Cost, Price)
VALUES ('Baseball Mitt','Wilson',24.7500,29.9900);



INSERT INTO ADONET.dbo.Product (Description, Vendor, Cost, Price)
VALUES ('Baseball','Rawlings',0.9500,1.7500);



INSERT INTO ADONET.dbo.Product (Description, Vendor, Cost, Price)
VALUES ('Basketball','Rawlings',11.5400,14.5000);



/* ADD INVOICES */

INSERT INTO ADONET.dbo.Invoice
  (InvoiceID, InvoiceDate, Terms, PO, CustomerID)
  VALUES ('463CDF10-2609-41F3-99A3-05F4CEDF9FE2', '2002-03-21', 'Net 30', '100042', '11D59CB7-BF61-4540-9317-4F154D717796');


  
INSERT INTO ADONET.dbo.Invoice
  (InvoiceID, InvoiceDate, Terms, PO, CustomerID)
  VALUES ('5E1E9BEB-5915-4513-8D67-0F3E0F6A81D0', '2002-03-31', 'Net 30', '100104', '11D59CB7-BF61-4540-9317-4F154D717796');


  
INSERT INTO ADONET.dbo.Invoice
  (InvoiceID, InvoiceDate, Terms, PO, CustomerID)
  VALUES ('45CA216E-EA75-4C4C-81BC-3A81698EEA2C', '2002-03-24', 'Net 30', '100085', '80FCE1C0-176F-4367-AEFA-66DEB58E6BED');
  

  
INSERT INTO ADONET.dbo.Invoice
  (InvoiceID, InvoiceDate, Terms, PO, CustomerID)
  VALUES ('9847592F-616D-4CCF-9147-D51A86B731C0', '2002-03-27', 'Net 30', '100304', '2541729B-AFFF-482E-A4A9-A2E6BBCFEAB4');
  


INSERT INTO ADONET.dbo.Invoice
  (InvoiceID, InvoiceDate, Terms, PO, CustomerID)
   VALUES ('A931D7DC-9806-4403-8F71-F479466EE953', '2002-04-01', 'Net 30', '100594', '2541729B-AFFF-482E-A4A9-A2E6BBCFEAB4');
   


/* ADD INVOICE ITEMS */

INSERT INTO ADONET.dbo.InvoiceItem
  (InvoiceItemID, InvoiceID, ProductID, Quantity, Discount)
  VALUES ('4150D81C-79CB-458B-A303-047E3CD6DBEA', '5E1E9BEB-5915-4513-8D67-0F3E0F6A81D0', 1, 1, 0.000000000000000e+000);


  
INSERT INTO ADONET.dbo.InvoiceItem
  (InvoiceItemID, InvoiceID, ProductID, Quantity, Discount)
  VALUES ('42426D45-E39A-467C-8017-2DC52C7BA58B', '9847592F-616D-4CCF-9147-D51A86B731C0', 1, 1, 0.000000000000000e+000);
  

  
INSERT INTO ADONET.dbo.InvoiceItem
  (InvoiceItemID, InvoiceID, ProductID, Quantity, Discount)
  VALUES ('04F0CB70-5DE1-4C3E-8821-83664B2E09B5', '45CA216E-EA75-4C4C-81BC-3A81698EEA2C', 2, 1, 0.000000000000000e+000);
  

  
INSERT INTO ADONET.dbo.InvoiceItem
  (InvoiceItemID, InvoiceID, ProductID, Quantity, Discount)
  VALUES ('A3895169-8E34-4ADF-9CC1-9C3EC9814549', 'A931D7DC-9806-4403-8F71-F479466EE953', 3, 1, 0.000000000000000e+000);
  

  
INSERT INTO ADONET.dbo.InvoiceItem
  (InvoiceItemID, InvoiceID, ProductID, Quantity, Discount)
  VALUES ('C7395127-891D-4ED4-8C37-D4E73BCFDF55', '463CDF10-2609-41F3-99A3-05F4CEDF9FE2', 4, 2, 42.500000000000000e-001);
  

  
INSERT INTO ADONET.dbo.InvoiceItem
  (InvoiceItemID, InvoiceID, ProductID, Quantity, Discount)
  VALUES ('B30B585F-5FE7-48FD-B97A-E7A31BAD0D72', '463CDF10-2609-41F3-99A3-05F4CEDF9FE2', 2, 3, 0.000000000000000e+000);


  
