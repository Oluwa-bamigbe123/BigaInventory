﻿// <auto-generated />
using System;
using LocalBetBiga.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocalBetBiga.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LocalBetBiga.Models.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(72)")
                        .HasMaxLength(72);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.AdminEquipmentDistribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("text");

                    b.Property<int>("EquipmentsId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("ManagerUserName")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfEquipmentAssigned")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EquipmentsId");

                    b.HasIndex("ManagerId");

                    b.ToTable("AdminEquipmentDistribution");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.AdminHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime");

                    b.Property<string>("EquipmentName")
                        .HasColumnType("text");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfEquipmentAssigned")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ManagerId");

                    b.ToTable("AdminHistories");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.Equipments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(72)")
                        .HasMaxLength(72);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.ManagerEquipmentDistribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfAgentAssignedTo")
                        .HasColumnType("text");

                    b.Property<string>("NameOfEquipmentAssigned")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfEquipmentAssigned")
                        .HasColumnType("int");

                    b.Property<string>("ShopAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("ManagerEquipmentDistribution");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.ManagerHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AgentAddress")
                        .HasColumnType("text");

                    b.Property<string>("AgentName")
                        .HasColumnType("text");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("ManagerHistories");
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.AdminEquipmentDistribution", b =>
                {
                    b.HasOne("LocalBetBiga.Models.Entities.Admin", "Admin")
                        .WithMany("EquipmentDistribution")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalBetBiga.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalBetBiga.Models.Entities.Equipments", "Equipments")
                        .WithMany()
                        .HasForeignKey("EquipmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalBetBiga.Models.Entities.Manager", "Manager")
                        .WithMany("AdminEquipmentDistribution")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.AdminHistory", b =>
                {
                    b.HasOne("LocalBetBiga.Models.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalBetBiga.Models.Entities.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.Equipments", b =>
                {
                    b.HasOne("LocalBetBiga.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.ManagerEquipmentDistribution", b =>
                {
                    b.HasOne("LocalBetBiga.Models.Entities.Manager", "Manager")
                        .WithMany("ManagerEquipmentDistribution")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalBetBiga.Models.Entities.ManagerHistory", b =>
                {
                    b.HasOne("LocalBetBiga.Models.Entities.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
