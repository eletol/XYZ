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
    public class AdminsBusinessManager
        <TRepository> : BaseBussinessManger<Admin, TRepository, AdminVM>,
            IAdminsBusinessManager where TRepository : IAdminsRepository
    {

        public AdminsBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public BussinessCustomResponse<AdminVM> Update(AdminVM entityToUpdateVM)
        {
          
            return base.Update(entityToUpdateVM);
        }

    }
}