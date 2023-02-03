﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RealEstate.Data.Context;

#nullable disable

namespace RealEstate.Data.Migrations.ContractsDB
{
    [DbContext(typeof(ContractsDBContext))]
    [Migration("20230119144342_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Clients.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUser_Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Client_Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contact_Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Contact_Time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Estate_Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("Client_Id")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Contracts.Contract", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Client_Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contract_Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Contract_Type_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date_Signed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Employee_Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Fee_Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Fee_Percentage")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Number_Of_Invoices")
                        .HasColumnType("integer");

                    b.Property<decimal>("Payment_Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Payment_Frequency_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Transaction_Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Contracts.Contract_Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contract_Invoice_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Contract_Invoices");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Contracts.Contract_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contract_Type_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Fee_Percentage")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Contract_Type");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Contracts.Payment_Frequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Payment_Frequency_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Payment_Frequencies");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Contracts.Under_Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Contract_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Estate_Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Under_Contracts");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Clients.Client", b =>
                {
                    b.HasBaseType("RealEstate.Models.Entities.Identity.ApplicationUser");

                    b.Property<string>("Client_Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Client_Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Client_Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Client_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contact_Person")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Time_Created")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.HasOne("RealEstate.Models.Entities.Clients.Client", null)
                        .WithMany("Roles")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Clients.Contact", b =>
                {
                    b.HasOne("RealEstate.Models.Entities.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Models.Entities.Clients.Client", "Client")
                        .WithOne("Contact")
                        .HasForeignKey("RealEstate.Models.Entities.Clients.Contact", "Client_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Contracts.Contract", b =>
                {
                    b.HasOne("RealEstate.Models.Entities.Clients.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("Client_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("RealEstate.Models.Entities.Clients.Client", b =>
                {
                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Contracts");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
