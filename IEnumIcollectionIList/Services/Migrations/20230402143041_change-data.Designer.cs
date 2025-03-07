﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.DataEntity;

#nullable disable

namespace Services.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230402143041_change-data")]
    partial class changedata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("schools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Delhi",
                            Name = "Amit"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Delhi",
                            Name = "Sumit"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Delhi",
                            Name = "Mohan"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Gurgaon",
                            Name = "Ram"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Delhi",
                            Name = "Shyam"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Delhi",
                            Name = "Monika"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
