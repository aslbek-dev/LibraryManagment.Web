﻿// <auto-generated />
using System;
using LibraryManagment.Api.Brokers.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagment.Api.Migrations
{
    [DbContext(typeof(StorageBroker))]
    partial class StorageBrokerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagment.Api.Models.Baskets.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Books.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PublisherAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Rents.Rent", b =>
                {
                    b.Property<Guid>("RentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RentAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RentId");

                    b.HasIndex("BasketId")
                        .IsUnique();

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Users.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Baskets.Basket", b =>
                {
                    b.HasOne("LibraryManagment.Api.Models.Users.User", "User")
                        .WithOne("Basket")
                        .HasForeignKey("LibraryManagment.Api.Models.Baskets.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Books.Book", b =>
                {
                    b.HasOne("LibraryManagment.Api.Models.Baskets.Basket", "Basket")
                        .WithMany("Books")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Rents.Rent", b =>
                {
                    b.HasOne("LibraryManagment.Api.Models.Baskets.Basket", "Basket")
                        .WithOne("Rent")
                        .HasForeignKey("LibraryManagment.Api.Models.Rents.Rent", "BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Baskets.Basket", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("LibraryManagment.Api.Models.Users.User", b =>
                {
                    b.Navigation("Basket");
                });
#pragma warning restore 612, 618
        }
    }
}