﻿// <auto-generated />
using System;
using AT.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AT.Data.Migrations
{
    [DbContext(typeof(TrainerTftDbContext))]
    [Migration("20211026124432_ChampionCardAvatar")]
    partial class ChampionCardAvatar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AT.Data.Models.ChampionCard", b =>
                {
                    b.Property<string>("ChampionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ShopCard")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Traits")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChampionId");

                    b.ToTable("ChampionCard");
                });
#pragma warning restore 612, 618
        }
    }
}
