using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XYZ.DAL.Collections.Interfaces;
using XYZ.DAL.DBContext;
using XYZ.DAL.Repository.Interfaces;

namespace XYZ.DAL.Repository.Classes
{
    public class BaseRepository<TCollection, TItem> : IBaseRepository<TItem>
        where TCollection : IBaseCollection<TItem,IDbContext>, new() where TItem : class, new()
        
    {
        public BaseRepository(IDbContext context)
        {
            Collection = new TCollection() { ContextObject = context };
        }

        public TCollection Collection { get; set; }

        public int Count(Expression<Func<TItem, bool>> filter)
        {
            return Collection.Count( filter);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TItem GetById(object id)
        {
            return Collection.GetByID(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual TItem Save(TItem item)
        {
            return Collection.Insert(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual List<TItem> SaveList(List<TItem> items)
        {
            return Collection.InsertList(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void SaveOrEdit(TItem item)
        {
             Collection.InsertOrEdit(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual TItem Update(TItem entityToUpdate)
        {
            return Collection.Update(entityToUpdate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TItem Delete(object id)
        {
            return Collection.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public virtual void DeleteByFilter(Expression<Func<TItem, bool>> filter)
        {
             Collection.DeleteByFilter(filter);
            
        }


         /// <summary>
         /// 
         /// </summary>
         /// <param name="filter"></param>
         /// <param name="orderBy"></param>
         /// <param name="includeProperties"></param>
         /// <returns></returns>
        public virtual IQueryable<TItem> Get(Expression<Func<TItem, bool>> filter = null,
            Func<IQueryable<TItem>, IOrderedQueryable<TItem>> orderBy = null,
            params Expression<Func<TItem, object>>[] includeProperties)
        {
            return Collection.Get(filter, orderBy, includeProperties);
        }
    }
}