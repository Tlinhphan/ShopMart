using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMart.Data.EF.Extentions;
using ShopMart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Configurations
{
   public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        }
    }
}
