CREATE TABLE [dbo].[Employee_T] (
    [ID]        INT          NOT NULL,
    [FirstName] VARCHAR (32) NOT NULL,
    [LastName]  VARCHAR (32) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Log_T] (
    [ID]         INT      NOT NULL,
    [Content]    TEXT     NULL,
    [DateLogged] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Product_T] (
    [ID]                 INT             NOT NULL,
    [ProductName]        VARCHAR (30)    NOT NULL,
    [ProductDescription] TEXT            NOT NULL,
    [ProductQuantity]    INT             NOT NULL,
    [ProductSalePrice]   DECIMAL (10, 2) NOT NULL,
    [ProductBuyPrice]    DECIMAL (10, 2) NULL,
    [isDiscounted]       BINARY (1)      NULL,
    [DiscountedPrice]    DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Transaction_T] (
    [ID]                INT             NOT NULL,
    [ProductQuantity]   INT             NOT NULL,
    [PurchasedProduct]  VARCHAR (50)    NOT NULL,
    [ExclusiveDiscount] DECIMAL (10, 2) NOT NULL,
    [Tax]               DECIMAL (10, 2) NOT NULL,
    [TotalSale]         DECIMAL (10, 2) NOT NULL,
    [SaleDate]          DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

