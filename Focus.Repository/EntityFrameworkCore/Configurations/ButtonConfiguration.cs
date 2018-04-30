using Focus.Domain.Constants;
using Focus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focus.Repository.EntityFrameworkCore.Configurations
{
    public class ButtonConfiguration : IEntityTypeConfiguration<Button>
    {
        public void Configure(EntityTypeBuilder<Button> builder)
        {
            //设置表名
            builder.ToTable("Button");

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired().HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralEntityNameLength);
            builder.Property(e => e.Code).HasColumnName("Code").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.Url).HasColumnName("Url").HasMaxLength(FocusConstants.Validation.EntityValidator.UrlStringLength);
            builder.Property(e => e.Icon).HasColumnName("Icon").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralStringLength);
            builder.Property(e => e.SortNumber).HasColumnName("SortNumber");
            builder.Property(e => e.Remark).HasColumnName("Remark").HasMaxLength(FocusConstants.Validation.EntityValidator.GeneralDescriptionLength);
            builder.Property(e => e.Enabled).HasColumnName("Enabled");
            builder.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(e => e.DeletedBy).HasColumnName("DeletedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.DeletedTime).HasColumnName("DeletedTime");
            builder.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(FocusConstants.Validation.EntityValidator.GuidStringLength);
            builder.Property(e => e.ModifiedTime).HasColumnName("ModifiedTime");
        }
    }
}
