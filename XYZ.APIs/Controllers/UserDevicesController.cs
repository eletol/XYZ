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
    [RoutePrefix("api/UserDevices")]

    public class UserDevicesController : BaseODataController<IUserDevicesBusinessManager, UserDevice, UserDeviceVM>
    {

        public IUserDevicesBusinessManager UserDeviceBusinessManager { get; set; }


        [Inject]
        public UserDevicesController(IUserDevicesBusinessManager userDevicesBusinessManager) : base(userDevicesBusinessManager)
        {
            UserDeviceBusinessManager = userDevicesBusinessManager;
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
                var result = UserDeviceBusinessManager.Get();
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
        [ResponseType(typeof(UserDeviceVM))]
        [ODataRoute("UserDevices({id})")]

        public UserDeviceVM Get(int id)
        {
            if (!EntityExisted(s => s.Id == id)) // no userDevice with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = UserDeviceBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}