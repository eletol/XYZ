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
    public class UserGroupsBusinessManager
        <TRepository> : BaseBussinessManger<UserGroup, TRepository, UserGroupVM>,
            IUserGroupsBusinessManager where TRepository : IUserGroupsRepository
    {

        public UserGroupsBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<UserGroupVM> Update(UserGroupVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }


    }
}