﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using muhasebe22.Data;

#nullable disable

namespace muhasebe22.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("muhasebe22.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("kul")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sifre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("muhasebe22.Models.idare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adsoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("okulId")
                        .HasColumnType("int");

                    b.Property<string>("sinif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tcno")
                        .HasColumnType("int");

                    b.Property<string>("unvan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("okulId");

                    b.ToTable("idares");
                });

            modelBuilder.Entity("muhasebe22.Models.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adsoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("okulId")
                        .HasColumnType("int");

                    b.Property<string>("sinif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tcno")
                        .HasColumnType("int");

                    b.Property<string>("unvan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("okulId");

                    b.ToTable("ogrencis");
                });

            modelBuilder.Entity("muhasebe22.Models.ogretmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adsoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("okulId")
                        .HasColumnType("int");

                    b.Property<string>("sinif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tcno")
                        .HasColumnType("int");

                    b.Property<string>("unvan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("okulId");

                    b.ToTable("ogretmens");
                });

            modelBuilder.Entity("muhasebe22.Models.okul", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("okulKodu")
                        .HasColumnType("int");

                    b.Property<int?>("vergino")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("okuls");
                });

            modelBuilder.Entity("muhasebe22.Models.idare", b =>
                {
                    b.HasOne("muhasebe22.Models.okul", "okul")
                        .WithMany("idares")
                        .HasForeignKey("okulId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("okul");
                });

            modelBuilder.Entity("muhasebe22.Models.Ogrenci", b =>
                {
                    b.HasOne("muhasebe22.Models.okul", "okul")
                        .WithMany("Ogrencis")
                        .HasForeignKey("okulId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("okul");
                });

            modelBuilder.Entity("muhasebe22.Models.ogretmen", b =>
                {
                    b.HasOne("muhasebe22.Models.okul", "okul")
                        .WithMany("ogretmens")
                        .HasForeignKey("okulId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("okul");
                });

            modelBuilder.Entity("muhasebe22.Models.okul", b =>
                {
                    b.Navigation("Ogrencis");

                    b.Navigation("idares");

                    b.Navigation("ogretmens");
                });
#pragma warning restore 612, 618
        }
    }
}
