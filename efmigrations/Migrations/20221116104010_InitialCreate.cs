using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace wwimporters.efmigrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Application");

            migrationBuilder.EnsureSchema(
                name: "Warehouse");

            migrationBuilder.EnsureSchema(
                name: "Purchasing");

            migrationBuilder.EnsureSchema(
                name: "Sequences");

            migrationBuilder.AlterDatabase()
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateSequence<int>(
                name: "BuyingGroupID",
                schema: "Sequences",
                startValue: 3L);

            migrationBuilder.CreateSequence<int>(
                name: "CityID",
                schema: "Sequences",
                startValue: 38187L);

            migrationBuilder.CreateSequence<int>(
                name: "ColorID",
                schema: "Sequences",
                startValue: 37L);

            migrationBuilder.CreateSequence<int>(
                name: "CountryID",
                schema: "Sequences",
                startValue: 242L);

            migrationBuilder.CreateSequence<int>(
                name: "CustomerCategoryID",
                schema: "Sequences",
                startValue: 9L);

            migrationBuilder.CreateSequence<int>(
                name: "CustomerID",
                schema: "Sequences",
                startValue: 1062L);

            migrationBuilder.CreateSequence<int>(
                name: "DeliveryMethodID",
                schema: "Sequences",
                startValue: 11L);

            migrationBuilder.CreateSequence<int>(
                name: "InvoiceID",
                schema: "Sequences",
                startValue: 70511L);

            migrationBuilder.CreateSequence<int>(
                name: "InvoiceLineID",
                schema: "Sequences",
                startValue: 228266L);

            migrationBuilder.CreateSequence<int>(
                name: "OrderID",
                schema: "Sequences",
                startValue: 73596L);

            migrationBuilder.CreateSequence<int>(
                name: "OrderLineID",
                schema: "Sequences",
                startValue: 231413L);

            migrationBuilder.CreateSequence<int>(
                name: "PackageTypeID",
                schema: "Sequences",
                startValue: 15L);

            migrationBuilder.CreateSequence<int>(
                name: "PaymentMethodID",
                schema: "Sequences",
                startValue: 5L);

            migrationBuilder.CreateSequence<int>(
                name: "PersonID",
                schema: "Sequences",
                startValue: 3262L);

            migrationBuilder.CreateSequence<int>(
                name: "PurchaseOrderID",
                schema: "Sequences",
                startValue: 2075L);

            migrationBuilder.CreateSequence<int>(
                name: "PurchaseOrderLineID",
                schema: "Sequences",
                startValue: 8368L);

            migrationBuilder.CreateSequence<int>(
                name: "SpecialDealID",
                schema: "Sequences",
                startValue: 3L);

            migrationBuilder.CreateSequence<int>(
                name: "StateProvinceID",
                schema: "Sequences",
                startValue: 54L);

            migrationBuilder.CreateSequence<int>(
                name: "StockGroupID",
                schema: "Sequences",
                startValue: 11L);

            migrationBuilder.CreateSequence<int>(
                name: "StockItemID",
                schema: "Sequences",
                startValue: 228L);

            migrationBuilder.CreateSequence<int>(
                name: "StockItemStockGroupID",
                schema: "Sequences",
                startValue: 443L);

            migrationBuilder.CreateSequence<int>(
                name: "SupplierCategoryID",
                schema: "Sequences",
                startValue: 10L);

            migrationBuilder.CreateSequence<int>(
                name: "SupplierID",
                schema: "Sequences",
                startValue: 14L);

            migrationBuilder.CreateSequence<int>(
                name: "SystemParameterID",
                schema: "Sequences",
                startValue: 2L);

            migrationBuilder.CreateSequence<int>(
                name: "TransactionID",
                schema: "Sequences",
                startValue: 336253L);

            migrationBuilder.CreateSequence<int>(
                name: "TransactionTypeID",
                schema: "Sequences",
                startValue: 14L);

            migrationBuilder.CreateTable(
                name: "ColdRoomTemperatures",
                schema: "Warehouse",
                columns: table => new
                {
                    ColdRoomTemperatureID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColdRoomSensorNumber = table.Column<int>(type: "int", nullable: false),
                    RecordedWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_ColdRoomTemperatures", x => x.ColdRoomTemperatureID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ColdRoomTemperatures_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "People",
                schema: "Application",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PersonID])", comment: "Numeric ID used for reference to a person within the database"),
                    FullName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Full name for this person"),
                    PreferredName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Name that this person prefers to be called"),
                    SearchName = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false, computedColumnSql: "(concat([PreferredName],N' ',[FullName]))", stored: true, comment: "Name to build full text search on (computed column)"),
                    IsPermittedToLogon = table.Column<bool>(type: "bit", nullable: false, comment: "Is this person permitted to log on?"),
                    LogonName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true, comment: "Person's system logon name"),
                    IsExternalLogonProvider = table.Column<bool>(type: "bit", nullable: false, comment: "Is logon token provided by an external system?"),
                    HashedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "Hash of password for users without external logon tokens"),
                    IsSystemUser = table.Column<bool>(type: "bit", nullable: false, comment: "Is the currently permitted to make online access?"),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false, comment: "Is this person an employee?"),
                    IsSalesperson = table.Column<bool>(type: "bit", nullable: false, comment: "Is this person a staff salesperson?"),
                    UserPreferences = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User preferences related to the website (holds JSON data)"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true, comment: "Phone number"),
                    FaxNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true, comment: "Fax number"),
                    EmailAddress = table.Column<string>(type: "nvarchar(264)", maxLength: 264, nullable: true, comment: "Email address for this person"),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "Photo of this person"),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Custom fields for employees and salespeople"),
                    OtherLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "(json_query([CustomFields],N'$.OtherLanguages'))", stored: false, comment: "Other languages spoken (computed column from custom fields)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Application_People_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "People known to the application (staff, customer contacts, supplier contacts)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "People_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "VehicleTemperatures",
                schema: "Warehouse",
                columns: table => new
                {
                    VehicleTemperatureID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRegistration = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false, collation: "Latin1_General_CI_AS"),
                    ChillerSensorNumber = table.Column<int>(type: "int", nullable: false),
                    RecordedWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FullSensorData = table.Column<string>(type: "nvarchar(1008)", maxLength: 1008, nullable: true, collation: "Latin1_General_CI_AS"),
                    IsCompressed = table.Column<bool>(type: "bit", nullable: false),
                    CompressedSensorData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_VehicleTemperatures", x => x.VehicleTemperatureID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "BuyingGroups",
                schema: "Sales",
                columns: table => new
                {
                    BuyingGroupID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[BuyingGroupID])", comment: "Numeric ID used for reference to a buying group within the database"),
                    BuyingGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Full name of a buying group that customers can be members of"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingGroups", x => x.BuyingGroupID);
                    table.ForeignKey(
                        name: "FK_Sales_BuyingGroups_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Customer organizations can be part of groups that exert greater buying power")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BuyingGroups_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Sales")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Colors",
                schema: "Warehouse",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[ColorID])", comment: "Numeric ID used for reference to a color within the database"),
                    ColorName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Full name of a color that can be used to describe stock items"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                    table.ForeignKey(
                        name: "FK_Warehouse_Colors_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Stock items can (optionally) have colors")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Colors_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Application",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CountryID])", comment: "Numeric ID used for reference to a country within the database"),
                    CountryName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Name of the country"),
                    FormalName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Full formal name of the country as agreed by United Nations"),
                    IsoAlpha3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true, comment: "3 letter alphabetic code assigned to the country by ISO"),
                    IsoNumericCode = table.Column<int>(type: "int", nullable: true, comment: "Numeric code assigned to the country by ISO"),
                    CountryType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Type of country or administrative region"),
                    LatestRecordedPopulation = table.Column<long>(type: "bigint", nullable: true, comment: "Latest available population for the country"),
                    Continent = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the continent"),
                    Region = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the region"),
                    Subregion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the subregion"),
                    Border = table.Column<Geometry>(type: "geography", nullable: true, comment: "Geographic border of the country as described by the United Nations"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Application_Countries_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Countries that contain the states or provinces (including geographic boundaries)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Countries_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "CustomerCategories",
                schema: "Sales",
                columns: table => new
                {
                    CustomerCategoryID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CustomerCategoryID])", comment: "Numeric ID used for reference to a customer category within the database"),
                    CustomerCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Full name of the category that customers can be assigned to"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategories", x => x.CustomerCategoryID);
                    table.ForeignKey(
                        name: "FK_Sales_CustomerCategories_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Categories for customers (ie restaurants, cafes, supermarkets, etc.)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CustomerCategories_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Sales")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                schema: "Application",
                columns: table => new
                {
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[DeliveryMethodID])", comment: "Numeric ID used for reference to a delivery method within the database"),
                    DeliveryMethodName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Full name of methods that can be used for delivery of customer orders"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.DeliveryMethodID);
                    table.ForeignKey(
                        name: "FK_Application_DeliveryMethods_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Ways that stock items can be delivered (ie: truck/van, post, pickup, courier, etc.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DeliveryMethods_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "PackageTypes",
                schema: "Warehouse",
                columns: table => new
                {
                    PackageTypeID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PackageTypeID])", comment: "Numeric ID used for reference to a package type within the database"),
                    PackageTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Full name of package types that stock items can be purchased in or sold in"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTypes", x => x.PackageTypeID);
                    table.ForeignKey(
                        name: "FK_Warehouse_PackageTypes_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Ways that stock items can be packaged (ie: each, box, carton, pallet, kg, etc.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "PackageTypes_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                schema: "Application",
                columns: table => new
                {
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PaymentMethodID])", comment: "Numeric ID used for reference to a payment type within the database"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Full name of ways that customers can make payments or that suppliers can be paid"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodID);
                    table.ForeignKey(
                        name: "FK_Application_PaymentMethods_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Ways that payments can be made (ie: cash, check, EFT, etc.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "PaymentMethods_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "StockGroups",
                schema: "Warehouse",
                columns: table => new
                {
                    StockGroupID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StockGroupID])", comment: "Numeric ID used for reference to a stock group within the database"),
                    StockGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Full name of groups used to categorize stock items"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockGroups", x => x.StockGroupID);
                    table.ForeignKey(
                        name: "FK_Warehouse_StockGroups_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Groups for categorizing stock items (ie: novelties, toys, edible novelties, etc.)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "StockGroups_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "SupplierCategories",
                schema: "Purchasing",
                columns: table => new
                {
                    SupplierCategoryID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SupplierCategoryID])", comment: "Numeric ID used for reference to a supplier category within the database"),
                    SupplierCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Full name of the category that suppliers can be assigned to"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierCategories", x => x.SupplierCategoryID);
                    table.ForeignKey(
                        name: "FK_Purchasing_SupplierCategories_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Categories for suppliers (ie novelties, toys, clothing, packaging, etc.)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SupplierCategories_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Purchasing")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                schema: "Application",
                columns: table => new
                {
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionTypeID])", comment: "Numeric ID used for reference to a transaction type within the database"),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Full name of the transaction type"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeID);
                    table.ForeignKey(
                        name: "FK_Application_TransactionTypes_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Types of customer, supplier, or stock transactions (ie: invoice, credit note, etc.)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionTypes_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "StateProvinces",
                schema: "Application",
                columns: table => new
                {
                    StateProvinceID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StateProvinceID])", comment: "Numeric ID used for reference to a state or province within the database"),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "Common code for this state or province (such as WA - Washington for the USA)"),
                    StateProvinceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Formal name of the state or province"),
                    CountryID = table.Column<int>(type: "int", nullable: false, comment: "Country for this StateProvince"),
                    SalesTerritory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Sales territory for this StateProvince"),
                    Border = table.Column<Geometry>(type: "geography", nullable: true, comment: "Geographic boundary of the state or province"),
                    LatestRecordedPopulation = table.Column<long>(type: "bigint", nullable: true, comment: "Latest available population for the StateProvince"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvinces", x => x.StateProvinceID);
                    table.ForeignKey(
                        name: "FK_Application_StateProvinces_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Application_StateProvinces_CountryID_Application_Countries",
                        column: x => x.CountryID,
                        principalSchema: "Application",
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                },
                comment: "States or provinces that contain cities (including geographic location)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "StateProvinces_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Application",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CityID])", comment: "Numeric ID used for reference to a city within the database"),
                    CityName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Formal name of the city"),
                    StateProvinceID = table.Column<int>(type: "int", nullable: false, comment: "State or province for this city. Has a foreign key"),
                    Location = table.Column<Geometry>(type: "geography", nullable: true, comment: "Geographic location of the city"),
                    LatestRecordedPopulation = table.Column<long>(type: "bigint", nullable: true, comment: "Latest available population for the City"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Application_Cities_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Application_Cities_StateProvinceID_Application_StateProvinces",
                        column: x => x.StateProvinceID,
                        principalSchema: "Application",
                        principalTable: "StateProvinces",
                        principalColumn: "StateProvinceID");
                },
                comment: "Cities that are part of any address (including geographic location)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Cities_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CustomerID])", comment: "Numeric ID used for reference to a customer within the database"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Customer's full name (usually a trading name)"),
                    BillToCustomerID = table.Column<int>(type: "int", nullable: false, comment: "Customer that this is billed to (usually the same customer but can be another parent company)"),
                    CustomerCategoryID = table.Column<int>(type: "int", nullable: false, comment: "Customer's category"),
                    BuyingGroupID = table.Column<int>(type: "int", nullable: true, comment: "Customer's buying group (optional)"),
                    PrimaryContactPersonID = table.Column<int>(type: "int", nullable: false, comment: "Primary contact"),
                    AlternateContactPersonID = table.Column<int>(type: "int", nullable: true, comment: "Alternate contact"),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false, comment: "Standard delivery method for stock items sent to this customer"),
                    DeliveryCityID = table.Column<int>(type: "int", nullable: false, comment: "ID of the delivery city for this address"),
                    PostalCityID = table.Column<int>(type: "int", nullable: false, comment: "ID of the postal city for this address"),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Credit limit for this customer (NULL if unlimited)"),
                    AccountOpenedDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date this customer account was opened"),
                    StandardDiscountPercentage = table.Column<decimal>(type: "decimal(18,3)", nullable: false, comment: "Standard discount offered to this customer"),
                    IsStatementSent = table.Column<bool>(type: "bit", nullable: false, comment: "Is a statement sent to this customer? (Or do they just pay on each invoice?)"),
                    IsOnCreditHold = table.Column<bool>(type: "bit", nullable: false, comment: "Is this customer on credit hold? (Prevents further deliveries to this customer)"),
                    PaymentDays = table.Column<int>(type: "int", nullable: false, comment: "Number of days for payment of an invoice (ie payment terms)"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Phone number"),
                    FaxNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Fax number"),
                    DeliveryRun = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Normal delivery run for this customer"),
                    RunPosition = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Normal position in the delivery run for this customer"),
                    WebsiteURL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "URL for the website for this customer"),
                    DeliveryAddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First delivery address line for the customer"),
                    DeliveryAddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second delivery address line for the customer"),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Delivery postal code for the customer"),
                    DeliveryLocation = table.Column<Geometry>(type: "geography", nullable: true, comment: "Geographic location for the customer's office/warehouse"),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First postal address line for the customer"),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second postal address line for the customer"),
                    PostalPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Postal code for the customer when sending by mail"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_AlternateContactPersonID_Application_People",
                        column: x => x.AlternateContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_BillToCustomerID_Sales_Customers",
                        column: x => x.BillToCustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_BuyingGroupID_Sales_BuyingGroups",
                        column: x => x.BuyingGroupID,
                        principalSchema: "Sales",
                        principalTable: "BuyingGroups",
                        principalColumn: "BuyingGroupID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerCategoryID_Sales_CustomerCategories",
                        column: x => x.CustomerCategoryID,
                        principalSchema: "Sales",
                        principalTable: "CustomerCategories",
                        principalColumn: "CustomerCategoryID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_DeliveryCityID_Application_Cities",
                        column: x => x.DeliveryCityID,
                        principalSchema: "Application",
                        principalTable: "Cities",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_DeliveryMethodID_Application_DeliveryMethods",
                        column: x => x.DeliveryMethodID,
                        principalSchema: "Application",
                        principalTable: "DeliveryMethods",
                        principalColumn: "DeliveryMethodID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_PostalCityID_Application_Cities",
                        column: x => x.PostalCityID,
                        principalSchema: "Application",
                        principalTable: "Cities",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Sales_Customers_PrimaryContactPersonID_Application_People",
                        column: x => x.PrimaryContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Main entity tables for customers (organizations or individuals)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Customers_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Sales")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Purchasing",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SupplierID])", comment: "Numeric ID used for reference to a supplier within the database"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Supplier's full name (usually a trading name)"),
                    SupplierCategoryID = table.Column<int>(type: "int", nullable: false, comment: "Supplier's category"),
                    PrimaryContactPersonID = table.Column<int>(type: "int", nullable: false, comment: "Primary contact"),
                    AlternateContactPersonID = table.Column<int>(type: "int", nullable: false, comment: "Alternate contact"),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: true, comment: "Standard delivery method for stock items received from this supplier"),
                    DeliveryCityID = table.Column<int>(type: "int", nullable: false, comment: "ID of the delivery city for this address"),
                    PostalCityID = table.Column<int>(type: "int", nullable: false, comment: "ID of the mailing city for this address"),
                    SupplierReference = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Supplier reference for our organization (might be our account number at the supplier)"),
                    BankAccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Supplier's bank account name (ie name on the account)"),
                    BankAccountBranch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Supplier's bank branch"),
                    BankAccountCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Supplier's bank account code (usually a numeric reference for the bank branch)"),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Supplier's bank account number"),
                    BankInternationalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Supplier's bank's international code (such as a SWIFT code)"),
                    PaymentDays = table.Column<int>(type: "int", nullable: false, comment: "Number of days for payment of an invoice (ie payment terms)"),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Internal comments (not exposed outside organization)"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Phone number"),
                    FaxNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Fax number"),
                    WebsiteURL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "URL for the website for this supplier"),
                    DeliveryAddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First delivery address line for the supplier"),
                    DeliveryAddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second delivery address line for the supplier"),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Delivery postal code for the supplier"),
                    DeliveryLocation = table.Column<Geometry>(type: "geography", nullable: true, comment: "Geographic location for the supplier's office/warehouse"),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First postal address line for the supplier"),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second postal address line for the supplier"),
                    PostalPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Postal code for the supplier when sending by mail"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_AlternateContactPersonID_Application_People",
                        column: x => x.AlternateContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_DeliveryCityID_Application_Cities",
                        column: x => x.DeliveryCityID,
                        principalSchema: "Application",
                        principalTable: "Cities",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_DeliveryMethodID_Application_DeliveryMethods",
                        column: x => x.DeliveryMethodID,
                        principalSchema: "Application",
                        principalTable: "DeliveryMethods",
                        principalColumn: "DeliveryMethodID");
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_PostalCityID_Application_Cities",
                        column: x => x.PostalCityID,
                        principalSchema: "Application",
                        principalTable: "Cities",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_PrimaryContactPersonID_Application_People",
                        column: x => x.PrimaryContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_Suppliers_SupplierCategoryID_Purchasing_SupplierCategories",
                        column: x => x.SupplierCategoryID,
                        principalSchema: "Purchasing",
                        principalTable: "SupplierCategories",
                        principalColumn: "SupplierCategoryID");
                },
                comment: "Main entity table for suppliers (organizations)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Suppliers_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Purchasing")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                schema: "Application",
                columns: table => new
                {
                    SystemParameterID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SystemParameterID])", comment: "Numeric ID used for row holding system parameters"),
                    DeliveryAddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First address line for the company"),
                    DeliveryAddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second address line for the company"),
                    DeliveryCityID = table.Column<int>(type: "int", nullable: false, comment: "ID of the city for this address"),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Postal code for the company"),
                    DeliveryLocation = table.Column<Geometry>(type: "geography", nullable: false, comment: "Geographic location for the company office"),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First postal address line for the company"),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second postaladdress line for the company"),
                    PostalCityID = table.Column<int>(type: "int", nullable: false, comment: "ID of the city for this postaladdress"),
                    PostalPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Postal code for the company when sending via mail"),
                    ApplicationSettings = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "JSON-structured application settings"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.SystemParameterID);
                    table.ForeignKey(
                        name: "FK_Application_SystemParameters_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Application_SystemParameters_DeliveryCityID_Application_Cities",
                        column: x => x.DeliveryCityID,
                        principalSchema: "Application",
                        principalTable: "Cities",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Application_SystemParameters_PostalCityID_Application_Cities",
                        column: x => x.PostalCityID,
                        principalSchema: "Application",
                        principalTable: "Cities",
                        principalColumn: "CityID");
                },
                comment: "Any configurable parameters for the whole system");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Sales",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[OrderID])", comment: "Numeric ID used for reference to an order within the database"),
                    CustomerID = table.Column<int>(type: "int", nullable: false, comment: "Customer for this order"),
                    SalespersonPersonID = table.Column<int>(type: "int", nullable: false, comment: "Salesperson for this order"),
                    PickedByPersonID = table.Column<int>(type: "int", nullable: true, comment: "Person who picked this shipment"),
                    ContactPersonID = table.Column<int>(type: "int", nullable: false, comment: "Customer contact for this order"),
                    BackorderOrderID = table.Column<int>(type: "int", nullable: true, comment: "If this order is a backorder, this column holds the original order number"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date that this order was raised"),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Expected delivery date"),
                    CustomerPurchaseOrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Purchase Order Number received from customer"),
                    IsUndersupplyBackordered = table.Column<bool>(type: "bit", nullable: false, comment: "If items cannot be supplied are they backordered?"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any comments related to this order (sent to customer)"),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "	Any comments related to order delivery (sent to customer)"),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any internal comments related to this order (not sent to the customer)"),
                    PickingCompletedWhen = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "When was picking of the entire order completed?"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Sales_Orders_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Orders_BackorderOrderID_Sales_Orders",
                        column: x => x.BackorderOrderID,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Sales_Orders_ContactPersonID_Application_People",
                        column: x => x.ContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Orders_CustomerID_Sales_Customers",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Sales_Orders_PickedByPersonID_Application_People",
                        column: x => x.PickedByPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Orders_SalespersonPersonID_Application_People",
                        column: x => x.SalespersonPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Detail of customer orders");

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PurchaseOrderID])", comment: "Numeric ID used for reference to a purchase order within the database"),
                    SupplierID = table.Column<int>(type: "int", nullable: false, comment: "Supplier for this purchase order"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date that this purchase order was raised"),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false, comment: "How this purchase order should be delivered"),
                    ContactPersonID = table.Column<int>(type: "int", nullable: false, comment: "The person who is the primary contact for this purchase order"),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "date", nullable: true, comment: "Expected delivery date for this purchase order"),
                    SupplierReference = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Supplier reference for our organization (might be our account number at the supplier)"),
                    IsOrderFinalized = table.Column<bool>(type: "bit", nullable: false, comment: "Is this purchase order now considered finalized?"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any comments related this purchase order (comments sent to the supplier)"),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any internal comments related this purchase order (comments for internal reference only and not sent to the supplier)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrders_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrders_ContactPersonID_Application_People",
                        column: x => x.ContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrders_DeliveryMethodID_Application_DeliveryMethods",
                        column: x => x.DeliveryMethodID,
                        principalSchema: "Application",
                        principalTable: "DeliveryMethods",
                        principalColumn: "DeliveryMethodID");
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrders_SupplierID_Purchasing_Suppliers",
                        column: x => x.SupplierID,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                },
                comment: "Details of supplier purchase orders");

            migrationBuilder.CreateTable(
                name: "StockItems",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StockItemID])", comment: "Numeric ID used for reference to a stock item within the database"),
                    StockItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Full name of a stock item (but not a full description)"),
                    SupplierID = table.Column<int>(type: "int", nullable: false, comment: "Usual supplier for this stock item"),
                    ColorID = table.Column<int>(type: "int", nullable: true, comment: "Color (optional) for this stock item"),
                    UnitPackageID = table.Column<int>(type: "int", nullable: false, comment: "Usual package for selling units of this stock item"),
                    OuterPackageID = table.Column<int>(type: "int", nullable: false, comment: "Usual package for selling outers of this stock item (ie cartons, boxes, etc.)"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Brand for the stock item (if the item is branded)"),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Size of this item (eg: 100mm)"),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: false, comment: "Number of days typically taken from order to receipt of this stock item"),
                    QuantityPerOuter = table.Column<int>(type: "int", nullable: false, comment: "Quantity of the stock item in an outer package"),
                    IsChillerStock = table.Column<bool>(type: "bit", nullable: false, comment: "Does this stock item need to be in a chiller?"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Barcode for this stock item"),
                    TaxRate = table.Column<decimal>(type: "decimal(18,3)", nullable: false, comment: "Tax rate to be applied"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Selling price (ex-tax) for one unit of this product"),
                    RecommendedRetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Recommended retail price for this stock item"),
                    TypicalWeightPerUnit = table.Column<decimal>(type: "decimal(18,3)", nullable: false, comment: "Typical weight for one unit of this product (packaged)"),
                    MarketingComments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Marketing comments for this stock item (shared outside the organization)"),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Internal comments (not exposed outside organization)"),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "Photo of the product"),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Custom fields added by system users"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "(json_query([CustomFields],N'$.Tags'))", stored: false, comment: "Advertising tags associated with this stock item (JSON array retrieved from CustomFields)"),
                    SearchDetails = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "(concat([StockItemName],N' ',[MarketingComments]))", stored: false, comment: "Combination of columns used by full text search"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.StockItemID);
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItems_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItems_ColorID_Warehouse_Colors",
                        column: x => x.ColorID,
                        principalSchema: "Warehouse",
                        principalTable: "Colors",
                        principalColumn: "ColorID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItems_OuterPackageID_Warehouse_PackageTypes",
                        column: x => x.OuterPackageID,
                        principalSchema: "Warehouse",
                        principalTable: "PackageTypes",
                        principalColumn: "PackageTypeID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItems_SupplierID_Purchasing_Suppliers",
                        column: x => x.SupplierID,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItems_UnitPackageID_Warehouse_PackageTypes",
                        column: x => x.UnitPackageID,
                        principalSchema: "Warehouse",
                        principalTable: "PackageTypes",
                        principalColumn: "PackageTypeID");
                },
                comment: "Main entity table for stock items")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "StockItems_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Sales",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[InvoiceID])", comment: "Numeric ID used for reference to an invoice within the database"),
                    CustomerID = table.Column<int>(type: "int", nullable: false, comment: "Customer for this invoice"),
                    BillToCustomerID = table.Column<int>(type: "int", nullable: false, comment: "Bill to customer for this invoice (invoices might be billed to a head office)"),
                    OrderID = table.Column<int>(type: "int", nullable: true, comment: "Sales order (if any) for this invoice"),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false, comment: "How these stock items are beign delivered"),
                    ContactPersonID = table.Column<int>(type: "int", nullable: false, comment: "Customer contact for this invoice"),
                    AccountsPersonID = table.Column<int>(type: "int", nullable: false, comment: "Customer accounts contact for this invoice"),
                    SalespersonPersonID = table.Column<int>(type: "int", nullable: false, comment: "Salesperson for this invoice"),
                    PackedByPersonID = table.Column<int>(type: "int", nullable: false, comment: "Person who packed this shipment (or checked the packing)"),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date that this invoice was raised"),
                    CustomerPurchaseOrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Purchase Order Number received from customer"),
                    IsCreditNote = table.Column<bool>(type: "bit", nullable: false, comment: "Is this a credit note (rather than an invoice)"),
                    CreditNoteReason = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Reason that this credit note needed to be generated (if applicable)"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any comments related to this invoice (sent to customer)"),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any comments related to delivery (sent to customer)"),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Any internal comments related to this invoice (not sent to the customer)"),
                    TotalDryItems = table.Column<int>(type: "int", nullable: false, comment: "Total number of dry packages (information for the delivery driver)"),
                    TotalChillerItems = table.Column<int>(type: "int", nullable: false, comment: "Total number of chiller packages (information for the delivery driver)"),
                    DeliveryRun = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Delivery run for this shipment"),
                    RunPosition = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Position in the delivery run for this shipment"),
                    ReturnedDeliveryData = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "JSON-structured data returned from delivery devices for deliveries made directly by the organization"),
                    ConfirmedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true, computedColumnSql: "(TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126)))", stored: false, comment: "Confirmed delivery date and time promoted from JSON delivery data"),
                    ConfirmedReceivedBy = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, computedColumnSql: "(json_value([ReturnedDeliveryData],N'$.ReceivedBy'))", stored: false, comment: "Confirmed receiver promoted from JSON delivery data"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_AccountsPersonID_Application_People",
                        column: x => x.AccountsPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_BillToCustomerID_Sales_Customers",
                        column: x => x.BillToCustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_ContactPersonID_Application_People",
                        column: x => x.ContactPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_CustomerID_Sales_Customers",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_DeliveryMethodID_Application_DeliveryMethods",
                        column: x => x.DeliveryMethodID,
                        principalSchema: "Application",
                        principalTable: "DeliveryMethods",
                        principalColumn: "DeliveryMethodID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_OrderID_Sales_Orders",
                        column: x => x.OrderID,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_PackedByPersonID_Application_People",
                        column: x => x.PackedByPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_Invoices_SalespersonPersonID_Application_People",
                        column: x => x.SalespersonPersonID,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                },
                comment: "Details of customer invoices");

            migrationBuilder.CreateTable(
                name: "SupplierTransactions",
                schema: "Purchasing",
                columns: table => new
                {
                    SupplierTransactionID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionID])", comment: "Numeric ID used to refer to a supplier transaction within the database"),
                    SupplierID = table.Column<int>(type: "int", nullable: false, comment: "Supplier for this transaction"),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false, comment: "Type of transaction"),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true, comment: "ID of an purchase order (for transactions associated with a purchase order)"),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: true, comment: "ID of a payment method (for transactions involving payments)"),
                    SupplierInvoiceNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Invoice number for an invoice received from the supplier"),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date for the transaction"),
                    AmountExcludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Transaction amount (excluding tax)"),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Tax amount calculated"),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Transaction amount (including tax)"),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount still outstanding for this transaction"),
                    FinalizationDate = table.Column<DateTime>(type: "date", nullable: true, comment: "Date that this transaction was finalized (if it has been)"),
                    IsFinalized = table.Column<bool>(type: "bit", nullable: true, computedColumnSql: "(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", stored: true, comment: "Is this transaction finalized (invoices, credits and payments have been matched)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasing_SupplierTransactions", x => x.SupplierTransactionID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Purchasing_SupplierTransactions_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_SupplierTransactions_PaymentMethodID_Application_PaymentMethods",
                        column: x => x.PaymentMethodID,
                        principalSchema: "Application",
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodID");
                    table.ForeignKey(
                        name: "FK_Purchasing_SupplierTransactions_PurchaseOrderID_Purchasing_PurchaseOrders",
                        column: x => x.PurchaseOrderID,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderID");
                    table.ForeignKey(
                        name: "FK_Purchasing_SupplierTransactions_SupplierID_Purchasing_Suppliers",
                        column: x => x.SupplierID,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                    table.ForeignKey(
                        name: "FK_Purchasing_SupplierTransactions_TransactionTypeID_Application_TransactionTypes",
                        column: x => x.TransactionTypeID,
                        principalSchema: "Application",
                        principalTable: "TransactionTypes",
                        principalColumn: "TransactionTypeID");
                },
                comment: "All financial transactions that are supplier-related");

            migrationBuilder.CreateTable(
                name: "OrderLines",
                schema: "Sales",
                columns: table => new
                {
                    OrderLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[OrderLineID])", comment: "Numeric ID used for reference to a line on an Order within the database"),
                    OrderID = table.Column<int>(type: "int", nullable: false, comment: "Order that this line is associated with"),
                    StockItemID = table.Column<int>(type: "int", nullable: false, comment: "Stock item for this order line (FK not indexed as separate index exists)"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Description of the item supplied (Usually the stock item name but can be overridden)"),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false, comment: "Type of package to be supplied"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity to be supplied"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Unit price to be charged"),
                    TaxRate = table.Column<decimal>(type: "decimal(18,3)", nullable: false, comment: "Tax rate to be applied"),
                    PickedQuantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity picked from stock"),
                    PickingCompletedWhen = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "When was picking of this line completed?"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineID);
                    table.ForeignKey(
                        name: "FK_Sales_OrderLines_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_OrderLines_OrderID_Sales_Orders",
                        column: x => x.OrderID,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Sales_OrderLines_PackageTypeID_Warehouse_PackageTypes",
                        column: x => x.PackageTypeID,
                        principalSchema: "Warehouse",
                        principalTable: "PackageTypes",
                        principalColumn: "PackageTypeID");
                    table.ForeignKey(
                        name: "FK_Sales_OrderLines_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                },
                comment: "Detail lines from customer orders");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLines",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])", comment: "Numeric ID used for reference to a line on a purchase order within the database"),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false, comment: "Purchase order that this line is associated with"),
                    StockItemID = table.Column<int>(type: "int", nullable: false, comment: "Stock item for this purchase order line"),
                    OrderedOuters = table.Column<int>(type: "int", nullable: false, comment: "Quantity of the stock item that is ordered"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Description of the item to be supplied (Often the stock item name but could be supplier description)"),
                    ReceivedOuters = table.Column<int>(type: "int", nullable: false, comment: "Total quantity of the stock item that has been received so far"),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false, comment: "Type of package received"),
                    ExpectedUnitPricePerOuter = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "The unit price that we expect to be charged"),
                    LastReceiptDate = table.Column<DateTime>(type: "date", nullable: true, comment: "The last date on which this stock item was received for this purchase order"),
                    IsOrderLineFinalized = table.Column<bool>(type: "bit", nullable: false, comment: "Is this purchase order line now considered finalized? (Receipted quantities and weights are often not precise)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLines", x => x.PurchaseOrderLineID);
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrderLines_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrderLines_PackageTypeID_Warehouse_PackageTypes",
                        column: x => x.PackageTypeID,
                        principalSchema: "Warehouse",
                        principalTable: "PackageTypes",
                        principalColumn: "PackageTypeID");
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrderLines_PurchaseOrderID_Purchasing_PurchaseOrders",
                        column: x => x.PurchaseOrderID,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderID");
                    table.ForeignKey(
                        name: "FK_Purchasing_PurchaseOrderLines_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                },
                comment: "Detail lines from supplier purchase orders");

            migrationBuilder.CreateTable(
                name: "SpecialDeals",
                schema: "Sales",
                columns: table => new
                {
                    SpecialDealID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SpecialDealID])", comment: "ID (sequence based) for a special deal"),
                    StockItemID = table.Column<int>(type: "int", nullable: true, comment: "Stock item that the deal applies to (if NULL, then only discounts are permitted not unit prices)"),
                    CustomerID = table.Column<int>(type: "int", nullable: true, comment: "ID of the customer that the special pricing applies to (if NULL then all customers)"),
                    BuyingGroupID = table.Column<int>(type: "int", nullable: true, comment: "ID of the buying group that the special pricing applies to (optional)"),
                    CustomerCategoryID = table.Column<int>(type: "int", nullable: true, comment: "ID of the customer category that the special pricing applies to (optional)"),
                    StockGroupID = table.Column<int>(type: "int", nullable: true, comment: "ID of the stock group that the special pricing applies to (optional)"),
                    DealDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Description of the special deal"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date that the special pricing starts from"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date that the special pricing ends on"),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Discount per unit to be applied to sale price (optional)"),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,3)", nullable: true, comment: "	Discount percentage per unit to be applied to sale price (optional)"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Special price per unit to be applied instead of sale price (optional)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDeals", x => x.SpecialDealID);
                    table.ForeignKey(
                        name: "FK_Sales_SpecialDeals_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_SpecialDeals_BuyingGroupID_Sales_BuyingGroups",
                        column: x => x.BuyingGroupID,
                        principalSchema: "Sales",
                        principalTable: "BuyingGroups",
                        principalColumn: "BuyingGroupID");
                    table.ForeignKey(
                        name: "FK_Sales_SpecialDeals_CustomerCategoryID_Sales_CustomerCategories",
                        column: x => x.CustomerCategoryID,
                        principalSchema: "Sales",
                        principalTable: "CustomerCategories",
                        principalColumn: "CustomerCategoryID");
                    table.ForeignKey(
                        name: "FK_Sales_SpecialDeals_CustomerID_Sales_Customers",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Sales_SpecialDeals_StockGroupID_Warehouse_StockGroups",
                        column: x => x.StockGroupID,
                        principalSchema: "Warehouse",
                        principalTable: "StockGroups",
                        principalColumn: "StockGroupID");
                    table.ForeignKey(
                        name: "FK_Sales_SpecialDeals_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                },
                comment: "Special pricing (can include fixed prices, discount $ or discount %)");

            migrationBuilder.CreateTable(
                name: "StockItemHoldings",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false, comment: "ID of the stock item that this holding relates to (this table holds non-temporal columns for stock)"),
                    QuantityOnHand = table.Column<int>(type: "int", nullable: false, comment: "Quantity currently on hand (if tracked)"),
                    BinLocation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Bin location (ie location of this stock item within the depot)"),
                    LastStocktakeQuantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity at last stocktake (if tracked)"),
                    LastCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Unit cost price the last time this stock item was purchased"),
                    ReorderLevel = table.Column<int>(type: "int", nullable: false, comment: "Quantity below which reordering should take place"),
                    TargetStockLevel = table.Column<int>(type: "int", nullable: false, comment: "Typical quantity ordered"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_StockItemHoldings", x => x.StockItemID);
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemHoldings_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "PKFK_Warehouse_StockItemHoldings_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                },
                comment: "Non-temporal attributes for stock items");

            migrationBuilder.CreateTable(
                name: "StockItemStockGroups",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemStockGroupID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StockItemStockGroupID])", comment: "Internal reference for this linking row"),
                    StockItemID = table.Column<int>(type: "int", nullable: false, comment: "Stock item assigned to this stock group (FK indexed via unique constraint)"),
                    StockGroupID = table.Column<int>(type: "int", nullable: false, comment: "StockGroup assigned to this stock item (FK indexed via unique constraint)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItemStockGroups", x => x.StockItemStockGroupID);
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemStockGroups_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemStockGroups_StockGroupID_Warehouse_StockGroups",
                        column: x => x.StockGroupID,
                        principalSchema: "Warehouse",
                        principalTable: "StockGroups",
                        principalColumn: "StockGroupID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemStockGroups_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                },
                comment: "Which stock items are in which stock groups");

            migrationBuilder.CreateTable(
                name: "CustomerTransactions",
                schema: "Sales",
                columns: table => new
                {
                    CustomerTransactionID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionID])", comment: "Numeric ID used to refer to a customer transaction within the database"),
                    CustomerID = table.Column<int>(type: "int", nullable: false, comment: "Customer for this transaction"),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false, comment: "Type of transaction"),
                    InvoiceID = table.Column<int>(type: "int", nullable: true, comment: "ID of an invoice (for transactions associated with an invoice)"),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: true, comment: "ID of a payment method (for transactions involving payments)"),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Date for the transaction"),
                    AmountExcludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Transaction amount (excluding tax)"),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Tax amount calculated"),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Transaction amount (including tax)"),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount still outstanding for this transaction"),
                    FinalizationDate = table.Column<DateTime>(type: "date", nullable: true, comment: "Date that this transaction was finalized (if it has been)"),
                    IsFinalized = table.Column<bool>(type: "bit", nullable: true, computedColumnSql: "(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", stored: true, comment: "Is this transaction finalized (invoices, credits and payments have been matched)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_CustomerTransactions", x => x.CustomerTransactionID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Sales_CustomerTransactions_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_CustomerTransactions_CustomerID_Sales_Customers",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Sales_CustomerTransactions_InvoiceID_Sales_Invoices",
                        column: x => x.InvoiceID,
                        principalSchema: "Sales",
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID");
                    table.ForeignKey(
                        name: "FK_Sales_CustomerTransactions_PaymentMethodID_Application_PaymentMethods",
                        column: x => x.PaymentMethodID,
                        principalSchema: "Application",
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodID");
                    table.ForeignKey(
                        name: "FK_Sales_CustomerTransactions_TransactionTypeID_Application_TransactionTypes",
                        column: x => x.TransactionTypeID,
                        principalSchema: "Application",
                        principalTable: "TransactionTypes",
                        principalColumn: "TransactionTypeID");
                },
                comment: "All financial transactions that are customer-related");

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                schema: "Sales",
                columns: table => new
                {
                    InvoiceLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[InvoiceLineID])", comment: "Numeric ID used for reference to a line on an invoice within the database"),
                    InvoiceID = table.Column<int>(type: "int", nullable: false, comment: "Invoice that this line is associated with"),
                    StockItemID = table.Column<int>(type: "int", nullable: false, comment: "Stock item for this invoice line"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Description of the item supplied (Usually the stock item name but can be overridden)"),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false, comment: "Type of package supplied"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity supplied"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Unit price charged"),
                    TaxRate = table.Column<decimal>(type: "decimal(18,3)", nullable: false, comment: "Tax rate to be applied"),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Tax amount calculated"),
                    LineProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Profit made on this line item at current cost price"),
                    ExtendedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Extended line price charged"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.InvoiceLineID);
                    table.ForeignKey(
                        name: "FK_Sales_InvoiceLines_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Sales_InvoiceLines_InvoiceID_Sales_Invoices",
                        column: x => x.InvoiceID,
                        principalSchema: "Sales",
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID");
                    table.ForeignKey(
                        name: "FK_Sales_InvoiceLines_PackageTypeID_Warehouse_PackageTypes",
                        column: x => x.PackageTypeID,
                        principalSchema: "Warehouse",
                        principalTable: "PackageTypes",
                        principalColumn: "PackageTypeID");
                    table.ForeignKey(
                        name: "FK_Sales_InvoiceLines_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                },
                comment: "Detail lines from customer invoices");

            migrationBuilder.CreateTable(
                name: "StockItemTransactions",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemTransactionID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionID])", comment: "Numeric ID used to refer to a stock item transaction within the database"),
                    StockItemID = table.Column<int>(type: "int", nullable: false, comment: "StockItem for this transaction"),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false, comment: "Type of transaction"),
                    CustomerID = table.Column<int>(type: "int", nullable: true, comment: "Customer for this transaction (if applicable)"),
                    InvoiceID = table.Column<int>(type: "int", nullable: true, comment: "ID of an invoice (for transactions associated with an invoice)"),
                    SupplierID = table.Column<int>(type: "int", nullable: true, comment: "Supplier for this stock transaction (if applicable)"),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true, comment: "ID of an purchase order (for transactions associated with a purchase order)"),
                    TransactionOccurredWhen = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the transaction occurred"),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false, comment: "Quantity of stock movement (positive is incoming stock, negative is outgoing)"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    LastEditedWhen = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_StockItemTransactions", x => x.StockItemTransactionID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_Application_People",
                        column: x => x.LastEditedBy,
                        principalSchema: "Application",
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_CustomerID_Sales_Customers",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_InvoiceID_Sales_Invoices",
                        column: x => x.InvoiceID,
                        principalSchema: "Sales",
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_PurchaseOrderID_Purchasing_PurchaseOrders",
                        column: x => x.PurchaseOrderID,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_StockItemID_Warehouse_StockItems",
                        column: x => x.StockItemID,
                        principalSchema: "Warehouse",
                        principalTable: "StockItems",
                        principalColumn: "StockItemID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_SupplierID_Purchasing_Suppliers",
                        column: x => x.SupplierID,
                        principalSchema: "Purchasing",
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                    table.ForeignKey(
                        name: "FK_Warehouse_StockItemTransactions_TransactionTypeID_Application_TransactionTypes",
                        column: x => x.TransactionTypeID,
                        principalSchema: "Application",
                        principalTable: "TransactionTypes",
                        principalColumn: "TransactionTypeID");
                },
                comment: "Transactions covering all movements of all stock items");

            migrationBuilder.CreateIndex(
                name: "IX_BuyingGroups_LastEditedBy",
                schema: "Sales",
                table: "BuyingGroups",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Sales_BuyingGroups_BuyingGroupName",
                schema: "Sales",
                table: "BuyingGroups",
                column: "BuyingGroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Application_Cities_StateProvinceID",
                schema: "Application",
                table: "Cities",
                column: "StateProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LastEditedBy",
                schema: "Application",
                table: "Cities",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_ColdRoomTemperatures_ColdRoomSensorNumber",
                schema: "Warehouse",
                table: "ColdRoomTemperatures",
                column: "ColdRoomSensorNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_LastEditedBy",
                schema: "Warehouse",
                table: "Colors",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Warehouse_Colors_ColorName",
                schema: "Warehouse",
                table: "Colors",
                column: "ColorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LastEditedBy",
                schema: "Application",
                table: "Countries",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Application_Countries_CountryName",
                schema: "Application",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Application_Countries_FormalName",
                schema: "Application",
                table: "Countries",
                column: "FormalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCategories_LastEditedBy",
                schema: "Sales",
                table: "CustomerCategories",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Sales_CustomerCategories_CustomerCategoryName",
                schema: "Sales",
                table: "CustomerCategories",
                column: "CustomerCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_AlternateContactPersonID",
                schema: "Sales",
                table: "Customers",
                column: "AlternateContactPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_BuyingGroupID",
                schema: "Sales",
                table: "Customers",
                column: "BuyingGroupID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_CustomerCategoryID",
                schema: "Sales",
                table: "Customers",
                column: "CustomerCategoryID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_DeliveryCityID",
                schema: "Sales",
                table: "Customers",
                column: "DeliveryCityID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_DeliveryMethodID",
                schema: "Sales",
                table: "Customers",
                column: "DeliveryMethodID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_PostalCityID",
                schema: "Sales",
                table: "Customers",
                column: "PostalCityID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Customers_PrimaryContactPersonID",
                schema: "Sales",
                table: "Customers",
                column: "PrimaryContactPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillToCustomerID",
                schema: "Sales",
                table: "Customers",
                column: "BillToCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LastEditedBy",
                schema: "Sales",
                table: "Customers",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Customers_Perf_20160301_06",
                schema: "Sales",
                table: "Customers",
                columns: new[] { "IsOnCreditHold", "CustomerID", "BillToCustomerID" });

            migrationBuilder.CreateIndex(
                name: "UQ_Sales_Customers_CustomerName",
                schema: "Sales",
                table: "Customers",
                column: "CustomerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CX_Sales_CustomerTransactions",
                schema: "Sales",
                table: "CustomerTransactions",
                column: "TransactionDate")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "FK_Sales_CustomerTransactions_CustomerID",
                schema: "Sales",
                table: "CustomerTransactions",
                columns: new[] { "TransactionDate", "CustomerID" });

            migrationBuilder.CreateIndex(
                name: "FK_Sales_CustomerTransactions_InvoiceID",
                schema: "Sales",
                table: "CustomerTransactions",
                columns: new[] { "TransactionDate", "InvoiceID" });

            migrationBuilder.CreateIndex(
                name: "FK_Sales_CustomerTransactions_PaymentMethodID",
                schema: "Sales",
                table: "CustomerTransactions",
                columns: new[] { "TransactionDate", "PaymentMethodID" });

            migrationBuilder.CreateIndex(
                name: "FK_Sales_CustomerTransactions_TransactionTypeID",
                schema: "Sales",
                table: "CustomerTransactions",
                columns: new[] { "TransactionDate", "TransactionTypeID" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_CustomerID",
                schema: "Sales",
                table: "CustomerTransactions",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_InvoiceID",
                schema: "Sales",
                table: "CustomerTransactions",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_LastEditedBy",
                schema: "Sales",
                table: "CustomerTransactions",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_PaymentMethodID",
                schema: "Sales",
                table: "CustomerTransactions",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_TransactionTypeID",
                schema: "Sales",
                table: "CustomerTransactions",
                column: "TransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerTransactions_IsFinalized",
                schema: "Sales",
                table: "CustomerTransactions",
                columns: new[] { "TransactionDate", "IsFinalized" });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethods_LastEditedBy",
                schema: "Application",
                table: "DeliveryMethods",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Application_DeliveryMethods_DeliveryMethodName",
                schema: "Application",
                table: "DeliveryMethods",
                column: "DeliveryMethodName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Sales_InvoiceLines_InvoiceID",
                schema: "Sales",
                table: "InvoiceLines",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_InvoiceLines_PackageTypeID",
                schema: "Sales",
                table: "InvoiceLines",
                column: "PackageTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_InvoiceLines_StockItemID",
                schema: "Sales",
                table: "InvoiceLines",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_LastEditedBy",
                schema: "Sales",
                table: "InvoiceLines",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_AccountsPersonID",
                schema: "Sales",
                table: "Invoices",
                column: "AccountsPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_BillToCustomerID",
                schema: "Sales",
                table: "Invoices",
                column: "BillToCustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_ContactPersonID",
                schema: "Sales",
                table: "Invoices",
                column: "ContactPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_CustomerID",
                schema: "Sales",
                table: "Invoices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_DeliveryMethodID",
                schema: "Sales",
                table: "Invoices",
                column: "DeliveryMethodID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_OrderID",
                schema: "Sales",
                table: "Invoices",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_PackedByPersonID",
                schema: "Sales",
                table: "Invoices",
                column: "PackedByPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Invoices_SalespersonPersonID",
                schema: "Sales",
                table: "Invoices",
                column: "SalespersonPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LastEditedBy",
                schema: "Sales",
                table: "Invoices",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Invoices_ConfirmedDeliveryTime",
                schema: "Sales",
                table: "Invoices",
                column: "ConfirmedDeliveryTime");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_OrderLines_OrderID",
                schema: "Sales",
                table: "OrderLines",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_OrderLines_PackageTypeID",
                schema: "Sales",
                table: "OrderLines",
                column: "PackageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LastEditedBy",
                schema: "Sales",
                table: "OrderLines",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OrderLines_AllocatedStockItems",
                schema: "Sales",
                table: "OrderLines",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OrderLines_Perf_20160301_01",
                schema: "Sales",
                table: "OrderLines",
                columns: new[] { "PickingCompletedWhen", "OrderID", "OrderLineID" });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OrderLines_Perf_20160301_02",
                schema: "Sales",
                table: "OrderLines",
                columns: new[] { "StockItemID", "PickingCompletedWhen" });

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Orders_ContactPersonID",
                schema: "Sales",
                table: "Orders",
                column: "ContactPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Orders_CustomerID",
                schema: "Sales",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Orders_PickedByPersonID",
                schema: "Sales",
                table: "Orders",
                column: "PickedByPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_Orders_SalespersonPersonID",
                schema: "Sales",
                table: "Orders",
                column: "SalespersonPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BackorderOrderID",
                schema: "Sales",
                table: "Orders",
                column: "BackorderOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastEditedBy",
                schema: "Sales",
                table: "Orders",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTypes_LastEditedBy",
                schema: "Warehouse",
                table: "PackageTypes",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Warehouse_PackageTypes_PackageTypeName",
                schema: "Warehouse",
                table: "PackageTypes",
                column: "PackageTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_LastEditedBy",
                schema: "Application",
                table: "PaymentMethods",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Application_PaymentMethods_PaymentMethodName",
                schema: "Application",
                table: "PaymentMethods",
                column: "PaymentMethodName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_People_FullName",
                schema: "Application",
                table: "People",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Application_People_IsEmployee",
                schema: "Application",
                table: "People",
                column: "IsEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Application_People_IsSalesperson",
                schema: "Application",
                table: "People",
                column: "IsSalesperson");

            migrationBuilder.CreateIndex(
                name: "IX_Application_People_Perf_20160301_05",
                schema: "Application",
                table: "People",
                columns: new[] { "IsPermittedToLogon", "PersonID" });

            migrationBuilder.CreateIndex(
                name: "IX_People_LastEditedBy",
                schema: "Application",
                table: "People",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_PurchaseOrderLines_PackageTypeID",
                schema: "Purchasing",
                table: "PurchaseOrderLines",
                column: "PackageTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_PurchaseOrderLines_PurchaseOrderID",
                schema: "Purchasing",
                table: "PurchaseOrderLines",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_PurchaseOrderLines_StockItemID",
                schema: "Purchasing",
                table: "PurchaseOrderLines",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLines_LastEditedBy",
                schema: "Purchasing",
                table: "PurchaseOrderLines",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasing_PurchaseOrderLines_Perf_20160301_4",
                schema: "Purchasing",
                table: "PurchaseOrderLines",
                columns: new[] { "IsOrderLineFinalized", "StockItemID" });

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_PurchaseOrders_ContactPersonID",
                schema: "Purchasing",
                table: "PurchaseOrders",
                column: "ContactPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_PurchaseOrders_DeliveryMethodID",
                schema: "Purchasing",
                table: "PurchaseOrders",
                column: "DeliveryMethodID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_PurchaseOrders_SupplierID",
                schema: "Purchasing",
                table: "PurchaseOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_LastEditedBy",
                schema: "Purchasing",
                table: "PurchaseOrders",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_SpecialDeals_BuyingGroupID",
                schema: "Sales",
                table: "SpecialDeals",
                column: "BuyingGroupID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_SpecialDeals_CustomerCategoryID",
                schema: "Sales",
                table: "SpecialDeals",
                column: "CustomerCategoryID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_SpecialDeals_CustomerID",
                schema: "Sales",
                table: "SpecialDeals",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_SpecialDeals_StockGroupID",
                schema: "Sales",
                table: "SpecialDeals",
                column: "StockGroupID");

            migrationBuilder.CreateIndex(
                name: "FK_Sales_SpecialDeals_StockItemID",
                schema: "Sales",
                table: "SpecialDeals",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDeals_LastEditedBy",
                schema: "Sales",
                table: "SpecialDeals",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "FK_Application_StateProvinces_CountryID",
                schema: "Application",
                table: "StateProvinces",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_StateProvinces_SalesTerritory",
                schema: "Application",
                table: "StateProvinces",
                column: "SalesTerritory");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvinces_LastEditedBy",
                schema: "Application",
                table: "StateProvinces",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Application_StateProvinces_StateProvinceName",
                schema: "Application",
                table: "StateProvinces",
                column: "StateProvinceName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockGroups_LastEditedBy",
                schema: "Warehouse",
                table: "StockGroups",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Warehouse_StockGroups_StockGroupName",
                schema: "Warehouse",
                table: "StockGroups",
                column: "StockGroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItemHoldings_LastEditedBy",
                schema: "Warehouse",
                table: "StockItemHoldings",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItems_ColorID",
                schema: "Warehouse",
                table: "StockItems",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItems_OuterPackageID",
                schema: "Warehouse",
                table: "StockItems",
                column: "OuterPackageID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItems_SupplierID",
                schema: "Warehouse",
                table: "StockItems",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItems_UnitPackageID",
                schema: "Warehouse",
                table: "StockItems",
                column: "UnitPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_LastEditedBy",
                schema: "Warehouse",
                table: "StockItems",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Warehouse_StockItems_StockItemName",
                schema: "Warehouse",
                table: "StockItems",
                column: "StockItemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItemStockGroups_LastEditedBy",
                schema: "Warehouse",
                table: "StockItemStockGroups",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_StockItemStockGroups_StockGroupID_Lookup",
                schema: "Warehouse",
                table: "StockItemStockGroups",
                columns: new[] { "StockGroupID", "StockItemID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_StockItemStockGroups_StockItemID_Lookup",
                schema: "Warehouse",
                table: "StockItemStockGroups",
                columns: new[] { "StockItemID", "StockGroupID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItemTransactions_CustomerID",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItemTransactions_InvoiceID",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItemTransactions_PurchaseOrderID",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItemTransactions_StockItemID",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItemTransactions_SupplierID",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "FK_Warehouse_StockItemTransactions_TransactionTypeID",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "TransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemTransactions_LastEditedBy",
                schema: "Warehouse",
                table: "StockItemTransactions",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierCategories_LastEditedBy",
                schema: "Purchasing",
                table: "SupplierCategories",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Purchasing_SupplierCategories_SupplierCategoryName",
                schema: "Purchasing",
                table: "SupplierCategories",
                column: "SupplierCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_Suppliers_AlternateContactPersonID",
                schema: "Purchasing",
                table: "Suppliers",
                column: "AlternateContactPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_Suppliers_DeliveryCityID",
                schema: "Purchasing",
                table: "Suppliers",
                column: "DeliveryCityID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_Suppliers_DeliveryMethodID",
                schema: "Purchasing",
                table: "Suppliers",
                column: "DeliveryMethodID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_Suppliers_PostalCityID",
                schema: "Purchasing",
                table: "Suppliers",
                column: "PostalCityID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_Suppliers_PrimaryContactPersonID",
                schema: "Purchasing",
                table: "Suppliers",
                column: "PrimaryContactPersonID");

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_Suppliers_SupplierCategoryID",
                schema: "Purchasing",
                table: "Suppliers",
                column: "SupplierCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LastEditedBy",
                schema: "Purchasing",
                table: "Suppliers",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Purchasing_Suppliers_SupplierName",
                schema: "Purchasing",
                table: "Suppliers",
                column: "SupplierName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CX_Purchasing_SupplierTransactions",
                schema: "Purchasing",
                table: "SupplierTransactions",
                column: "TransactionDate")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_SupplierTransactions_PaymentMethodID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                columns: new[] { "TransactionDate", "PaymentMethodID" });

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_SupplierTransactions_PurchaseOrderID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                columns: new[] { "TransactionDate", "PurchaseOrderID" });

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_SupplierTransactions_SupplierID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                columns: new[] { "TransactionDate", "SupplierID" });

            migrationBuilder.CreateIndex(
                name: "FK_Purchasing_SupplierTransactions_TransactionTypeID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                columns: new[] { "TransactionDate", "TransactionTypeID" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasing_SupplierTransactions_IsFinalized",
                schema: "Purchasing",
                table: "SupplierTransactions",
                columns: new[] { "TransactionDate", "IsFinalized" });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTransactions_LastEditedBy",
                schema: "Purchasing",
                table: "SupplierTransactions",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTransactions_PaymentMethodID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTransactions_PurchaseOrderID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTransactions_SupplierID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTransactions_TransactionTypeID",
                schema: "Purchasing",
                table: "SupplierTransactions",
                column: "TransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "FK_Application_SystemParameters_DeliveryCityID",
                schema: "Application",
                table: "SystemParameters",
                column: "DeliveryCityID");

            migrationBuilder.CreateIndex(
                name: "FK_Application_SystemParameters_PostalCityID",
                schema: "Application",
                table: "SystemParameters",
                column: "PostalCityID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParameters_LastEditedBy",
                schema: "Application",
                table: "SystemParameters",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_LastEditedBy",
                schema: "Application",
                table: "TransactionTypes",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Application_TransactionTypes_TransactionTypeName",
                schema: "Application",
                table: "TransactionTypes",
                column: "TransactionTypeName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColdRoomTemperatures",
                schema: "Warehouse")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ColdRoomTemperatures_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "CustomerTransactions",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "InvoiceLines",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "OrderLines",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLines",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialDeals",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "StockItemHoldings",
                schema: "Warehouse");

            migrationBuilder.DropTable(
                name: "StockItemStockGroups",
                schema: "Warehouse");

            migrationBuilder.DropTable(
                name: "StockItemTransactions",
                schema: "Warehouse");

            migrationBuilder.DropTable(
                name: "SupplierTransactions",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SystemParameters",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "VehicleTemperatures",
                schema: "Warehouse")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "StockGroups",
                schema: "Warehouse")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "StockGroups_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "StockItems",
                schema: "Warehouse")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "StockItems_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "PaymentMethods",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "PaymentMethods_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "PurchaseOrders",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "TransactionTypes",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TransactionTypes_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Colors",
                schema: "Warehouse")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Colors_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "PackageTypes",
                schema: "Warehouse")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "PackageTypes_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Warehouse")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Purchasing")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Suppliers_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Purchasing")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Sales")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Customers_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Sales")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "SupplierCategories",
                schema: "Purchasing")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SupplierCategories_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Purchasing")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "BuyingGroups",
                schema: "Sales")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BuyingGroups_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Sales")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "CustomerCategories",
                schema: "Sales")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "CustomerCategories_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Sales")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Cities_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "DeliveryMethods",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DeliveryMethods_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "StateProvinces",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "StateProvinces_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Countries_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropTable(
                name: "People",
                schema: "Application")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "People_Archive")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Application")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropSequence(
                name: "BuyingGroupID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "CityID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "ColorID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "CountryID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "CustomerCategoryID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "CustomerID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "DeliveryMethodID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "InvoiceID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "InvoiceLineID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "OrderID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "OrderLineID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "PackageTypeID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "PaymentMethodID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "PersonID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "PurchaseOrderID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "PurchaseOrderLineID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "SpecialDealID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "StateProvinceID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "StockGroupID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "StockItemID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "StockItemStockGroupID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "SupplierCategoryID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "SupplierID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "SystemParameterID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "TransactionID",
                schema: "Sequences");

            migrationBuilder.DropSequence(
                name: "TransactionTypeID",
                schema: "Sequences");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("SqlServer:MemoryOptimized", true);
        }
    }
}
