using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace superTech.Database
{
    public partial class superTechRSContext : DbContext
    {
        public superTechRSContext()
        {
        }

        public superTechRSContext(DbContextOptions<superTechRSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillItem> BillItems { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BuyerOrder> BuyerOrders { get; set; }
        public virtual DbSet<BuyerOrderItem> BuyerOrderItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOffer> ProductOffers { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UnitsOfMeasure> UnitsOfMeasures { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=superTechRS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_BIN");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AmountWithTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FkBuyerOrder).HasColumnName("FK_BuyerOrder");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.Property(e => e.IssuingDate).HasColumnType("date");

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FkBuyerOrderNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.FkBuyerOrder)
                    .HasConstraintName("FK__Bills__FK_BuyerO__5FB337D6");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.FkUserId)
                    .HasConstraintName("FK__Bills__FK_UserId__5EBF139D");
            });

            modelBuilder.Entity<BillItem>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FkBillId).HasColumnName("FK_BillId");

                entity.Property(e => e.FkProductId).HasColumnName("FK_ProductId");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FkBill)
                    .WithMany(p => p.BillItems)
                    .HasForeignKey(d => d.FkBillId)
                    .HasConstraintName("FK__BillItems__FK_Bi__628FA481");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.BillItems)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__BillItems__FK_Pr__6383C8BA");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.WebAddress).HasMaxLength(150);
            });

            modelBuilder.Entity<BuyerOrder>(entity =>
            {

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.BuyerOrders)
                    .HasForeignKey(d => d.FkUserId)
                    .HasConstraintName("FK__BuyerOrde__FK_Us__5812160E");
            });

            modelBuilder.Entity<BuyerOrderItem>(entity =>
            {
                entity.HasKey(e => e.BuyerOrderItemsId)
                    .HasName("PK__BuyerOrd__8E1D118BEDBD0F49");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FkBuyerOrder).HasColumnName("FK_BuyerOrder");

                entity.Property(e => e.FkProductId).HasColumnName("FK_ProductId");

                entity.HasOne(d => d.FkBuyerOrderNavigation)
                    .WithMany(p => p.BuyerOrderItems)
                    .HasForeignKey(d => d.FkBuyerOrder)
                    .HasConstraintName("FK__BuyerOrde__FK_Bu__5BE2A6F2");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.BuyerOrderItems)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__BuyerOrde__FK_Pr__5AEE82B9");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.DateOfCreation).HasColumnType("date");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.FkUserId)
                    .HasConstraintName("FK__News__FK_UserId__440B1D61");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FkSupplierId).HasColumnName("FK_SupplierId");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.HasOne(d => d.FkSupplier)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkSupplierId)
                    .HasConstraintName("FK__Orders__FK_Suppl__693CA210");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkUserId)
                    .HasConstraintName("FK__Orders__FK_UserI__68487DD7");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FkOrderId).HasColumnName("FK_OrderId");

                entity.Property(e => e.FkProductId).HasColumnName("FK_ProductId");

                entity.HasOne(d => d.FkOrder)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FkOrderId)
                    .HasConstraintName("FK__OrderItem__FK_Or__6C190EBB");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__OrderItem__FK_Pr__6D0D32F4");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FkCategoryId).HasColumnName("FK_CategoryId");

                entity.Property(e => e.FkUnitOfMeasureId).HasColumnName("FK_UnitOfMeasureId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Products__BrandI__160F4887");

                entity.HasOne(d => d.FkCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FkCategoryId)
                    .HasConstraintName("FK__Products__FK_Cat__4BAC3F29");

                entity.HasOne(d => d.FkUnitOfMeasure)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FkUnitOfMeasureId)
                    .HasConstraintName("FK__Products__FK_Uni__4AB81AF0");
            });

            modelBuilder.Entity<ProductOffer>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FkOfferId).HasColumnName("FK_OfferId");

                entity.Property(e => e.FkProductId).HasColumnName("FK_ProductId");

                entity.Property(e => e.PriceWithDiscount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FkOffer)
                    .WithMany(p => p.ProductOffers)
                    .HasForeignKey(d => d.FkOfferId)
                    .HasConstraintName("FK__ProductOf__FK_Of__5535A963");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.ProductOffers)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__ProductOf__FK_Pr__5441852A");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FkProductId).HasColumnName("FK_ProductId");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__Ratings__FK_Prod__4F7CD00D");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.FkUserId)
                    .HasConstraintName("FK__Ratings__FK_User__4E88ABD4");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(80);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.BankAccount)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WebAddress).HasMaxLength(50);
            });

            modelBuilder.Entity<UnitsOfMeasure>(entity =>
            {
                entity.HasKey(e => e.UnitOfMeasureId)
                    .HasName("PK__UnitsOfM__F36083F1EE73BD8B");

                entity.ToTable("UnitsOfMeasure");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D1053469742187")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456803E0209")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FkCityId).HasColumnName("FK_CityId");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkCity)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkCityId)
                    .HasConstraintName("FK__Users__FK_CityId__3B75D760");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId)
                    .HasName("PK__UsersRol__3D978A354EF9B121");

                entity.Property(e => e.DateOfModification).HasColumnType("datetime");

                entity.Property(e => e.FkRoleId).HasColumnName("FK_RoleId");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.HasOne(d => d.FkRole)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.FkRoleId)
                    .HasConstraintName("FK__UsersRole__FK_Ro__412EB0B6");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.FkUserId)
                    .HasConstraintName("FK__UsersRole__FK_Us__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
