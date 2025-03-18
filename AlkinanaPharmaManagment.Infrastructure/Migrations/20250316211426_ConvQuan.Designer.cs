﻿// <auto-generated />
using System;
using AlkinanaPharmaManagment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlkinanaPharmaManagment.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250316211426_ConvQuan")]
    partial class ConvQuan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isFulfilled")
                        .HasColumnType("bit");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Images.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.LineItem", b =>
                {
                    b.Property<Guid>("lineItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("cartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isFulfilled")
                        .HasColumnType("bit");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("lineItemId");

                    b.HasIndex("cartId");

                    b.HasIndex("productId");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PublicPrice")
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WarningId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId");

                    b.HasIndex("ImageId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WarningId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Suppliers.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Warnings.Warning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Warnings");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Cart", b =>
                {
                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Customers.Customer", b =>
                {
                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Customers.Address", "address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Address");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Customers.CustomerName", "customerName", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CustomerName");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Customers.Pharma", "pharma", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Pharma");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Customers.ValueObject.PhoneNumber", "Phone", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Phone")
                        .IsRequired();

                    b.Navigation("address")
                        .IsRequired();

                    b.Navigation("customerName")
                        .IsRequired();

                    b.Navigation("pharma")
                        .IsRequired();
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.LineItem", b =>
                {
                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Cart", "Cart")
                        .WithMany("lineItems")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Product", b =>
                {
                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Images.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Warnings.Warning", "Warning")
                        .WithMany()
                        .HasForeignKey("WarningId");

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject.CompanyName", "companyName", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CompanyName");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject.Description", "description", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject.Price", "price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Value")
                                .HasColumnType("float")
                                .HasColumnName("Price");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject.Supplier", "supplier", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Supplier");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.ValueObject.ProductName", "name", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ProductName");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Image");

                    b.Navigation("Supplier");

                    b.Navigation("Warning");

                    b.Navigation("companyName")
                        .IsRequired();

                    b.Navigation("description")
                        .IsRequired();

                    b.Navigation("name")
                        .IsRequired();

                    b.Navigation("price")
                        .IsRequired();

                    b.Navigation("supplier")
                        .IsRequired();
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Suppliers.Supplier", b =>
                {
                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject.SupplierAddress", "SupplierAddress", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Address");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject.SupplierEmail", "SupplierEmail", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject.SupplierFirstName", "SupplierFirstName", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject.SupplierLastName", "SupplierLastName", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject.SupplierName", "SupplierName", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject.UserId", "UserId", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserId");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Suppliers");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.Navigation("SupplierAddress")
                        .IsRequired();

                    b.Navigation("SupplierEmail")
                        .IsRequired();

                    b.Navigation("SupplierFirstName")
                        .IsRequired();

                    b.Navigation("SupplierLastName")
                        .IsRequired();

                    b.Navigation("SupplierName")
                        .IsRequired();

                    b.Navigation("UserId")
                        .IsRequired();
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Warnings.Warning", b =>
                {
                    b.HasOne("AlkinanaPharmaManagment.Domain.Entities.Images.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Cart", b =>
                {
                    b.Navigation("lineItems");
                });

            modelBuilder.Entity("AlkinanaPharmaManagment.Domain.Entities.Suppliers.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
