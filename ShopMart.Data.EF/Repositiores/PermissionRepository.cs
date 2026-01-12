using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
    public class PermissionRepository : EFRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
