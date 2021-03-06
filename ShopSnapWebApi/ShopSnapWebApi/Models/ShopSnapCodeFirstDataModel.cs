namespace ShopSnapWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopSnapDatabaseContext : DbContext
    {
        public ShopSnapDatabaseContext()
            : base("name=ShopSnapDatabaseContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<ReceiptItem> ReceiptItems { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiptItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiptItem>()
                .Property(e => e.Quantity);

            modelBuilder.Entity<ReceiptItem>()
                .Property(e => e.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiptItem>()
            .HasRequired<Receipt>(s => s.Receipt)
            .WithMany(g => g.ReceiptItems)
            .HasForeignKey<int>(s => s.ReceiptID);

            modelBuilder.Entity<Product>()
            .HasRequired<Category>(s => s.Category)
            .WithMany(g => g.Products)
            .HasForeignKey<int>(s => s.CategoryID);

            modelBuilder.Entity<Receipt>()
            .HasRequired<Store>(s => s.Store);
        }
    }
}
