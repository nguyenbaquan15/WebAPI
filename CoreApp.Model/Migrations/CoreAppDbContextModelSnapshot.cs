﻿// <auto-generated />
using System;
using CoreApp.Model.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreApp.Model.Migrations
{
    [DbContext(typeof(CoreAppDbContext))]
    partial class CoreAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApp.Model.Entity.BookingOffice", b =>
                {
                    b.Property<int>("BookingOfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("BookingOfficeId");

                    b.HasIndex("TripId");

                    b.ToTable("BookingOffices");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Car", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CarColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PackingLotId")
                        .HasColumnType("int");

                    b.HasKey("LicensePlate");

                    b.HasIndex("PackingLotId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.PackingLot", b =>
                {
                    b.Property<int>("PackingLotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Packinglot")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PackingLotId");

                    b.ToTable("PackingLotS");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("LicensePlate");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaximumOnlineTicket")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.ToTable("TripS");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.BookingOffice", b =>
                {
                    b.HasOne("CoreApp.Model.Entity.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Car", b =>
                {
                    b.HasOne("CoreApp.Model.Entity.PackingLot", "PackingLot")
                        .WithMany()
                        .HasForeignKey("PackingLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackingLot");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Ticket", b =>
                {
                    b.HasOne("CoreApp.Model.Entity.Car", "Car")
                        .WithMany("Tickets")
                        .HasForeignKey("LicensePlate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreApp.Model.Entity.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Car", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
