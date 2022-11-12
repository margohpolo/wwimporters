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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Sales') IS NULL EXEC(N'CREATE SCHEMA [Sales];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Application') IS NULL EXEC(N'CREATE SCHEMA [Application];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Warehouse') IS NULL EXEC(N'CREATE SCHEMA [Warehouse];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Purchasing') IS NULL EXEC(N'CREATE SCHEMA [Purchasing];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'Sequences') IS NULL EXEC(N'CREATE SCHEMA [Sequences];');
END;
GO

COMMIT;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[BuyingGroupID] AS int START WITH 3 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CityID] AS int START WITH 38187 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[ColorID] AS int START WITH 37 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CountryID] AS int START WITH 242 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CustomerCategoryID] AS int START WITH 9 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[CustomerID] AS int START WITH 1062 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[DeliveryMethodID] AS int START WITH 11 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[InvoiceID] AS int START WITH 70511 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[InvoiceLineID] AS int START WITH 228266 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[OrderID] AS int START WITH 73596 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[OrderLineID] AS int START WITH 231413 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PackageTypeID] AS int START WITH 15 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PaymentMethodID] AS int START WITH 5 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PersonID] AS int START WITH 3262 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PurchaseOrderID] AS int START WITH 2075 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[PurchaseOrderLineID] AS int START WITH 8368 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SpecialDealID] AS int START WITH 3 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StateProvinceID] AS int START WITH 54 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StockGroupID] AS int START WITH 11 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StockItemID] AS int START WITH 228 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[StockItemStockGroupID] AS int START WITH 443 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SupplierCategoryID] AS int START WITH 10 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SupplierID] AS int START WITH 14 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[SystemParameterID] AS int START WITH 2 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[TransactionID] AS int START WITH 336253 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE SEQUENCE [Sequences].[TransactionTypeID] AS int START WITH 14 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
END;
GO

COMMIT;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[BuyingGroups] (
        [BuyingGroupID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[BuyingGroupID])),
        [BuyingGroupName] nvarchar(58) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[Colors] (
        [ColorID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[ColorID])),
        [ColorName] nvarchar(28) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Colors] PRIMARY KEY ([ColorID]),
        CONSTRAINT [FK_Warehouse_Colors_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[Colors_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Application].[Countries] (
        [CountryID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CountryID])),
        [CountryName] nvarchar(68) NOT NULL,
        [FormalName] nvarchar(68) NOT NULL,
        [IsoAlpha3Code] nvarchar(11) NULL,
        [IsoNumericCode] int NULL,
        [CountryType] nvarchar(28) NULL,
        [LatestRecordedPopulation] bigint NULL,
        [Continent] nvarchar(38) NOT NULL,
        [Region] nvarchar(38) NOT NULL,
        [Subregion] nvarchar(38) NOT NULL,
        [Border] geography NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryID]),
        CONSTRAINT [FK_Application_Countries_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[Countries_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[CustomerCategories] (
        [CustomerCategoryID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CustomerCategoryID])),
        [CustomerCategoryName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_CustomerCategories] PRIMARY KEY ([CustomerCategoryID]),
        CONSTRAINT [FK_Sales_CustomerCategories_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Sales].[CustomerCategories_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[PackageTypes] (
        [PackageTypeID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PackageTypeID])),
        [PackageTypeName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_PackageTypes] PRIMARY KEY ([PackageTypeID]),
        CONSTRAINT [FK_Warehouse_PackageTypes_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[PackageTypes_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockGroups] (
        [StockGroupID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StockGroupID])),
        [StockGroupName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_StockGroups] PRIMARY KEY ([StockGroupID]),
        CONSTRAINT [FK_Warehouse_StockGroups_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Warehouse].[StockGroups_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[SupplierCategories] (
        [SupplierCategoryID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SupplierCategoryID])),
        [SupplierCategoryName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_SupplierCategories] PRIMARY KEY ([SupplierCategoryID]),
        CONSTRAINT [FK_Purchasing_SupplierCategories_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Purchasing].[SupplierCategories_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Application].[TransactionTypes] (
        [TransactionTypeID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[TransactionTypeID])),
        [TransactionTypeName] nvarchar(58) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
        [ValidTo] datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
        CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([TransactionTypeID]),
        CONSTRAINT [FK_Application_TransactionTypes_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo])
    ) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[TransactionTypes_Archive]));
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Application].[StateProvinces] (
        [StateProvinceID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StateProvinceID])),
        [StateProvinceCode] nvarchar(11) NOT NULL,
        [StateProvinceName] nvarchar(58) NOT NULL,
        [CountryID] int NOT NULL,
        [SalesTerritory] nvarchar(58) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[Customers] (
        [CustomerID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[CustomerID])),
        [CustomerName] nvarchar(107) NOT NULL,
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
        [PhoneNumber] nvarchar(28) NOT NULL,
        [FaxNumber] nvarchar(28) NOT NULL,
        [DeliveryRun] nvarchar(11) NULL,
        [RunPosition] nvarchar(11) NULL,
        [WebsiteURL] nvarchar(264) NOT NULL,
        [DeliveryAddressLine1] nvarchar(68) NOT NULL,
        [DeliveryAddressLine2] nvarchar(68) NULL,
        [DeliveryPostalCode] nvarchar(18) NOT NULL,
        [DeliveryLocation] geography NULL,
        [PostalAddressLine1] nvarchar(68) NOT NULL,
        [PostalAddressLine2] nvarchar(68) NULL,
        [PostalPostalCode] nvarchar(18) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[Suppliers] (
        [SupplierID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SupplierID])),
        [SupplierName] nvarchar(107) NOT NULL,
        [SupplierCategoryID] int NOT NULL,
        [PrimaryContactPersonID] int NOT NULL,
        [AlternateContactPersonID] int NOT NULL,
        [DeliveryMethodID] int NULL,
        [DeliveryCityID] int NOT NULL,
        [PostalCityID] int NOT NULL,
        [SupplierReference] nvarchar(28) NULL,
        [BankAccountName] nvarchar(58) NULL,
        [BankAccountBranch] nvarchar(58) NULL,
        [BankAccountCode] nvarchar(28) NULL,
        [BankAccountNumber] nvarchar(28) NULL,
        [BankInternationalCode] nvarchar(28) NULL,
        [PaymentDays] int NOT NULL,
        [InternalComments] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(28) NOT NULL,
        [FaxNumber] nvarchar(28) NOT NULL,
        [WebsiteURL] nvarchar(264) NOT NULL,
        [DeliveryAddressLine1] nvarchar(68) NOT NULL,
        [DeliveryAddressLine2] nvarchar(68) NULL,
        [DeliveryPostalCode] nvarchar(18) NOT NULL,
        [DeliveryLocation] geography NULL,
        [PostalAddressLine1] nvarchar(68) NOT NULL,
        [PostalAddressLine2] nvarchar(68) NULL,
        [PostalPostalCode] nvarchar(18) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Application].[SystemParameters] (
        [SystemParameterID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SystemParameterID])),
        [DeliveryAddressLine1] nvarchar(68) NOT NULL,
        [DeliveryAddressLine2] nvarchar(68) NULL,
        [DeliveryCityID] int NOT NULL,
        [DeliveryPostalCode] nvarchar(18) NOT NULL,
        [DeliveryLocation] geography NOT NULL,
        [PostalAddressLine1] nvarchar(68) NOT NULL,
        [PostalAddressLine2] nvarchar(68) NULL,
        [PostalCityID] int NOT NULL,
        [PostalPostalCode] nvarchar(18) NOT NULL,
        [ApplicationSettings] nvarchar(max) NOT NULL,
        [LastEditedBy] int NOT NULL,
        [LastEditedWhen] datetime2 NOT NULL DEFAULT ((sysdatetime())),
        CONSTRAINT [PK_SystemParameters] PRIMARY KEY ([SystemParameterID]),
        CONSTRAINT [FK_Application_SystemParameters_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]),
        CONSTRAINT [FK_Application_SystemParameters_DeliveryCityID_Application_Cities] FOREIGN KEY ([DeliveryCityID]) REFERENCES [Application].[Cities] ([CityID]),
        CONSTRAINT [FK_Application_SystemParameters_PostalCityID_Application_Cities] FOREIGN KEY ([PostalCityID]) REFERENCES [Application].[Cities] ([CityID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
        [CustomerPurchaseOrderNumber] nvarchar(28) NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[PurchaseOrders] (
        [PurchaseOrderID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PurchaseOrderID])),
        [SupplierID] int NOT NULL,
        [OrderDate] date NOT NULL,
        [DeliveryMethodID] int NOT NULL,
        [ContactPersonID] int NOT NULL,
        [ExpectedDeliveryDate] date NULL,
        [SupplierReference] nvarchar(28) NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockItems] (
        [StockItemID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[StockItemID])),
        [StockItemName] nvarchar(107) NOT NULL,
        [SupplierID] int NOT NULL,
        [ColorID] int NULL,
        [UnitPackageID] int NOT NULL,
        [OuterPackageID] int NOT NULL,
        [Brand] nvarchar(58) NULL,
        [Size] nvarchar(28) NULL,
        [LeadTimeDays] int NOT NULL,
        [QuantityPerOuter] int NOT NULL,
        [IsChillerStock] bit NOT NULL,
        [Barcode] nvarchar(58) NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
        [CustomerPurchaseOrderNumber] nvarchar(28) NULL,
        [IsCreditNote] bit NOT NULL,
        [CreditNoteReason] nvarchar(max) NULL,
        [Comments] nvarchar(max) NULL,
        [DeliveryInstructions] nvarchar(max) NULL,
        [InternalComments] nvarchar(max) NULL,
        [TotalDryItems] int NOT NULL,
        [TotalChillerItems] int NOT NULL,
        [DeliveryRun] nvarchar(11) NULL,
        [RunPosition] nvarchar(11) NULL,
        [ReturnedDeliveryData] nvarchar(max) NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[SupplierTransactions] (
        [SupplierTransactionID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[TransactionID])),
        [SupplierID] int NOT NULL,
        [TransactionTypeID] int NOT NULL,
        [PurchaseOrderID] int NULL,
        [PaymentMethodID] int NULL,
        [SupplierInvoiceNumber] nvarchar(28) NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[OrderLines] (
        [OrderLineID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[OrderLineID])),
        [OrderID] int NOT NULL,
        [StockItemID] int NOT NULL,
        [Description] nvarchar(107) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Purchasing].[PurchaseOrderLines] (
        [PurchaseOrderLineID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])),
        [PurchaseOrderID] int NOT NULL,
        [StockItemID] int NOT NULL,
        [OrderedOuters] int NOT NULL,
        [Description] nvarchar(107) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[SpecialDeals] (
        [SpecialDealID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[SpecialDealID])),
        [StockItemID] int NULL,
        [CustomerID] int NULL,
        [BuyingGroupID] int NULL,
        [CustomerCategoryID] int NULL,
        [StockGroupID] int NULL,
        [DealDescription] nvarchar(38) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Warehouse].[StockItemHoldings] (
        [StockItemID] int NOT NULL,
        [QuantityOnHand] int NOT NULL,
        [BinLocation] nvarchar(28) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE TABLE [Sales].[InvoiceLines] (
        [InvoiceLineID] int NOT NULL DEFAULT ((NEXT VALUE FOR [Sequences].[InvoiceLineID])),
        [InvoiceID] int NOT NULL,
        [StockItemID] int NOT NULL,
        [Description] nvarchar(107) NOT NULL,
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_BuyingGroups_LastEditedBy] ON [Sales].[BuyingGroups] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Sales_BuyingGroups_BuyingGroupName] ON [Sales].[BuyingGroups] ([BuyingGroupName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_Cities_StateProvinceID] ON [Application].[Cities] ([StateProvinceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Cities_LastEditedBy] ON [Application].[Cities] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Warehouse_ColdRoomTemperatures_ColdRoomSensorNumber] ON [Warehouse].[ColdRoomTemperatures] ([ColdRoomSensorNumber]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Colors_LastEditedBy] ON [Warehouse].[Colors] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_Colors_ColorName] ON [Warehouse].[Colors] ([ColorName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Countries_LastEditedBy] ON [Application].[Countries] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_Countries_CountryName] ON [Application].[Countries] ([CountryName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_Countries_FormalName] ON [Application].[Countries] ([FormalName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerCategories_LastEditedBy] ON [Sales].[CustomerCategories] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Sales_CustomerCategories_CustomerCategoryName] ON [Sales].[CustomerCategories] ([CustomerCategoryName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_AlternateContactPersonID] ON [Sales].[Customers] ([AlternateContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_BuyingGroupID] ON [Sales].[Customers] ([BuyingGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_CustomerCategoryID] ON [Sales].[Customers] ([CustomerCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_DeliveryCityID] ON [Sales].[Customers] ([DeliveryCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_DeliveryMethodID] ON [Sales].[Customers] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_PostalCityID] ON [Sales].[Customers] ([PostalCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Customers_PrimaryContactPersonID] ON [Sales].[Customers] ([PrimaryContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Customers_BillToCustomerID] ON [Sales].[Customers] ([BillToCustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Customers_LastEditedBy] ON [Sales].[Customers] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_Customers_Perf_20160301_06] ON [Sales].[Customers] ([IsOnCreditHold], [CustomerID], [BillToCustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Sales_Customers_CustomerName] ON [Sales].[Customers] ([CustomerName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE CLUSTERED INDEX [CX_Sales_CustomerTransactions] ON [Sales].[CustomerTransactions] ([TransactionDate]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_CustomerID] ON [Sales].[CustomerTransactions] ([TransactionDate], [CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_InvoiceID] ON [Sales].[CustomerTransactions] ([TransactionDate], [InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_PaymentMethodID] ON [Sales].[CustomerTransactions] ([TransactionDate], [PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_CustomerTransactions_TransactionTypeID] ON [Sales].[CustomerTransactions] ([TransactionDate], [TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_CustomerID] ON [Sales].[CustomerTransactions] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_InvoiceID] ON [Sales].[CustomerTransactions] ([InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_LastEditedBy] ON [Sales].[CustomerTransactions] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_PaymentMethodID] ON [Sales].[CustomerTransactions] ([PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomerTransactions_TransactionTypeID] ON [Sales].[CustomerTransactions] ([TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_CustomerTransactions_IsFinalized] ON [Sales].[CustomerTransactions] ([TransactionDate], [IsFinalized]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_DeliveryMethods_LastEditedBy] ON [Application].[DeliveryMethods] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_DeliveryMethods_DeliveryMethodName] ON [Application].[DeliveryMethods] ([DeliveryMethodName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_InvoiceLines_InvoiceID] ON [Sales].[InvoiceLines] ([InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_InvoiceLines_PackageTypeID] ON [Sales].[InvoiceLines] ([PackageTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_InvoiceLines_StockItemID] ON [Sales].[InvoiceLines] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_InvoiceLines_LastEditedBy] ON [Sales].[InvoiceLines] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_AccountsPersonID] ON [Sales].[Invoices] ([AccountsPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_BillToCustomerID] ON [Sales].[Invoices] ([BillToCustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_ContactPersonID] ON [Sales].[Invoices] ([ContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_CustomerID] ON [Sales].[Invoices] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_DeliveryMethodID] ON [Sales].[Invoices] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_OrderID] ON [Sales].[Invoices] ([OrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_PackedByPersonID] ON [Sales].[Invoices] ([PackedByPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Invoices_SalespersonPersonID] ON [Sales].[Invoices] ([SalespersonPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Invoices_LastEditedBy] ON [Sales].[Invoices] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_Invoices_ConfirmedDeliveryTime] ON [Sales].[Invoices] ([ConfirmedDeliveryTime]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_OrderLines_OrderID] ON [Sales].[OrderLines] ([OrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_OrderLines_PackageTypeID] ON [Sales].[OrderLines] ([PackageTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_OrderLines_LastEditedBy] ON [Sales].[OrderLines] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_OrderLines_AllocatedStockItems] ON [Sales].[OrderLines] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_OrderLines_Perf_20160301_01] ON [Sales].[OrderLines] ([PickingCompletedWhen], [OrderID], [OrderLineID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Sales_OrderLines_Perf_20160301_02] ON [Sales].[OrderLines] ([StockItemID], [PickingCompletedWhen]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_ContactPersonID] ON [Sales].[Orders] ([ContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_CustomerID] ON [Sales].[Orders] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_PickedByPersonID] ON [Sales].[Orders] ([PickedByPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_Orders_SalespersonPersonID] ON [Sales].[Orders] ([SalespersonPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Orders_BackorderOrderID] ON [Sales].[Orders] ([BackorderOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Orders_LastEditedBy] ON [Sales].[Orders] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_PackageTypes_LastEditedBy] ON [Warehouse].[PackageTypes] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_PackageTypes_PackageTypeName] ON [Warehouse].[PackageTypes] ([PackageTypeName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_PaymentMethods_LastEditedBy] ON [Application].[PaymentMethods] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_PaymentMethods_PaymentMethodName] ON [Application].[PaymentMethods] ([PaymentMethodName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_FullName] ON [Application].[People] ([FullName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_IsEmployee] ON [Application].[People] ([IsEmployee]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_IsSalesperson] ON [Application].[People] ([IsSalesperson]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_People_Perf_20160301_05] ON [Application].[People] ([IsPermittedToLogon], [PersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_People_LastEditedBy] ON [Application].[People] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrderLines_PackageTypeID] ON [Purchasing].[PurchaseOrderLines] ([PackageTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrderLines_PurchaseOrderID] ON [Purchasing].[PurchaseOrderLines] ([PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrderLines_StockItemID] ON [Purchasing].[PurchaseOrderLines] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_PurchaseOrderLines_LastEditedBy] ON [Purchasing].[PurchaseOrderLines] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Purchasing_PurchaseOrderLines_Perf_20160301_4] ON [Purchasing].[PurchaseOrderLines] ([IsOrderLineFinalized], [StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrders_ContactPersonID] ON [Purchasing].[PurchaseOrders] ([ContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrders_DeliveryMethodID] ON [Purchasing].[PurchaseOrders] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_PurchaseOrders_SupplierID] ON [Purchasing].[PurchaseOrders] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_PurchaseOrders_LastEditedBy] ON [Purchasing].[PurchaseOrders] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_BuyingGroupID] ON [Sales].[SpecialDeals] ([BuyingGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_CustomerCategoryID] ON [Sales].[SpecialDeals] ([CustomerCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_CustomerID] ON [Sales].[SpecialDeals] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_StockGroupID] ON [Sales].[SpecialDeals] ([StockGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Sales_SpecialDeals_StockItemID] ON [Sales].[SpecialDeals] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SpecialDeals_LastEditedBy] ON [Sales].[SpecialDeals] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_StateProvinces_CountryID] ON [Application].[StateProvinces] ([CountryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Application_StateProvinces_SalesTerritory] ON [Application].[StateProvinces] ([SalesTerritory]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_StateProvinces_LastEditedBy] ON [Application].[StateProvinces] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_StateProvinces_StateProvinceName] ON [Application].[StateProvinces] ([StateProvinceName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockGroups_LastEditedBy] ON [Warehouse].[StockGroups] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_StockGroups_StockGroupName] ON [Warehouse].[StockGroups] ([StockGroupName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItemHoldings_LastEditedBy] ON [Warehouse].[StockItemHoldings] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_ColorID] ON [Warehouse].[StockItems] ([ColorID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_OuterPackageID] ON [Warehouse].[StockItems] ([OuterPackageID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_SupplierID] ON [Warehouse].[StockItems] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItems_UnitPackageID] ON [Warehouse].[StockItems] ([UnitPackageID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItems_LastEditedBy] ON [Warehouse].[StockItems] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Warehouse_StockItems_StockItemName] ON [Warehouse].[StockItems] ([StockItemName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItemStockGroups_LastEditedBy] ON [Warehouse].[StockItemStockGroups] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_StockItemStockGroups_StockGroupID_Lookup] ON [Warehouse].[StockItemStockGroups] ([StockGroupID], [StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_StockItemStockGroups_StockItemID_Lookup] ON [Warehouse].[StockItemStockGroups] ([StockItemID], [StockGroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_CustomerID] ON [Warehouse].[StockItemTransactions] ([CustomerID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_InvoiceID] ON [Warehouse].[StockItemTransactions] ([InvoiceID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_PurchaseOrderID] ON [Warehouse].[StockItemTransactions] ([PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_StockItemID] ON [Warehouse].[StockItemTransactions] ([StockItemID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_SupplierID] ON [Warehouse].[StockItemTransactions] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Warehouse_StockItemTransactions_TransactionTypeID] ON [Warehouse].[StockItemTransactions] ([TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_StockItemTransactions_LastEditedBy] ON [Warehouse].[StockItemTransactions] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierCategories_LastEditedBy] ON [Purchasing].[SupplierCategories] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Purchasing_SupplierCategories_SupplierCategoryName] ON [Purchasing].[SupplierCategories] ([SupplierCategoryName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_AlternateContactPersonID] ON [Purchasing].[Suppliers] ([AlternateContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_DeliveryCityID] ON [Purchasing].[Suppliers] ([DeliveryCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_DeliveryMethodID] ON [Purchasing].[Suppliers] ([DeliveryMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_PostalCityID] ON [Purchasing].[Suppliers] ([PostalCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_PrimaryContactPersonID] ON [Purchasing].[Suppliers] ([PrimaryContactPersonID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_Suppliers_SupplierCategoryID] ON [Purchasing].[Suppliers] ([SupplierCategoryID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Suppliers_LastEditedBy] ON [Purchasing].[Suppliers] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Purchasing_Suppliers_SupplierName] ON [Purchasing].[Suppliers] ([SupplierName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE CLUSTERED INDEX [CX_Purchasing_SupplierTransactions] ON [Purchasing].[SupplierTransactions] ([TransactionDate]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_PaymentMethodID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_PurchaseOrderID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_SupplierID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Purchasing_SupplierTransactions_TransactionTypeID] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_Purchasing_SupplierTransactions_IsFinalized] ON [Purchasing].[SupplierTransactions] ([TransactionDate], [IsFinalized]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_LastEditedBy] ON [Purchasing].[SupplierTransactions] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_PaymentMethodID] ON [Purchasing].[SupplierTransactions] ([PaymentMethodID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_PurchaseOrderID] ON [Purchasing].[SupplierTransactions] ([PurchaseOrderID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_SupplierID] ON [Purchasing].[SupplierTransactions] ([SupplierID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SupplierTransactions_TransactionTypeID] ON [Purchasing].[SupplierTransactions] ([TransactionTypeID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_SystemParameters_DeliveryCityID] ON [Application].[SystemParameters] ([DeliveryCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [FK_Application_SystemParameters_PostalCityID] ON [Application].[SystemParameters] ([PostalCityID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_SystemParameters_LastEditedBy] ON [Application].[SystemParameters] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE INDEX [IX_TransactionTypes_LastEditedBy] ON [Application].[TransactionTypes] ([LastEditedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ_Application_TransactionTypes_TransactionTypeName] ON [Application].[TransactionTypes] ([TransactionTypeName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221110111715_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221110111715_InitialCreate', N'6.0.11');
END;
GO

COMMIT;
GO

