USE [master];
GO

IF DB_ID(N'Batestel') IS NULL
BEGIN
    CREATE DATABASE [Batestel];
END
GO

USE [Batestel]
GO
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLogs](
	[AuditId] [bigint] IDENTITY(1,1) NOT NULL,
	[ActorUserId] [int] NULL,
	[Action] [nvarchar](100) NOT NULL,
	[TargetUserId] [int] NULL,
	[Details] [nvarchar](1000) NULL,
	[CreatedAt] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Categories_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](30) NULL,
	[Email] [nvarchar](120) NULL,
	[Street] [nvarchar](100) NULL,
	[Barangay] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryLog]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ChangeQty] [int] NOT NULL,
	[Reason] [nvarchar](200) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_InventoryLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[LineTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](30) NOT NULL,
	[CustomerId] [int] NULL,
	[UserId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[TaxAmount] [decimal](18, 2) NOT NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[PaymentMethod] [nvarchar](20) NOT NULL,
	[AmountPaid] [decimal](18, 2) NOT NULL,
	[ChangeDue] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Orders_Number] UNIQUE NONCLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[PermissionCode] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Permissions_Code] UNIQUE NONCLUSTERED 
(
	[PermissionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Sku] [nvarchar](30) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[StockQty] [int] NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[ImagePath] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Products_Sku] UNIQUE NONCLUSTERED 
(
	[Sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Roles_RoleName] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [varchar](64) NOT NULL,
	[Salt] [varchar](32) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastLoginAt] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_Barcode]    Script Date: 02/11/2026 00:19:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_Barcode] ON [dbo].[Products]
(
	[Barcode] ASC
)
WHERE ([Barcode] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuditLogs] ADD  CONSTRAINT [DF_AuditLogs_CreatedAt]  DEFAULT (sysdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[InventoryLog] ADD  CONSTRAINT [DF_InventoryLog_Created]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Date]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Discount]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Status]  DEFAULT (N'Completed') FOR [Status]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Stock]  DEFAULT ((0)) FOR [StockQty]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Reorder]  DEFAULT ((5)) FOR [ReorderLevel]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UpdatedAt]  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[AuditLogs]  WITH CHECK ADD  CONSTRAINT [FK_AuditLogs_Actor] FOREIGN KEY([ActorUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[AuditLogs] CHECK CONSTRAINT [FK_AuditLogs_Actor]
GO
ALTER TABLE [dbo].[AuditLogs]  WITH CHECK ADD  CONSTRAINT [FK_AuditLogs_Target] FOREIGN KEY([TargetUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[AuditLogs] CHECK CONSTRAINT [FK_AuditLogs_Target]
GO
ALTER TABLE [dbo].[InventoryLog]  WITH CHECK ADD  CONSTRAINT [FK_InventoryLog_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[InventoryLog] CHECK CONSTRAINT [FK_InventoryLog_Products]
GO
ALTER TABLE [dbo].[InventoryLog]  WITH CHECK ADD  CONSTRAINT [FK_InventoryLog_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[InventoryLog] CHECK CONSTRAINT [FK_InventoryLog_Users]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permissions] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([PermissionId])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permissions]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [CK_OrderDetails_Qty] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [CK_OrderDetails_Qty]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [CK_Orders_Payment] CHECK  (([PaymentMethod]=N'Mobile' OR [PaymentMethod]=N'Card' OR [PaymentMethod]=N'Cash'))
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [CK_Orders_Payment]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [CK_Orders_Status] CHECK  (([Status]=N'Voided' OR [Status]=N'Completed'))
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [CK_Orders_Status]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_Cost] CHECK  (([Cost]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_Cost]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_Price] CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_Price]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_Reorder] CHECK  (([ReorderLevel]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_Reorder]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_Stock] CHECK  (([StockQty]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_Stock]
GO
/****** Object:  StoredProcedure [dbo].[usp_AuditLog_Insert]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_AuditLog_Insert]
    @ActorUserId INT,
    @Action NVARCHAR(100),
    @TargetUserId INT = NULL,
    @Details NVARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR(
            'Permission denied: Users.Manage required.',
            16,
            1
        );
        RETURN;
    END;

    INSERT INTO dbo.AuditLogs
        (ActorUserId, Action, TargetUserId, Details)
    VALUES
        (@ActorUserId, @Action, @TargetUserId, @Details);
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_AuditLog_List]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 4. View audit history */
CREATE   PROCEDURE [dbo].[usp_AuditLog_List]
    @ActorUserId INT,
    @Search NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR('Permission denied: Users.Manage required.', 16, 1);
        RETURN;
    END;

    SELECT
        a.AuditId,
        a.ActorUserId,
        actor.Username AS ActorUsername,
        a.Action,
        a.TargetUserId,
        targetUser.Username AS TargetUsername,
        a.Details,
        a.CreatedAt
    FROM dbo.AuditLogs AS a
    LEFT JOIN dbo.Users AS actor
        ON actor.UserId = a.ActorUserId
    LEFT JOIN dbo.Users AS targetUser
        ON targetUser.UserId = a.TargetUserId
    WHERE
        @Search IS NULL
        OR a.Action LIKE '%' + @Search + '%'
        OR a.Details LIKE '%' + @Search + '%'
        OR actor.Username LIKE '%' + @Search + '%'
        OR targetUser.Username LIKE '%' + @Search + '%'
    ORDER BY a.CreatedAt DESC, a.AuditId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Inventory_Adjust]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_Inventory_Adjust]
    @ProductId INT,
    @ChangeQty INT,
    @Reason NVARCHAR(200),
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Check Inventory.Adjust permission
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Inventory.Adjust'
    )
    BEGIN
        RAISERROR(
            'You do not have permission to adjust inventory.',
            16, 1
        );
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Cur INT;

        SELECT @Cur = StockQty
        FROM dbo.Products WITH (UPDLOCK, ROWLOCK)
        WHERE ProductId = @ProductId;

        IF @Cur IS NULL
        BEGIN
            RAISERROR('Product not found.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        IF @Cur + @ChangeQty < 0
        BEGIN
            RAISERROR(
                'Adjustment would make stock negative.',
                16, 1
            );
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        UPDATE dbo.Products
        SET
            StockQty = @Cur + @ChangeQty,
            UpdatedAt = GETDATE()
        WHERE ProductId = @ProductId;

        INSERT INTO dbo.InventoryLog
        (
            ProductId,
            ChangeQty,
            Reason,
            UserId
        )
        VALUES
        (
            @ProductId,
            @ChangeQty,
            @Reason,
            @UserId
        );

        COMMIT TRANSACTION;

        SELECT @Cur + @ChangeQty AS NewStock;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Login]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ===================== AUTH ===================== */

CREATE PROCEDURE [dbo].[usp_Login] @Username NVARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON;
   SELECT u.UserId, u.Username, u.PasswordHash, u.Salt, 
          u.FirstName, u.MiddleName, u.LastName,
          CONCAT(u.FirstName, N' ', COALESCE(u.MiddleName + N' ', N''), u.LastName) AS FullName,
          u.RoleId, r.RoleName, u.IsActive
  FROM dbo.Users u JOIN dbo.Roles r ON r.RoleId = u.RoleId
  WHERE u.Username = @Username;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Order_Create]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_Order_Create]
    @UserId INT,
    @CustomerId INT = NULL,
    @PaymentMethod NVARCHAR(20),
    @DiscountAmount DECIMAL(18,2) = 0,
    @TaxRate DECIMAL(5,2) = 0,
    @AmountPaid DECIMAL(18,2),
    @ItemsXml XML
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Check Orders.Create permission
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Orders.Create'
    )
    BEGIN
        RAISERROR(
            'You do not have permission to create orders.',
            16, 1
        );
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Items TABLE
        (
            ProductId INT NOT NULL PRIMARY KEY,
            Quantity INT NOT NULL
        );

        INSERT INTO @Items (ProductId, Quantity)
        SELECT
            ProductId,
            SUM(Quantity)
        FROM
        (
            SELECT
                x.value('@ProductId', 'INT') AS ProductId,
                x.value('@Quantity', 'INT') AS Quantity
            FROM @ItemsXml.nodes('/Items/Item') AS t(x)
        ) AS s
        GROUP BY ProductId;

        IF NOT EXISTS (SELECT 1 FROM @Items)
        BEGIN
            RAISERROR('The order has no items.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        IF EXISTS (SELECT 1 FROM @Items WHERE Quantity <= 0)
        BEGIN
            RAISERROR('Invalid item quantity.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM @Items AS i
            LEFT JOIN dbo.Products AS p
                WITH (UPDLOCK, ROWLOCK)
                ON p.ProductId = i.ProductId
            WHERE p.ProductId IS NULL
               OR p.IsActive = 0
        )
        BEGIN
            RAISERROR(
                'One or more products are unavailable.',
                16, 1
            );
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        DECLARE @Msg NVARCHAR(200);

        SELECT TOP 1
            @Msg = N'Insufficient stock for ' + p.Name
                + N' (available: '
                + CAST(p.StockQty AS NVARCHAR(10)) + N').'
        FROM @Items AS i
        INNER JOIN dbo.Products AS p
            ON p.ProductId = i.ProductId
        WHERE p.StockQty < i.Quantity;

        IF @Msg IS NOT NULL
        BEGIN
            RAISERROR(@Msg, 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        DECLARE @Subtotal DECIMAL(18,2);

        SELECT
            @Subtotal = SUM(p.Price * i.Quantity)
        FROM @Items AS i
        INNER JOIN dbo.Products AS p
            ON p.ProductId = i.ProductId;

        IF @DiscountAmount < 0
           OR @DiscountAmount > @Subtotal
        BEGIN
            RAISERROR('Invalid discount amount.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        DECLARE @Tax DECIMAL(18,2);

        SET @Tax = ROUND(
            (@Subtotal - @DiscountAmount) * @TaxRate / 100.0,
            2
        );

        DECLARE @Total DECIMAL(18,2);

        SET @Total = @Subtotal - @DiscountAmount + @Tax;

        IF @AmountPaid < @Total
        BEGIN
            RAISERROR(
                'Amount paid is less than the total.',
                16, 1
            );
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        INSERT INTO dbo.Orders
        (
            OrderNumber,
            CustomerId,
            UserId,
            OrderDate,
            Subtotal,
            TaxAmount,
            DiscountAmount,
            Total,
            PaymentMethod,
            AmountPaid,
            ChangeDue,
            Status
        )
        VALUES
        (
            LEFT(CONVERT(NVARCHAR(36), NEWID()), 30),
            @CustomerId,
            @UserId,
            GETDATE(),
            @Subtotal,
            @Tax,
            @DiscountAmount,
            @Total,
            @PaymentMethod,
            @AmountPaid,
            @AmountPaid - @Total,
            N'Completed'
        );

        DECLARE @OrderId INT;

        SET @OrderId = SCOPE_IDENTITY();

        DECLARE @OrderNumber NVARCHAR(30);

        SET @OrderNumber =
            N'ORD-' + CONVERT(NVARCHAR(8), GETDATE(), 112)
            + N'-'
            + RIGHT(
                N'000000' + CAST(@OrderId AS NVARCHAR(10)),
                6
            );

        UPDATE dbo.Orders
        SET OrderNumber = @OrderNumber
        WHERE OrderId = @OrderId;

        INSERT INTO dbo.OrderDetails
        (
            OrderId,
            ProductId,
            Quantity,
            UnitPrice,
            LineTotal
        )
        SELECT
            @OrderId,
            i.ProductId,
            i.Quantity,
            p.Price,
            p.Price * i.Quantity
        FROM @Items AS i
        INNER JOIN dbo.Products AS p
            ON p.ProductId = i.ProductId;

        UPDATE p
        SET
            StockQty = p.StockQty - i.Quantity,
            UpdatedAt = GETDATE()
        FROM dbo.Products AS p
        INNER JOIN @Items AS i
            ON i.ProductId = p.ProductId;

        INSERT INTO dbo.InventoryLog
        (
            ProductId,
            ChangeQty,
            Reason,
            UserId
        )
        SELECT
            i.ProductId,
            -i.Quantity,
            N'Sale ' + @OrderNumber,
            @UserId
        FROM @Items AS i;

        COMMIT TRANSACTION;

        SELECT @OrderId AS Id;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);

        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Order_Void]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_Order_Void]
    @OrderId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Check Orders.Void permission
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Orders.Void'
    )
    BEGIN
        RAISERROR(
            'You do not have permission to void orders.',
            16, 1
        );
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if the order exists and is completed
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Orders WITH (UPDLOCK, ROWLOCK)
            WHERE OrderId = @OrderId
              AND Status = N'Completed'
        )
        BEGIN
            RAISERROR(
                'Order not found or has already been voided.',
                16, 1
            );

            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Restore product stock
        UPDATE p
        SET
            p.StockQty = p.StockQty + od.Quantity,
            p.UpdatedAt = GETDATE()
        FROM dbo.Products AS p
        INNER JOIN dbo.OrderDetails AS od
            ON od.ProductId = p.ProductId
        WHERE od.OrderId = @OrderId;

        -- Record restored stock in InventoryLog
        INSERT INTO dbo.InventoryLog
        (
            ProductId,
            ChangeQty,
            Reason,
            UserId
        )
        SELECT
            od.ProductId,
            od.Quantity,
            N'Voided Order ' + o.OrderNumber,
            @UserId
        FROM dbo.OrderDetails AS od
        INNER JOIN dbo.Orders AS o
            ON o.OrderId = od.OrderId
        WHERE od.OrderId = @OrderId;

        -- Update order status
        UPDATE dbo.Orders
        SET Status = N'Voided'
        WHERE OrderId = @OrderId;

        COMMIT TRANSACTION;

        SELECT
            @OrderId AS OrderId,
            N'Order successfully voided.' AS Message;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Product_Delete]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* PRODUCT DEACTIVATE */
CREATE   PROCEDURE [dbo].[usp_Product_Delete]
    @ProductId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Products.Edit'
    )
    BEGIN
        RAISERROR(
            'You do not have permission to deactivate products.',
            16, 1
        );
        RETURN;
    END;

    UPDATE dbo.Products
    SET
        IsActive = 0,
        UpdatedAt = GETDATE()
    WHERE ProductId = @ProductId;

    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Product not found.', 16, 1);
        RETURN;
    END;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Product_Insert]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* PRODUCT INSERT */
CREATE   PROCEDURE [dbo].[usp_Product_Insert]
    @Sku NVARCHAR(30),
    @Barcode NVARCHAR(50) = NULL,
    @Name NVARCHAR(150),
    @CategoryId INT,
    @Price DECIMAL(18,2),
    @Cost DECIMAL(18,2),
    @StockQty INT,
    @ReorderLevel INT,
    @ImagePath NVARCHAR(255) = NULL,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Products.Edit'
    )
    BEGIN
        RAISERROR(
            'You do not have permission to create products.',
            16, 1
        );
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.Products
        (
            Sku, Barcode, Name, CategoryId, Price, Cost,
            StockQty, ReorderLevel, ImagePath
        )
        VALUES
        (
            @Sku, @Barcode, @Name, @CategoryId, @Price, @Cost,
            @StockQty, @ReorderLevel, @ImagePath
        );

        DECLARE @Id INT = SCOPE_IDENTITY();

        IF @StockQty > 0
        BEGIN
            INSERT INTO dbo.InventoryLog
            (
                ProductId, ChangeQty, Reason, UserId
            )
            VALUES
            (
                @Id, @StockQty, N'Initial stock', @UserId
            );
        END;

        COMMIT TRANSACTION;

        SELECT @Id AS Id;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Product_Update]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* PRODUCT UPDATE */
CREATE   PROCEDURE [dbo].[usp_Product_Update]
    @ProductId INT,
    @Sku NVARCHAR(30),
    @Barcode NVARCHAR(50) = NULL,
    @Name NVARCHAR(150),
    @CategoryId INT,
    @Price DECIMAL(18,2),
    @Cost DECIMAL(18,2),
    @ReorderLevel INT,
    @IsActive BIT,
    @ImagePath NVARCHAR(255) = NULL,
    @ChangeImage BIT = 0,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @UserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Products.Edit'
    )
    BEGIN
        RAISERROR(
            'You do not have permission to update products.',
            16, 1
        );
        RETURN;
    END;

    UPDATE dbo.Products
    SET
        Sku = @Sku,
        Barcode = @Barcode,
        Name = @Name,
        CategoryId = @CategoryId,
        Price = @Price,
        Cost = @Cost,
        ReorderLevel = @ReorderLevel,
        IsActive = @IsActive,
        ImagePath = CASE
            WHEN @ChangeImage = 1 THEN @ImagePath
            ELSE ImagePath
        END,
        UpdatedAt = GETDATE()
    WHERE ProductId = @ProductId;

    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Product not found.', 16, 1);
        RETURN;
    END;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_AnalyticsSummary]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*  ANALYTICS SUMMARY CARDS */
CREATE   PROCEDURE [dbo].[usp_Report_AnalyticsSummary]
    @ActorUserId INT,
    @From DATETIME,
    @To DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        COUNT(*) AS OrderCount,
        COALESCE(SUM(Subtotal), 0) AS GrossSales,
        COALESCE(SUM(DiscountAmount), 0) AS Discounts,
        COALESCE(SUM(TaxAmount), 0) AS Tax,
        COALESCE(SUM(Subtotal - DiscountAmount), 0) AS NetSales
    FROM dbo.Orders
    WHERE Status = N'Completed'
      AND OrderDate >= @From
      AND OrderDate < DATEADD(DAY, 1, @To);
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_DailySales]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*  DAILY SALES */
CREATE   PROCEDURE [dbo].[usp_Report_DailySales]
    @ActorUserId INT,
    @From DATETIME,
    @To DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        CAST(OrderDate AS DATE) AS SaleDay,
        COUNT(*) AS OrderCount,
        COALESCE(SUM(Subtotal), 0) AS GrossSales,
        COALESCE(SUM(DiscountAmount), 0) AS Discounts,
        COALESCE(SUM(TaxAmount), 0) AS Tax,
        COALESCE(SUM(Subtotal - DiscountAmount), 0) AS NetSales,
        COALESCE(SUM(Total), 0) AS TotalCollected
    FROM dbo.Orders
    WHERE Status = N'Completed'
      AND OrderDate >= @From
      AND OrderDate < DATEADD(DAY, 1, @To)
    GROUP BY CAST(OrderDate AS DATE)
    ORDER BY SaleDay;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_Dashboard]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*  Dashboard */
CREATE   PROCEDURE [dbo].[usp_Report_Dashboard]
    @ActorUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        (SELECT ISNULL(SUM(Total), 0)
         FROM dbo.Orders
         WHERE Status = N'Completed'
           AND OrderDate >= CAST(GETDATE() AS DATE)) AS TodaySales,

        (SELECT COUNT(*)
         FROM dbo.Orders
         WHERE Status = N'Completed'
           AND OrderDate >= CAST(GETDATE() AS DATE)) AS TodayOrders,

        (SELECT COUNT(*)
         FROM dbo.Products
         WHERE IsActive = 1
           AND StockQty <= ReorderLevel) AS LowStockCount,

        (SELECT COUNT(*)
         FROM dbo.Products
         WHERE IsActive = 1) AS ActiveProducts;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_InventoryValuation]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*  INVENTORY VALUATION */
CREATE   PROCEDURE [dbo].[usp_Report_InventoryValuation]
    @ActorUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        p.ProductId,
        p.Sku,
        p.Name AS ProductName,
        p.StockQty,
        p.Cost AS UnitCost,
        p.Price AS UnitSellingPrice,
        CAST(p.StockQty * p.Cost AS DECIMAL(18,2))
            AS CostValue,
        CAST(p.StockQty * p.Price AS DECIMAL(18,2))
            AS RetailValue
    FROM dbo.Products p
    ORDER BY p.Name;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_LowStock]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*  Low Stock */
CREATE   PROCEDURE [dbo].[usp_Report_LowStock]
    @ActorUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        ProductId,
        Sku,
        Name,
        StockQty,
        ReorderLevel
    FROM dbo.Products
    WHERE IsActive = 1
      AND StockQty <= ReorderLevel
    ORDER BY StockQty, Name;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_RecentTransactions]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*  Recent Transactions */
CREATE   PROCEDURE [dbo].[usp_Report_RecentTransactions]
    @ActorUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT TOP 50
        o.OrderId,
        o.OrderNumber,
        CONCAT(
            c.FirstName, N' ',
            COALESCE(c.MiddleName + N' ', N''),
            c.LastName
        ) AS CustomerName,
        CONCAT(
            u.FirstName, N' ',
            COALESCE(u.MiddleName + N' ', N''),
            u.LastName
        ) AS CashierName,
        o.OrderDate,
        o.Subtotal,
        o.TaxAmount,
        o.DiscountAmount,
        o.Total,
        o.PaymentMethod,
        o.Status
    FROM dbo.Orders o
    LEFT JOIN dbo.Customers c
        ON c.CustomerId = o.CustomerId
    JOIN dbo.Users u
        ON u.UserId = o.UserId
    ORDER BY o.OrderId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_SalesByCashier]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*  SALES BY CASHIER*/
CREATE   PROCEDURE [dbo].[usp_Report_SalesByCashier]
    @ActorUserId INT,
    @From DATETIME,
    @To DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        u.Username AS Cashier,
        COUNT(*) AS OrderCount,
        COALESCE(SUM(o.Subtotal), 0) AS GrossSales,
        COALESCE(SUM(o.DiscountAmount), 0) AS Discounts,
        COALESCE(SUM(o.Total), 0) AS TotalCollected
    FROM dbo.Orders o
    INNER JOIN dbo.Users u
        ON u.UserId = o.UserId
    WHERE o.Status = N'Completed'
      AND o.OrderDate >= @From
      AND o.OrderDate < DATEADD(DAY, 1, @To)
    GROUP BY u.Username
    ORDER BY SUM(o.Total) DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_SalesByCategory]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*  SALES BY CATEGORY*/
CREATE   PROCEDURE [dbo].[usp_Report_SalesByCategory]
    @ActorUserId INT,
    @From DATETIME,
    @To DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT
        c.Name AS CategoryName,
        SUM(od.Quantity) AS QuantitySold,
        COALESCE(SUM(od.LineTotal), 0) AS SalesAmount
    FROM dbo.OrderDetails od
    INNER JOIN dbo.Orders o ON o.OrderId = od.OrderId
    INNER JOIN dbo.Products p ON p.ProductId = od.ProductId
    INNER JOIN dbo.Categories c ON c.CategoryId = p.CategoryId
    WHERE o.Status = N'Completed'
      AND o.OrderDate >= @From
      AND o.OrderDate < DATEADD(DAY, 1, @To)
    GROUP BY c.Name
    ORDER BY SUM(od.LineTotal) DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Report_TopProducts]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*  TOP PRODUCTS*/
CREATE   PROCEDURE [dbo].[usp_Report_TopProducts]
    @ActorUserId INT,
    @From DATETIME,
    @To DATETIME,
    @Top INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Reports.View'
    )
    BEGIN
        RAISERROR('Permission denied: Reports.View required.', 16, 1);
        RETURN;
    END;

    SELECT TOP (@Top)
        p.ProductId,
        p.Name AS ProductName,
        SUM(od.Quantity) AS QuantitySold,
        COALESCE(SUM(od.LineTotal), 0) AS SalesAmount
    FROM dbo.OrderDetails od
    INNER JOIN dbo.Orders o ON o.OrderId = od.OrderId
    INNER JOIN dbo.Products p ON p.ProductId = od.ProductId
    WHERE o.Status = N'Completed'
      AND o.OrderDate >= @From
      AND o.OrderDate < DATEADD(DAY, 1, @To)
    GROUP BY p.ProductId, p.Name
    ORDER BY
        SUM(od.Quantity) DESC,
        SUM(od.LineTotal) DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Role_List]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 2. List roles */
CREATE   PROCEDURE [dbo].[usp_Role_List]
    @ActorUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR('Permission denied: Users.Manage required.', 16, 1);
        RETURN;
    END;

    SELECT RoleId, RoleName, Description
    FROM dbo.Roles
    ORDER BY RoleName;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_RolePermission_List]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 3. List permissions assigned to a role */
CREATE   PROCEDURE [dbo].[usp_RolePermission_List]
    @ActorUserId INT,
    @RoleId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR('Permission denied: Users.Manage required.', 16, 1);
        RETURN;
    END;

    SELECT
        p.PermissionId,
        p.PermissionCode,
        p.Description,
        CAST(
            CASE WHEN rp.RoleId IS NULL THEN 0 ELSE 1 END
            AS BIT
        ) AS IsAssigned
    FROM dbo.Permissions AS p
    LEFT JOIN dbo.RolePermissions AS rp
        ON rp.PermissionId = p.PermissionId
        AND rp.RoleId = @RoleId
    ORDER BY p.PermissionCode;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Create]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_User_Create]
    @ActorUserId INT,
    @Username NVARCHAR(100),
    @PasswordHash VARCHAR(64),
    @Salt VARCHAR(32),
    @FirstName NVARCHAR(100),
    @MiddleName NVARCHAR(100) = NULL,
    @LastName NVARCHAR(100),
    @RoleId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Users
        WHERE UserId = @ActorUserId
          AND IsActive = 1
    )
        THROW 50001, 'Actor is not an active user.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Users U
        INNER JOIN dbo.RolePermissions RP
            ON RP.RoleId = U.RoleId
        INNER JOIN dbo.Permissions P
            ON P.PermissionId = RP.PermissionId
        WHERE U.UserId = @ActorUserId
          AND U.IsActive = 1
          AND P.PermissionCode = 'Users.Manage'
    )
        THROW 50002,
            'Permission denied: Users.Manage required.', 1;

    -- Duplicate username validation
    IF EXISTS (
        SELECT 1
        FROM dbo.Users
        WHERE LTRIM(RTRIM(Username)) =
              LTRIM(RTRIM(@Username))
    )
        THROW 50003, 'Username already exists.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Roles
        WHERE RoleId = @RoleId
    )
        THROW 50004, 'Invalid role.', 1;

    INSERT INTO dbo.Users
        (
            Username,
            PasswordHash,
            Salt,
            FirstName,
            MiddleName,
            LastName,
            RoleId,
            IsActive,
            CreatedAt
        )
    VALUES
        (
            LTRIM(RTRIM(@Username)),
            @PasswordHash,
            @Salt,
            LTRIM(RTRIM(@FirstName)),
            NULLIF(LTRIM(RTRIM(@MiddleName)), ''),
            LTRIM(RTRIM(@LastName)),
            @RoleId,
            1,
            GETDATE()
        );

    DECLARE @NewUserId INT = SCOPE_IDENTITY();

    EXEC dbo.usp_AuditLog_Insert
        @ActorUserId = @ActorUserId,
        @Action = 'USER_CREATED',
        @TargetUserId = @NewUserId,
        @Details = 'Created user account';

    SELECT @NewUserId AS UserId;
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_User_HasPermission]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 4. Check permissions for a user */
CREATE   PROCEDURE [dbo].[usp_User_HasPermission]
    @UserId INT,
    @PermissionCode NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CAST(
        CASE WHEN EXISTS
        (
            SELECT 1
            FROM dbo.Users AS u
            INNER JOIN dbo.RolePermissions AS rp
                ON rp.RoleId = u.RoleId
            INNER JOIN dbo.Permissions AS p
                ON p.PermissionId = rp.PermissionId
            WHERE u.UserId = @UserId
              AND u.IsActive = 1
              AND p.PermissionCode = @PermissionCode
        )
        THEN 1 ELSE 0 END
        AS BIT
    ) AS HasPermission;
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_User_List]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 1. List users */
CREATE   PROCEDURE [dbo].[usp_User_List]
    @ActorUserId INT,
    @Search NVARCHAR(100) = NULL,
    @RoleId INT = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users u
        INNER JOIN dbo.RolePermissions rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR('Permission denied: Users.Manage required.', 16, 1);
        RETURN;
    END;

    SELECT
        u.UserId,
        u.Username,
        u.FirstName,
        u.MiddleName,
        u.LastName,
        LTRIM(RTRIM(
            CONCAT(
                u.FirstName, ' ',
                CASE
                    WHEN NULLIF(LTRIM(RTRIM(u.MiddleName)), '') IS NOT NULL
                    THEN u.MiddleName + ' '
                    ELSE ''
                END,
                u.LastName
            )
        )) AS FullName,
        u.RoleId,
        r.RoleName,
        u.IsActive,
        u.CreatedAt,
        u.LastLoginAt
    FROM dbo.Users AS u
    INNER JOIN dbo.Roles AS r
        ON r.RoleId = u.RoleId
    WHERE
        (
            @Search IS NULL
            OR u.Username LIKE '%' + @Search + '%'
            OR u.FirstName LIKE '%' + @Search + '%'
            OR u.LastName LIKE '%' + @Search + '%'
        )
        AND (@RoleId IS NULL OR u.RoleId = @RoleId)
        AND (@IsActive IS NULL OR u.IsActive = @IsActive)
    ORDER BY u.UserId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_User_ResetPassword]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_User_ResetPassword]
    @ActorUserId INT,
    @TargetUserId INT,
    @PasswordHash VARCHAR(64),
    @Salt VARCHAR(32)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.Users
        WHERE UserId = @ActorUserId AND IsActive = 1
    )
        THROW 50011, 'Actor is not an active user.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Users U
        INNER JOIN dbo.RolePermissions RP ON RP.RoleId = U.RoleId
        INNER JOIN dbo.Permissions P ON P.PermissionId = RP.PermissionId
        WHERE U.UserId = @ActorUserId
          AND U.IsActive = 1
          AND P.PermissionCode = 'Users.Manage'
    )
        THROW 50012, 'Permission denied: Users.Manage required.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.Users WHERE UserId = @TargetUserId
    )
        THROW 50013, 'Target user not found.', 1;

    UPDATE dbo.Users
    SET PasswordHash = @PasswordHash,
        Salt = @Salt
    WHERE UserId = @TargetUserId;

    EXEC dbo.usp_AuditLog_Insert
        @ActorUserId = @ActorUserId,
        @Action = 'PASSWORD_RESET',
        @TargetUserId = @TargetUserId,
        @Details = 'Password reset by administrator';
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_User_SetStatus]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_User_SetStatus]
    @ActorUserId INT,
    @TargetUserId INT,
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Check Users.Manage permission
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR(
            'Permission denied: Users.Manage required.',
            16, 1
        );
        RETURN;
    END;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Users
            WHERE UserId = @TargetUserId
        )
        BEGIN
            RAISERROR('Target user not found.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        IF @ActorUserId = @TargetUserId AND @IsActive = 0
        BEGIN
            RAISERROR(
                'You cannot deactivate your own account.',
                16, 1
            );
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        UPDATE dbo.Users
        SET IsActive = @IsActive
        WHERE UserId = @TargetUserId;

        INSERT INTO dbo.AuditLogs
        (
            ActorUserId,
            Action,
            TargetUserId,
            Details
        )
        VALUES
        (
            @ActorUserId,
            CASE
                WHEN @IsActive = 1 THEN 'USER_ACTIVATED'
                ELSE 'USER_DEACTIVATED'
            END,
            @TargetUserId,
            CASE
                WHEN @IsActive = 1 THEN 'User account activated.'
                ELSE 'User account deactivated.'
            END
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_User_TouchLogin]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_User_TouchLogin] @UserId INT
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE dbo.Users SET LastLoginAt = GETDATE() WHERE UserId = @UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 02/11/2026 00:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[usp_User_Update]
    @ActorUserId INT,
    @TargetUserId INT,
    @Username NVARCHAR(50),
    @FirstName NVARCHAR(100),
    @MiddleName NVARCHAR(100) = NULL,
    @LastName NVARCHAR(100),
    @RoleId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Check Users.Manage permission
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS u
        INNER JOIN dbo.RolePermissions AS rp
            ON rp.RoleId = u.RoleId
        INNER JOIN dbo.Permissions AS p
            ON p.PermissionId = rp.PermissionId
        WHERE u.UserId = @ActorUserId
          AND u.IsActive = 1
          AND p.PermissionCode = N'Users.Manage'
    )
    BEGIN
        RAISERROR(
            'Permission denied: Users.Manage required.',
            16, 1
        );
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users
        WHERE UserId = @TargetUserId
    )
    BEGIN
        RAISERROR('Selected user was not found.', 16, 1);
        RETURN;
    END;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.Users
        WHERE Username = LTRIM(RTRIM(@Username))
          AND UserId <> @TargetUserId
    )
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Roles
        WHERE RoleId = @RoleId
    )
    BEGIN
        RAISERROR('Invalid role.', 16, 1);
        RETURN;
    END;

    UPDATE dbo.Users
    SET
        Username = LTRIM(RTRIM(@Username)),
        FirstName = LTRIM(RTRIM(@FirstName)),
        MiddleName = NULLIF(LTRIM(RTRIM(@MiddleName)), ''),
        LastName = LTRIM(RTRIM(@LastName)),
        RoleId = @RoleId
    WHERE UserId = @TargetUserId;
END;
GO
USE [master]
GO
ALTER DATABASE [Batestel] SET  READ_WRITE 
GO
