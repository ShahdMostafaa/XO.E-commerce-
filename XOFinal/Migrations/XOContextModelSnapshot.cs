﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XO_CodeFirst.Model;

namespace XOFinal.Migrations
{
    [DbContext(typeof(XOContext))]
    partial class XOContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XOFinal.Models.Favorite", b =>
                {
                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.HasKey("CustId", "ProdId");

                    b.HasIndex("ProdId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("XOFinal.Models.Report", b =>
                {
                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.HasKey("CustId", "ProdId");

                    b.HasIndex("ProdId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBill")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.Property<string>("ProdTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BillId");

                    b.HasIndex("CustId");

                    b.HasIndex("ProdId")
                        .IsUnique()
                        .HasFilter("[ProdId] IS NOT NULL");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfSignUp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int");

                    b.HasKey("PictureId");

                    b.HasIndex("ProdId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatId")
                        .HasColumnType("int");

                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Negotiable")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CatId");

                    b.HasIndex("CustId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("XOFinal.Models.Favorite", b =>
                {
                    b.HasOne("XO_CodeFirst.Model.Customer", "Cust")
                        .WithMany("Favorites")
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XO_CodeFirst.Model.Product", "Prod")
                        .WithMany("Favorites")
                        .HasForeignKey("ProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cust");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("XOFinal.Models.Report", b =>
                {
                    b.HasOne("XO_CodeFirst.Model.Customer", "Cust")
                        .WithMany("Reports")
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XO_CodeFirst.Model.Product", "Prod")
                        .WithMany("Reports")
                        .HasForeignKey("ProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cust");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Bill", b =>
                {
                    b.HasOne("XO_CodeFirst.Model.Customer", "Cust")
                        .WithMany("Bills")
                        .HasForeignKey("CustId");

                    b.HasOne("XO_CodeFirst.Model.Product", "Prod")
                        .WithOne("Bill")
                        .HasForeignKey("XO_CodeFirst.Model.Bill", "ProdId");

                    b.Navigation("Cust");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Picture", b =>
                {
                    b.HasOne("XO_CodeFirst.Model.Product", "Prod")
                        .WithMany("Pictures")
                        .HasForeignKey("ProdId");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Product", b =>
                {
                    b.HasOne("XO_CodeFirst.Model.Category", "Cat")
                        .WithMany("Products")
                        .HasForeignKey("CatId");

                    b.HasOne("XO_CodeFirst.Model.Customer", "Cust")
                        .WithMany("Products")
                        .HasForeignKey("CustId");

                    b.Navigation("Cat");

                    b.Navigation("Cust");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Favorites");

                    b.Navigation("Products");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("XO_CodeFirst.Model.Product", b =>
                {
                    b.Navigation("Bill");

                    b.Navigation("Favorites");

                    b.Navigation("Pictures");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
