using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMart.Data.EF.Extentions;
using ShopMart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Configurations
{
    class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
