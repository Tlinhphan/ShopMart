using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Color = ShopMart.Data.Entities.Color;

namespace ShopMart.Data.EF.Repositiores
{
   public class ColorRepository : EFRepository<Color, int>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {

        }

        public void Add(Entities.Color entity)
        {
            throw new NotImplementedException();
        }

    

        public IQueryable<Entities.Color> FindAll(Expression<Func<Entities.Color, bool>> predicate, params Expression<Func<Entities.Color, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Entities.Color FindById(int id, params Expression<Func<Entities.Color, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Entities.Color FindSingle(Expression<Func<Entities.Color, bool>> predicate, params Expression<Func<Entities.Color, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(Entities.Color entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveMultiple(List<Entities.Color> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
