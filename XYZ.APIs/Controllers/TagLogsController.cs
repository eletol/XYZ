using Ninject;
using System;

using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData.Routing;

using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;

namespace XYZ.APIs.Controllers
{
    [RoutePrefix("api/TagLog")]

    public class TagLogController : BaseODataController<ITagLogsBusinessManager, TagLog, TagLogVM>
    {

        public ITagLogsBusinessManager TagLogBusinessManager { get; set; }


        [Inject]
        public TagLogController(ITagLogsBusinessManager tagLogsBusinessManager) : base(tagLogsBusinessManager)
        {
            TagLogBusinessManager = tagLogsBusinessManager;
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
                var result = TagLogBusinessManager.Get();
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
        [ResponseType(typeof(TagLogVM))]
        [ODataRoute("TagLog({id})")]

        public TagLogVM Get(int id)
        {
            if (!EntityExisted(s => s.Id == id)) // no TagLog with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = TagLogBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}