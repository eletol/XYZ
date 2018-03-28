using System;
using System.Linq;
using AutoMapper;
using DAL.Models;
using DAL.Repository.Interfaces;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.Helper;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;
using XYZ.DAL.Repository.Interfaces;
using XYZ.DAL.UnitOfWork;

namespace XYZ.BL.BussinessMangers.Classes
{
    public class PlayerStatusBusinessManager
        <TRepository> : BaseBussinessManger<PlayerStatus, TRepository, PlayerStatusVM>,
            IPlayerStatusBusinessManager where TRepository : IPlayerStatusRepository
    {

        public PlayerStatusBusinessManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public override BussinessCustomResponse<PlayerStatusVM> Update(PlayerStatusVM entityToUpdateVM)
        {
            return base.Update(entityToUpdateVM);
        }
        public override BussinessCustomResponse<PlayerStatusVM> Save(PlayerStatusVM itemVM)
        {
        

            return base.Save(itemVM);
        }

    }
  
}