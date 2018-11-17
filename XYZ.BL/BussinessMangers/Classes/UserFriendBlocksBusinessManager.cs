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
    public class UserFriendBlocksBusinessManager
        <TRepository> : BaseBussinessManger<UserFriendBlock, TRepository, UserFriendBlockVM>,
            IUserFriendBlocksBusinessManager where TRepository : IUserFriendBlocksRepository
    {

        public UserFriendBlocksBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<UserFriendBlockVM> Update(UserFriendBlockVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }


    }
}