using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace wwimporters.infrastructure.Migrations
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
                    PersonID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PersonID])"),
                    FullName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
                    PreferredName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false, computedColumnSql: "(concat([PreferredName],N' ',[FullName]))", stored: true),
                    IsPermittedToLogon = table.Column<bool>(type: "bit", nullable: false),
                    LogonName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true),
                    IsExternalLogonProvider = table.Column<bool>(type: "bit", nullable: false),
                    HashedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsSystemUser = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsSalesperson = table.Column<bool>(type: "bit", nullable: false),
                    UserPreferences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(264)", maxLength: 264, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "(json_query([CustomFields],N'$.OtherLanguages'))", stored: false),
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
                })
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
                    BuyingGroupID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[BuyingGroupID])"),
                    BuyingGroupName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    ColorID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[ColorID])"),
                    ColorName = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
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
                })
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
                    CountryID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CountryID])"),
                    CountryName = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    FormalName = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    IsoAlpha3Code = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IsoNumericCode = table.Column<int>(type: "int", nullable: true),
                    CountryType = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    LatestRecordedPopulation = table.Column<long>(type: "bigint", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    Subregion = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    Border = table.Column<Geometry>(type: "geography", nullable: true),
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
                })
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
                    CustomerCategoryID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CustomerCategoryID])"),
                    CustomerCategoryName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[DeliveryMethodID])"),
                    DeliveryMethodName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    PackageTypeID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PackageTypeID])"),
                    PackageTypeName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PaymentMethodID])"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    StockGroupID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StockGroupID])"),
                    StockGroupName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    SupplierCategoryID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SupplierCategoryID])"),
                    SupplierCategoryName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionTypeID])"),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
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
                })
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
                    StateProvinceID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StateProvinceID])"),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    StateProvinceName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    SalesTerritory = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
                    Border = table.Column<Geometry>(type: "geography", nullable: true),
                    LatestRecordedPopulation = table.Column<long>(type: "bigint", nullable: true),
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
                })
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
                    CityID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CityID])"),
                    CityName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
                    StateProvinceID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<Geometry>(type: "geography", nullable: true),
                    LatestRecordedPopulation = table.Column<long>(type: "bigint", nullable: true),
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
                })
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
                    CustomerID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[CustomerID])"),
                    CustomerName = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false),
                    BillToCustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerCategoryID = table.Column<int>(type: "int", nullable: false),
                    BuyingGroupID = table.Column<int>(type: "int", nullable: true),
                    PrimaryContactPersonID = table.Column<int>(type: "int", nullable: false),
                    AlternateContactPersonID = table.Column<int>(type: "int", nullable: true),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false),
                    DeliveryCityID = table.Column<int>(type: "int", nullable: false),
                    PostalCityID = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccountOpenedDate = table.Column<DateTime>(type: "date", nullable: false),
                    StandardDiscountPercentage = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    IsStatementSent = table.Column<bool>(type: "bit", nullable: false),
                    IsOnCreditHold = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDays = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    DeliveryRun = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RunPosition = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    WebsiteURL = table.Column<string>(type: "nvarchar(264)", maxLength: 264, nullable: false),
                    DeliveryAddressLine1 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    DeliveryAddressLine2 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DeliveryLocation = table.Column<Geometry>(type: "geography", nullable: true),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    PostalPostalCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
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
                })
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
                    SupplierID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SupplierID])"),
                    SupplierName = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false),
                    SupplierCategoryID = table.Column<int>(type: "int", nullable: false),
                    PrimaryContactPersonID = table.Column<int>(type: "int", nullable: false),
                    AlternateContactPersonID = table.Column<int>(type: "int", nullable: false),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: true),
                    DeliveryCityID = table.Column<int>(type: "int", nullable: false),
                    PostalCityID = table.Column<int>(type: "int", nullable: false),
                    SupplierReference = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true),
                    BankAccountBranch = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true),
                    BankAccountCode = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    BankInternationalCode = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    PaymentDays = table.Column<int>(type: "int", nullable: false),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    WebsiteURL = table.Column<string>(type: "nvarchar(264)", maxLength: 264, nullable: false),
                    DeliveryAddressLine1 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    DeliveryAddressLine2 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DeliveryLocation = table.Column<Geometry>(type: "geography", nullable: true),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    PostalPostalCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
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
                })
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
                    SystemParameterID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SystemParameterID])"),
                    DeliveryAddressLine1 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    DeliveryAddressLine2 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    DeliveryCityID = table.Column<int>(type: "int", nullable: false),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DeliveryLocation = table.Column<Geometry>(type: "geography", nullable: false),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: false),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    PostalCityID = table.Column<int>(type: "int", nullable: false),
                    PostalPostalCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    ApplicationSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Sales",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[OrderID])"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SalespersonPersonID = table.Column<int>(type: "int", nullable: false),
                    PickedByPersonID = table.Column<int>(type: "int", nullable: true),
                    ContactPersonID = table.Column<int>(type: "int", nullable: false),
                    BackorderOrderID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    CustomerPurchaseOrderNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    IsUndersupplyBackordered = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickingCompletedWhen = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PurchaseOrderID])"),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false),
                    ContactPersonID = table.Column<int>(type: "int", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    SupplierReference = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    IsOrderFinalized = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StockItemID])"),
                    StockItemName = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: true),
                    UnitPackageID = table.Column<int>(type: "int", nullable: false),
                    OuterPackageID = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: false),
                    QuantityPerOuter = table.Column<int>(type: "int", nullable: false),
                    IsChillerStock = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecommendedRetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TypicalWeightPerUnit = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MarketingComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "(json_query([CustomFields],N'$.Tags'))", stored: false),
                    SearchDetails = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "(concat([StockItemName],N' ',[MarketingComments]))", stored: false),
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
                })
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
                    InvoiceID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[InvoiceID])"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BillToCustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    DeliveryMethodID = table.Column<int>(type: "int", nullable: false),
                    ContactPersonID = table.Column<int>(type: "int", nullable: false),
                    AccountsPersonID = table.Column<int>(type: "int", nullable: false),
                    SalespersonPersonID = table.Column<int>(type: "int", nullable: false),
                    PackedByPersonID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    CustomerPurchaseOrderNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    IsCreditNote = table.Column<bool>(type: "bit", nullable: false),
                    CreditNoteReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDryItems = table.Column<int>(type: "int", nullable: false),
                    TotalChillerItems = table.Column<int>(type: "int", nullable: false),
                    DeliveryRun = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RunPosition = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ReturnedDeliveryData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true, computedColumnSql: "(TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126)))", stored: false),
                    ConfirmedReceivedBy = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, computedColumnSql: "(json_value([ReturnedDeliveryData],N'$.ReceivedBy'))", stored: false),
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
                });

            migrationBuilder.CreateTable(
                name: "SupplierTransactions",
                schema: "Purchasing",
                columns: table => new
                {
                    SupplierTransactionID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionID])"),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: true),
                    SupplierInvoiceNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    AmountExcludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalizationDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsFinalized = table.Column<bool>(type: "bit", nullable: true, computedColumnSql: "(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", stored: true),
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
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                schema: "Sales",
                columns: table => new
                {
                    OrderLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[OrderLineID])"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    PickedQuantity = table.Column<int>(type: "int", nullable: false),
                    PickingCompletedWhen = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLines",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])"),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    OrderedOuters = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false),
                    ReceivedOuters = table.Column<int>(type: "int", nullable: false),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false),
                    ExpectedUnitPricePerOuter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastReceiptDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsOrderLineFinalized = table.Column<bool>(type: "bit", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "SpecialDeals",
                schema: "Sales",
                columns: table => new
                {
                    SpecialDealID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[SpecialDealID])"),
                    StockItemID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    BuyingGroupID = table.Column<int>(type: "int", nullable: true),
                    CustomerCategoryID = table.Column<int>(type: "int", nullable: true),
                    StockGroupID = table.Column<int>(type: "int", nullable: true),
                    DealDescription = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "StockItemHoldings",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    QuantityOnHand = table.Column<int>(type: "int", nullable: false),
                    BinLocation = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    LastStocktakeQuantity = table.Column<int>(type: "int", nullable: false),
                    LastCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReorderLevel = table.Column<int>(type: "int", nullable: false),
                    TargetStockLevel = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "StockItemStockGroups",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemStockGroupID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[StockItemStockGroupID])"),
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    StockGroupID = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "CustomerTransactions",
                schema: "Sales",
                columns: table => new
                {
                    CustomerTransactionID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionID])"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    AmountExcludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalizationDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsFinalized = table.Column<bool>(type: "bit", nullable: true, computedColumnSql: "(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", stored: true),
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
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                schema: "Sales",
                columns: table => new
                {
                    InvoiceLineID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[InvoiceLineID])"),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(107)", maxLength: 107, nullable: false),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtendedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "StockItemTransactions",
                schema: "Warehouse",
                columns: table => new
                {
                    StockItemTransactionID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(NEXT VALUE FOR [Sequences].[TransactionID])"),
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    InvoiceID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true),
                    TransactionOccurredWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
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
                });

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
