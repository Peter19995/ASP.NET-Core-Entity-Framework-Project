﻿// <auto-generated />
using EF_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230717084656_seedBookTable")]
    partial class seedBookTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Model.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            ISBN = "123B12",
                            Price = 10.99m,
                            Title = "Spider without Duty"
                        },
                        new
                        {
                            BookId = 2,
                            ISBN = "12S3B12",
                            Price = 11.99m,
                            Title = "Fortune Of Time"
                        },
                        new
                        {
                            BookId = 3,
                            ISBN = "123L",
                            Price = 20.99m,
                            Title = "Fake Sunday"
                        },
                        new
                        {
                            BookId = 4,
                            ISBN = "123M",
                            Price = 25.99m,
                            Title = "Cookie Jar"
                        },
                        new
                        {
                            BookId = 5,
                            ISBN = "123Q",
                            Price = 11.99m,
                            Title = "Cloudy Forest"
                        });
                });

            modelBuilder.Entity("EF_Model.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
