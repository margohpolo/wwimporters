IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Sales') IS NULL EXEC(N'CREATE SCHEMA [Sales];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Application') IS NULL EXEC(N'CREATE SCHEMA [Application];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Warehouse') IS NULL EXEC(N'CREATE SCHEMA [Warehouse];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Purchasing') IS NULL EXEC(N'CREATE SCHEMA [Purchasing];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Sequences') IS NULL EXEC(N'CREATE SCHEMA [Sequences];');
END;
GO

COMMIT;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    IF SERVERPROPERTY('IsXTPSupported') = 1 AND SERVERPROPERTY('EngineEdition') <> 5
        BEGIN
        IF NOT EXISTS (
            SELECT 1 FROM [sys].[filegroups] [FG] JOIN [sys].[database_files] [F] ON [FG].[data_space_id] = [F].[data_space_id] WHERE [FG].[type] = N'FX' AND [F].[type] = 2)
            BEGIN
            ALTER DATABASE CURRENT SET AUTO_CLOSE OFF;
            DECLARE @db_name nvarchar(max) = DB_NAME();
            DECLARE @fg_name nvarchar(max);
            SELECT TOP(1) @fg_name = [name] FROM [sys].[filegroups] WHERE [type] = N'FX';

            IF @fg_name IS NULL
                BEGIN
                SET @fg_name = @db_name + N'_MODFG';
                EXEC(N'ALTER DATABASE CURRENT ADD FILEGROUP [' + @fg_name + '] CONTAINS MEMORY_OPTIMIZED_DATA;');
                END

            DECLARE @path nvarchar(max);
            SELECT TOP(1) @path = [physical_name] FROM [sys].[database_files] WHERE charindex('\', [physical_name]) > 0 ORDER BY [file_id];
            IF (@path IS NULL)
                SET @path = '\' + @db_name;

            DECLARE @filename nvarchar(max) = right(@path, charindex('\', reverse(@path)) - 1);
            SET @filename = REPLACE(left(@filename, len(@filename) - charindex('.', reverse(@filename))), '''', '''''') + N'_MOD';
            DECLARE @new_path nvarchar(max) = REPLACE(CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS nvarchar(max)), '''', '''''') + @filename;

            EXEC(N'
                ALTER DATABASE CURRENT
                ADD FILE (NAME=''' + @filename + ''', filename=''' + @new_path + ''')
                TO FILEGROUP [' + @fg_name + '];')
            END
        END

    IF SERVERPROPERTY('IsXTPSupported') = 1
    EXEC(N'
        ALTER DATABASE CURRENT
        SET MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT ON;')
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[BuyingGroupID] AS int START WITH 3 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CityID] AS int START WITH 38187 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[ColorID] AS int START WITH 37 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CountryID] AS int START WITH 242 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CustomerCategoryID] AS int START WITH 9 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CustomerID] AS int START WITH 1062 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[DeliveryMethodID] AS int START WITH 11 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[InvoiceID] AS int START WITH 70511 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[InvoiceLineID] AS int START WITH 228266 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[OrderID] AS int START WITH 73596 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[OrderLineID] AS int START WITH 231413 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PackageTypeID] AS int START WITH 15 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PaymentMethodID] AS int START WITH 5 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PersonID] AS int START WITH 3262 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PurchaseOrderID] AS int START WITH 2075 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PurchaseOrderLineID] AS int START WITH 8368 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SpecialDealID] AS int START WITH 3 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StateProvinceID] AS int START WITH 54 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StockGroupID] AS int START WITH 11 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StockItemID] AS int START WITH 228 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StockItemStockGroupID] AS int START WITH 443 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SupplierCategoryID] AS int START WITH 10 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SupplierID] AS int START WITH 14 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SystemParameterID] AS int START WITH 2 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[TransactionID] AS int START WITH 336253 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[TransactionTypeID] AS int START WITH 14 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[ColdRoomTemperatures] (
        [ColdRoomTemperatureID] bigint NOT NULL IDENTITY,
        [ColdRoomSensorNumber] int NOT NULL,
        [RecordedWhen] datetime2 NOT NULL,
        [Temperature] decimal(10,2) NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Warehouse_ColdRoomTemperatures] PRIMARY KEY NONCLUSTERED ([ColdRoomTemperatureID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[ColdRoomTemperatures_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[People] (
        [PersonID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PersonID])),
        [FullName] nvarchar(58) NOT NULL,
        [PreferredName] nvarchar(58) NOT NULL,
        [SearchName] AS (concat([PreferredName],N' ',[FullName])) PERSISTED,
        [IsPermittedToLogon] bit NOT NULL,
        [LogonName] nvarchar(58) NULL,
        [IsExternalLogonProvider] bit NOT NULL,
        [HashedPassword] varbinary(max) NULL,
        [IsSystemUser] bit NOT NULL,
        [IsEmployee] bit NOT NULL,
        [IsSalesperson] bit NOT NULL,
        [UserPreferences] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(28) NULL,
        [FaxNumber] nvarchar(28) NULL,
        [EmailAddress] nvarchar(264) NULL,
        [Photo] varbinary(max) NULL,
        [CustomFields] nvarchar(max) NULL,
        [OtherLanguages] AS (json_query([CustomFields],N'$.OtherLanguages')),
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_People] PRIMARY KEY ([PersonID]),
        CONSTRAINT [FK_Application_People_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[People_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'People known to the application (staff, customer contacts, supplier contacts)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People';
    SET @description = N'Numeric ID used for reference to a person within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'PersonID';
    SET @description = N'Full name for this person';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'FullName';
    SET @description = N'Name that this person prefers to be called';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'PreferredName';
    SET @description = N'Name to build full text search on (computed column)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'SearchName';
    SET @description = N'Is this person permitted to log on?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'IsPermittedToLogon';
    SET @description = N'Person''s system logon name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'LogonName';
    SET @description = N'Is logon token provided by an external system?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'IsExternalLogonProvider';
    SET @description = N'Hash of password for users without external logon tokens';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'HashedPassword';
    SET @description = N'Is the currently permitted to make online access?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'IsSystemUser';
    SET @description = N'Is this person an employee?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'IsEmployee';
    SET @description = N'Is this person a staff salesperson?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'IsSalesperson';
    SET @description = N'User preferences related to the website (holds JSON data)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'UserPreferences';
    SET @description = N'Phone number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'PhoneNumber';
    SET @description = N'Fax number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'FaxNumber';
    SET @description = N'Email address for this person';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'EmailAddress';
    SET @description = N'Photo of this person';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'Photo';
    SET @description = N'Custom fields for employees and salespeople';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'CustomFields';
    SET @description = N'Other languages spoken (computed column from custom fields)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'People', 'COLUMN', N'OtherLanguages';
END;
GO

COMMIT;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[VehicleTemperatures] (
        [VehicleTemperatureID] bigint NOT NULL IDENTITY,
        [VehicleRegistration] nvarchar(28) COLLATE Latin1_General_CI_AS NOT NULL,
        [ChillerSensorNumber] int NOT NULL,
        [RecordedWhen] datetime2 NOT NULL,
        [Temperature] decimal(10,2) NOT NULL,
        [FullSensorData] nvarchar(1008) COLLATE Latin1_General_CI_AS NULL,
        [IsCompressed] bit NOT NULL,
        [CompressedSensorData] varbinary(max) NULL,
        CONSTRAINT [PK_Warehouse_VehicleTemperatures] PRIMARY KEY NONCLUSTERED ([VehicleTemperatureID])
    )
        WITH
            (MEMORY_OPTIMIZED = ON);
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[BuyingGroups] (
        [BuyingGroupID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[BuyingGroupID])),
        [BuyingGroupName] nvarchar(50) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_BuyingGroups] PRIMARY KEY ([BuyingGroupID]),
        CONSTRAINT [FK_Sales_BuyingGroups_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Sales].[BuyingGroups_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Customer organizations can be part of groups that exert greater buying power';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'BuyingGroups';
    SET @description = N'Numeric ID used for reference to a buying group within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'BuyingGroups', 'COLUMN', N'BuyingGroupID';
    SET @description = N'Full name of a buying group that customers can be members of';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'BuyingGroups', 'COLUMN', N'BuyingGroupName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[Colors] (
        [ColorID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[ColorID])),
        [ColorName] nvarchar(20) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Colors] PRIMARY KEY ([ColorID]),
        CONSTRAINT [FK_Warehouse_Colors_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[Colors_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Stock items can (optionally) have colors';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'Colors';
    SET @description = N'Numeric ID used for reference to a color within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'Colors', 'COLUMN', N'ColorID';
    SET @description = N'Full name of a color that can be used to describe stock items';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'Colors', 'COLUMN', N'ColorName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[Countries] (
        [CountryID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CountryID])),
        [CountryName] nvarchar(60) NOT NULL,
        [FormalName] nvarchar(60) NOT NULL,
        [IsoAlpha3Code] nvarchar(3) NULL,
        [IsoNumericCode] int NULL,
        [CountryType] nvarchar(20) NULL,
        [LatestRecordedPopulation] bigint NULL,
        [Continent] nvarchar(30) NOT NULL,
        [Region] nvarchar(30) NOT NULL,
        [Subregion] nvarchar(30) NOT NULL,
        [Border] geography NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryID]),
        CONSTRAINT [FK_Application_Countries_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[Countries_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Countries that contain the states or provinces (including geographic boundaries)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries';
    SET @description = N'Numeric ID used for reference to a country within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'CountryID';
    SET @description = N'Name of the country';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'CountryName';
    SET @description = N'Full formal name of the country as agreed by United Nations';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'FormalName';
    SET @description = N'3 letter alphabetic code assigned to the country by ISO';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'IsoAlpha3Code';
    SET @description = N'Numeric code assigned to the country by ISO';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'IsoNumericCode';
    SET @description = N'Type of country or administrative region';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'CountryType';
    SET @description = N'Latest available population for the country';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'LatestRecordedPopulation';
    SET @description = N'Name of the continent';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'Continent';
    SET @description = N'Name of the region';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'Region';
    SET @description = N'Name of the subregion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'Subregion';
    SET @description = N'Geographic border of the country as described by the United Nations';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Countries', 'COLUMN', N'Border';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[CustomerCategories] (
        [CustomerCategoryID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CustomerCategoryID])),
        [CustomerCategoryName] nvarchar(50) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_CustomerCategories] PRIMARY KEY ([CustomerCategoryID]),
        CONSTRAINT [FK_Sales_CustomerCategories_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Sales].[CustomerCategories_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Categories for customers (ie restaurants, cafes, supermarkets, etc.)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerCategories';
    SET @description = N'Numeric ID used for reference to a customer category within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerCategories', 'COLUMN', N'CustomerCategoryID';
    SET @description = N'Full name of the category that customers can be assigned to';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerCategories', 'COLUMN', N'CustomerCategoryName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[DeliveryMethods] (
        [DeliveryMethodID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[DeliveryMethodID])),
        [DeliveryMethodName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_DeliveryMethods] PRIMARY KEY ([DeliveryMethodID]),
        CONSTRAINT [FK_Application_DeliveryMethods_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[DeliveryMethods_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Ways that stock items can be delivered (ie: truck/van, post, pickup, courier, etc.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'DeliveryMethods';
    SET @description = N'Numeric ID used for reference to a delivery method within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'DeliveryMethods', 'COLUMN', N'DeliveryMethodID';
    SET @description = N'Full name of methods that can be used for delivery of customer orders';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'DeliveryMethods', 'COLUMN', N'DeliveryMethodName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[PackageTypes] (
        [PackageTypeID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PackageTypeID])),
        [PackageTypeName] nvarchar(50) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_PackageTypes] PRIMARY KEY ([PackageTypeID]),
        CONSTRAINT [FK_Warehouse_PackageTypes_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[PackageTypes_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Ways that stock items can be packaged (ie: each, box, carton, pallet, kg, etc.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'PackageTypes';
    SET @description = N'Numeric ID used for reference to a package type within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'PackageTypes', 'COLUMN', N'PackageTypeID';
    SET @description = N'Full name of package types that stock items can be purchased in or sold in';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'PackageTypes', 'COLUMN', N'PackageTypeName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[PaymentMethods] (
        [PaymentMethodID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PaymentMethodID])),
        [PaymentMethodName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_PaymentMethods] PRIMARY KEY ([PaymentMethodID]),
        CONSTRAINT [FK_Application_PaymentMethods_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[PaymentMethods_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Ways that payments can be made (ie: cash, check, EFT, etc.';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'PaymentMethods';
    SET @description = N'Numeric ID used for reference to a payment type within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'PaymentMethods', 'COLUMN', N'PaymentMethodID';
    SET @description = N'Full name of ways that customers can make payments or that suppliers can be paid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'PaymentMethods', 'COLUMN', N'PaymentMethodName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockGroups] (
        [StockGroupID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StockGroupID])),
        [StockGroupName] nvarchar(50) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_StockGroups] PRIMARY KEY ([StockGroupID]),
        CONSTRAINT [FK_Warehouse_StockGroups_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[StockGroups_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Groups for categorizing stock items (ie: novelties, toys, edible novelties, etc.)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockGroups';
    SET @description = N'Numeric ID used for reference to a stock group within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockGroups', 'COLUMN', N'StockGroupID';
    SET @description = N'Full name of groups used to categorize stock items';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockGroups', 'COLUMN', N'StockGroupName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[SupplierCategories] (
        [SupplierCategoryID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SupplierCategoryID])),
        [SupplierCategoryName] nvarchar(50) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_SupplierCategories] PRIMARY KEY ([SupplierCategoryID]),
        CONSTRAINT [FK_Purchasing_SupplierCategories_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Purchasing].[SupplierCategories_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Categories for suppliers (ie novelties, toys, clothing, packaging, etc.)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierCategories';
    SET @description = N'Numeric ID used for reference to a supplier category within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierCategories', 'COLUMN', N'SupplierCategoryID';
    SET @description = N'Full name of the category that suppliers can be assigned to';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierCategories', 'COLUMN', N'SupplierCategoryName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[TransactionTypes] (
        [TransactionTypeID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[TransactionTypeID])),
        [TransactionTypeName] nvarchar(50) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([TransactionTypeID]),
        CONSTRAINT [FK_Application_TransactionTypes_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[TransactionTypes_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Types of customer, supplier, or stock transactions (ie: invoice, credit note, etc.)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'TransactionTypes';
    SET @description = N'Numeric ID used for reference to a transaction type within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'TransactionTypes', 'COLUMN', N'TransactionTypeID';
    SET @description = N'Full name of the transaction type';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'TransactionTypes', 'COLUMN', N'TransactionTypeName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[StateProvinces] (
        [StateProvinceID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StateProvinceID])),
        [StateProvinceCode] nvarchar(5) NOT NULL,
        [StateProvinceName] nvarchar(50) NOT NULL,
        [CountryID] int NOT NULL,
        [SalesTerritory] nvarchar(50) NOT NULL,
        [Border] geography NULL,
        [LatestRecordedPopulation] bigint NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_StateProvinces] PRIMARY KEY ([StateProvinceID]),
        CONSTRAINT [FK_Application_StateProvinces_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Application_StateProvinces_CountryID_Application_Countries] FOREIGN KEY ([CountryID]) REFERENCES [Application].[Countries] ([CountryID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[StateProvinces_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'States or provinces that contain cities (including geographic location)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces';
    SET @description = N'Numeric ID used for reference to a state or province within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'StateProvinceID';
    SET @description = N'Common code for this state or province (such as WA - Washington for the USA)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'StateProvinceCode';
    SET @description = N'Formal name of the state or province';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'StateProvinceName';
    SET @description = N'Country for this StateProvince';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'CountryID';
    SET @description = N'Sales territory for this StateProvince';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'SalesTerritory';
    SET @description = N'Geographic boundary of the state or province';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'Border';
    SET @description = N'Latest available population for the StateProvince';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'StateProvinces', 'COLUMN', N'LatestRecordedPopulation';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[Cities] (
        [CityID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CityID])),
        [CityName] nvarchar(58) NOT NULL,
        [StateProvinceID] int NOT NULL,
        [Location] geography NULL,
        [LatestRecordedPopulation] bigint NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([CityID]),
        CONSTRAINT [FK_Application_Cities_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Application_Cities_StateProvinceID_Application_StateProvinces] FOREIGN KEY ([StateProvinceID]) REFERENCES [Application].[StateProvinces] ([StateProvinceID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[Cities_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Cities that are part of any address (including geographic location)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Cities';
    SET @description = N'Numeric ID used for reference to a city within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Cities', 'COLUMN', N'CityID';
    SET @description = N'Formal name of the city';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Cities', 'COLUMN', N'CityName';
    SET @description = N'State or province for this city. Has a foreign key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Cities', 'COLUMN', N'StateProvinceID';
    SET @description = N'Geographic location of the city';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Cities', 'COLUMN', N'Location';
    SET @description = N'Latest available population for the City';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'Cities', 'COLUMN', N'LatestRecordedPopulation';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[Customers] (
        [CustomerID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CustomerID])),
        [CustomerName] nvarchar(100) NOT NULL,
        [BillToCustomerID] int NOT NULL,
        [CustomerCategoryID] int NOT NULL,
        [BuyingGroupID] int NULL,
        [PrimaryContactPersonID] int NOT NULL,
        [AlternateContactPersonID] int NULL,
        [DeliveryMethodID] int NOT NULL,
        [DeliveryCityID] int NOT NULL,
        [PostalCityID] int NOT NULL,
        [CreditLimit] decimal(18,2) NULL,
        [AccountOpenedDate] date NOT NULL,
        [StandardDiscountPercentage] decimal(18,3) NOT NULL,
        [IsStatementSent] bit NOT NULL,
        [IsOnCreditHold] bit NOT NULL,
        [PaymentDays] int NOT NULL,
        [PhoneNumber] nvarchar(20) NOT NULL,
        [FaxNumber] nvarchar(20) NOT NULL,
        [DeliveryRun] nvarchar(5) NULL,
        [RunPosition] nvarchar(5) NULL,
        [WebsiteURL] nvarchar(256) NOT NULL,
        [DeliveryAddressLine1] nvarchar(60) NOT NULL,
        [DeliveryAddressLine2] nvarchar(60) NULL,
        [DeliveryPostalCode] nvarchar(10) NOT NULL,
        [DeliveryLocation] geography NULL,
        [PostalAddressLine1] nvarchar(60) NOT NULL,
        [PostalAddressLine2] nvarchar(60) NULL,
        [PostalPostalCode] nvarchar(10) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID]),
        CONSTRAINT [FK_Sales_Customers_AlternateContactPersonID_Application_People] FOREIGN KEY ([AlternateContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Customers_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Customers_BillToCustomerID_Sales_Customers] FOREIGN KEY ([BillToCustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Sales_Customers_BuyingGroupID_Sales_BuyingGroups] FOREIGN KEY ([BuyingGroupID]) REFERENCES [Sales].[BuyingGroups] ([BuyingGroupID]),
        CONSTRAINT [FK_Sales_Customers_CustomerCategoryID_Sales_CustomerCategories] FOREIGN KEY ([CustomerCategoryID]) REFERENCES [Sales].[CustomerCategories] ([CustomerCategoryID]),
        CONSTRAINT [FK_Sales_Customers_DeliveryCityID_Application_Cities] FOREIGN KEY ([DeliveryCityID]) REFERENCES [Application].[Cities] ([CityID]),
        CONSTRAINT [FK_Sales_Customers_DeliveryMethodID_Application_DeliveryMethods] FOREIGN KEY ([DeliveryMethodID]) REFERENCES [Application].[DeliveryMethods] ([DeliveryMethodID]),
        CONSTRAINT [FK_Sales_Customers_PostalCityID_Application_Cities] FOREIGN KEY ([PostalCityID]) REFERENCES [Application].[Cities] ([CityID]),
        CONSTRAINT [FK_Sales_Customers_PrimaryContactPersonID_Application_People] FOREIGN KEY ([PrimaryContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Sales].[Customers_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Main entity tables for customers (organizations or individuals)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers';
    SET @description = N'Numeric ID used for reference to a customer within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'CustomerID';
    SET @description = N'Customer''s full name (usually a trading name)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'CustomerName';
    SET @description = N'Customer that this is billed to (usually the same customer but can be another parent company)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'BillToCustomerID';
    SET @description = N'Customer''s category';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'CustomerCategoryID';
    SET @description = N'Customer''s buying group (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'BuyingGroupID';
    SET @description = N'Primary contact';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PrimaryContactPersonID';
    SET @description = N'Alternate contact';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'AlternateContactPersonID';
    SET @description = N'Standard delivery method for stock items sent to this customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryMethodID';
    SET @description = N'ID of the delivery city for this address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryCityID';
    SET @description = N'ID of the postal city for this address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PostalCityID';
    SET @description = N'Credit limit for this customer (NULL if unlimited)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'CreditLimit';
    SET @description = N'Date this customer account was opened';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'AccountOpenedDate';
    SET @description = N'Standard discount offered to this customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'StandardDiscountPercentage';
    SET @description = N'Is a statement sent to this customer? (Or do they just pay on each invoice?)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'IsStatementSent';
    SET @description = N'Is this customer on credit hold? (Prevents further deliveries to this customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'IsOnCreditHold';
    SET @description = N'Number of days for payment of an invoice (ie payment terms)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PaymentDays';
    SET @description = N'Phone number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PhoneNumber';
    SET @description = N'Fax number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'FaxNumber';
    SET @description = N'Normal delivery run for this customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryRun';
    SET @description = N'Normal position in the delivery run for this customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'RunPosition';
    SET @description = N'URL for the website for this customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'WebsiteURL';
    SET @description = N'First delivery address line for the customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryAddressLine1';
    SET @description = N'Second delivery address line for the customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryAddressLine2';
    SET @description = N'Delivery postal code for the customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryPostalCode';
    SET @description = N'Geographic location for the customer''s office/warehouse';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'DeliveryLocation';
    SET @description = N'First postal address line for the customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PostalAddressLine1';
    SET @description = N'Second postal address line for the customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PostalAddressLine2';
    SET @description = N'Postal code for the customer when sending by mail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Customers', 'COLUMN', N'PostalPostalCode';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[Suppliers] (
        [SupplierID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SupplierID])),
        [SupplierName] nvarchar(100) NOT NULL,
        [SupplierCategoryID] int NOT NULL,
        [PrimaryContactPersonID] int NOT NULL,
        [AlternateContactPersonID] int NOT NULL,
        [DeliveryMethodID] int NULL,
        [DeliveryCityID] int NOT NULL,
        [PostalCityID] int NOT NULL,
        [SupplierReference] nvarchar(20) NULL,
        [BankAccountName] nvarchar(50) NULL,
        [BankAccountBranch] nvarchar(50) NULL,
        [BankAccountCode] nvarchar(20) NULL,
        [BankAccountNumber] nvarchar(20) NULL,
        [BankInternationalCode] nvarchar(20) NULL,
        [PaymentDays] int NOT NULL,
        [InternalComments] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(20) NOT NULL,
        [FaxNumber] nvarchar(20) NOT NULL,
        [WebsiteURL] nvarchar(256) NOT NULL,
        [DeliveryAddressLine1] nvarchar(60) NOT NULL,
        [DeliveryAddressLine2] nvarchar(60) NULL,
        [DeliveryPostalCode] nvarchar(10) NOT NULL,
        [DeliveryLocation] geography NULL,
        [PostalAddressLine1] nvarchar(60) NOT NULL,
        [PostalAddressLine2] nvarchar(60) NULL,
        [PostalPostalCode] nvarchar(10) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Suppliers] PRIMARY KEY ([SupplierID]),
        CONSTRAINT [FK_Purchasing_Suppliers_AlternateContactPersonID_Application_People] FOREIGN KEY ([AlternateContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_Suppliers_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_Suppliers_DeliveryCityID_Application_Cities] FOREIGN KEY ([DeliveryCityID]) REFERENCES [Application].[Cities] ([CityID]),
        CONSTRAINT [FK_Purchasing_Suppliers_DeliveryMethodID_Application_DeliveryMethods] FOREIGN KEY ([DeliveryMethodID]) REFERENCES [Application].[DeliveryMethods] ([DeliveryMethodID]),
        CONSTRAINT [FK_Purchasing_Suppliers_PostalCityID_Application_Cities] FOREIGN KEY ([PostalCityID]) REFERENCES [Application].[Cities] ([CityID]),
        CONSTRAINT [FK_Purchasing_Suppliers_PrimaryContactPersonID_Application_People] FOREIGN KEY ([PrimaryContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_Suppliers_SupplierCategoryID_Purchasing_SupplierCategories] FOREIGN KEY ([SupplierCategoryID]) REFERENCES [Purchasing].[SupplierCategories] ([SupplierCategoryID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Purchasing].[Suppliers_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Main entity table for suppliers (organizations)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers';
    SET @description = N'Numeric ID used for reference to a supplier within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'SupplierID';
    SET @description = N'Supplier''s full name (usually a trading name)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'SupplierName';
    SET @description = N'Supplier''s category';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'SupplierCategoryID';
    SET @description = N'Primary contact';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PrimaryContactPersonID';
    SET @description = N'Alternate contact';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'AlternateContactPersonID';
    SET @description = N'Standard delivery method for stock items received from this supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'DeliveryMethodID';
    SET @description = N'ID of the delivery city for this address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'DeliveryCityID';
    SET @description = N'ID of the mailing city for this address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PostalCityID';
    SET @description = N'Supplier reference for our organization (might be our account number at the supplier)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'SupplierReference';
    SET @description = N'Supplier''s bank account name (ie name on the account)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'BankAccountName';
    SET @description = N'Supplier''s bank branch';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'BankAccountBranch';
    SET @description = N'Supplier''s bank account code (usually a numeric reference for the bank branch)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'BankAccountCode';
    SET @description = N'Supplier''s bank account number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'BankAccountNumber';
    SET @description = N'Supplier''s bank''s international code (such as a SWIFT code)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'BankInternationalCode';
    SET @description = N'Number of days for payment of an invoice (ie payment terms)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PaymentDays';
    SET @description = N'Internal comments (not exposed outside organization)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'InternalComments';
    SET @description = N'Phone number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PhoneNumber';
    SET @description = N'Fax number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'FaxNumber';
    SET @description = N'URL for the website for this supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'WebsiteURL';
    SET @description = N'First delivery address line for the supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'DeliveryAddressLine1';
    SET @description = N'Second delivery address line for the supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'DeliveryAddressLine2';
    SET @description = N'Delivery postal code for the supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'DeliveryPostalCode';
    SET @description = N'Geographic location for the supplier''s office/warehouse';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'DeliveryLocation';
    SET @description = N'First postal address line for the supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PostalAddressLine1';
    SET @description = N'Second postal address line for the supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PostalAddressLine2';
    SET @description = N'Postal code for the supplier when sending by mail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'Suppliers', 'COLUMN', N'PostalPostalCode';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Application].[SystemParameters] (
        [SystemParameterID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SystemParameterID])),
        [DeliveryAddressLine1] nvarchar(60) NOT NULL,
        [DeliveryAddressLine2] nvarchar(60) NULL,
        [DeliveryCityID] int NOT NULL,
        [DeliveryPostalCode] nvarchar(10) NOT NULL,
        [DeliveryLocation] geography NOT NULL,
        [PostalAddressLine1] nvarchar(60) NOT NULL,
        [PostalAddressLine2] nvarchar(60) NULL,
        [PostalCityID] int NOT NULL,
        [PostalPostalCode] nvarchar(10) NOT NULL,
        [ApplicationSettings] nvarchar(max) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_SystemParameters] PRIMARY KEY ([SystemParameterID]),
        CONSTRAINT [FK_Application_SystemParameters_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Application_SystemParameters_DeliveryCityID_Application_Cities] FOREIGN KEY ([DeliveryCityID]) REFERENCES [Application].[Cities] ([CityID]),
        CONSTRAINT [FK_Application_SystemParameters_PostalCityID_Application_Cities] FOREIGN KEY ([PostalCityID]) REFERENCES [Application].[Cities] ([CityID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Any configurable parameters for the whole system';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters';
    SET @description = N'Numeric ID used for row holding system parameters';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'SystemParameterID';
    SET @description = N'First address line for the company';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'DeliveryAddressLine1';
    SET @description = N'Second address line for the company';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'DeliveryAddressLine2';
    SET @description = N'ID of the city for this address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'DeliveryCityID';
    SET @description = N'Postal code for the company';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'DeliveryPostalCode';
    SET @description = N'Geographic location for the company office';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'DeliveryLocation';
    SET @description = N'First postal address line for the company';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'PostalAddressLine1';
    SET @description = N'Second postaladdress line for the company';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'PostalAddressLine2';
    SET @description = N'ID of the city for this postaladdress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'PostalCityID';
    SET @description = N'Postal code for the company when sending via mail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'PostalPostalCode';
    SET @description = N'JSON-structured application settings';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Application', 'TABLE', N'SystemParameters', 'COLUMN', N'ApplicationSettings';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[Orders] (
        [OrderID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[OrderID])),
        [CustomerID] int NOT NULL,
        [SalespersonPersonID] int NOT NULL,
        [PickedByPersonID] int NULL,
        [ContactPersonID] int NOT NULL,
        [BackorderOrderID] int NULL,
        [OrderDate] date NOT NULL,
        [ExpectedDeliveryDate] date NOT NULL,
        [CustomerPurchaseOrderNumber] nvarchar(20) NULL,
        [IsUndersupplyBackordered] bit NOT NULL,
        [Comments] nvarchar(max) NULL,
        [DeliveryInstructions] nvarchar(max) NULL,
        [InternalComments] nvarchar(max) NULL,
        [PickingCompletedWhen] datetime2 NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
        CONSTRAINT [FK_Sales_Orders_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Orders_BackorderOrderID_Sales_Orders] FOREIGN KEY ([BackorderOrderID]) REFERENCES [Sales].[Orders] ([OrderID]),
        CONSTRAINT [FK_Sales_Orders_ContactPersonID_Application_People] FOREIGN KEY ([ContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Orders_CustomerID_Sales_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Sales_Orders_PickedByPersonID_Application_People] FOREIGN KEY ([PickedByPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Orders_SalespersonPersonID_Application_People] FOREIGN KEY ([SalespersonPersonID]) REFERENCES [Application].[People] ([PersonID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Detail of customer orders';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders';
    SET @description = N'Numeric ID used for reference to an order within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'OrderID';
    SET @description = N'Customer for this order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'CustomerID';
    SET @description = N'Salesperson for this order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'SalespersonPersonID';
    SET @description = N'Person who picked this shipment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'PickedByPersonID';
    SET @description = N'Customer contact for this order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'ContactPersonID';
    SET @description = N'If this order is a backorder, this column holds the original order number';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'BackorderOrderID';
    SET @description = N'Date that this order was raised';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'OrderDate';
    SET @description = N'Expected delivery date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'ExpectedDeliveryDate';
    SET @description = N'Purchase Order Number received from customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'CustomerPurchaseOrderNumber';
    SET @description = N'If items cannot be supplied are they backordered?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'IsUndersupplyBackordered';
    SET @description = N'Any comments related to this order (sent to customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'Comments';
    SET @description = N'	Any comments related to order delivery (sent to customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'DeliveryInstructions';
    SET @description = N'Any internal comments related to this order (not sent to the customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'InternalComments';
    SET @description = N'When was picking of the entire order completed?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Orders', 'COLUMN', N'PickingCompletedWhen';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[PurchaseOrders] (
        [PurchaseOrderID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PurchaseOrderID])),
        [SupplierID] int NOT NULL,
        [OrderDate] date NOT NULL,
        [DeliveryMethodID] int NOT NULL,
        [ContactPersonID] int NOT NULL,
        [ExpectedDeliveryDate] date NULL,
        [SupplierReference] nvarchar(20) NULL,
        [IsOrderFinalized] bit NOT NULL,
        [Comments] nvarchar(max) NULL,
        [InternalComments] nvarchar(max) NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_PurchaseOrders] PRIMARY KEY ([PurchaseOrderID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrders_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrders_ContactPersonID_Application_People] FOREIGN KEY ([ContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrders_DeliveryMethodID_Application_DeliveryMethods] FOREIGN KEY ([DeliveryMethodID]) REFERENCES [Application].[DeliveryMethods] ([DeliveryMethodID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrders_SupplierID_Purchasing_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [Purchasing].[Suppliers] ([SupplierID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Details of supplier purchase orders';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders';
    SET @description = N'Numeric ID used for reference to a purchase order within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'PurchaseOrderID';
    SET @description = N'Supplier for this purchase order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'SupplierID';
    SET @description = N'Date that this purchase order was raised';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'OrderDate';
    SET @description = N'How this purchase order should be delivered';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'DeliveryMethodID';
    SET @description = N'The person who is the primary contact for this purchase order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'ContactPersonID';
    SET @description = N'Expected delivery date for this purchase order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'ExpectedDeliveryDate';
    SET @description = N'Supplier reference for our organization (might be our account number at the supplier)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'SupplierReference';
    SET @description = N'Is this purchase order now considered finalized?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'IsOrderFinalized';
    SET @description = N'Any comments related this purchase order (comments sent to the supplier)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'Comments';
    SET @description = N'Any internal comments related this purchase order (comments for internal reference only and not sent to the supplier)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrders', 'COLUMN', N'InternalComments';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockItems] (
        [StockItemID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StockItemID])),
        [StockItemName] nvarchar(100) NOT NULL,
        [SupplierID] int NOT NULL,
        [ColorID] int NULL,
        [UnitPackageID] int NOT NULL,
        [OuterPackageID] int NOT NULL,
        [Brand] nvarchar(50) NULL,
        [Size] nvarchar(20) NULL,
        [LeadTimeDays] int NOT NULL,
        [QuantityPerOuter] int NOT NULL,
        [IsChillerStock] bit NOT NULL,
        [Barcode] nvarchar(50) NULL,
        [TaxRate] decimal(18,3) NOT NULL,
        [UnitPrice] decimal(18,2) NOT NULL,
        [RecommendedRetailPrice] decimal(18,2) NULL,
        [TypicalWeightPerUnit] decimal(18,3) NOT NULL,
        [MarketingComments] nvarchar(max) NULL,
        [InternalComments] nvarchar(max) NULL,
        [Photo] varbinary(max) NULL,
        [CustomFields] nvarchar(max) NULL,
        [Tags] AS (json_query([CustomFields],N'$.Tags')),
        [SearchDetails] AS (concat([StockItemName],N' ',[MarketingComments])),
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_StockItems] PRIMARY KEY ([StockItemID]),
        CONSTRAINT [FK_Warehouse_StockItems_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Warehouse_StockItems_ColorID_Warehouse_Colors] FOREIGN KEY ([ColorID]) REFERENCES [Warehouse].[Colors] ([ColorID]),
        CONSTRAINT [FK_Warehouse_StockItems_OuterPackageID_Warehouse_PackageTypes] FOREIGN KEY ([OuterPackageID]) REFERENCES [Warehouse].[PackageTypes] ([PackageTypeID]),
        CONSTRAINT [FK_Warehouse_StockItems_SupplierID_Purchasing_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [Purchasing].[Suppliers] ([SupplierID]),
        CONSTRAINT [FK_Warehouse_StockItems_UnitPackageID_Warehouse_PackageTypes] FOREIGN KEY ([UnitPackageID]) REFERENCES [Warehouse].[PackageTypes] ([PackageTypeID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[StockItems_Archive]));
    DECLARE @description AS sql_variant;
    SET @description = N'Main entity table for stock items';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems';
    SET @description = N'Numeric ID used for reference to a stock item within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'StockItemID';
    SET @description = N'Full name of a stock item (but not a full description)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'StockItemName';
    SET @description = N'Usual supplier for this stock item';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'SupplierID';
    SET @description = N'Color (optional) for this stock item';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'ColorID';
    SET @description = N'Usual package for selling units of this stock item';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'UnitPackageID';
    SET @description = N'Usual package for selling outers of this stock item (ie cartons, boxes, etc.)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'OuterPackageID';
    SET @description = N'Brand for the stock item (if the item is branded)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'Brand';
    SET @description = N'Size of this item (eg: 100mm)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'Size';
    SET @description = N'Number of days typically taken from order to receipt of this stock item';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'LeadTimeDays';
    SET @description = N'Quantity of the stock item in an outer package';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'QuantityPerOuter';
    SET @description = N'Does this stock item need to be in a chiller?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'IsChillerStock';
    SET @description = N'Barcode for this stock item';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'Barcode';
    SET @description = N'Tax rate to be applied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'TaxRate';
    SET @description = N'Selling price (ex-tax) for one unit of this product';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'UnitPrice';
    SET @description = N'Recommended retail price for this stock item';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'RecommendedRetailPrice';
    SET @description = N'Typical weight for one unit of this product (packaged)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'TypicalWeightPerUnit';
    SET @description = N'Marketing comments for this stock item (shared outside the organization)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'MarketingComments';
    SET @description = N'Internal comments (not exposed outside organization)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'InternalComments';
    SET @description = N'Photo of the product';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'Photo';
    SET @description = N'Custom fields added by system users';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'CustomFields';
    SET @description = N'Advertising tags associated with this stock item (JSON array retrieved from CustomFields)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'Tags';
    SET @description = N'Combination of columns used by full text search';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItems', 'COLUMN', N'SearchDetails';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[Invoices] (
        [InvoiceID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[InvoiceID])),
        [CustomerID] int NOT NULL,
        [BillToCustomerID] int NOT NULL,
        [OrderID] int NULL,
        [DeliveryMethodID] int NOT NULL,
        [ContactPersonID] int NOT NULL,
        [AccountsPersonID] int NOT NULL,
        [SalespersonPersonID] int NOT NULL,
        [PackedByPersonID] int NOT NULL,
        [InvoiceDate] date NOT NULL,
        [CustomerPurchaseOrderNumber] nvarchar(20) NULL,
        [IsCreditNote] bit NOT NULL,
        [CreditNoteReason] nvarchar(max) NULL,
        [Comments] nvarchar(max) NULL,
        [DeliveryInstructions] nvarchar(max) NULL,
        [InternalComments] nvarchar(max) NULL,
        [TotalDryItems] int NOT NULL,
        [TotalChillerItems] int NOT NULL,
        [DeliveryRun] nvarchar(5) NULL,
        [RunPosition] nvarchar(5) NULL,
        [ReturnedDeliveryData] nvarchar(5) NULL,
        [ConfirmedDeliveryTime] AS (TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126))),
        [ConfirmedReceivedBy] AS (json_value([ReturnedDeliveryData],N'$.ReceivedBy')),
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_Invoices] PRIMARY KEY ([InvoiceID]),
        CONSTRAINT [FK_Sales_Invoices_AccountsPersonID_Application_People] FOREIGN KEY ([AccountsPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Invoices_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Invoices_BillToCustomerID_Sales_Customers] FOREIGN KEY ([BillToCustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Sales_Invoices_ContactPersonID_Application_People] FOREIGN KEY ([ContactPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Invoices_CustomerID_Sales_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Sales_Invoices_DeliveryMethodID_Application_DeliveryMethods] FOREIGN KEY ([DeliveryMethodID]) REFERENCES [Application].[DeliveryMethods] ([DeliveryMethodID]),
        CONSTRAINT [FK_Sales_Invoices_OrderID_Sales_Orders] FOREIGN KEY ([OrderID]) REFERENCES [Sales].[Orders] ([OrderID]),
        CONSTRAINT [FK_Sales_Invoices_PackedByPersonID_Application_People] FOREIGN KEY ([PackedByPersonID]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_Invoices_SalespersonPersonID_Application_People] FOREIGN KEY ([SalespersonPersonID]) REFERENCES [Application].[People] ([PersonID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Details of customer invoices';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices';
    SET @description = N'Numeric ID used for reference to an invoice within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'InvoiceID';
    SET @description = N'Customer for this invoice';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'CustomerID';
    SET @description = N'Bill to customer for this invoice (invoices might be billed to a head office)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'BillToCustomerID';
    SET @description = N'Sales order (if any) for this invoice';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'OrderID';
    SET @description = N'How these stock items are beign delivered';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'DeliveryMethodID';
    SET @description = N'Customer contact for this invoice';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'ContactPersonID';
    SET @description = N'Customer accounts contact for this invoice';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'AccountsPersonID';
    SET @description = N'Salesperson for this invoice';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'SalespersonPersonID';
    SET @description = N'Person who packed this shipment (or checked the packing)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'PackedByPersonID';
    SET @description = N'Date that this invoice was raised';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'InvoiceDate';
    SET @description = N'Purchase Order Number received from customer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'CustomerPurchaseOrderNumber';
    SET @description = N'Is this a credit note (rather than an invoice)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'IsCreditNote';
    SET @description = N'Reason that this credit note needed to be generated (if applicable)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'CreditNoteReason';
    SET @description = N'Any comments related to this invoice (sent to customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'Comments';
    SET @description = N'Any comments related to delivery (sent to customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'DeliveryInstructions';
    SET @description = N'Any internal comments related to this invoice (not sent to the customer)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'InternalComments';
    SET @description = N'Total number of dry packages (information for the delivery driver)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'TotalDryItems';
    SET @description = N'Total number of chiller packages (information for the delivery driver)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'TotalChillerItems';
    SET @description = N'Delivery run for this shipment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'DeliveryRun';
    SET @description = N'Position in the delivery run for this shipment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'RunPosition';
    SET @description = N'JSON-structured data returned from delivery devices for deliveries made directly by the organization';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'ReturnedDeliveryData';
    SET @description = N'Confirmed delivery date and time promoted from JSON delivery data';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'ConfirmedDeliveryTime';
    SET @description = N'Confirmed receiver promoted from JSON delivery data';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'Invoices', 'COLUMN', N'ConfirmedReceivedBy';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[SupplierTransactions] (
        [SupplierTransactionID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[TransactionID])),
        [SupplierID] int NOT NULL,
        [TransactionTypeID] int NOT NULL,
        [PurchaseOrderID] int NULL,
        [PaymentMethodID] int NULL,
        [SupplierInvoiceNumber] nvarchar(20) NULL,
        [TransactionDate] date NOT NULL,
        [AmountExcludingTax] decimal(18,2) NOT NULL,
        [TaxAmount] decimal(18,2) NOT NULL,
        [TransactionAmount] decimal(18,2) NOT NULL,
        [OutstandingBalance] decimal(18,2) NOT NULL,
        [FinalizationDate] date NULL,
        [IsFinalized] AS (case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end) PERSISTED,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_Purchasing_SupplierTransactions] PRIMARY KEY NONCLUSTERED ([SupplierTransactionID]),
        CONSTRAINT [FK_Purchasing_SupplierTransactions_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_SupplierTransactions_PaymentMethodID_Application_PaymentMethods] FOREIGN KEY ([PaymentMethodID]) REFERENCES [Application].[PaymentMethods] ([PaymentMethodID]),
        CONSTRAINT [FK_Purchasing_SupplierTransactions_PurchaseOrderID_Purchasing_PurchaseOrders] FOREIGN KEY ([PurchaseOrderID]) REFERENCES [Purchasing].[PurchaseOrders] ([PurchaseOrderID]),
        CONSTRAINT [FK_Purchasing_SupplierTransactions_SupplierID_Purchasing_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [Purchasing].[Suppliers] ([SupplierID]),
        CONSTRAINT [FK_Purchasing_SupplierTransactions_TransactionTypeID_Application_TransactionTypes] FOREIGN KEY ([TransactionTypeID]) REFERENCES [Application].[TransactionTypes] ([TransactionTypeID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'All financial transactions that are supplier-related';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions';
    SET @description = N'Numeric ID used to refer to a supplier transaction within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'SupplierTransactionID';
    SET @description = N'Supplier for this transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'SupplierID';
    SET @description = N'Type of transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'TransactionTypeID';
    SET @description = N'ID of an purchase order (for transactions associated with a purchase order)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'PurchaseOrderID';
    SET @description = N'ID of a payment method (for transactions involving payments)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'PaymentMethodID';
    SET @description = N'Invoice number for an invoice received from the supplier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'SupplierInvoiceNumber';
    SET @description = N'Date for the transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'TransactionDate';
    SET @description = N'Transaction amount (excluding tax)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'AmountExcludingTax';
    SET @description = N'Tax amount calculated';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'TaxAmount';
    SET @description = N'Transaction amount (including tax)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'TransactionAmount';
    SET @description = N'Amount still outstanding for this transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'OutstandingBalance';
    SET @description = N'Date that this transaction was finalized (if it has been)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'FinalizationDate';
    SET @description = N'Is this transaction finalized (invoices, credits and payments have been matched)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'SupplierTransactions', 'COLUMN', N'IsFinalized';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[OrderLines] (
        [OrderLineID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[OrderLineID])),
        [OrderID] int NOT NULL,
        [StockItemID] int NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [PackageTypeID] int NOT NULL,
        [Quantity] int NOT NULL,
        [UnitPrice] decimal(18,2) NULL,
        [TaxRate] decimal(18,3) NOT NULL,
        [PickedQuantity] int NOT NULL,
        [PickingCompletedWhen] datetime2 NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_OrderLines] PRIMARY KEY ([OrderLineID]),
        CONSTRAINT [FK_Sales_OrderLines_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_OrderLines_OrderID_Sales_Orders] FOREIGN KEY ([OrderID]) REFERENCES [Sales].[Orders] ([OrderID]),
        CONSTRAINT [FK_Sales_OrderLines_PackageTypeID_Warehouse_PackageTypes] FOREIGN KEY ([PackageTypeID]) REFERENCES [Warehouse].[PackageTypes] ([PackageTypeID]),
        CONSTRAINT [FK_Sales_OrderLines_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Detail lines from customer orders';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines';
    SET @description = N'Numeric ID used for reference to a line on an Order within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'OrderLineID';
    SET @description = N'Order that this line is associated with';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'OrderID';
    SET @description = N'Stock item for this order line (FK not indexed as separate index exists)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'StockItemID';
    SET @description = N'Description of the item supplied (Usually the stock item name but can be overridden)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'Description';
    SET @description = N'Type of package to be supplied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'PackageTypeID';
    SET @description = N'Quantity to be supplied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'Quantity';
    SET @description = N'Unit price to be charged';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'UnitPrice';
    SET @description = N'Tax rate to be applied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'TaxRate';
    SET @description = N'Quantity picked from stock';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'PickedQuantity';
    SET @description = N'When was picking of this line completed?';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'OrderLines', 'COLUMN', N'PickingCompletedWhen';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[PurchaseOrderLines] (
        [PurchaseOrderLineID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])),
        [PurchaseOrderID] int NOT NULL,
        [StockItemID] int NOT NULL,
        [OrderedOuters] int NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [ReceivedOuters] int NOT NULL,
        [PackageTypeID] int NOT NULL,
        [ExpectedUnitPricePerOuter] decimal(18,2) NULL,
        [LastReceiptDate] date NULL,
        [IsOrderLineFinalized] bit NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_PurchaseOrderLines] PRIMARY KEY ([PurchaseOrderLineID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrderLines_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrderLines_PackageTypeID_Warehouse_PackageTypes] FOREIGN KEY ([PackageTypeID]) REFERENCES [Warehouse].[PackageTypes] ([PackageTypeID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrderLines_PurchaseOrderID_Purchasing_PurchaseOrders] FOREIGN KEY ([PurchaseOrderID]) REFERENCES [Purchasing].[PurchaseOrders] ([PurchaseOrderID]),
        CONSTRAINT [FK_Purchasing_PurchaseOrderLines_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Detail lines from supplier purchase orders';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines';
    SET @description = N'Numeric ID used for reference to a line on a purchase order within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'PurchaseOrderLineID';
    SET @description = N'Purchase order that this line is associated with';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'PurchaseOrderID';
    SET @description = N'Stock item for this purchase order line';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'StockItemID';
    SET @description = N'Quantity of the stock item that is ordered';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'OrderedOuters';
    SET @description = N'Description of the item to be supplied (Often the stock item name but could be supplier description)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'Description';
    SET @description = N'Total quantity of the stock item that has been received so far';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'ReceivedOuters';
    SET @description = N'Type of package received';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'PackageTypeID';
    SET @description = N'The unit price that we expect to be charged';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'ExpectedUnitPricePerOuter';
    SET @description = N'The last date on which this stock item was received for this purchase order';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'LastReceiptDate';
    SET @description = N'Is this purchase order line now considered finalized? (Receipted quantities and weights are often not precise)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Purchasing', 'TABLE', N'PurchaseOrderLines', 'COLUMN', N'IsOrderLineFinalized';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[SpecialDeals] (
        [SpecialDealID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SpecialDealID])),
        [StockItemID] int NULL,
        [CustomerID] int NULL,
        [BuyingGroupID] int NULL,
        [CustomerCategoryID] int NULL,
        [StockGroupID] int NULL,
        [DealDescription] nvarchar(30) NOT NULL,
        [StartDate] date NOT NULL,
        [EndDate] date NOT NULL,
        [DiscountAmount] decimal(18,2) NULL,
        [DiscountPercentage] decimal(18,3) NULL,
        [UnitPrice] decimal(18,2) NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_SpecialDeals] PRIMARY KEY ([SpecialDealID]),
        CONSTRAINT [FK_Sales_SpecialDeals_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_SpecialDeals_BuyingGroupID_Sales_BuyingGroups] FOREIGN KEY ([BuyingGroupID]) REFERENCES [Sales].[BuyingGroups] ([BuyingGroupID]),
        CONSTRAINT [FK_Sales_SpecialDeals_CustomerCategoryID_Sales_CustomerCategories] FOREIGN KEY ([CustomerCategoryID]) REFERENCES [Sales].[CustomerCategories] ([CustomerCategoryID]),
        CONSTRAINT [FK_Sales_SpecialDeals_CustomerID_Sales_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Sales_SpecialDeals_StockGroupID_Warehouse_StockGroups] FOREIGN KEY ([StockGroupID]) REFERENCES [Warehouse].[StockGroups] ([StockGroupID]),
        CONSTRAINT [FK_Sales_SpecialDeals_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Special pricing (can include fixed prices, discount $ or discount %)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals';
    SET @description = N'ID (sequence based) for a special deal';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'SpecialDealID';
    SET @description = N'Stock item that the deal applies to (if NULL, then only discounts are permitted not unit prices)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'StockItemID';
    SET @description = N'ID of the customer that the special pricing applies to (if NULL then all customers)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'CustomerID';
    SET @description = N'ID of the buying group that the special pricing applies to (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'BuyingGroupID';
    SET @description = N'ID of the customer category that the special pricing applies to (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'CustomerCategoryID';
    SET @description = N'ID of the stock group that the special pricing applies to (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'StockGroupID';
    SET @description = N'Description of the special deal';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'DealDescription';
    SET @description = N'Date that the special pricing starts from';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'StartDate';
    SET @description = N'Date that the special pricing ends on';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'EndDate';
    SET @description = N'Discount per unit to be applied to sale price (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'DiscountAmount';
    SET @description = N'	Discount percentage per unit to be applied to sale price (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'DiscountPercentage';
    SET @description = N'Special price per unit to be applied instead of sale price (optional)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'SpecialDeals', 'COLUMN', N'UnitPrice';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockItemHoldings] (
        [StockItemID] int NOT NULL,
        [QuantityOnHand] int NOT NULL,
        [BinLocation] nvarchar(20) NOT NULL,
        [LastStocktakeQuantity] int NOT NULL,
        [LastCostPrice] decimal(18,2) NOT NULL,
        [ReorderLevel] int NOT NULL,
        [TargetStockLevel] int NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_Warehouse_StockItemHoldings] PRIMARY KEY ([StockItemID]),
        CONSTRAINT [FK_Warehouse_StockItemHoldings_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [PKFK_Warehouse_StockItemHoldings_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Non-temporal attributes for stock items';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings';
    SET @description = N'ID of the stock item that this holding relates to (this table holds non-temporal columns for stock)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'StockItemID';
    SET @description = N'Quantity currently on hand (if tracked)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'QuantityOnHand';
    SET @description = N'Bin location (ie location of this stock item within the depot)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'BinLocation';
    SET @description = N'Quantity at last stocktake (if tracked)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'LastStocktakeQuantity';
    SET @description = N'Unit cost price the last time this stock item was purchased';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'LastCostPrice';
    SET @description = N'Quantity below which reordering should take place';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'ReorderLevel';
    SET @description = N'Typical quantity ordered';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemHoldings', 'COLUMN', N'TargetStockLevel';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockItemStockGroups] (
        [StockItemStockGroupID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StockItemStockGroupID])),
        [StockItemID] int NOT NULL,
        [StockGroupID] int NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_StockItemStockGroups] PRIMARY KEY ([StockItemStockGroupID]),
        CONSTRAINT [FK_Warehouse_StockItemStockGroups_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Warehouse_StockItemStockGroups_StockGroupID_Warehouse_StockGroups] FOREIGN KEY ([StockGroupID]) REFERENCES [Warehouse].[StockGroups] ([StockGroupID]),
        CONSTRAINT [FK_Warehouse_StockItemStockGroups_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Which stock items are in which stock groups';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemStockGroups';
    SET @description = N'Internal reference for this linking row';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemStockGroups', 'COLUMN', N'StockItemStockGroupID';
    SET @description = N'Stock item assigned to this stock group (FK indexed via unique constraint)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemStockGroups', 'COLUMN', N'StockItemID';
    SET @description = N'StockGroup assigned to this stock item (FK indexed via unique constraint)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemStockGroups', 'COLUMN', N'StockGroupID';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[CustomerTransactions] (
        [CustomerTransactionID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[TransactionID])),
        [CustomerID] int NOT NULL,
        [TransactionTypeID] int NOT NULL,
        [InvoiceID] int NULL,
        [PaymentMethodID] int NULL,
        [TransactionDate] date NOT NULL,
        [AmountExcludingTax] decimal(18,2) NOT NULL,
        [TaxAmount] decimal(18,2) NOT NULL,
        [TransactionAmount] decimal(18,2) NOT NULL,
        [OutstandingBalance] decimal(18,2) NOT NULL,
        [FinalizationDate] date NULL,
        [IsFinalized] AS (case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end) PERSISTED,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_Sales_CustomerTransactions] PRIMARY KEY NONCLUSTERED ([CustomerTransactionID]),
        CONSTRAINT [FK_Sales_CustomerTransactions_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_CustomerTransactions_CustomerID_Sales_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Sales_CustomerTransactions_InvoiceID_Sales_Invoices] FOREIGN KEY ([InvoiceID]) REFERENCES [Sales].[Invoices] ([InvoiceID]),
        CONSTRAINT [FK_Sales_CustomerTransactions_PaymentMethodID_Application_PaymentMethods] FOREIGN KEY ([PaymentMethodID]) REFERENCES [Application].[PaymentMethods] ([PaymentMethodID]),
        CONSTRAINT [FK_Sales_CustomerTransactions_TransactionTypeID_Application_TransactionTypes] FOREIGN KEY ([TransactionTypeID]) REFERENCES [Application].[TransactionTypes] ([TransactionTypeID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'All financial transactions that are customer-related';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions';
    SET @description = N'Numeric ID used to refer to a customer transaction within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'CustomerTransactionID';
    SET @description = N'Customer for this transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'CustomerID';
    SET @description = N'Type of transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'TransactionTypeID';
    SET @description = N'ID of an invoice (for transactions associated with an invoice)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'InvoiceID';
    SET @description = N'ID of a payment method (for transactions involving payments)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'PaymentMethodID';
    SET @description = N'Date for the transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'TransactionDate';
    SET @description = N'Transaction amount (excluding tax)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'AmountExcludingTax';
    SET @description = N'Tax amount calculated';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'TaxAmount';
    SET @description = N'Transaction amount (including tax)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'TransactionAmount';
    SET @description = N'Amount still outstanding for this transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'OutstandingBalance';
    SET @description = N'Date that this transaction was finalized (if it has been)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'FinalizationDate';
    SET @description = N'Is this transaction finalized (invoices, credits and payments have been matched)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'CustomerTransactions', 'COLUMN', N'IsFinalized';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[InvoiceLines] (
        [InvoiceLineID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[InvoiceLineID])),
        [InvoiceID] int NOT NULL,
        [StockItemID] int NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [PackageTypeID] int NOT NULL,
        [Quantity] int NOT NULL,
        [UnitPrice] decimal(18,2) NULL,
        [TaxRate] decimal(18,3) NOT NULL,
        [TaxAmount] decimal(18,2) NOT NULL,
        [LineProfit] decimal(18,2) NOT NULL,
        [ExtendedPrice] decimal(18,2) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_InvoiceLines] PRIMARY KEY ([InvoiceLineID]),
        CONSTRAINT [FK_Sales_InvoiceLines_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Sales_InvoiceLines_InvoiceID_Sales_Invoices] FOREIGN KEY ([InvoiceID]) REFERENCES [Sales].[Invoices] ([InvoiceID]),
        CONSTRAINT [FK_Sales_InvoiceLines_PackageTypeID_Warehouse_PackageTypes] FOREIGN KEY ([PackageTypeID]) REFERENCES [Warehouse].[PackageTypes] ([PackageTypeID]),
        CONSTRAINT [FK_Sales_InvoiceLines_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Detail lines from customer invoices';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines';
    SET @description = N'Numeric ID used for reference to a line on an invoice within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'InvoiceLineID';
    SET @description = N'Invoice that this line is associated with';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'InvoiceID';
    SET @description = N'Stock item for this invoice line';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'StockItemID';
    SET @description = N'Description of the item supplied (Usually the stock item name but can be overridden)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'Description';
    SET @description = N'Type of package supplied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'PackageTypeID';
    SET @description = N'Quantity supplied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'Quantity';
    SET @description = N'Unit price charged';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'UnitPrice';
    SET @description = N'Tax rate to be applied';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'TaxRate';
    SET @description = N'Tax amount calculated';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'TaxAmount';
    SET @description = N'Profit made on this line item at current cost price';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'LineProfit';
    SET @description = N'Extended line price charged';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Sales', 'TABLE', N'InvoiceLines', 'COLUMN', N'ExtendedPrice';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockItemTransactions] (
        [StockItemTransactionID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[TransactionID])),
        [StockItemID] int NOT NULL,
        [TransactionTypeID] int NOT NULL,
        [CustomerID] int NULL,
        [InvoiceID] int NULL,
        [SupplierID] int NULL,
        [PurchaseOrderID] int NULL,
        [TransactionOccurredWhen] datetime2 NOT NULL,
        [Quantity] decimal(18,3) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_Warehouse_StockItemTransactions] PRIMARY KEY NONCLUSTERED ([StockItemTransactionID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_CustomerID_Sales_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Sales].[Customers] ([CustomerID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_InvoiceID_Sales_Invoices] FOREIGN KEY ([InvoiceID]) REFERENCES [Sales].[Invoices] ([InvoiceID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_PurchaseOrderID_Purchasing_PurchaseOrders] FOREIGN KEY ([PurchaseOrderID]) REFERENCES [Purchasing].[PurchaseOrders] ([PurchaseOrderID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_StockItemID_Warehouse_StockItems] FOREIGN KEY ([StockItemID]) REFERENCES [Warehouse].[StockItems] ([StockItemID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_SupplierID_Purchasing_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [Purchasing].[Suppliers] ([SupplierID]),
        CONSTRAINT [FK_Warehouse_StockItemTransactions_TransactionTypeID_Application_TransactionTypes] FOREIGN KEY ([TransactionTypeID]) REFERENCES [Application].[TransactionTypes] ([TransactionTypeID])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Transactions covering all movements of all stock items';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions';
    SET @description = N'Numeric ID used to refer to a stock item transaction within the database';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'StockItemTransactionID';
    SET @description = N'StockItem for this transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'StockItemID';
    SET @description = N'Type of transaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'TransactionTypeID';
    SET @description = N'Customer for this transaction (if applicable)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'CustomerID';
    SET @description = N'ID of an invoice (for transactions associated with an invoice)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'InvoiceID';
    SET @description = N'Supplier for this stock transaction (if applicable)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'SupplierID';
    SET @description = N'ID of an purchase order (for transactions associated with a purchase order)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'PurchaseOrderID';
    SET @description = N'Date and time when the transaction occurred';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'TransactionOccurredWhen';
    SET @description = N'Quantity of stock movement (positive is incoming stock, negative is outgoing)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'Warehouse', 'TABLE', N'StockItemTransactions', 'COLUMN', N'Quantity';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_BuyingGroups_LastEditedBy] ON [Sales].[BuyingGroups] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Sales_BuyingGroups_BuyingGroupName] ON [Sales].[BuyingGroups] ([BuyingGroupName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_Cities_StateProvinceID] ON [Application].[Cities] ([StateProvinceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Cities_LastEditedBy] ON [Application].[Cities] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Warehouse_ColdRoomTemperatures_ColdRoomSensorNumber] ON [Warehouse].[ColdRoomTemperatures] ([ColdRoomSensorNumber]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Colors_LastEditedBy] ON [Warehouse].[Colors] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_Colors_ColorName] ON [Warehouse].[Colors] ([ColorName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Countries_LastEditedBy] ON [Application].[Countries] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_Countries_CountryName] ON [Application].[Countries] ([CountryName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_Countries_FormalName] ON [Application].[Countries] ([FormalName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerCategories_LastEditedBy] ON [Sales].[CustomerCategories] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Sales_CustomerCategories_CustomerCategoryName] ON [Sales].[CustomerCategories] ([CustomerCategoryName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_AlternateContactPersonID] ON [Sales].[Customers] ([AlternateContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_BuyingGroupID] ON [Sales].[Customers] ([BuyingGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_CustomerCategoryID] ON [Sales].[Customers] ([CustomerCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_DeliveryCityID] ON [Sales].[Customers] ([DeliveryCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_DeliveryMethodID] ON [Sales].[Customers] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_PostalCityID] ON [Sales].[Customers] ([PostalCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_PrimaryContactPersonID] ON [Sales].[Customers] ([PrimaryContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Customers_BillToCustomerID] ON [Sales].[Customers] ([BillToCustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Customers_LastEditedBy] ON [Sales].[Customers] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_Customers_Perf_20160301_06] ON [Sales].[Customers] ([IsOnCreditHold], [CustomerID], [BillToCustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Sales_Customers_CustomerName] ON [Sales].[Customers] ([CustomerName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE CLUSTERED INDEX [CX_Sales_CustomerTransactions] ON [Sales].[CustomerTransactions] ([TransactionDate]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_CustomerID] ON [Sales].[CustomerTransactions] ([TransactionDate], [CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_InvoiceID] ON [Sales].[CustomerTransactions] ([TransactionDate], [InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_PaymentMethodID] ON [Sales].[CustomerTransactions] ([TransactionDate], [PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_TransactionTypeID] ON [Sales].[CustomerTransactions] ([TransactionDate], [TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_CustomerID] ON [Sales].[CustomerTransactions] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_InvoiceID] ON [Sales].[CustomerTransactions] ([InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_LastEditedBy] ON [Sales].[CustomerTransactions] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_PaymentMethodID] ON [Sales].[CustomerTransactions] ([PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_TransactionTypeID] ON [Sales].[CustomerTransactions] ([TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_CustomerTransactions_IsFinalized] ON [Sales].[CustomerTransactions] ([TransactionDate], [IsFinalized]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_DeliveryMethods_LastEditedBy] ON [Application].[DeliveryMethods] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_DeliveryMethods_DeliveryMethodName] ON [Application].[DeliveryMethods] ([DeliveryMethodName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_InvoiceLines_InvoiceID] ON [Sales].[InvoiceLines] ([InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_InvoiceLines_PackageTypeID] ON [Sales].[InvoiceLines] ([PackageTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_InvoiceLines_StockItemID] ON [Sales].[InvoiceLines] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_InvoiceLines_LastEditedBy] ON [Sales].[InvoiceLines] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_AccountsPersonID] ON [Sales].[Invoices] ([AccountsPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_BillToCustomerID] ON [Sales].[Invoices] ([BillToCustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_ContactPersonID] ON [Sales].[Invoices] ([ContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_CustomerID] ON [Sales].[Invoices] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_DeliveryMethodID] ON [Sales].[Invoices] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_OrderID] ON [Sales].[Invoices] ([OrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_PackedByPersonID] ON [Sales].[Invoices] ([PackedByPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_SalespersonPersonID] ON [Sales].[Invoices] ([SalespersonPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Invoices_LastEditedBy] ON [Sales].[Invoices] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_Invoices_ConfirmedDeliveryTime] ON [Sales].[Invoices] ([ConfirmedDeliveryTime]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_OrderLines_OrderID] ON [Sales].[OrderLines] ([OrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_OrderLines_PackageTypeID] ON [Sales].[OrderLines] ([PackageTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_OrderLines_LastEditedBy] ON [Sales].[OrderLines] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_OrderLines_AllocatedStockItems] ON [Sales].[OrderLines] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_OrderLines_Perf_20160301_01] ON [Sales].[OrderLines] ([PickingCompletedWhen], [OrderID], [OrderLineID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_OrderLines_Perf_20160301_02] ON [Sales].[OrderLines] ([StockItemID], [PickingCompletedWhen]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_ContactPersonID] ON [Sales].[Orders] ([ContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_CustomerID] ON [Sales].[Orders] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_PickedByPersonID] ON [Sales].[Orders] ([PickedByPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_SalespersonPersonID] ON [Sales].[Orders] ([SalespersonPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Orders_BackorderOrderID] ON [Sales].[Orders] ([BackorderOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Orders_LastEditedBy] ON [Sales].[Orders] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_PackageTypes_LastEditedBy] ON [Warehouse].[PackageTypes] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_PackageTypes_PackageTypeName] ON [Warehouse].[PackageTypes] ([PackageTypeName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_PaymentMethods_LastEditedBy] ON [Application].[PaymentMethods] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_PaymentMethods_PaymentMethodName] ON [Application].[PaymentMethods] ([PaymentMethodName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_FullName] ON [Application].[People] ([FullName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_IsEmployee] ON [Application].[People] ([IsEmployee]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_IsSalesperson] ON [Application].[People] ([IsSalesperson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_Perf_20160301_05] ON [Application].[People] ([IsPermittedToLogon], [PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_People_LastEditedBy] ON [Application].[People] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrderLines_PackageTypeID] ON [Purchasing].[PurchaseOrderLines] ([PackageTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrderLines_PurchaseOrderID] ON [Purchasing].[PurchaseOrderLines] ([PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrderLines_StockItemID] ON [Purchasing].[PurchaseOrderLines] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_PurchaseOrderLines_LastEditedBy] ON [Purchasing].[PurchaseOrderLines] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Purchasing_PurchaseOrderLines_Perf_20160301_4] ON [Purchasing].[PurchaseOrderLines] ([IsOrderLineFinalized], [StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrders_ContactPersonID] ON [Purchasing].[PurchaseOrders] ([ContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrders_DeliveryMethodID] ON [Purchasing].[PurchaseOrders] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrders_SupplierID] ON [Purchasing].[PurchaseOrders] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_PurchaseOrders_LastEditedBy] ON [Purchasing].[PurchaseOrders] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_BuyingGroupID] ON [Sales].[SpecialDeals] ([BuyingGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_CustomerCategoryID] ON [Sales].[SpecialDeals] ([CustomerCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_CustomerID] ON [Sales].[SpecialDeals] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_StockGroupID] ON [Sales].[SpecialDeals] ([StockGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_StockItemID] ON [Sales].[SpecialDeals] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SpecialDeals_LastEditedBy] ON [Sales].[SpecialDeals] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_StateProvinces_CountryID] ON [Application].[StateProvinces] ([CountryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_StateProvinces_SalesTerritory] ON [Application].[StateProvinces] ([SalesTerritory]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_StateProvinces_LastEditedBy] ON [Application].[StateProvinces] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_StateProvinces_StateProvinceName] ON [Application].[StateProvinces] ([StateProvinceName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockGroups_LastEditedBy] ON [Warehouse].[StockGroups] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_StockGroups_StockGroupName] ON [Warehouse].[StockGroups] ([StockGroupName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItemHoldings_LastEditedBy] ON [Warehouse].[StockItemHoldings] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_ColorID] ON [Warehouse].[StockItems] ([ColorID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_OuterPackageID] ON [Warehouse].[StockItems] ([OuterPackageID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_SupplierID] ON [Warehouse].[StockItems] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_UnitPackageID] ON [Warehouse].[StockItems] ([UnitPackageID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItems_LastEditedBy] ON [Warehouse].[StockItems] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_StockItems_StockItemName] ON [Warehouse].[StockItems] ([StockItemName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItemStockGroups_LastEditedBy] ON [Warehouse].[StockItemStockGroups] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_StockItemStockGroups_StockGroupID_Lookup] ON [Warehouse].[StockItemStockGroups] ([StockGroupID], [StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_StockItemStockGroups_StockItemID_Lookup] ON [Warehouse].[StockItemStockGroups] ([StockItemID], [StockGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_CustomerID] ON [Warehouse].[StockItemTransactions] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_InvoiceID] ON [Warehouse].[StockItemTransactions] ([InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_PurchaseOrderID] ON [Warehouse].[StockItemTransactions] ([PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_StockItemID] ON [Warehouse].[StockItemTransactions] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_SupplierID] ON [Warehouse].[StockItemTransactions] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_TransactionTypeID] ON [Warehouse].[StockItemTransactions] ([TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItemTransactions_LastEditedBy] ON [Warehouse].[StockItemTransactions] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierCategories_LastEditedBy] ON [Purchasing].[SupplierCategories] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Purchasing_SupplierCategories_SupplierCategoryName] ON [Purchasing].[SupplierCategories] ([SupplierCategoryName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_AlternateContactPersonID] ON [Purchasing].[Suppliers] ([AlternateContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_DeliveryCityID] ON [Purchasing].[Suppliers] ([DeliveryCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_DeliveryMethodID] ON [Purchasing].[Suppliers] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_PostalCityID] ON [Purchasing].[Suppliers] ([PostalCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_PrimaryContactPersonID] ON [Purchasing].[Suppliers] ([PrimaryContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_SupplierCategoryID] ON [Purchasing].[Suppliers] ([SupplierCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Suppliers_LastEditedBy] ON [Purchasing].[Suppliers] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Purchasing_Suppliers_SupplierName] ON [Purchasing].[Suppliers] ([SupplierName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE CLUSTERED INDEX [CX_Purchasing_SupplierTransactions] ON [Purchasing].[SupplierTransactions] ([TransactionDate]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_PaymentMethodID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_PurchaseOrderID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_SupplierID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_TransactionTypeID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_Purchasing_SupplierTransactions_IsFinalized] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [IsFinalized]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_LastEditedBy] ON [Purchasing].[SupplierTransactions] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_PaymentMethodID] ON [Purchasing].[SupplierTransactions] ([PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_PurchaseOrderID] ON [Purchasing].[SupplierTransactions] ([PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_SupplierID] ON [Purchasing].[SupplierTransactions] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_TransactionTypeID] ON [Purchasing].[SupplierTransactions] ([TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_SystemParameters_DeliveryCityID] ON [Application].[SystemParameters] ([DeliveryCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_SystemParameters_PostalCityID] ON [Application].[SystemParameters] ([PostalCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_SystemParameters_LastEditedBy] ON [Application].[SystemParameters] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE INDEX [IX_TransactionTypes_LastEditedBy] ON [Application].[TransactionTypes] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_TransactionTypes_TransactionTypeName] ON [Application].[TransactionTypes] ([TransactionTypeName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080053_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221120080053_InitialCreate', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080257_CreateStoredProcedures')
BEGIN
    IF EXISTS (
    	SELECT type_desc
    	FROM sys.procedures
    	WHERE NAME = 'Configuration_ApplyFullTextIndexing'
    		AND type = 'P'
    	)
    	DROP PROCEDURE [Application].Configuration_ApplyFullTextIndexing
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080257_CreateStoredProcedures')
BEGIN
    CREATE PROCEDURE [Application].Configuration_ApplyFullTextIndexing
    WITH EXECUTE AS OWNER
    AS
    BEGIN
     IF SERVERPROPERTY(N'IsFullTextInstalled') = 0
     BEGIN
     PRINT N'Warning: Full text options cannot be configured because full text indexing is not installed.';
     END ELSE BEGIN -- if full text is installed
     DECLARE @SQL nvarchar(max) = N'';

     IF NOT EXISTS (SELECT 1 FROM sys.fulltext_catalogs WHERE name = N'FTCatalog')
     BEGIN
     SET @SQL = N'CREATE FULLTEXT CATALOG FTCatalog AS DEFAULT;'
     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.fulltext_indexes AS fti WHERE fti.object_id = OBJECT_ID(N'[Application].People'))
     BEGIN
     SET @SQL = N'
    CREATE FULLTEXT INDEX
    ON [Application].People (SearchName, CustomFields, OtherLanguages)
    KEY INDEX PK_Application_People
    WITH CHANGE_TRACKING AUTO;';
     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.fulltext_indexes AS fti WHERE fti.object_id = OBJECT_ID(N'Sales.Customers'))
     BEGIN
     SET @SQL = N'
    CREATE FULLTEXT INDEX
    ON Sales.Customers (CustomerName)
    KEY INDEX PK_Sales_Customers
    WITH CHANGE_TRACKING AUTO;';
     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.fulltext_indexes AS fti WHERE fti.object_id = OBJECT_ID(N'Purchasing.Suppliers'))
     BEGIN
     SET @SQL = N'
    CREATE FULLTEXT INDEX
    ON Purchasing.Suppliers (SupplierName)
    KEY INDEX PK_Purchasing_Suppliers
    WITH CHANGE_TRACKING AUTO;';
     EXECUTE (@SQL);
     END;


     IF NOT EXISTS (SELECT 1 FROM sys.fulltext_indexes AS fti WHERE fti.object_id = OBJECT_ID(N'Warehouse.StockItems'))
     BEGIN
     SET @SQL = N'CREATE FULLTEXT INDEX
    ON Warehouse.StockItems (SearchDetails, CustomFields, Tags)
    KEY INDEX PK_Warehouse_StockItems
    WITH CHANGE_TRACKING AUTO;';
     EXECUTE (@SQL);
     END;

     SET @SQL = N'DROP PROCEDURE IF EXISTS Website.SearchForPeople;';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE PROCEDURE Website.SearchForPeople
    @SearchText nvarchar(1000),
    @MaximumRowsToReturn int
    AS
    BEGIN
     SELECT p.PersonID,
     p.FullName,
     p.PreferredName,
     CASE WHEN p.IsSalesperson <> 0 THEN N''Salesperson''
     WHEN p.IsEmployee <> 0 THEN N''Employee''
     WHEN c.CustomerID IS NOT NULL THEN N''Customer''
     WHEN sp.SupplierID IS NOT NULL THEN N''Supplier''
     WHEN sa.SupplierID IS NOT NULL THEN N''Supplier''
     END AS Relationship,
     COALESCE(c.CustomerName, sp.SupplierName, sa.SupplierName, N''WWI'') AS Company
     FROM [Application].People AS p
     INNER JOIN FREETEXTTABLE([Application].People, SearchName, @SearchText, @MaximumRowsToReturn) AS ft
     ON p.PersonID = ft.[KEY]
     LEFT OUTER JOIN Sales.Customers AS c
     ON c.PrimaryContactPersonID = p.PersonID
     LEFT OUTER JOIN Purchasing.Suppliers AS sp
     ON sp.PrimaryContactPersonID = p.PersonID
     LEFT OUTER JOIN Purchasing.Suppliers AS sa
     ON sa.AlternateContactPersonID = p.PersonID
     ORDER BY ft.[RANK]
     FOR JSON AUTO, ROOT(N''People'');
    END;';
     EXECUTE (@SQL);

     SET @SQL = N'DROP PROCEDURE IF EXISTS Website.SearchForSuppliers;';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE PROCEDURE Website.SearchForSuppliers
    @SearchText nvarchar(1000),
    @MaximumRowsToReturn int
    AS
    BEGIN
     SELECT s.SupplierID,
     s.SupplierName,
     c.CityName,
     s.PhoneNumber,
     s.FaxNumber ,
     p.FullName AS PrimaryContactFullName,
     p.PreferredName AS PrimaryContactPreferredName
     FROM Purchasing.Suppliers AS s
     INNER JOIN FREETEXTTABLE(Purchasing.Suppliers, SupplierName, @SearchText, @MaximumRowsToReturn) AS ft
     ON s.SupplierID = ft.[KEY]
     INNER JOIN [Application].Cities AS c
     ON s.DeliveryCityID = c.CityID
     LEFT OUTER JOIN [Application].People AS p
     ON s.PrimaryContactPersonID = p.PersonID
     ORDER BY ft.[RANK]
     FOR JSON AUTO, ROOT(N''Suppliers'');
    END;';
     EXECUTE (@SQL);

     SET @SQL = N'DROP PROCEDURE IF EXISTS Website.SearchForCustomers;';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE PROCEDURE Website.SearchForCustomers
    @SearchText nvarchar(1000),
    @MaximumRowsToReturn int
    WITH EXECUTE AS OWNER
    AS
    BEGIN
     SELECT c.CustomerID,
     c.CustomerName,
     ct.CityName,
     c.PhoneNumber,
     c.FaxNumber,
     p.FullName AS PrimaryContactFullName,
     p.PreferredName AS PrimaryContactPreferredName
     FROM Sales.Customers AS c
     INNER JOIN FREETEXTTABLE(Sales.Customers, CustomerName, @SearchText, @MaximumRowsToReturn) AS ft
     ON c.CustomerID = ft.[KEY]
     INNER JOIN [Application].Cities AS ct
     ON c.DeliveryCityID = ct.CityID
     LEFT OUTER JOIN [Application].People AS p
     ON c.PrimaryContactPersonID = p.PersonID
     ORDER BY ft.[RANK]
     FOR JSON AUTO, ROOT(N''Customers'');
    END;';
     EXECUTE (@SQL);

     SET @SQL = N'DROP PROCEDURE IF EXISTS Website.SearchForStockItems;';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE PROCEDURE Website.SearchForStockItems
    @SearchText nvarchar(1000),
    @MaximumRowsToReturn int
    WITH EXECUTE AS OWNER
    AS
    BEGIN
     SELECT si.StockItemID,
     si.StockItemName
     FROM Warehouse.StockItems AS si
     INNER JOIN FREETEXTTABLE(Warehouse.StockItems, SearchDetails, @SearchText, @MaximumRowsToReturn) AS ft
     ON si.StockItemID = ft.[KEY]
     ORDER BY ft.[RANK]
     FOR JSON AUTO, ROOT(N''StockItems'');
    END;';
     EXECUTE (@SQL);

     SET @SQL = N'DROP PROCEDURE IF EXISTS Website.SearchForStockItemsByTags;';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE PROCEDURE Website.SearchForStockItemsByTags
    @SearchText nvarchar(1000),
    @MaximumRowsToReturn int
    WITH EXECUTE AS OWNER
    AS
    BEGIN
     SELECT si.StockItemID,
     si.StockItemName
     FROM Warehouse.StockItems AS si
     INNER JOIN FREETEXTTABLE(Warehouse.StockItems, Tags, @SearchText, @MaximumRowsToReturn) AS ft
     ON si.StockItemID = ft.[KEY]
     ORDER BY ft.[RANK]
     FOR JSON AUTO, ROOT(N''StockItems'');
    END;';
     EXECUTE (@SQL);

     PRINT N'Full text successfully enabled';
     END;
    END;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080257_CreateStoredProcedures')
BEGIN
    IF EXISTS (
    	SELECT type_desc
    	FROM sys.procedures
    	WHERE NAME = 'Configuration_ApplyPartitioning'
    		AND type = 'P'
    	)
    	DROP PROCEDURE [Application].Configuration_ApplyPartitioning
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080257_CreateStoredProcedures')
BEGIN
    CREATE PROCEDURE [Application].Configuration_ApplyPartitioning
    WITH EXECUTE AS OWNER
    AS
    BEGIN
     SET NOCOUNT ON;
     SET XACT_ABORT ON;

     IF SERVERPROPERTY(N'IsXTPSupported') = 0 -- TODO Check for a better way to check for partitioning
     BEGIN -- Currently versions that support in-memory OLTP also support partitions
     PRINT N'Warning: Partitions are not supported in this edition.';
     END ELSE BEGIN -- if partitions are permitted

     BEGIN TRAN;

     DECLARE @SQL nvarchar(max) = N'';

     IF NOT EXISTS (SELECT 1 FROM sys.partition_functions WHERE name = N'PF_TransactionDateTime')
     BEGIN
     SET @SQL = N'
    CREATE PARTITION FUNCTION PF_TransactionDateTime(datetime)
    AS RANGE RIGHT
    FOR VALUES (N''20140101'', N''20150101'', N''20160101'', N''20170101'');';
     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.partition_functions WHERE name = N'PF_TransactionDate')
     BEGIN
     SET @SQL = N'
    CREATE PARTITION FUNCTION PF_TransactionDate(date)
    AS RANGE RIGHT
    FOR VALUES (N''20140101'', N''20150101'', N''20160101'', N''20170101'');';
     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT * FROM sys.partition_schemes WHERE name = N'PS_TransactionDateTime')
     BEGIN

     -- for Azure DB, assign to primary filegroup
     IF SERVERPROPERTY('EngineEdition') = 5
     SET @SQL = N'
    CREATE PARTITION SCHEME PS_TransactionDateTime
    AS PARTITION PF_TransactionDateTime
    ALL TO ([PRIMARY]);';
     -- for other engine editions, assign to user data filegroup
     IF SERVERPROPERTY('EngineEdition') != 5
     SET @SQL = N'
    CREATE PARTITION SCHEME PS_TransactionDateTime
    AS PARTITION PF_TransactionDateTime
    ALL TO ([USERDATA]);';

     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.partition_schemes WHERE name = N'PS_TransactionDate')
     BEGIN
     -- for Azure DB, assign to primary filegroup
     IF SERVERPROPERTY('EngineEdition') = 5
     SET @SQL = N'
    CREATE PARTITION SCHEME PS_TransactionDate
    AS PARTITION PF_TransactionDate
    ALL TO ([PRIMARY]);';
     -- for other engine editions, assign to user data filegroup
     IF SERVERPROPERTY('EngineEdition') != 5
     SET @SQL = N'
    CREATE PARTITION SCHEME PS_TransactionDate
    AS PARTITION PF_TransactionDate
    ALL TO ([USERDATA]);';

     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'CX_Sales_CustomerTransactions')
     BEGIN
     SET @SQL = N'
    ALTER TABLE Sales.CustomerTransactions
    DROP CONSTRAINT PK_Sales_CustomerTransactions;';
     EXECUTE (@SQL);

     SET @SQL = N'
    ALTER TABLE Sales.CustomerTransactions
    ADD CONSTRAINT PK_Sales_CustomerTransactions PRIMARY KEY NONCLUSTERED
    (
    	CustomerTransactionID
    );';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE CLUSTERED INDEX CX_Sales_CustomerTransactions
    ON Sales.CustomerTransactions
    (
    	TransactionDate
    )
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Sales_CustomerTransactions_CustomerID
    ON Sales.CustomerTransactions
    (
    	CustomerID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Sales_CustomerTransactions_InvoiceID
    ON Sales.CustomerTransactions
    (
    	InvoiceID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Sales_CustomerTransactions_PaymentMethodID
    ON Sales.CustomerTransactions
    (
    	PaymentMethodID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Sales_CustomerTransactions_TransactionTypeID
    ON Sales.CustomerTransactions
    (
    	TransactionTypeID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX IX_Sales_CustomerTransactions_IsFinalized
    ON Sales.CustomerTransactions
    (
    	IsFinalized
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);
     END;

     IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'CX_Purchasing_SupplierTransactions')
     BEGIN
     SET @SQL = N'
    ALTER TABLE Purchasing.SupplierTransactions
    DROP CONSTRAINT PK_Purchasing_SupplierTransactions;';
     EXECUTE (@SQL);

     SET @SQL = N'
    ALTER TABLE Purchasing.SupplierTransactions
    ADD CONSTRAINT PK_Purchasing_SupplierTransactions PRIMARY KEY NONCLUSTERED
    (
    	SupplierTransactionID
    );';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE CLUSTERED INDEX CX_Purchasing_SupplierTransactions
    ON Purchasing.SupplierTransactions
    (
    	TransactionDate
    )
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Purchasing_SupplierTransactions_PaymentMethodID
    ON Purchasing.SupplierTransactions
    (
    	PaymentMethodID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Purchasing_SupplierTransactions_PurchaseOrderID
    ON Purchasing.SupplierTransactions
    (
    	PurchaseOrderID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Purchasing_SupplierTransactions_SupplierID
    ON Purchasing.SupplierTransactions
    (
    	SupplierID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX FK_Purchasing_SupplierTransactions_TransactionTypeID
    ON Purchasing.SupplierTransactions
    (
    	TransactionTypeID
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);

     SET @SQL = N'
    CREATE INDEX IX_Purchasing_SupplierTransactions_IsFinalized
    ON Purchasing.SupplierTransactions
    (
    	IsFinalized
    )
    WITH (DROP_EXISTING = ON)
    ON PS_TransactionDate(TransactionDate);';
     EXECUTE (@SQL);
     END;

     COMMIT;

     PRINT N'Partitioning successfully enabled';
     END;
    END;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221120080257_CreateStoredProcedures')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221120080257_CreateStoredProcedures', N'6.0.11');
END;
GO

COMMIT;
GO

