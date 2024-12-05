﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp_aspnetcorenine.Data;

#nullable disable

namespace MyApp_aspnetcorenine.Migrations
{
    [DbContext(typeof(MyAppDataContext))]
    [Migration("20241205211255_one to one")]
    partial class onetoone
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyApp_aspnetcorenine.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SerialNumberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Name = "MicroPhone",
                            Price = 50.0,
                            SerialNumberId = 2
                        });
                });

            modelBuilder.Entity("MyApp_aspnetcorenine.Models.SerialNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique()
                        .HasFilter("[ItemId] IS NOT NULL");

                    b.ToTable("SerialNumbers");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ItemId = 4,
                            Name = "MICRO23"
                        });
                });

            modelBuilder.Entity("MyApp_aspnetcorenine.Models.SerialNumber", b =>
                {
                    b.HasOne("MyApp_aspnetcorenine.Models.Item", "Item")
                        .WithOne("SerialNumber")
                        .HasForeignKey("MyApp_aspnetcorenine.Models.SerialNumber", "ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("MyApp_aspnetcorenine.Models.Item", b =>
                {
                    b.Navigation("SerialNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
