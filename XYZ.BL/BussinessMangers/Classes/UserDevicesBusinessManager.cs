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
    public class UserDevicesBusinessManager
        <TRepository> : BaseBussinessManger<UserDevice, TRepository, UserDeviceVM>,
            IUserDevicesBusinessManager where TRepository : IUserDevicesRepository
    {

        public UserDevicesBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<UserDeviceVM> Update(UserDeviceVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }


    }
}