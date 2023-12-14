﻿// <auto-generated />
using System;
using BookStoreAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231214082856_3emigr")]
    partial class _3emigr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Auteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Auteur");
                });

            modelBuilder.Entity("BookStoreAPI.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenresId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookStoreAPI.Entities.Book", b =>
                {
                    b.HasOne("Auteur", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Genres", "Genres")
                        .WithMany()
                        .HasForeignKey("GenresId");

                    b.Navigation("Author");

                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}