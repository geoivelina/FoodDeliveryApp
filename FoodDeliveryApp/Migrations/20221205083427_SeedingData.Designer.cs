﻿// <auto-generated />
using System;
using FoodDeliveryApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodDeliveryApp.Migrations
{
    [DbContext(typeof(FoodDeliveryAppDbContext))]
    [Migration("20221205083427_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppartmentNumber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Neighbourhood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.CuisineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("CuisineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Indian"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Burgers"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sishi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Asian"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bulgarian"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Arab"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Vegetarian"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Europian"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Fine dine"
                        });
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descriprion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DishImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Salads",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cold appetizers",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pizza",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Salads",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Starters",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "The boxes",
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "Burgers",
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 9,
                            Name = "Nigiri",
                            RestaurantId = 5
                        },
                        new
                        {
                            Id = 10,
                            Name = "Hosomaki",
                            RestaurantId = 5
                        },
                        new
                        {
                            Id = 11,
                            Name = "Uramaki",
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DishId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CuisineTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryCost")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DeliveryTime")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MinOrderAmount")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Rating")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<string>("RestaurantImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingHours")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.HasIndex("CuisineTypeId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CuisineTypeId = 8,
                            DeliveryCost = "Free",
                            DeliveryTime = "20 - 50 min.",
                            Description = "Authentic Italian pizza",
                            MinOrderAmount = "Min. 10.00 lv.",
                            Name = "Genaro`s pizza",
                            Rating = 8.50m,
                            RestaurantImage = "https://tse1.mm.bing.net/th?id=OIP.VIHoNlxPTkXfW2i6DgfIbwHaF7&pid=Api",
                            WorkingHours = "12:00 - 22:00"
                        },
                        new
                        {
                            Id = 2,
                            CuisineTypeId = 1,
                            DeliveryCost = "Free from 30.00 lv.",
                            DeliveryTime = "30 - 50 min.",
                            Description = "Authentic Indian pizza",
                            MinOrderAmount = "Min. 20.00 lv.",
                            Name = "Taj Mahal",
                            Rating = 7.5m,
                            RestaurantImage = "https://tse2.mm.bing.net/th?id=OIP.8gNduGMsG-TnwPqLDlRQVQHaE8&pid=Api",
                            WorkingHours = "11:00 - 23:00"
                        },
                        new
                        {
                            Id = 3,
                            CuisineTypeId = 2,
                            DeliveryCost = "Free from 20.00 lv.",
                            DeliveryTime = "20 - 50 min.",
                            Description = "Best American style burgers",
                            MinOrderAmount = "Min. 20.00 lv.",
                            Name = "Burgers & Fries",
                            Rating = 9.8m,
                            RestaurantImage = "https://tse1.mm.bing.net/th?id=OIP.W0r1nOj-EPrXoziOqjjFPAHaE8&pid=Api",
                            WorkingHours = "11:00 - 23:00"
                        },
                        new
                        {
                            Id = 5,
                            CuisineTypeId = 3,
                            DeliveryCost = "2.99 lv.",
                            DeliveryTime = "30 - 60 min.",
                            Description = "Authentic sushi prepared from our sushi master",
                            MinOrderAmount = "Min. 20.00 lv.",
                            Name = "Kioto sushi",
                            Rating = 7.80m,
                            RestaurantImage = "https://tse3.mm.bing.net/th?id=OIP.2oT2R6wz3DbEm0NIePcJzwHaE_&pid=Api",
                            WorkingHours = "11:00 - 24:00"
                        });
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Address", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDeliveryApp.Data.Entities.Customer", null)
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Dish", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.Menu", "Menu")
                        .WithMany("Dishes")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDeliveryApp.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Menu");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Menu", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Order", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDeliveryApp.Data.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDeliveryApp.Data.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Restaurant", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.CuisineType", "CuisineType")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CuisineType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDeliveryApp.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FoodDeliveryApp.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.CuisineType", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Menu", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("FoodDeliveryApp.Data.Entities.Restaurant", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Menus");
                });
#pragma warning restore 612, 618
        }
    }
}
