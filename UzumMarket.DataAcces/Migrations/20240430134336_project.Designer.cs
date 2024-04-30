﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UzumMarket.DataAcces.AppDBContexts;

#nullable disable

namespace UzumMarket.DataAcces.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240430134336_project")]
    partial class project
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UzumMarket.Domain.Entity.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IsCreated")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("UsersId")
                        .HasColumnType("integer");

                    b.Property<int?>("UsersId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UsersId");

                    b.HasIndex("UsersId1");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("UzumMarket.Domain.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("IsCreated")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<int?>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("UzumMarket.Domain.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IsCreated")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UzumMarket.Domain.Entity.Item", b =>
                {
                    b.HasOne("UzumMarket.Domain.Entity.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("UzumMarket.Domain.Entity.Users", null)
                        .WithMany("ShoppingCart")
                        .HasForeignKey("UsersId");

                    b.HasOne("UzumMarket.Domain.Entity.Users", null)
                        .WithMany("Wishlist")
                        .HasForeignKey("UsersId1");
                });

            modelBuilder.Entity("UzumMarket.Domain.Entity.Order", b =>
                {
                    b.HasOne("UzumMarket.Domain.Entity.Users", null)
                        .WithMany("OrderHistory")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("UzumMarket.Domain.Entity.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("UzumMarket.Domain.Entity.Users", b =>
                {
                    b.Navigation("OrderHistory");

                    b.Navigation("ShoppingCart");

                    b.Navigation("Wishlist");
                });
#pragma warning restore 612, 618
        }
    }
}
