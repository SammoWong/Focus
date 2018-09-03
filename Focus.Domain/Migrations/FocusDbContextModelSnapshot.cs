﻿// <auto-generated />
using System;
using Focus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Focus.Domain.Migrations
{
    [DbContext(typeof(FocusDbContext))]
    partial class FocusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Focus.Domain.Entities.Article", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<byte>("Category")
                        .HasColumnName("Category");

                    b.Property<string>("Content")
                        .HasColumnName("Content")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsTop")
                        .HasColumnName("IsTop");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Title")
                        .HasColumnName("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Button", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("Code")
                        .HasColumnName("Code")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<string>("Icon")
                        .HasColumnName("Icon")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("JsEvent")
                        .HasColumnName("JsEvent")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("ModuleId")
                        .HasColumnName("ModuleId")
                        .HasMaxLength(36);

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnName("Remark")
                        .HasMaxLength(512);

                    b.Property<int>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.Property<string>("Url")
                        .HasColumnName("Url")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Button");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("Address")
                        .HasColumnName("Address")
                        .HasMaxLength(128);

                    b.Property<string>("Contact")
                        .HasColumnName("Contact")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Creator")
                        .HasColumnName("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(50);

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<string>("FullName")
                        .HasColumnName("FullName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Mobile")
                        .HasColumnName("Mobile")
                        .HasMaxLength(11);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Nature")
                        .HasColumnName("Nature")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("ShortName")
                        .HasColumnName("ShortName")
                        .HasMaxLength(50);

                    b.Property<string>("Website")
                        .HasColumnName("Website")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Focus.Domain.Entities.DictionaryDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnName("Remark")
                        .HasMaxLength(512);

                    b.Property<int?>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.Property<string>("TypeId")
                        .HasColumnName("TypeId")
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("DictionaryDetail");
                });

            modelBuilder.Entity("Focus.Domain.Entities.DictionaryType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("CompanyId")
                        .HasColumnName("CompanyId")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("ParentId")
                        .HasColumnName("ParentId")
                        .HasMaxLength(36);

                    b.Property<string>("Remark")
                        .HasColumnName("Remark")
                        .HasMaxLength(512);

                    b.Property<int?>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("DictionaryType");
                });

            modelBuilder.Entity("Focus.Domain.Entities.File", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Path")
                        .HasColumnName("Path")
                        .HasMaxLength(512);

                    b.Property<byte>("Type")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Module", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<byte>("Category")
                        .HasColumnName("Category");

                    b.Property<string>("Code")
                        .HasColumnName("Code")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyId")
                        .HasColumnName("CompanyId")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<string>("Icon")
                        .HasColumnName("Icon")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<bool?>("IsExpanded")
                        .HasColumnName("IsExpanded");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("ParentId")
                        .HasColumnName("ParentId")
                        .HasMaxLength(36);

                    b.Property<short>("Rank")
                        .HasColumnName("Rank");

                    b.Property<string>("Remark")
                        .HasColumnName("Remark")
                        .HasMaxLength(512);

                    b.Property<int?>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.Property<string>("Url")
                        .HasColumnName("Url")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Organization", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<byte>("Category")
                        .HasColumnName("Category");

                    b.Property<string>("Code")
                        .HasColumnName("Code")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyId")
                        .HasColumnName("CompanyId")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("ParentId")
                        .HasColumnName("ParentId")
                        .HasMaxLength(36);

                    b.Property<int?>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Permission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("AccessId")
                        .HasColumnName("AccessId")
                        .HasMaxLength(36);

                    b.Property<byte>("AccessType")
                        .HasColumnName("AccessType");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("MasterId")
                        .HasColumnName("MasterId")
                        .HasMaxLength(36);

                    b.Property<byte>("MasterType")
                        .HasColumnName("MasterType");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<int?>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Position", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("CompanyId")
                        .HasColumnName("CompanyId")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DepartmentId")
                        .HasColumnName("DepartmentId")
                        .HasMaxLength(36);

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnName("Remark")
                        .HasMaxLength(512);

                    b.Property<int?>("SortNumber")
                        .HasColumnName("SortNumber");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("Code")
                        .HasColumnName("Code")
                        .HasMaxLength(36);

                    b.Property<string>("CompanyId")
                        .HasColumnName("CompanyId")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasMaxLength(512);

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Focus.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(36);

                    b.Property<string>("Account")
                        .HasColumnName("Account")
                        .HasMaxLength(50);

                    b.Property<string>("Avatar")
                        .HasColumnName("Avatar")
                        .HasMaxLength(512);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnName("Birthday")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CompanyId")
                        .HasColumnName("CompanyId")
                        .HasMaxLength(36);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnName("CreatedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DeletedBy")
                        .HasColumnName("DeletedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnName("DeletedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DepartmentId")
                        .HasColumnName("DepartmentId")
                        .HasMaxLength(36);

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(50);

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled");

                    b.Property<byte?>("Gender")
                        .HasColumnName("Gender");

                    b.Property<string>("IdCard")
                        .HasColumnName("IdCard")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Mobile")
                        .HasColumnName("Mobile")
                        .HasMaxLength(11);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(36);

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnName("ModifiedTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Password")
                        .HasColumnName("Password")
                        .HasMaxLength(64);

                    b.Property<string>("PositionId")
                        .HasColumnName("PositionId")
                        .HasMaxLength(36);

                    b.Property<string>("RealName")
                        .HasColumnName("RealName")
                        .HasMaxLength(50);

                    b.Property<string>("RoleId")
                        .HasColumnName("RoleId")
                        .HasMaxLength(36);

                    b.Property<string>("Salt")
                        .HasColumnName("Salt")
                        .HasMaxLength(64);

                    b.Property<string>("WorkgroupId")
                        .HasColumnName("WorkgroupId")
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkgroupId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Button", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Module", "Module")
                        .WithMany("Buttons")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.DictionaryDetail", b =>
                {
                    b.HasOne("Focus.Domain.Entities.DictionaryType", "DictionaryType")
                        .WithMany("DictionaryDetails")
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.DictionaryType", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Company", "Company")
                        .WithMany("DictionaryTypes")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Module", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Company", "Company")
                        .WithMany("Modules")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Organization", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Company", "Company")
                        .WithMany("Organizations")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Position", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Company", "Company")
                        .WithMany("Positions")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Focus.Domain.Entities.Organization", "Organization")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.Role", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Company", "Company")
                        .WithMany("Roles")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Focus.Domain.Entities.User", b =>
                {
                    b.HasOne("Focus.Domain.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Focus.Domain.Entities.Position", "Position")
                        .WithMany("Users")
                        .HasForeignKey("PositionId");

                    b.HasOne("Focus.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("Focus.Domain.Entities.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("WorkgroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
