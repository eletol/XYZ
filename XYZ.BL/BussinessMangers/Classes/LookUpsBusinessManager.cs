using System;
using System.Linq;
using AutoMapper;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.Helper;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;
using XYZ.DAL.Repository.Interfaces;
using XYZ.DAL.UnitOfWork;

namespace XYZ.BL.BussinessMangers.Classes
{
    public class TagStatusBusinessManager
        <TRepository> : BaseBussinessManger<TagStatus, TRepository, TagStatusVM>,
            ITagStatusBusinessManager where TRepository : ITagStatusRepository
    {

        public TagStatusBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<TagStatusVM> Update(TagStatusVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }
        public override BussinessCustomResponse<TagStatusVM> Save(TagStatusVM itemVM)
        {
        

            return base.Save(itemVM);
        }

    }
  
}