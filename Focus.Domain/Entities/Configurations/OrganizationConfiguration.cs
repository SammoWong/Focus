﻿using Focus.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focus.Domain.Entities.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            //设置表名
            builder.ToTable("Organization");

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired().HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.ParentId).HasColumnName("ParentId").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralEntityNameLength);
            builder.Property(e => e.Code).HasColumnName("Code").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Category).HasColumnName("Category");
            builder.Property(e => e.SortNumber).HasColumnName("SortNumber");
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.Enabled).HasColumnName("Enabled");
            builder.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.CreatedTime).HasColumnName("CreatedTime").HasColumnType("DATETIME");
            builder.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(e => e.DeletedBy).HasColumnName("DeletedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.DeletedTime).HasColumnName("DeletedTime").HasColumnType("DATETIME");
            builder.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.ModifiedTime).HasColumnName("ModifiedTime").HasColumnType("DATETIME");

            //设置表之间关系
            builder.HasMany(e => e.Positions).WithOne(e => e.Organization).HasForeignKey(e => e.DepartmentId);
            //builder.HasMany(e => e.Users).WithOne(e => e.Organization).HasForeignKey(e => new { e.DepartmentId, e.WorkgroupId});
            builder.HasMany(e => e.Users).WithOne(e => e.Organization).HasForeignKey(e => e.DepartmentId);
            builder.HasMany(e => e.Users).WithOne(e => e.Organization).HasForeignKey(e => e.WorkgroupId);
        }
    }
}
