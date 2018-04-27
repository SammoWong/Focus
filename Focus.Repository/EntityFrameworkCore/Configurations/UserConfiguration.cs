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
            builder.HasKey(u => u.Id);

            //设置字段属性
            builder.Property(u => u.Id).HasColumnName("Id").IsRequired().HasMaxLength(FocusConstants.Validations.GuidStringLength);
            builder.Property(u => u.Account).IsRequired().HasMaxLength(50);
            builder.Property(u => u.RealName).HasMaxLength(50);
        }
    }
}
