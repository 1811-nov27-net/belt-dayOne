using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFDBFirstDemo.DataAccess
{
    public partial class adventureworksContext : DbContext
    {
        public adventureworksContext()
        {
        }

        public adventureworksContext(DbContextOptions<adventureworksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BuildVersion> BuildVersion { get; set; }
        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EmpDetails> EmpDetails { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "SalesLT");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Address_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.StateProvince);

                entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvince, e.PostalCode, e.CountryRegion });

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AddressLine2).HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryRegion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BuildVersion>(entity =>
            {
                entity.HasKey(e => e.SystemInformationId)
                    .HasName("PK__BuildVer__35E58ECAE5390060");

                entity.Property(e => e.SystemInformationId)
                    .HasColumnName("SystemInformationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DatabaseVersion)
                    .IsRequired()
                    .HasColumnName("Database Version")
                    .HasMaxLength(25);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VersionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "PS");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Crust__737584F6620F410B")
                    .IsUnique();

                entity.Property(e => e.CrustId)
                    .HasColumnName("CrustID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.InternalName)
                    .HasMaxLength(121)
                    .HasComputedColumnSql("((CONVERT([varchar](20),[CrustID])+'_')+[Name])");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "SalesLT");

                entity.HasIndex(e => e.EmailAddress);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Customer_rowguid")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesPerson).HasMaxLength(256);

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId })
                    .HasName("PK_CustomerAddress_CustomerID_AddressID");

                entity.ToTable("CustomerAddress", "SalesLT");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_CustomerAddress_rowguid")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "example");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpDetails>(entity =>
            {
                entity.ToTable("EmpDetails", "example");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("U_EmpDetails_EmployeeID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmpDetails)
                    .HasForeignKey<EmpDetails>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmpDetail__Emplo__793DFFAF");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "example");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Employee_DeptID");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.ErrorLogId).HasColumnName("ErrorLogID");

                entity.Property(e => e.ErrorMessage)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.ErrorProcedure).HasMaxLength(126);

                entity.Property(e => e.ErrorTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre", "Movies");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Location__E7FEA4772BACD39D");

                entity.ToTable("Locations", "project0");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Inventory)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Menu).HasMaxLength(200);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie", "Movies");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movies_Genre_GenreID");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF40A5EEC3");

                entity.ToTable("Orders", "project0");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.OrderDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TotalCost).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_LocationID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Orders_UserID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PS");

                entity.HasIndex(e => e.Name)
                    .HasName("U_Pizza_Name")
                    .IsUnique();

                entity.Property(e => e.PizzaId)
                    .HasColumnName("PizzaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatorName).HasMaxLength(100);

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.InternalName)
                    .HasMaxLength(121)
                    .HasComputedColumnSql("((CONVERT([varchar](20),[PizzaID])+'_')+[Name])");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "SalesLT");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryId);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductModelId);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory", "SalesLT");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ParentProductCategory)
                    .WithMany(p => p.InverseParentProductCategory)
                    .HasForeignKey(d => d.ParentProductCategoryId)
                    .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.ToTable("ProductDescription", "SalesLT");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("ProductModel", "SalesLT");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductModel_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModel_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.CatalogDescription).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductModelProductDescription>(entity =>
            {
                entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture })
                    .HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

                entity.ToTable("ProductModelProductDescription", "SalesLT");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModelProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.Culture).HasMaxLength(6);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ProductDescription)
                    .WithMany(p => p.ProductModelProductDescription)
                    .HasForeignKey(d => d.ProductDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.ProductModelProductDescription)
                    .HasForeignKey(d => d.ProductModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId })
                    .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

                entity.ToTable("SalesOrderDetail", "SalesLT");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesOrderDetail_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.SalesOrderDetailId)
                    .HasColumnName("SalesOrderDetailID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LineTotal)
                    .HasColumnType("numeric(38, 6)")
                    .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.UnitPriceDiscount).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesOrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SalesOrderDetail)
                    .HasForeignKey(d => d.SalesOrderId);
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId)
                    .HasName("PK_SalesOrderHeader_SalesOrderID");

                entity.ToTable("SalesOrderHeader", "SalesLT");

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesOrderHeader_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.SalesOrderNumber)
                    .HasName("AK_SalesOrderHeader_SalesOrderNumber")
                    .IsUnique();

                entity.Property(e => e.SalesOrderId)
                    .HasColumnName("SalesOrderID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [SalesLT].[SalesOrderNumber])");

                entity.Property(e => e.AccountNumber).HasMaxLength(15);

                entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");

                entity.Property(e => e.CreditCardApprovalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OnlineOrderFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(25);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesOrderNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***'))");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipMethod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmt)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");

                entity.HasOne(d => d.BillToAddress)
                    .WithMany(p => p.SalesOrderHeaderBillToAddress)
                    .HasForeignKey(d => d.BillToAddressId)
                    .HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ShipToAddress)
                    .WithMany(p => p.SalesOrderHeaderShipToAddress)
                    .HasForeignKey(d => d.ShipToAddressId)
                    .HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC43FFFDE5");

                entity.ToTable("Users", "project0");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.DefaultLocationNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DefaultLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Users_DefaultLocation");
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber");
        }
    }
}
