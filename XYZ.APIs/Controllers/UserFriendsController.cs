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
    [RoutePrefix("api/UserFriends")]

    public class UserFriendsController : BaseODataController<IUserFriendsBusinessManager, UserFriend, UserFriendVM>
    {

        public IUserFriendsBusinessManager UserFriendBusinessManager { get; set; }


        [Inject]
        public UserFriendsController(IUserFriendsBusinessManager userFriendsBusinessManager) : base(userFriendsBusinessManager)
        {
            UserFriendBusinessManager = userFriendsBusinessManager;
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
                var result = UserFriendBusinessManager.Get();
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
        [ResponseType(typeof(UserFriendVM))]
        [ODataRoute("UserFriends({id})")]

        public UserFriendVM Get(int id)
        {
            if (!EntityExisted(s => s.Id == id)) // no userFriend with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = UserFriendBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}