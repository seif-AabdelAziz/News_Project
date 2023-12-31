﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.DAL;

#nullable disable

namespace News.DAL.Migrations
{
    [DbContext(typeof(NewsContext))]
    [Migration("20230620182716_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("News.DAL.Author", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = new Guid("1815b750-4fd6-466b-b9d1-90144cd17b6b"),
                            Bio = "",
                            Name = "Seif"
                        },
                        new
                        {
                            ID = new Guid("dea9b0df-f895-414e-a87f-28b2f08b7aed"),
                            Bio = "",
                            Name = "Ahmed"
                        },
                        new
                        {
                            ID = new Guid("dbb55392-b5a5-44e7-b3e8-3e8d9d9487da"),
                            Bio = "",
                            Name = "Hossam"
                        },
                        new
                        {
                            ID = new Guid("86aa4da3-e79f-4bfe-bbf8-608f2e20fd93"),
                            Bio = "",
                            Name = "Karim"
                        },
                        new
                        {
                            ID = new Guid("f38cfb90-82a7-4ad8-938e-f7873f95f0ce"),
                            Bio = "",
                            Name = "Ali"
                        });
                });

            modelBuilder.Entity("News.DAL.News", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            ID = new Guid("f559cdd1-0680-4452-9e7d-a217d548f7cb"),
                            AuthorID = new Guid("1815b750-4fd6-466b-b9d1-90144cd17b6b"),
                            CreationDate = new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5789),
                            ImageUrl = "",
                            NewsDetails = "",
                            Title = "First"
                        },
                        new
                        {
                            ID = new Guid("1f05af74-6ea6-468f-b96f-de04a74dce2d"),
                            AuthorID = new Guid("86aa4da3-e79f-4bfe-bbf8-608f2e20fd93"),
                            CreationDate = new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5846),
                            ImageUrl = "",
                            NewsDetails = "",
                            Title = "Second"
                        },
                        new
                        {
                            ID = new Guid("2f902703-7745-49cd-bf8e-25278c16604b"),
                            AuthorID = new Guid("dbb55392-b5a5-44e7-b3e8-3e8d9d9487da"),
                            CreationDate = new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5852),
                            ImageUrl = "",
                            NewsDetails = "",
                            Title = "Third"
                        },
                        new
                        {
                            ID = new Guid("ab1c0602-5c6b-49c2-92c0-64fa284dc510"),
                            AuthorID = new Guid("dea9b0df-f895-414e-a87f-28b2f08b7aed"),
                            CreationDate = new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5860),
                            ImageUrl = "",
                            NewsDetails = "",
                            Title = "Fourth"
                        },
                        new
                        {
                            ID = new Guid("4d9fdae5-5faa-4111-baad-7a72cc6f3aee"),
                            AuthorID = new Guid("f38cfb90-82a7-4ad8-938e-f7873f95f0ce"),
                            CreationDate = new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5865),
                            ImageUrl = "",
                            NewsDetails = "",
                            Title = "Fifth"
                        });
                });

            modelBuilder.Entity("News.DAL.News", b =>
                {
                    b.HasOne("News.DAL.Author", "Author")
                        .WithMany("News")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("News.DAL.Author", b =>
                {
                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}
