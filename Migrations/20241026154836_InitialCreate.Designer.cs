﻿// <auto-generated />
using System;
using CoworkingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoworkingApi.Migrations
{
    [DbContext(typeof(CoworkingContext))]
    [Migration("20241026154836_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CoworkingApi.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("TEXT");

                    b.Property<int>("SalaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("CoworkingApi.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacidade")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Equipamentos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });
#pragma warning restore 612, 618
        }
    }
}
