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
    [RoutePrefix("api/Tags")]

    public class TagsController : BaseODataController<ITagsBusinessManager, Tag, TagVM>
    {

        public ITagsBusinessManager TagBusinessManager { get; set; }


        [Inject]
        public TagsController(ITagsBusinessManager tagsBusinessManager) : base(tagsBusinessManager)
        {
            TagBusinessManager = tagsBusinessManager;
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
                var result = TagBusinessManager.Get();
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
        [ResponseType(typeof(TagVM))]
        [ODataRoute("Tags({id})")]

        public TagVM Get(int id)
        {
            if (!EntityExisted(s => s.Id == id)) // no tag with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = TagBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}