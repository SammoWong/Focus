using Focus.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //设置表名
            builder.ToTable("Article");

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired().HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.Category).HasColumnName("Category");
            builder.Property(e => e.Title).HasColumnName("Title").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Content).HasColumnName("Content").HasColumnType("NVARCHAR(MAX)");
            builder.Property(e => e.IsTop).HasColumnName("IsTop");
            builder.Property(e => e.Enabled).HasColumnName("Enabled");
            builder.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.CreatedTime).HasColumnName("CreatedTime").HasColumnType("DATETIME");
            builder.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.ModifiedTime).HasColumnName("ModifiedTime").HasColumnType("DATETIME");
        }
    }
}
