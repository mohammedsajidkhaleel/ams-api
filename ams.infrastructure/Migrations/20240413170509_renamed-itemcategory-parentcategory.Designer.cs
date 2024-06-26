﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ams.infrastructure;

#nullable disable

namespace ams.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240413170509_renamed-itemcategory-parentcategory")]
    partial class renameditemcategoryparentcategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ams.domain.Items.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<Guid>("ItemCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_category_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("ams.domain.Items.ItemCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentItemCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("parent_item_category_id");

                    b.HasKey("Id")
                        .HasName("pk_item_categories");

                    b.ToTable("item_categories", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
