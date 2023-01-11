﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MunicipalityProject.Contexts;

namespace DanskeBankMunicipality.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201017144603_Updated-Municipality")]
    partial class UpdatedMunicipality
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DanskeBankMunicipality.Business.Models.Municipality", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Schedule")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TaxRate")
                        .HasColumnType("float");

                    b.HasKey("Name", "Schedule");

                    b.ToTable("Municipalities");
                });
#pragma warning restore 612, 618
        }
    }
}
