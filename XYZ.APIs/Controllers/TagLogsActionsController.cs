using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Ninject;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;

namespace XYZ.APIs.Controllers
{
    [RoutePrefix("api/TagLogs")]

    public class TagLogsActionsController : BaseActionsController<ITagLogsBusinessManager, TagLog, TagLogVM>
    {

        public ITagLogsBusinessManager TagLogsBusinessManager { get; set; }


        [Inject]
        public TagLogsActionsController(ITagLogsBusinessManager tagLogsBusinessManager) : base(tagLogsBusinessManager)
        {
            TagLogsBusinessManager = tagLogsBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagLog"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(TagStatusVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(TagLogVM tagLog)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
               var userFromId=  User.Identity.GetUserId();
                if (userFromId!=null)
                {
                    tagLog.UserFromId = userFromId;

                }
                var response=  TagLogsBusinessManager.Save(tagLog);

                return Request.CreateResponse(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest, response);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="tagLog"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(long id, TagLogVM tagLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no tagLog with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            tagLog.Id = id;

            try
            {
                TagLogsBusinessManager.Update(tagLog);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExisted(s=>s.Id==id))
                {
                    return NotFound();
                }
                throw;
            }

            catch (Exception e)
            {

                throw e;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(long id)
        {
            var tagLog = TagLogsBusinessManager.GetVMById(id);
            if (tagLog == null)
            {
                return NotFound();
            }
            try
            {
                TagLogsBusinessManager.DeleteSoftly(id);

                return Ok(tagLog);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an tagLog is existed

    }
}