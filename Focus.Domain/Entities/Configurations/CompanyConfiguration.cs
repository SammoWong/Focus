using Focus.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            //设置表名
            builder.ToTable("Company");

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired().HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralEntityNameLength);
            builder.Property(e => e.ShortName).HasColumnName("ShortName").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralEntityNameLength);
            builder.Property(e => e.Nature).HasColumnName("Nature").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Website).HasColumnName("Website").HasMaxLength(FocusConstants.Validation.EntityValidator.UrlStringLength);
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(FocusConstants.Validation.EntityValidator.EmailStringLength);
            builder.Property(e => e.Creator).HasColumnName("Creator").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Contact).HasColumnName("Contact").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Mobile).HasColumnName("Mobile").HasMaxLength(FocusConstants.Validation.EntityValidator.MobileStringLength);
            builder.Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(FocusConstants.Validation.EntityValidator.PhoneStringLength);
            builder.Property(e => e.Address).HasColumnName("Address").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralLongerStringLength);
            builder.Property(e => e.Description).HasColumnName("Description").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralDescriptionLength);
            builder.Property(e => e.Enabled).HasColumnName("Enabled");
            builder.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.CreatedTime).HasColumnName("CreatedTime").HasColumnType("DATETIME");
            builder.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(e => e.DeletedBy).HasColumnName("DeletedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.DeletedTime).HasColumnName("DeletedTime").HasColumnType("DATETIME");
            builder.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.ModifiedTime).HasColumnName("ModifiedTime").HasColumnType("DATETIME");

            //设置表之间关系
            builder.HasMany(e => e.Users).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
            builder.HasMany(e => e.Roles).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
            builder.HasMany(e => e.Modules).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
            builder.HasMany(e => e.Organizations).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
            builder.HasMany(e => e.Positions).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
            builder.HasMany(e => e.DictionaryTypes).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
        }
    }
}
