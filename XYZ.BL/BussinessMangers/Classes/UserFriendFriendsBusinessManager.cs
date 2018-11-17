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
    public class UserFriendsBusinessManager
        <TRepository> : BaseBussinessManger<UserFriend, TRepository, UserFriendVM>,
            IUserFriendsBusinessManager where TRepository : IUserFriendsRepository
    {

        public UserFriendsBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<UserFriendVM> Update(UserFriendVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }


    }
}