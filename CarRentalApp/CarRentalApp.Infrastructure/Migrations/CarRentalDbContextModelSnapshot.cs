﻿// <auto-generated />
using System;
using CarRentalApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentalApp.Infrastructure.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    partial class CarRentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30");

            modelBuilder.Entity("CarRentalApp.Domain.Models.Automovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Ano_Fabrico")
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProprietarioId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Thumb")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Automoveis");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NrDias")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumContrato")
                        .HasColumnType("INTEGER");

                    b.Property<float>("PrecoDia")
                        .HasColumnType("REAL");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("ValSeguro")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.ContratoAutomovel", b =>
                {
                    b.Property<int>("ContratoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AutomovelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContratoId", "AutomovelId");

                    b.HasIndex("AutomovelId");

                    b.ToTable("ContratoAutomoveis");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.Localidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodPostal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("LocalidadeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nif")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.UserProprietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Cota")
                        .HasColumnType("REAL");

                    b.Property<int>("EnderecoUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoUserId")
                        .IsUnique();

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.Automovel", b =>
                {
                    b.HasOne("CarRentalApp.Domain.Models.Categoria", "Categoria")
                        .WithMany("Automoveis")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarRentalApp.Domain.Models.UserProprietario", "Proprietario")
                        .WithMany("Automoveis")
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.Contrato", b =>
                {
                    b.HasOne("CarRentalApp.Domain.Models.User", "User")
                        .WithMany("Contratos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.ContratoAutomovel", b =>
                {
                    b.HasOne("CarRentalApp.Domain.Models.Automovel", "Automovel")
                        .WithMany("ContratoAutomoveis")
                        .HasForeignKey("AutomovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalApp.Domain.Models.Contrato", "Contrato")
                        .WithMany("ContratoAutomoveis")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.User", b =>
                {
                    b.HasOne("CarRentalApp.Domain.Models.Localidade", "Localidade")
                        .WithMany("Users")
                        .HasForeignKey("LocalidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentalApp.Domain.Models.UserProprietario", b =>
                {
                    b.HasOne("CarRentalApp.Domain.Models.User", "User")
                        .WithOne("Proprietario")
                        .HasForeignKey("CarRentalApp.Domain.Models.UserProprietario", "EnderecoUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
