using Microsoft.EntityFrameworkCore;
using wwimporters.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using wwimporters.infrastructure.Persistence.EntityConfigurations;

namespace wwimporters.infrastructure.Persistence
{
    public partial class WideWorldImportersContext : DbContext
    {
        public WideWorldImportersContext()
        {

        }

        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options) 
            : base(options)
        {

        }
        public virtual DbSet<BuyingGroup> BuyingGroups => Set<BuyingGroup>();
        public virtual DbSet<City> Cities => Set<City>();
        public virtual DbSet<ColdRoomTemperature> ColdRoomTemperatures => Set<ColdRoomTemperature>();
        public virtual DbSet<Color> Colors => Set<Color>();
        public virtual DbSet<Country> Countries => Set<Country>();
        public virtual DbSet<Customer> Customers => Set<Customer>();
        public virtual DbSet<Customer1> Customers1 => Set<Customer1>();
        public virtual DbSet<CustomerCategory> CustomerCategories => Set<CustomerCategory>();
        public virtual DbSet<CustomerTransaction> CustomerTransactions => Set<CustomerTransaction>();
        public virtual DbSet<DeliveryMethod> DeliveryMethods => Set<DeliveryMethod>();
        public virtual DbSet<Invoice> Invoices => Set<Invoice>();
        public virtual DbSet<InvoiceLine> InvoiceLines => Set<InvoiceLine>();
        public virtual DbSet<Order> Orders => Set<Order>();
        public virtual DbSet<OrderLine> OrderLines => Set<OrderLine>();
        public virtual DbSet<PackageType> PackageTypes => Set<PackageType>();
        public virtual DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
        public virtual DbSet<Person> People => Set<Person>();
        public virtual DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();
        public virtual DbSet<SpecialDeal> SpecialDeals => Set<SpecialDeal>();
        public virtual DbSet<StateProvince> StateProvinces => Set<StateProvince>();
        public virtual DbSet<StockGroup> StockGroups => Set<StockGroup>();
        public virtual DbSet<StockItem> StockItems => Set<StockItem>();
        public virtual DbSet<StockItemHolding> StockItemHoldings => Set<StockItemHolding>();
        public virtual DbSet<StockItemStockGroup> StockItemStockGroups => Set<StockItemStockGroup>();
        public virtual DbSet<StockItemTransaction> StockItemTransactions => Set<StockItemTransaction>();
        public virtual DbSet<Supplier> Suppliers => Set<Supplier>();
        public virtual DbSet<Supplier1> Suppliers1 => Set<Supplier1>();
        public virtual DbSet<SupplierCategory> SupplierCategories => Set<SupplierCategory>();
        public virtual DbSet<SupplierTransaction> SupplierTransactions => Set<SupplierTransaction>();
        public virtual DbSet<SystemParameter> SystemParameters => Set<SystemParameter>();
        public virtual DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
        public virtual DbSet<VehicleTemperature> VehicleTemperatures => Set<VehicleTemperature>();
        public virtual DbSet<VehicleTemperature1> VehicleTemperatures1 => Set<VehicleTemperature1>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_100_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<BuyingGroup>()
                .HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.BuyingGroups)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_BuyingGroups_Application_People");

            modelBuilder.Entity<City>()
                .HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Cities_Application_People");

            modelBuilder.Entity<City>()
                .HasOne(d => d.StateProvince)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Cities_StateProvinceID_Application_StateProvinces");

            modelBuilder.Entity<Color>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.Colors)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Colors_Application_People");

            modelBuilder.Entity<Country>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.Countries)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Countries_Application_People");

            modelBuilder.Entity<Customer>().HasOne(d => d.AlternateContactPerson)
                .WithMany(p => p.CustomerAlternateContactPeople)
                .HasForeignKey(d => d.AlternateContactPersonId)
                .HasConstraintName("FK_Sales_Customers_AlternateContactPersonID_Application_People"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.BillToCustomer)
                .WithMany(p => p.InverseBillToCustomer)
                .HasForeignKey(d => d.BillToCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_BillToCustomerID_Sales_Customers"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.BuyingGroup)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.BuyingGroupId)
                .HasConstraintName("FK_Sales_Customers_BuyingGroupID_Sales_BuyingGroups"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.CustomerCategory)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_CustomerCategoryID_Sales_CustomerCategories"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.DeliveryCity)
                .WithMany(p => p.CustomerDeliveryCities)
                .HasForeignKey(d => d.DeliveryCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_DeliveryCityID_Application_Cities"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.DeliveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_DeliveryMethodID_Application_DeliveryMethods"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.CustomerLastEditedByNavigations)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_Application_People"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.PostalCity)
                .WithMany(p => p.CustomerPostalCities)
                .HasForeignKey(d => d.PostalCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_PostalCityID_Application_Cities"); ;

            modelBuilder.Entity<Customer>().HasOne(d => d.PrimaryContactPerson)
                .WithMany(p => p.CustomerPrimaryContactPeople)
                .HasForeignKey(d => d.PrimaryContactPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_PrimaryContactPersonID_Application_People"); ;

            modelBuilder.Entity<CustomerCategory>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.CustomerCategories)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerCategories_Application_People");

            modelBuilder.Entity<CustomerTransaction>().HasOne(d => d.Customer)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_CustomerID_Sales_Customers"); ;

            modelBuilder.Entity<CustomerTransaction>().HasOne(d => d.Invoice)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_Sales_CustomerTransactions_InvoiceID_Sales_Invoices"); ;

            modelBuilder.Entity<CustomerTransaction>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_Application_People"); ;

            modelBuilder.Entity<CustomerTransaction>().HasOne(d => d.PaymentMethod)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_Sales_CustomerTransactions_PaymentMethodID_Application_PaymentMethods"); ;

            modelBuilder.Entity<CustomerTransaction>().HasOne(d => d.TransactionType)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_TransactionTypeID_Application_TransactionTypes"); ;

            modelBuilder.Entity<DeliveryMethod>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.DeliveryMethods)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_DeliveryMethods_Application_People");

            modelBuilder.Entity<Invoice>().HasOne(d => d.AccountsPerson)
                .WithMany(p => p.InvoiceAccountsPeople)
                .HasForeignKey(d => d.AccountsPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_AccountsPersonID_Application_People"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.BillToCustomer)
                .WithMany(p => p.InvoiceBillToCustomers)
                .HasForeignKey(d => d.BillToCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_BillToCustomerID_Sales_Customers"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.ContactPerson)
                .WithMany(p => p.InvoiceContactPeople)
                .HasForeignKey(d => d.ContactPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_ContactPersonID_Application_People"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.Customer)
                .WithMany(p => p.InvoiceCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_CustomerID_Sales_Customers"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.DeliveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_DeliveryMethodID_Application_DeliveryMethods"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.InvoiceLastEditedByNavigations)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_Application_People"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.Order)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Sales_Invoices_OrderID_Sales_Orders"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.PackedByPerson)
                .WithMany(p => p.InvoicePackedByPeople)
                .HasForeignKey(d => d.PackedByPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_PackedByPersonID_Application_People"); ;

            modelBuilder.Entity<Invoice>().HasOne(d => d.SalespersonPerson)
                .WithMany(p => p.InvoiceSalespersonPeople)
                .HasForeignKey(d => d.SalespersonPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_SalespersonPersonID_Application_People"); ;

            modelBuilder.Entity<InvoiceLine>().HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_InvoiceLines_InvoiceID_Sales_Invoices"); ;

            modelBuilder.Entity<InvoiceLine>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_InvoiceLines_Application_People"); ;

            modelBuilder.Entity<InvoiceLine>().HasOne(d => d.PackageType)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.PackageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_InvoiceLines_PackageTypeID_Warehouse_PackageTypes"); ;

            modelBuilder.Entity<InvoiceLine>().HasOne(d => d.StockItem)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_InvoiceLines_StockItemID_Warehouse_StockItems"); ;

            modelBuilder.Entity<Order>().HasOne(d => d.BackorderOrder)
                .WithMany(p => p.InverseBackorderOrder)
                .HasForeignKey(d => d.BackorderOrderId)
                .HasConstraintName("FK_Sales_Orders_BackorderOrderID_Sales_Orders"); ;

            modelBuilder.Entity<Order>().HasOne(d => d.ContactPerson)
                .WithMany(p => p.OrderContactPeople)
                .HasForeignKey(d => d.ContactPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_ContactPersonID_Application_People"); ;

            modelBuilder.Entity<Order>().HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_CustomerID_Sales_Customers"); ;

            modelBuilder.Entity<Order>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.OrderLastEditedByNavigations)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_Application_People"); ;

            modelBuilder.Entity<Order>().HasOne(d => d.PickedByPerson)
                .WithMany(p => p.OrderPickedByPeople)
                .HasForeignKey(d => d.PickedByPersonId)
                .HasConstraintName("FK_Sales_Orders_PickedByPersonID_Application_People"); ;

            modelBuilder.Entity<Order>().HasOne(d => d.SalespersonPerson)
                .WithMany(p => p.OrderSalespersonPeople)
                .HasForeignKey(d => d.SalespersonPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_SalespersonPersonID_Application_People"); ;

            modelBuilder.Entity<OrderLine>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_Application_People"); ;

            modelBuilder.Entity<OrderLine>().HasOne(d => d.Order)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_OrderID_Sales_Orders"); ;

            modelBuilder.Entity<OrderLine>().HasOne(d => d.PackageType)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.PackageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_PackageTypeID_Warehouse_PackageTypes"); ;

            modelBuilder.Entity<OrderLine>().HasOne(d => d.StockItem)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_StockItemID_Warehouse_StockItems");
            
            modelBuilder.Entity<PackageType>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.PackageTypes)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_PackageTypes_Application_People");

            modelBuilder.Entity<PaymentMethod>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_PaymentMethods_Application_People");

            modelBuilder.Entity<Person>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.InverseLastEditedByNavigation)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_People_Application_People");

            modelBuilder.Entity<PurchaseOrder>().HasOne(d => d.ContactPerson)
                .WithMany(p => p.PurchaseOrderContactPeople)
                .HasForeignKey(d => d.ContactPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_ContactPersonID_Application_People");

            modelBuilder.Entity<PurchaseOrder>().HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.DeliveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_DeliveryMethodID_Application_DeliveryMethods");

            modelBuilder.Entity<PurchaseOrder>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.PurchaseOrderLastEditedByNavigations)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_Application_People");

            modelBuilder.Entity<PurchaseOrder>().HasOne(d => d.Supplier)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_SupplierID_Purchasing_Suppliers");

            modelBuilder.Entity<PurchaseOrderLine>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_Application_People");

            modelBuilder.Entity<PurchaseOrderLine>().HasOne(d => d.PackageType)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PackageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_PackageTypeID_Warehouse_PackageTypes");

            modelBuilder.Entity<PurchaseOrderLine>().HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_PurchaseOrderID_Purchasing_PurchaseOrders");

            modelBuilder.Entity<PurchaseOrderLine>().HasOne(d => d.StockItem)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_StockItemID_Warehouse_StockItems");


            modelBuilder.Entity<SpecialDeal>().HasOne(d => d.BuyingGroup)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.BuyingGroupId)
                .HasConstraintName("FK_Sales_SpecialDeals_BuyingGroupID_Sales_BuyingGroups");

            modelBuilder.Entity<SpecialDeal>().HasOne(d => d.CustomerCategory)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.CustomerCategoryId)
                .HasConstraintName("FK_Sales_SpecialDeals_CustomerCategoryID_Sales_CustomerCategories");

            modelBuilder.Entity<SpecialDeal>().HasOne(d => d.Customer)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Sales_SpecialDeals_CustomerID_Sales_Customers");

            modelBuilder.Entity<SpecialDeal>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SpecialDeals_Application_People");

            modelBuilder.Entity<SpecialDeal>().HasOne(d => d.StockGroup)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.StockGroupId)
                .HasConstraintName("FK_Sales_SpecialDeals_StockGroupID_Warehouse_StockGroups");

            modelBuilder.Entity<SpecialDeal>().HasOne(d => d.StockItem)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.StockItemId)
                .HasConstraintName("FK_Sales_SpecialDeals_StockItemID_Warehouse_StockItems");

            modelBuilder.Entity<StateProvince>().HasOne(d => d.Country)
                .WithMany(p => p.StateProvinces)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_StateProvinces_CountryID_Application_Countries");

            modelBuilder.Entity<StateProvince>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.StateProvinces)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_StateProvinces_Application_People");

            modelBuilder.Entity<StockGroup>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.StockGroups)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockGroups_Application_People");

            modelBuilder.Entity<StockItem>().HasOne(d => d.Color)
                .WithMany(p => p.StockItems)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Warehouse_StockItems_ColorID_Warehouse_Colors");

            modelBuilder.Entity<StockItem>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.StockItems)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_Application_People");

            modelBuilder.Entity<StockItem>().HasOne(d => d.OuterPackage)
                .WithMany(p => p.StockItemOuterPackages)
                .HasForeignKey(d => d.OuterPackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_OuterPackageID_Warehouse_PackageTypes");

            modelBuilder.Entity<StockItem>().HasOne(d => d.Supplier)
                .WithMany(p => p.StockItems)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_SupplierID_Purchasing_Suppliers");

            modelBuilder.Entity<StockItem>().HasOne(d => d.UnitPackage)
                .WithMany(p => p.StockItemUnitPackages)
                .HasForeignKey(d => d.UnitPackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_UnitPackageID_Warehouse_PackageTypes");

            modelBuilder.Entity<StockItemHolding>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.StockItemHoldings)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemHoldings_Application_People");

            modelBuilder.Entity<StockItemHolding>().HasOne(d => d.StockItem)
                .WithOne(p => p.StockItemHolding)
                .HasForeignKey<StockItemHolding>(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PKFK_Warehouse_StockItemHoldings_StockItemID_Warehouse_StockItems");

            modelBuilder.Entity<StockItemStockGroup>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.StockItemStockGroups)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemStockGroups_Application_People");

            modelBuilder.Entity<StockItemStockGroup>().HasOne(d => d.StockGroup)
                .WithMany(p => p.StockItemStockGroups)
                .HasForeignKey(d => d.StockGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemStockGroups_StockGroupID_Warehouse_StockGroups");

            modelBuilder.Entity<StockItemStockGroup>().HasOne(d => d.StockItem)
                .WithMany(p => p.StockItemStockGroups)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemStockGroups_StockItemID_Warehouse_StockItems");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.Customer)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_CustomerID_Sales_Customers");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.Invoice)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_InvoiceID_Sales_Invoices");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_Application_People");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_PurchaseOrderID_Purchasing_PurchaseOrders");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.StockItem)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.StockItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_StockItemID_Warehouse_StockItems");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.Supplier)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_SupplierID_Purchasing_Suppliers");

            modelBuilder.Entity<StockItemTransaction>().HasOne(d => d.TransactionType)
                .WithMany(p => p.StockItemTransactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemTransactions_TransactionTypeID_Application_TransactionTypes");

            modelBuilder.Entity<SupplierCategory>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.SupplierCategories)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierCategories_Application_People");

            modelBuilder.Entity<Supplier>().HasOne(d => d.AlternateContactPerson)
                .WithMany(p => p.SupplierAlternateContactPeople)
                .HasForeignKey(d => d.AlternateContactPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_Suppliers_AlternateContactPersonID_Application_People");

            modelBuilder.Entity<Supplier>().HasOne(d => d.DeliveryCity)
                .WithMany(p => p.SupplierDeliveryCities)
                .HasForeignKey(d => d.DeliveryCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_Suppliers_DeliveryCityID_Application_Cities");

            modelBuilder.Entity<Supplier>().HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.DeliveryMethodId)
                .HasConstraintName("FK_Purchasing_Suppliers_DeliveryMethodID_Application_DeliveryMethods");

            modelBuilder.Entity<Supplier>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.SupplierLastEditedByNavigations)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_Suppliers_Application_People");

            modelBuilder.Entity<Supplier>().HasOne(d => d.PostalCity)
                .WithMany(p => p.SupplierPostalCities)
                .HasForeignKey(d => d.PostalCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_Suppliers_PostalCityID_Application_Cities");

            modelBuilder.Entity<Supplier>().HasOne(d => d.PrimaryContactPerson)
                .WithMany(p => p.SupplierPrimaryContactPeople)
                .HasForeignKey(d => d.PrimaryContactPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_Suppliers_PrimaryContactPersonID_Application_People");

            modelBuilder.Entity<Supplier>().HasOne(d => d.SupplierCategory)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_Suppliers_SupplierCategoryID_Purchasing_SupplierCategories");

            modelBuilder.Entity<SupplierTransaction>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_Application_People");

            modelBuilder.Entity<SupplierTransaction>().HasOne(d => d.PaymentMethod)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_PaymentMethodID_Application_PaymentMethods");

            modelBuilder.Entity<SupplierTransaction>().HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_PurchaseOrderID_Purchasing_PurchaseOrders");

            modelBuilder.Entity<SupplierTransaction>().HasOne(d => d.Supplier)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_SupplierID_Purchasing_Suppliers");

            modelBuilder.Entity<SupplierTransaction>().HasOne(d => d.TransactionType)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_TransactionTypeID_Application_TransactionTypes");

            modelBuilder.Entity<SystemParameter>().HasOne(d => d.DeliveryCity)
                    .WithMany(p => p.SystemParameterDeliveryCities)
                    .HasForeignKey(d => d.DeliveryCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_SystemParameters_DeliveryCityID_Application_Cities");

            modelBuilder.Entity<SystemParameter>().HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.SystemParameters)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_SystemParameters_Application_People");

            modelBuilder.Entity<SystemParameter>().HasOne(d => d.PostalCity)
                    .WithMany(p => p.SystemParameterPostalCities)
                    .HasForeignKey(d => d.PostalCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_SystemParameters_PostalCityID_Application_Cities");

            modelBuilder.Entity<TransactionType>().HasOne(d => d.LastEditedByNavigation)
                .WithMany(p => p.TransactionTypes)
                .HasForeignKey(d => d.LastEditedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_TransactionTypes_Application_People");




            modelBuilder.HasSequence<int>("BuyingGroupID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("CityID", "Sequences").StartsAt(38187);

            modelBuilder.HasSequence<int>("ColorID", "Sequences").StartsAt(37);

            modelBuilder.HasSequence<int>("CountryID", "Sequences").StartsAt(242);

            modelBuilder.HasSequence<int>("CustomerCategoryID", "Sequences").StartsAt(9);

            modelBuilder.HasSequence<int>("CustomerID", "Sequences").StartsAt(1062);

            modelBuilder.HasSequence<int>("DeliveryMethodID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("InvoiceID", "Sequences").StartsAt(70511);

            modelBuilder.HasSequence<int>("InvoiceLineID", "Sequences").StartsAt(228266);

            modelBuilder.HasSequence<int>("OrderID", "Sequences").StartsAt(73596);

            modelBuilder.HasSequence<int>("OrderLineID", "Sequences").StartsAt(231413);

            modelBuilder.HasSequence<int>("PackageTypeID", "Sequences").StartsAt(15);

            modelBuilder.HasSequence<int>("PaymentMethodID", "Sequences").StartsAt(5);

            modelBuilder.HasSequence<int>("PersonID", "Sequences").StartsAt(3262);

            modelBuilder.HasSequence<int>("PurchaseOrderID", "Sequences").StartsAt(2075);

            modelBuilder.HasSequence<int>("PurchaseOrderLineID", "Sequences").StartsAt(8368);

            modelBuilder.HasSequence<int>("SpecialDealID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("StateProvinceID", "Sequences").StartsAt(54);

            modelBuilder.HasSequence<int>("StockGroupID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("StockItemID", "Sequences").StartsAt(228);

            modelBuilder.HasSequence<int>("StockItemStockGroupID", "Sequences").StartsAt(443);

            modelBuilder.HasSequence<int>("SupplierCategoryID", "Sequences").StartsAt(10);

            modelBuilder.HasSequence<int>("SupplierID", "Sequences").StartsAt(14);

            modelBuilder.HasSequence<int>("SystemParameterID", "Sequences").StartsAt(2);

            modelBuilder.HasSequence<int>("TransactionID", "Sequences").StartsAt(336253);

            modelBuilder.HasSequence<int>("TransactionTypeID", "Sequences").StartsAt(14);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
