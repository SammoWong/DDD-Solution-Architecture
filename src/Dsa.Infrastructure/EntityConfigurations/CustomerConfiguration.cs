using Dsa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Infrastructure.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //设置表名
            builder.ToTable(nameof(Customer));

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName(nameof(Customer.Id)).IsRequired();
            builder.Property(e => e.FullName).HasMaxLength(32);
            builder.Property(e => e.UserName).HasMaxLength(32);
            builder.Property(e => e.Email).HasMaxLength(32);
            builder.Property(e => e.Mobile).HasMaxLength(32);
            builder.Property(e => e.IsDeleted).HasColumnName(nameof(Customer.IsDeleted)).HasDefaultValue(false);
            builder.Property(e => e.CreatedTime).HasColumnType("datetime(6)").HasDefaultValue(DateTime.Now);
            builder.Property(e => e.ModifiedTime).HasColumnType("datetime(6)");

            //设置表之间关系
            builder.HasMany(e => e.Orders).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
        }
    }
}
