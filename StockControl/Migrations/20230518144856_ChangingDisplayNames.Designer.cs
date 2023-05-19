﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockControl.Models;

#nullable disable

namespace StockControl.Migrations
{
    [DbContext(typeof(StockControlContext))]
    [Migration("20230518144856_ChangingDisplayNames")]
    partial class ChangingDisplayNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockControl.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"), 1L, 1);

                    b.Property<string>("DepartmentDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("StockControl.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("GradeLevel")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("StockControl.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("money");

                    b.Property<int?>("SupplierID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("date");

                    b.Property<string>("PurchaseOrderProgress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("PurchaseOrderSubtotal")
                        .HasColumnType("money");

                    b.Property<decimal?>("PurchaseOrderTotal")
                        .HasColumnType("money");

                    b.Property<int?>("RequestID")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("RequestID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Purchase_Order");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Order_Detail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("Purchase_Order_Detail");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"), 1L, 1);

                    b.Property<int?>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("PurchaseRequestStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("PurchaseRequestSubtotal")
                        .HasColumnType("money");

                    b.Property<decimal?>("PurchaseRequestTotal")
                        .HasColumnType("money");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("date");

                    b.HasKey("RequestID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Purchase_Request");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Request_Detail", b =>
                {
                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("ProductID");

                    b.ToTable("Purchase_Request_Detail");
                });

            modelBuilder.Entity("StockControl.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"), 1L, 1);

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("SupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupplierUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("StockControl.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("StockControl.Models.Employee", b =>
                {
                    b.HasOne("StockControl.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockControl.Models.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("StockControl.Models.Employee", "EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StockControl.Models.Product", b =>
                {
                    b.HasOne("StockControl.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Order", b =>
                {
                    b.HasOne("StockControl.Models.Purchase_Request", "Purchase_Request")
                        .WithMany("Purchase_Order")
                        .HasForeignKey("RequestID");

                    b.HasOne("StockControl.Models.Supplier", "Supplier")
                        .WithMany("Purchase_Order")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase_Request");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Order_Detail", b =>
                {
                    b.HasOne("StockControl.Models.Purchase_Order", "Purchase_Order")
                        .WithOne("Purchase_Order_Detail")
                        .HasForeignKey("StockControl.Models.Purchase_Order_Detail", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockControl.Models.Product", "Product")
                        .WithMany("Purchase_Order_Detail")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase_Order");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Request", b =>
                {
                    b.HasOne("StockControl.Models.Employee", "Employee")
                        .WithMany("Purchase_Request")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Request_Detail", b =>
                {
                    b.HasOne("StockControl.Models.Product", "Product")
                        .WithMany("Purchase_Request_Detail")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockControl.Models.Purchase_Request", "Purchase_Request")
                        .WithOne("Purchase_Request_Detail")
                        .HasForeignKey("StockControl.Models.Purchase_Request_Detail", "RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Purchase_Request");
                });

            modelBuilder.Entity("StockControl.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("StockControl.Models.Employee", b =>
                {
                    b.Navigation("Purchase_Request");
                });

            modelBuilder.Entity("StockControl.Models.Product", b =>
                {
                    b.Navigation("Purchase_Order_Detail");

                    b.Navigation("Purchase_Request_Detail");
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Order", b =>
                {
                    b.Navigation("Purchase_Order_Detail")
                        .IsRequired();
                });

            modelBuilder.Entity("StockControl.Models.Purchase_Request", b =>
                {
                    b.Navigation("Purchase_Order");

                    b.Navigation("Purchase_Request_Detail")
                        .IsRequired();
                });

            modelBuilder.Entity("StockControl.Models.Supplier", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Purchase_Order");
                });

            modelBuilder.Entity("StockControl.Models.User", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}