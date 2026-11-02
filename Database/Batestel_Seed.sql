
USE [Batestel];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    -- INITIAL ROLES

    IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleName = N'Admin')
        INSERT INTO dbo.Roles (RoleName, Description)
        VALUES (N'Admin', N'Full access including user management');

    IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleName = N'Manager')
        INSERT INTO dbo.Roles (RoleName, Description)
        VALUES (N'Manager', N'POS, products, inventory and analytics');

    IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleName = N'Cashier')
        INSERT INTO dbo.Roles (RoleName, Description)
        VALUES (N'Cashier', N'Point of sale only');


    -- INITIAL PERMISSIONS

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Products.View')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Products.View', N'View products');

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Products.Edit')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Products.Edit', N'Add and edit products');

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Inventory.Adjust')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Inventory.Adjust', N'Adjust inventory');

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Orders.Create')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Orders.Create', N'Create orders');

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Orders.Void')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Orders.Void', N'Void orders');

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Reports.View')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Reports.View', N'View reports');

    IF NOT EXISTS (SELECT 1 FROM dbo.Permissions WHERE PermissionCode = N'Users.Manage')
        INSERT INTO dbo.Permissions (PermissionCode, Description)
        VALUES (N'Users.Manage', N'Manage user accounts');


    -- ADMIN PERMISSIONS

    INSERT INTO dbo.RolePermissions (RoleId, PermissionId)
    SELECT r.RoleId, p.PermissionId
    FROM dbo.Roles r
    CROSS JOIN dbo.Permissions p
    WHERE r.RoleName = N'Admin'
    AND NOT EXISTS (
        SELECT 1
        FROM dbo.RolePermissions rp
        WHERE rp.RoleId = r.RoleId
        AND rp.PermissionId = p.PermissionId
    );


    -- MANAGER PERMISSIONS

    INSERT INTO dbo.RolePermissions (RoleId, PermissionId)
    SELECT r.RoleId, p.PermissionId
    FROM dbo.Roles r
    CROSS JOIN dbo.Permissions p
    WHERE r.RoleName = N'Manager'
    AND p.PermissionCode <> N'Users.Manage'
    AND NOT EXISTS (
        SELECT 1
        FROM dbo.RolePermissions rp
        WHERE rp.RoleId = r.RoleId
        AND rp.PermissionId = p.PermissionId
    );


    -- CASHIER PERMISSIONS

    INSERT INTO dbo.RolePermissions (RoleId, PermissionId)
    SELECT r.RoleId, p.PermissionId
    FROM dbo.Roles r
    CROSS JOIN dbo.Permissions p
    WHERE r.RoleName = N'Cashier'
    AND p.PermissionCode IN (N'Products.View', N'Orders.Create')
    AND NOT EXISTS (
        SELECT 1
        FROM dbo.RolePermissions rp
        WHERE rp.RoleId = r.RoleId
        AND rp.PermissionId = p.PermissionId
    );


    -- INITIAL PRODUCT CATEGORIES

    IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE Name = N'Beverages')
        INSERT INTO dbo.Categories (Name, Description)
        VALUES (N'Beverages', N'Drinks and beverages');

    IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE Name = N'Snacks')
        INSERT INTO dbo.Categories (Name, Description)
        VALUES (N'Snacks', N'Snack foods');

    IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE Name = N'Groceries')
        INSERT INTO dbo.Categories (Name, Description)
        VALUES (N'Groceries', N'Daily grocery items');

    IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE Name = N'Household')
        INSERT INTO dbo.Categories (Name, Description)
        VALUES (N'Household', N'Household essentials');

    IF NOT EXISTS (SELECT 1 FROM dbo.Categories WHERE Name = N'Personal Care')
        INSERT INTO dbo.Categories (Name, Description)
        VALUES (N'Personal Care', N'Personal hygiene and care products');


    -- DEFAULT ADMIN ACCOUNT

    IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = N'admin')
    BEGIN
        INSERT INTO dbo.Users
            (Username, PasswordHash, Salt, FirstName, LastName, RoleId, IsActive)
        SELECT
            N'admin',
            '1F9A42E8A16F7688E8073DDAE2224035159F224C24065D351CEC86AF9BECDC66',
            '6F1B160738FEA13E580497732EB7E99D',
            N'Admin',
            N'Account',
            RoleId,
            1
        FROM dbo.Roles
        WHERE RoleName = N'Admin';
    END;


    -- DEFAULT CASHIER ACCOUNT

    IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = N'cashier')
    BEGIN
        INSERT INTO dbo.Users
            (Username, PasswordHash, Salt, FirstName, LastName, RoleId, IsActive)
        SELECT
            N'cashier',
            'D3F63B413A3447AC65F6CA86FED541975835CE1FC1F757BEDAE1388FFAFA52B8',
            '4392E7C035F82F0B2CE21EDCE889B7BD',
            N'Cashier',
            N'Account',
            RoleId,
            1
        FROM dbo.Roles
        WHERE RoleName = N'Cashier';
    END;


    -- DEFAULT MANAGER ACCOUNT

    IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = N'manager')
    BEGIN
        INSERT INTO dbo.Users
            (Username, PasswordHash, Salt, FirstName, LastName, RoleId, IsActive)
        SELECT
            N'manager',
            'AA627CE2263185EC34396320BAA520421FE563E6F23B7DEDA594275486B701C7',
            'FC68886905B5210EC594F40F1F44E298',
            N'Manager',
            N'Account',
            RoleId,
            1
        FROM dbo.Roles
        WHERE RoleName = N'Manager';
    END;


    -- VERIFY REQUIRED ROLES AND ACCOUNTS

    IF EXISTS (
        SELECT Required.Username
        FROM (VALUES
            (N'admin', N'Admin'),
            (N'cashier', N'Cashier'),
            (N'manager', N'Manager')
        ) AS Required(Username, RoleName)
        LEFT JOIN dbo.Users u
            ON u.Username = Required.Username
        LEFT JOIN dbo.Roles r
            ON r.RoleId = u.RoleId
        WHERE u.UserId IS NULL
           OR r.RoleName <> Required.RoleName
           OR u.IsActive <> 1
    )
    BEGIN
        THROW 50001, 'Default account verification failed.', 1;
    END;


    -- COMMIT ONLY IF EVERYTHING SUCCEEDS

    COMMIT TRANSACTION;

    PRINT 'GreBaPOS initial database seeding completed successfully.';

END TRY
BEGIN CATCH

    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    THROW;

END CATCH;
GO


-- FINAL ACCOUNT VERIFICATION

SELECT
    u.UserId,
    u.Username,
    r.RoleName,
    u.IsActive
FROM dbo.Users u
INNER JOIN dbo.Roles r
    ON u.RoleId = r.RoleId
WHERE u.Username IN (N'admin', N'cashier', N'manager')
ORDER BY r.RoleName;
GO
