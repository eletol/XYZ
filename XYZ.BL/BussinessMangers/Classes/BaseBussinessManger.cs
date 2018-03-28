using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.Helper;
using XYZ.DAL.Repository.Interfaces;
using XYZ.DAL.UnitOfWork;

namespace XYZ.BL.BussinessMangers.Classes
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntityVM"></typeparam>
    public class BaseBussinessManger<TEntity, TRepository, TEntityVM> : IBaseBussinessManger<TEntity, TEntityVM> where TEntity : class
        where TRepository : IBaseRepository<TEntity>
          where TEntityVM : class
    {
        public BaseBussinessManger(IUnitOfWork _uow)
        {
           
            if (_uow == null)
            {
                throw new ArgumentNullException("no repository provided");
            }
         
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TEntity, TEntityVM>();
                cfg.CreateMap<TEntityVM, TEntity>();
            });
            UnitOfWork = _uow;
            Repository = UnitOfWork.Repository<TEntity, TRepository>();

       
        }

        protected IBaseRepository<TEntity> Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual  TEntityVM GetVMById(object id)
        {
            TEntity entity = Repository.GetById(id);
            TEntityVM itemVM = Mapper.Map<TEntityVM>(entity);

            return itemVM;
        }
        public virtual void DeleteByFilter(Expression<Func<TEntity, bool>> filter)
        {
             Repository.DeleteByFilter(filter);
            UnitOfWork.Save();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual BussinessCustomResponse<TEntityVM> Save(TEntityVM itemVM)
        {
    
            TEntity item = Mapper.Map<TEntity>(itemVM);
            TEntity addedItem = Repository.Save(item);
            UnitOfWork.Save();
            TEntityVM itemVMNew = Mapper.Map<TEntityVM>(addedItem);
            return BussinessCustomResponse(itemVMNew);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual BussinessCustomResponse<TEntity> Save(TEntity item)
        {
            var addedItem = Repository.Save(item);

            UnitOfWork.Save();
            return BussinessCustomResponse<TEntity>(addedItem);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual List<TEntity> SaveList(List<TEntity> items)
        {
            var addedItem = Repository.SaveList(items);

            UnitOfWork.Save();
            return addedItem;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual BussinessCustomResponse<TEntityVM> Update(TEntityVM entityToUpdateVM)
        {
            TEntity entityToUpdate = Mapper.Map<TEntity>(entityToUpdateVM);

            var editedItem = Repository.Update(entityToUpdate);
            TEntityVM editedItemVM = Mapper.Map<TEntityVM>(editedItem);

            UnitOfWork.Save();
            return BussinessCustomResponse(editedItemVM);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        public virtual BussinessCustomResponse<TEntity> Update(TEntity entityToUpdate)
        {
            var editedItem = Repository.Update(entityToUpdate);
            UnitOfWork.Save();
            return BussinessCustomResponse<TEntity>(editedItem);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual BussinessCustomResponse<TEntity> Delete(object id)
        {
            var deletedItem = Repository.Delete(id);
            UnitOfWork.Save();
            return BussinessCustomResponse<TEntity>(deletedItem);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }

        public virtual IQueryable<TEntityVM> GetVM(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var res= Repository.Get(filter, orderBy, includeProperties);
            IQueryable<TEntityVM> resVM = Mapper.Map<IQueryable<TEntityVM>>(res);
            return resVM;

        }
        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.Count(filter);

        }
        private BussinessCustomResponse<T> BussinessCustomResponse<T>(T res)  
        {
            return new BussinessCustomResponse<T>
            {
                ErrorMsg = "",
                Success = true,
                response = res
            };

        }
    }
}