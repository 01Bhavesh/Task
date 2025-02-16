﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using New_CRUDTask.Server;

#nullable disable

namespace New_CRUDTask.Migrations
{
    [DbContext(typeof(DbContextServer))]
    [Migration("20250216075451_TaskData")]
    partial class TaskData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("New_CRUDTask.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            IsActive = true,
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryId = 2,
                            IsActive = true,
                            Name = "Clothing"
                        });
                });

            modelBuilder.Entity("New_CRUDTask.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("New_CRUDTask.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Pirce")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            IsActive = true,
                            Pirce = 800,
                            ProductName = "Laptop"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            IsActive = true,
                            Pirce = 600,
                            ProductName = "Smartphone"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            IsActive = true,
                            Pirce = 50,
                            ProductName = "Jeans"
                        });
                });

            modelBuilder.Entity("New_CRUDTask.Model.ProductOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quntity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Quntity = 2
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 3,
                            Quntity = 1
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2,
                            Quntity = 1
                        });
                });

            modelBuilder.Entity("New_CRUDTask.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Rohit",
                            Gmail = "RohitSharma@gmail.com",
                            IsActive = true,
                            LastName = "Sharma",
                            Password = "264"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "Virat",
                            Gmail = "ViratKohli@gmail.com",
                            IsActive = true,
                            LastName = "Kohli",
                            Password = "51"
                        });
                });

            modelBuilder.Entity("New_CRUDTask.Model.Order", b =>
                {
                    b.HasOne("New_CRUDTask.Model.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("New_CRUDTask.Model.Product", b =>
                {
                    b.HasOne("New_CRUDTask.Model.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("New_CRUDTask.Model.ProductOrder", b =>
                {
                    b.HasOne("New_CRUDTask.Model.Order", "Orders")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("New_CRUDTask.Model.Product", "Products")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("New_CRUDTask.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("New_CRUDTask.Model.Order", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("New_CRUDTask.Model.Product", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("New_CRUDTask.Model.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
