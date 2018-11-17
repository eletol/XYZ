//using Ninject;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Data.Entity.Infrastructure;
//using System.Web.Http.Description;
//using System.Web.Http.OData;
//using System.Web.OData.Routing;
//using AutoMapper;
//using XYZ.BL.BussinessMangers.Classes;
//using XYZ.BL.BussinessMangers.Interfaces;
//using XYZ.BL.ViewModels;
//using XYZ.DAL.Models;
//using Microsoft.AspNet.Identity;

//namespace XYZ.APIs.Controllers
//{
//    [RoutePrefix("api/TagLogs")]

//    public class TagLogsController : BaseODataController<ITagLogsBusinessManager, TagLog, TagLogVM>
//    {

//        public ITagLogsBusinessManager TagLogBusinessManager { get; set; }


//        [Inject]
//        public TagLogsController(ITagLogsBusinessManager tagLogsBusinessManager) : base(tagLogsBusinessManager)
//        {
//            TagLogBusinessManager = tagLogsBusinessManager;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        // GET api/playerCategorys
//        public IHttpActionResult Get()
//        {


//            try
//            {
//                var result = TagLogBusinessManager.Get();
//                return Ok(result);
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }

//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        // GET api/playerCategorys/5
//        [ResponseType(typeof(TagLogVM))]
//        [ODataRoute("TagLogs({id})")]

//        public TagLogVM Get(int id)
//        {
//            if (!EntityExisted(s => s.Id == id)) // no tagLog with that id
//            {
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            }
//            try
//            {
//                var playerCategory = TagLogBusinessManager.GetVMById(id);
//                return playerCategory;
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }



//    }
//}