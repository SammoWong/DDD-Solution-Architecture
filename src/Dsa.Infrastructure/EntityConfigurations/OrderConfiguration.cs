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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //设置表名
            builder.ToTable(nameof(Order));

            //设置主键
            builder.HasKey(e => e.Id);

            //设置字段属性
            builder.Property(e => e.Id).HasColumnName(nameof(Order.Id)).IsRequired();
            builder.Property(e => e.No).HasColumnName(nameof(Order.No)).HasMaxLength(32).IsRequired();
            builder.Property(e => e.IsDeleted).HasColumnName(nameof(Order.IsDeleted)).HasDefaultValue(false);
            builder.Property(e => e.CreatedTime).HasColumnType("datetime(6)").HasDefaultValue(DateTime.Now);
            builder.Property(e => e.ModifiedTime).HasColumnType("datetime(6)");

            //设置表之间关系
            builder.HasMany(e => e.OrderItems).WithOne(e => e.Order).HasForeignKey(e => e.OrderId);

            //设置索引
            builder.HasIndex(e => e.No);

            //设置值对象
            builder.OwnsOne(e => e.Address, a =>
            {
                a.Property(s => s.Province).HasColumnName("Province").HasColumnType("varchar(32)");
                a.Property(s => s.City).HasColumnName("City").HasColumnType("varchar(32)");
                a.Property(s => s.District).HasColumnName("District").HasColumnType("varchar(32)");
                a.Property(s => s.Street).HasColumnName("Street").HasColumnType("varchar(32)");
            });
        }
    }
}
