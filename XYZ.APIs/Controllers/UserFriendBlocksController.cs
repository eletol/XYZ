using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;
using System.Web.Http.OData;
using System.Web.OData.Routing;
using AutoMapper;
using XYZ.BL.BussinessMangers.Classes;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;
using Microsoft.AspNet.Identity;

namespace XYZ.APIs.Controllers
{
    [RoutePrefix("api/UserFriendBlocks")]

    public class UserFriendBlocksController : BaseODataController<IUserFriendBlocksBusinessManager, UserFriendBlock, UserFriendBlockVM>
    {

        public IUserFriendBlocksBusinessManager UserFriendBlockBusinessManager { get; set; }


        [Inject]
        public UserFriendBlocksController(IUserFriendBlocksBusinessManager userFriendBlocksBusinessManager) : base(userFriendBlocksBusinessManager)
        {
            UserFriendBlockBusinessManager = userFriendBlocksBusinessManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/playerCategorys
        public IHttpActionResult Get()
        {


            try
            {
                var result = UserFriendBlockBusinessManager.Get();
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/playerCategorys/5
        [ResponseType(typeof(UserFriendBlockVM))]
        [ODataRoute("UserFriendBlocks({id})")]

        public UserFriendBlockVM Get(int id)
        {
            if (!EntityExisted(s => s.Id == id)) // no userFriendBlock with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = UserFriendBlockBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}