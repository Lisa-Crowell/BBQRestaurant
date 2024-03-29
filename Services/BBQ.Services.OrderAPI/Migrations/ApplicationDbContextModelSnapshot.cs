﻿// <auto-generated />
using System;
using BBQ.Services.OrderAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BBQ.Services.OrderAPI.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BBQ.Services.OrderAPI.Models.OrderHeader", b =>
                {
                    b.Property<int>("OrderHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CVV")
                        .HasColumnType("longtext");

                    b.Property<string>("CardNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("CartTotalItems")
                        .HasColumnType("int");

                    b.Property<string>("CouponCode")
                        .HasColumnType("longtext");

                    b.Property<double>("DiscountTotal")
                        .HasColumnType("double");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("ExpiryMonthYear")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("double");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PickupDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("OrderHeaderId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("BBQ.Services.OrderAPI.Models.OrderDetails", b =>
                {
                    b.HasOne("BBQ.Services.OrderAPI.Models.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("BBQ.Services.OrderAPI.Models.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
