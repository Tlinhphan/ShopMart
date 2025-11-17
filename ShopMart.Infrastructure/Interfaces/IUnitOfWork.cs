using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Infrastructure.Interfaces
{
   public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
