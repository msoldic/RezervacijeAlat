﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RezervacijeAlat.Model;

#nullable disable

namespace RezervacijeAlat.Migrations
{
    [DbContext(typeof(ToolReservationContext))]
    [Migration("20250307120119_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RezervacijeAlat.Model.Tool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PriceRentPerDay")
                        .HasColumnType("int");

                    b.Property<string>("ToolType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("RezervacijeAlat.Model.ToolReservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ClientFirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ClientSecondName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DateReservationFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReservationTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToolID")
                        .HasColumnType("int");

                    b.Property<int>("TotalRentPrice")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ToolID");

                    b.ToTable("ToolReservations");
                });

            modelBuilder.Entity("RezervacijeAlat.Model.ToolReservation", b =>
                {
                    b.HasOne("RezervacijeAlat.Model.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tool");
                });
#pragma warning restore 612, 618
        }
    }
}
