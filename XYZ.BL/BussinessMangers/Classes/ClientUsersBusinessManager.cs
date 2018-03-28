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
    public class ClientUsersBusinessManager
        <TRepository> : BaseBussinessManger<ClientUser, TRepository, ClientUserVM>,
            IClientUsersBusinessManager where TRepository : IClientUsersRepository
    {

        public ClientUsersBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<ClientUserVM> Update(ClientUserVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }


    }
}