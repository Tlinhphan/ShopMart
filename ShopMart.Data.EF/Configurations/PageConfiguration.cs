using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopMart.Data.EF.Extentions;
using ShopMart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Configurations
{
    public class PageConfiguration : DbEntityConfiguration<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
