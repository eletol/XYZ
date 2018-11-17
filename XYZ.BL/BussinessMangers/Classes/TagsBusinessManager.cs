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
    public class TagsBusinessManager
        <TRepository> : BaseBussinessManger<Tag, TRepository, TagVM>,
            ITagsBusinessManager where TRepository : ITagsRepository
    {

        public TagsBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<TagVM> Update(TagVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }


    }
}