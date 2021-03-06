﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using CW.Backend.DAL.CRUD.Entities;

namespace CW.Backend.DAL.CRUD.Contexts
{
    public class ProductCRUDContext : IdentityContext
    {
        private const string DefaultConnectionName = "CW_CRUD";

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<Order> Orders { get; set; }


        public ProductCRUDContext()
            : this(DefaultConnectionName)
        {

        }

        public ProductCRUDContext(string connectionName = DefaultConnectionName)
            : base(connectionName)
        {


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductProperty>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductTag>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductComment>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductGroup>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductPrice>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CategoryProperty>().Property(cp => cp.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Order>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Product>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<ProductPrice>().Property(p => p.DiscountValidity).HasColumnType("datetime2");
            modelBuilder.Entity<ApplicationUser>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<ApplicationUser>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Category>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Category>().Property(p => p.UpdatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Order>().Property(p => p.CreatedOn).HasColumnType("datetime2");
            modelBuilder.Entity<Order>().Property(p => p.UpdatedOn).HasColumnType("datetime2");

            //modelBuilder.Entity<Product>().HasRequired(p => p.PostedBy).WithMany(u => u.Products).HasForeignKey(p => p.PostedUserId);
            //modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>().HasMany(p => p.Groups).WithMany(g => g.Products);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOptional()
                .HasForeignKey(c => c.ParentId);

            //modelBuilder.Entity<Order>().HasRequired(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.OrderedBy).WillCascadeOnDelete(false);

        }
    }
}
