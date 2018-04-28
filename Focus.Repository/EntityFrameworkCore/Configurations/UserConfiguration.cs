using Focus.Domain.Constants;
using Focus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Repository.EntityFrameworkCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //设置表名
            builder.ToTable("User");

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired().HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.Account).HasColumnName("Account").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.RealName).HasColumnName("RealName").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(FocusConstants.Validation.EntityValidator.EmailStringLength);
            builder.Property(e => e.Password).HasColumnName("Password").HasMaxLength(FocusConstants.Validation.EntityValidator.EncryptedPasswordLength);
            builder.Property(e => e.Salt).HasColumnName("Salt").HasMaxLength(FocusConstants.Validation.EntityValidator.SaltStringLength);
            builder.Property(e => e.Gender).HasColumnName("Gender");
            builder.Property(e => e.Avatar).HasColumnName("Avatar").HasMaxLength(FocusConstants.Validation.EntityValidator.PathStringLength);
            builder.Property(e => e.Birthday).HasColumnName("Birthday");
            builder.Property(e => e.Mobile).HasColumnName("Mobile").HasMaxLength(FocusConstants.Validation.EntityValidator.MobileStringLength);
            builder.Property(e => e.IdCard).HasColumnName("IdCard").HasMaxLength(FocusConstants.Validation.EntityValidator.IdCardStringLength);
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentId").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.WorkgroupId).HasColumnName("WorkgroupId").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.Enabled).HasColumnName("Enabled");
            builder.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(e => e.DeletedBy).HasColumnName("DeletedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.DeletedTime).HasColumnName("DeletedTime");
            builder.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.ModifiedTime).HasColumnName("ModifiedTime");

            //设置表之间关系
            
        }
    }
}
