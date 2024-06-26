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
    [Migration("20240418204116_added-itemreceipt1")]
    partial class addeditemreceipt1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ams.domain.ItemReceipts.ItemReceipt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ItemReceiptNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("item_receipt_number");

                    b.Property<string>("PONumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("po_number");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_item_receipts");

                    b.HasIndex("ItemReceiptNumber")
                        .IsUnique()
                        .HasDatabaseName("ix_item_receipts_item_receipt_number");

                    b.ToTable("item_receipts", (string)null);
                });

            modelBuilder.Entity("ams.domain.ItemReceipts.ItemReceiptDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<Guid?>("ItemReceiptId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_receipt_id");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_item_receipt_details");

                    b.HasIndex("ItemReceiptId")
                        .HasDatabaseName("ix_item_receipt_details_item_receipt_id");

                    b.ToTable("item_receipt_details", (string)null);
                });

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

            modelBuilder.Entity("ams.domain.ItemReceipts.ItemReceiptDetail", b =>
                {
                    b.HasOne("ams.domain.ItemReceipts.ItemReceipt", null)
                        .WithMany("Details")
                        .HasForeignKey("ItemReceiptId")
                        .HasConstraintName("fk_item_receipt_details_item_receipts_item_receipt_id");
                });

            modelBuilder.Entity("ams.domain.ItemReceipts.ItemReceipt", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
