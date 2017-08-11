﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MvcMovie.Models.Database;

namespace MvcMovie.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20170811203304_CommentMigration")]
    partial class CommentMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("MvcMovie.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieID");

                    b.Property<string>("Text")
                        .HasMaxLength(140);

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MvcMovie.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("Price");

                    b.Property<string>("Rating")
                        .HasMaxLength(5);

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .HasMaxLength(60);

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MvcMovie.Models.Comment", b =>
                {
                    b.HasOne("MvcMovie.Models.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
