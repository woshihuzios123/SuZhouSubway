﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuZhouSubway.Model.Data;

namespace SuZhouSubway.Model.Migrations
{
    [DbContext(typeof(SubwayDbContext))]
    partial class SubwayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SuZhouSubway.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SuZhouSubway.Model.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Contents");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("Enabled");

                    b.Property<int>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("SuZhouSubway.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<string>("Duties");

                    b.Property<bool>("Enabled");

                    b.Property<string>("HeadPhoto");

                    b.Property<string>("JobNumber");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("SuZhouSubway.Model.Detail", b =>
                {
                    b.HasOne("SuZhouSubway.Model.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
