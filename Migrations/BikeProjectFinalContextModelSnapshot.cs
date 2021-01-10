﻿// <auto-generated />
using System;
using BikeProjectFinal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeProjectFinal.Migrations
{
    [DbContext(typeof(BikeProjectFinalContext))]
    partial class BikeProjectFinalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeProjectFinal.Model.Bike", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("ProviderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RestockDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Bike");
                });

            modelBuilder.Entity("BikeProjectFinal.Model.BikeType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BikeID")
                        .HasColumnType("int");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BikeID");

                    b.HasIndex("TypeID");

                    b.ToTable("BikeType");
                });

            modelBuilder.Entity("BikeProjectFinal.Model.Provider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProviderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("BikeProjectFinal.Model.Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("BikeProjectFinal.Model.Bike", b =>
                {
                    b.HasOne("BikeProjectFinal.Model.Provider", "Provider")
                        .WithMany("Bikes")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeProjectFinal.Model.BikeType", b =>
                {
                    b.HasOne("BikeProjectFinal.Model.Bike", "Bike")
                        .WithMany("BikeTypes")
                        .HasForeignKey("BikeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeProjectFinal.Model.Type", "Type")
                        .WithMany("Biketypes")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
