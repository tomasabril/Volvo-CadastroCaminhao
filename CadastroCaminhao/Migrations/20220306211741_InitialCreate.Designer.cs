﻿// <auto-generated />
using CadastroCaminhao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroCaminhao.Migrations
{
    [DbContext(typeof(CaminhaoContext))]
    [Migration("20220306211741_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("CadastroCaminhao.Models.Caminhao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ModeloCaminhaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Caminhao", (string)null);
                });

            modelBuilder.Entity("CadastroCaminhao.Models.ModeloCaminhao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ModeloCaminhao", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}