﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingAppApi.Data;

namespace WeddingAppApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220330214654_updateguest")]
    partial class updateguest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WeddingAppApi.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("WeddingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeddingId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeddingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("budget")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeddingId")
                        .IsUnique();

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BudgetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diet")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Response")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Seatid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Side")
                        .HasColumnType("TEXT");

                    b.Property<int>("WeddingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeddingId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diet")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Response")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeddingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Preparation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("WeddingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeddingId");

                    b.ToTable("Preparations");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Seating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeddingId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("layoutjson")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("WeddingId")
                        .IsUnique();

                    b.ToTable("Seating");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Spending", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Spendings");
                });

            modelBuilder.Entity("WeddingAppApi.Models.SubPreparation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreparationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PreparationId");

                    b.ToTable("SubPreparations");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Wedding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingAppApi.Models.AppUser", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Wedding", "Wedding")
                        .WithOne("AppUser")
                        .HasForeignKey("WeddingAppApi.Models.AppUser", "WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Budget", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Wedding", "Wedding")
                        .WithOne("Budget")
                        .HasForeignKey("WeddingAppApi.Models.Budget", "WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Category", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Budget", "Budget")
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Guest", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Wedding", "Wedding")
                        .WithMany("Guests")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Invitation", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Guest", "Guest")
                        .WithMany("Invitations")
                        .HasForeignKey("GuestId");

                    b.HasOne("WeddingAppApi.Models.Wedding", "Wedding")
                        .WithMany()
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Preparation", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Wedding", "Wedding")
                        .WithMany("Preparations")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Seating", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Wedding", "Wedding")
                        .WithOne("Seating")
                        .HasForeignKey("WeddingAppApi.Models.Seating", "WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Spending", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Category", "Category")
                        .WithMany("Spendings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WeddingAppApi.Models.SubPreparation", b =>
                {
                    b.HasOne("WeddingAppApi.Models.Preparation", "Preparation")
                        .WithMany("SubPreparations")
                        .HasForeignKey("PreparationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preparation");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Budget", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Category", b =>
                {
                    b.Navigation("Spendings");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Guest", b =>
                {
                    b.Navigation("Invitations");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Preparation", b =>
                {
                    b.Navigation("SubPreparations");
                });

            modelBuilder.Entity("WeddingAppApi.Models.Wedding", b =>
                {
                    b.Navigation("AppUser");

                    b.Navigation("Budget");

                    b.Navigation("Guests");

                    b.Navigation("Preparations");

                    b.Navigation("Seating");
                });
#pragma warning restore 612, 618
        }
    }
}
