﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ams.infrastructure;

#nullable disable

namespace ams.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ams.domain.Assets.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AssignedTo")
                        .HasColumnType("uuid")
                        .HasColumnName("assigned_to");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<string>("PONumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("po_number");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("serial_number");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_assets");

                    b.HasIndex("AssignedTo")
                        .HasDatabaseName("ix_assets_assigned_to");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_assets_item_id");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_assets_project_id");

                    b.ToTable("assets", (string)null);
                });

            modelBuilder.Entity("ams.domain.Employees.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentDepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("parent_department_id");

                    b.HasKey("Id")
                        .HasName("pk_departments");

                    b.HasIndex("ParentDepartmentId")
                        .HasDatabaseName("ix_departments_parent_department_id");

                    b.ToTable("departments", (string)null);
                });

            modelBuilder.Entity("ams.domain.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<DateOnly?>("DOJ")
                        .HasColumnType("date")
                        .HasColumnName("doj");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<Guid?>("EmployeeCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_category_id");

                    b.Property<Guid?>("EmployeePositionId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_position_id");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mobile");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<Guid?>("NationalityId")
                        .HasColumnType("uuid")
                        .HasColumnName("nationality_id");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<Guid?>("SponsorId")
                        .HasColumnType("uuid")
                        .HasColumnName("sponsor_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_employees_department_id");

                    b.HasIndex("EmployeeCategoryId")
                        .HasDatabaseName("ix_employees_employee_category_id");

                    b.HasIndex("EmployeePositionId")
                        .HasDatabaseName("ix_employees_employee_position_id");

                    b.HasIndex("NationalityId")
                        .HasDatabaseName("ix_employees_nationality_id");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_employees_project_id");

                    b.HasIndex("SponsorId")
                        .HasDatabaseName("ix_employees_sponsor_id");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("ams.domain.Employees.EmployeeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_employee_catogories");

                    b.ToTable("employee_catogories", (string)null);
                });

            modelBuilder.Entity("ams.domain.Employees.EmployeePosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_employee_positions");

                    b.ToTable("employee_positions", (string)null);
                });

            modelBuilder.Entity("ams.domain.Employees.Nationality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_nationalities");

                    b.ToTable("nationalities", (string)null);
                });

            modelBuilder.Entity("ams.domain.Employees.Sponsor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_sponsors");

                    b.ToTable("sponsors", (string)null);
                });

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

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

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

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_item_receipt_details_item_id");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

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

                    b.HasIndex("ItemCategoryId")
                        .HasDatabaseName("ix_items_item_category_id");

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

                    b.HasIndex("ParentItemCategoryId")
                        .HasDatabaseName("ix_item_categories_parent_item_category_id");

                    b.ToTable("item_categories", (string)null);
                });

            modelBuilder.Entity("ams.domain.Licenses.License", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<DateOnly?>("ExpirationDate")
                        .HasColumnType("date")
                        .HasColumnName("expiration_date");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.Property<string>("PONumber")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("po_number");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<DateOnly?>("PurchasedDate")
                        .HasColumnType("date")
                        .HasColumnName("purchased_date");

                    b.Property<int>("TotalLicenses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("total_licenses");

                    b.HasKey("Id")
                        .HasName("pk_licenses");

                    b.ToTable("licenses", (string)null);
                });

            modelBuilder.Entity("ams.domain.Projects.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTimeOffset>("CreationDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_projects");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("ams.domain.Assets.Asset", b =>
                {
                    b.HasOne("ams.domain.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("AssignedTo")
                        .HasConstraintName("fk_assets_employee_assigned_to");

                    b.HasOne("ams.domain.Items.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .HasConstraintName("fk_assets_item_item_id");

                    b.HasOne("ams.domain.Projects.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("fk_assets_project_project_id");
                });

            modelBuilder.Entity("ams.domain.Employees.Department", b =>
                {
                    b.HasOne("ams.domain.Employees.Department", null)
                        .WithMany()
                        .HasForeignKey("ParentDepartmentId")
                        .HasConstraintName("fk_departments_departments_parent_department_id");
                });

            modelBuilder.Entity("ams.domain.Employees.Employee", b =>
                {
                    b.HasOne("ams.domain.Employees.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_employees_departments_department_id");

                    b.HasOne("ams.domain.Employees.EmployeeCategory", null)
                        .WithMany()
                        .HasForeignKey("EmployeeCategoryId")
                        .HasConstraintName("fk_employees_employee_catogories_employee_category_id");

                    b.HasOne("ams.domain.Employees.EmployeePosition", null)
                        .WithMany()
                        .HasForeignKey("EmployeePositionId")
                        .HasConstraintName("fk_employees_employee_position_employee_position_id");

                    b.HasOne("ams.domain.Employees.Nationality", null)
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .HasConstraintName("fk_employees_nationality_nationality_id");

                    b.HasOne("ams.domain.Projects.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("fk_employees_project_project_id");

                    b.HasOne("ams.domain.Employees.Sponsor", null)
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .HasConstraintName("fk_employees_sponsor_sponsor_id");
                });

            modelBuilder.Entity("ams.domain.ItemReceipts.ItemReceiptDetail", b =>
                {
                    b.HasOne("ams.domain.Items.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_receipt_details_items_item_id");

                    b.HasOne("ams.domain.ItemReceipts.ItemReceipt", null)
                        .WithMany("Details")
                        .HasForeignKey("ItemReceiptId")
                        .HasConstraintName("fk_item_receipt_details_item_receipts_item_receipt_id");
                });

            modelBuilder.Entity("ams.domain.Items.Item", b =>
                {
                    b.HasOne("ams.domain.Items.ItemCategory", null)
                        .WithMany()
                        .HasForeignKey("ItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_items_item_categories_item_category_id");
                });

            modelBuilder.Entity("ams.domain.Items.ItemCategory", b =>
                {
                    b.HasOne("ams.domain.Items.ItemCategory", null)
                        .WithMany()
                        .HasForeignKey("ParentItemCategoryId")
                        .HasConstraintName("fk_item_categories_item_categories_parent_item_category_id");
                });

            modelBuilder.Entity("ams.domain.ItemReceipts.ItemReceipt", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
