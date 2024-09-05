﻿// <auto-generated />
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240904213741_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Astrid Lindgren",
                            Description = "Avarable in Swedish",
                            Genre = 6,
                            IsAvailable = true,
                            PublishedYear = 1945,
                            Title = "Pippi Långstrump"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jonas Jonasson",
                            Description = "Avarable in Swedish",
                            Genre = 6,
                            IsAvailable = false,
                            PublishedYear = 2009,
                            Title = "Hundraåringen som klev ut genom fönstret och försvann"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Sven Nordqvist",
                            Description = "Avarable in Swedish, Pettson och Findus",
                            Genre = 6,
                            IsAvailable = true,
                            PublishedYear = 1984,
                            Title = "Pannkakstårtan"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Sven Nordqvist",
                            Description = "Avarable in Swedish, Pettson och Findus",
                            Genre = 6,
                            IsAvailable = true,
                            PublishedYear = 1990,
                            Title = "Kackel i grönsakslandet "
                        },
                        new
                        {
                            Id = 5,
                            Author = "Fredrik Backman",
                            Description = "Avarable in Swedish",
                            Genre = 7,
                            IsAvailable = false,
                            PublishedYear = 2012,
                            Title = "En man som heter Ove"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
