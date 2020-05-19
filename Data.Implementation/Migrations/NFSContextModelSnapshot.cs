﻿// <auto-generated />
using System;
using Data.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Implementation.Migrations
{
    [DbContext(typeof(NFSContext))]
    partial class NFSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BatteryId")
                        .HasColumnType("int");

                    b.Property<bool>("CarRide")
                        .HasColumnType("bit");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int?>("MotorId")
                        .HasColumnType("int");

                    b.Property<int?>("RimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.HasIndex("MotorId");

                    b.HasIndex("RimId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Data.Entity.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanFunction")
                        .HasColumnType("bit");

                    b.Property<int>("DetailType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepairCost")
                        .HasColumnType("int");

                    b.Property<int>("RetailCost")
                        .HasColumnType("int");

                    b.Property<double>("Stability")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            CanFunction = true,
                            DetailType = 0,
                            Name = "Basic motor",
                            RepairCost = 120,
                            RetailCost = 230,
                            Stability = 0.59999999999999998
                        },
                        new
                        {
                            Id = 223,
                            CanFunction = true,
                            DetailType = 0,
                            Name = "Avarege Motor MT-20",
                            RepairCost = 150,
                            RetailCost = 290,
                            Stability = 0.71999999999999997
                        },
                        new
                        {
                            Id = 32,
                            CanFunction = true,
                            DetailType = 1,
                            Name = "Gold Rim",
                            RepairCost = 200,
                            RetailCost = 280,
                            Stability = 0.90000000000000002
                        },
                        new
                        {
                            Id = 5,
                            CanFunction = true,
                            DetailType = 2,
                            Name = "Poor Battery YM-49",
                            RepairCost = 120,
                            RetailCost = 80,
                            Stability = 0.5
                        });
                });

            modelBuilder.Entity("Data.Entity.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Cash")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Data.Entity.Car", b =>
                {
                    b.HasOne("Data.Entity.Detail", "Battery")
                        .WithMany()
                        .HasForeignKey("BatteryId");

                    b.HasOne("Data.Entity.Detail", "Motor")
                        .WithMany()
                        .HasForeignKey("MotorId");

                    b.HasOne("Data.Entity.Detail", "Rim")
                        .WithMany()
                        .HasForeignKey("RimId");
                });

            modelBuilder.Entity("Data.Entity.Player", b =>
                {
                    b.HasOne("Data.Entity.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
