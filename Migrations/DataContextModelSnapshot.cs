﻿// <auto-generated />
using System;
using BeautySolun.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeautySolun.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeautySolun.Models.ProfessionalModel", b =>
                {
                    b.Property<int>("Id_professional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_professional"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_status")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_professional");

                    b.HasIndex("Id_status");

                    b.ToTable("bt_professional");
                });

            modelBuilder.Entity("BeautySolun.Models.ScheduleModel", b =>
                {
                    b.Property<int>("Id_schedule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_schedule"), 1L, 1);

                    b.Property<string>("Client_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Client_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_schedule")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_professional")
                        .HasColumnType("int");

                    b.Property<int>("Id_status")
                        .HasColumnType("int");

                    b.Property<int>("Id_time")
                        .HasColumnType("int");

                    b.Property<double>("Total_price")
                        .HasColumnType("float");

                    b.HasKey("Id_schedule");

                    b.HasIndex("Id_professional");

                    b.HasIndex("Id_status");

                    b.HasIndex("Id_time");

                    b.ToTable("bt_schedule");
                });

            modelBuilder.Entity("BeautySolun.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id_service")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_service"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_status")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id_service");

                    b.HasIndex("Id_status");

                    b.ToTable("bt_service");
                });

            modelBuilder.Entity("BeautySolun.Models.StatusModel", b =>
                {
                    b.Property<int>("Id_status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_status"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_status");

                    b.ToTable("bt_status");
                });

            modelBuilder.Entity("BeautySolun.Models.TimeModel", b =>
                {
                    b.Property<int>("Id_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_time"), 1L, 1);

                    b.Property<string>("time_hhmm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id_time");

                    b.ToTable("bt_time");
                });

            modelBuilder.Entity("BeautySolun.Models.ProfessionalModel", b =>
                {
                    b.HasOne("BeautySolun.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("Id_status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BeautySolun.Models.ScheduleModel", b =>
                {
                    b.HasOne("BeautySolun.Models.ProfessionalModel", "Professional")
                        .WithMany()
                        .HasForeignKey("Id_professional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySolun.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("Id_status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySolun.Models.TimeModel", "time")
                        .WithMany()
                        .HasForeignKey("Id_time")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professional");

                    b.Navigation("Status");

                    b.Navigation("time");
                });

            modelBuilder.Entity("BeautySolun.Models.ServiceModel", b =>
                {
                    b.HasOne("BeautySolun.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("Id_status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}