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
    [RoutePrefix("api/UserGroups")]

    public class UserGroupsController : BaseODataController<IUserGroupsBusinessManager, UserGroup, UserGroupVM>
    {

        public IUserGroupsBusinessManager UserGroupBusinessManager { get; set; }


        [Inject]
        public UserGroupsController(IUserGroupsBusinessManager userGroupsBusinessManager) : base(userGroupsBusinessManager)
        {
            UserGroupBusinessManager = userGroupsBusinessManager;
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
                var result = UserGroupBusinessManager.Get();
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
        [ResponseType(typeof(UserGroupVM))]
        [ODataRoute("UserGroups({id})")]

        public UserGroupVM Get(int id)
        {
            if (!EntityExisted(s => s.Id == id)) // no userGroup with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = UserGroupBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}