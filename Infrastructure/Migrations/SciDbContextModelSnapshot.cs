﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SciDbContext))]
    partial class SciDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Atom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AtomicMass")
                        .HasColumnType("float");

                    b.Property<int>("AtomicNumber")
                        .HasColumnType("int");

                    b.Property<int>("ElectroValency")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atoms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("be1c681e-cce3-4340-b0fd-e72261f0e960"),
                            AtomicMass = 1.008,
                            AtomicNumber = 1,
                            ElectroValency = 1,
                            Name = "Hygrogen",
                            Symbol = "H"
                        },
                        new
                        {
                            Id = new Guid("a1cdb287-8c5f-4a82-b5ac-d2e84bf44230"),
                            AtomicMass = 4.0026000000000002,
                            AtomicNumber = 2,
                            ElectroValency = 0,
                            Name = "Helium",
                            Symbol = "He"
                        },
                        new
                        {
                            Id = new Guid("002d9add-fe1c-4e42-a351-4fd7bdb0a8bc"),
                            AtomicMass = 6.9400000000000004,
                            AtomicNumber = 3,
                            ElectroValency = 1,
                            Name = "Lithium",
                            Symbol = "Li"
                        },
                        new
                        {
                            Id = new Guid("c3e39aaf-9dc1-4966-88e0-f0ab41e2d0a5"),
                            AtomicMass = 9.0122,
                            AtomicNumber = 4,
                            ElectroValency = 2,
                            Name = "Beryllium",
                            Symbol = "Be"
                        },
                        new
                        {
                            Id = new Guid("e7f18280-06ab-4eaa-a23b-65290a308f8a"),
                            AtomicMass = 10.81,
                            AtomicNumber = 5,
                            ElectroValency = 3,
                            Name = "Boron",
                            Symbol = "B"
                        },
                        new
                        {
                            Id = new Guid("27251887-3bca-4fbb-8e06-57b39e495f59"),
                            AtomicMass = 12.010999999999999,
                            AtomicNumber = 6,
                            ElectroValency = 4,
                            Name = "Carbon",
                            Symbol = "C"
                        },
                        new
                        {
                            Id = new Guid("5aaed026-9192-43a7-a3a0-8eaed12cc10d"),
                            AtomicMass = 14.007,
                            AtomicNumber = 7,
                            ElectroValency = 3,
                            Name = "Nitrogen",
                            Symbol = "N"
                        },
                        new
                        {
                            Id = new Guid("be39cc70-5356-440d-8000-bac283cabc7d"),
                            AtomicMass = 15.999000000000001,
                            AtomicNumber = 8,
                            ElectroValency = 2,
                            Name = "Oxygen",
                            Symbol = "O"
                        },
                        new
                        {
                            Id = new Guid("da1197d8-7ba7-455e-ba33-c8293ad7765a"),
                            AtomicMass = 18.998000000000001,
                            AtomicNumber = 9,
                            ElectroValency = 1,
                            Name = "Fluorine",
                            Symbol = "F"
                        },
                        new
                        {
                            Id = new Guid("ef19273e-7bbe-4d90-beb4-17b6cf74a3f5"),
                            AtomicMass = 20.18,
                            AtomicNumber = 10,
                            ElectroValency = 0,
                            Name = "Neon",
                            Symbol = "Ne"
                        },
                        new
                        {
                            Id = new Guid("fb9fad70-1020-43b3-8871-bedd67a5001e"),
                            AtomicMass = 22.989999999999998,
                            AtomicNumber = 11,
                            ElectroValency = 1,
                            Name = "Sodium",
                            Symbol = "Na"
                        },
                        new
                        {
                            Id = new Guid("cda61de0-20e2-4bf3-924d-dc4f1f5cd51c"),
                            AtomicMass = 24.305,
                            AtomicNumber = 12,
                            ElectroValency = 2,
                            Name = "Magnesium",
                            Symbol = "Mg"
                        },
                        new
                        {
                            Id = new Guid("edd390be-4365-4655-ad29-4c6084cd3b15"),
                            AtomicMass = 26.981999999999999,
                            AtomicNumber = 13,
                            ElectroValency = 3,
                            Name = "Aluminium",
                            Symbol = "Al"
                        },
                        new
                        {
                            Id = new Guid("3a59c779-d930-454d-8c5f-3b76896c800c"),
                            AtomicMass = 28.085000000000001,
                            AtomicNumber = 14,
                            ElectroValency = 0,
                            Name = "Silicon",
                            Symbol = "Si"
                        },
                        new
                        {
                            Id = new Guid("47d59787-7aa8-460f-bb62-95fc3006f7af"),
                            AtomicMass = 30.974,
                            AtomicNumber = 15,
                            ElectroValency = 4,
                            Name = "Phosphorus",
                            Symbol = "P"
                        },
                        new
                        {
                            Id = new Guid("4768b422-0faf-4333-9c29-d7bdef9c4966"),
                            AtomicMass = 32.060000000000002,
                            AtomicNumber = 16,
                            ElectroValency = 2,
                            Name = "Sulphur",
                            Symbol = "S"
                        },
                        new
                        {
                            Id = new Guid("e2dc19b7-c857-4beb-8adc-c0519c908bee"),
                            AtomicMass = 35.450000000000003,
                            AtomicNumber = 17,
                            ElectroValency = 1,
                            Name = "Chlorine",
                            Symbol = "Cl"
                        },
                        new
                        {
                            Id = new Guid("f993f6f6-bf55-4a99-afe4-9dd0e63bc64b"),
                            AtomicMass = 39.950000000000003,
                            AtomicNumber = 18,
                            ElectroValency = 0,
                            Name = "Argon",
                            Symbol = "Ar"
                        },
                        new
                        {
                            Id = new Guid("3e9b52b2-3bec-41c6-b181-780eaef1a588"),
                            AtomicMass = 39.097999999999999,
                            AtomicNumber = 19,
                            ElectroValency = 1,
                            Name = "Potassium",
                            Symbol = "K"
                        },
                        new
                        {
                            Id = new Guid("15abd866-b43e-4ca7-877c-3052769598c7"),
                            AtomicMass = 40.078000000000003,
                            AtomicNumber = 20,
                            ElectroValency = 2,
                            Name = "Calcium",
                            Symbol = "Ca"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}