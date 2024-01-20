﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongStream.Models;

#nullable disable

namespace SongStream.Migrations
{
    [DbContext(typeof(SongDb))]
    partial class SongDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SongStream.Models.Song", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AudioSrc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SongArtist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
