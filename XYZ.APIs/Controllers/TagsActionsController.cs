using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ninject;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;

namespace XYZ.APIs.Controllers
{
    [RoutePrefix("api/Tags")]

    public class TagsActionsController : BaseActionsController<ITagsBusinessManager, Tag, TagVM>
    {

        public ITagsBusinessManager TagsBusinessManager { get; set; }


        [Inject]
        public TagsActionsController(ITagsBusinessManager tagsBusinessManager) : base(tagsBusinessManager)
        {
            TagsBusinessManager = tagsBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(TagVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(TagVM tag)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
              var response=  TagsBusinessManager.Save(tag);

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
        /// <param name="tag"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(long id, TagVM tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no tag with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            tag.Id = id;

            try
            {
                TagsBusinessManager.Update(tag);
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
            var tag = TagsBusinessManager.GetVMById(id);
            if (tag == null)
            {
                return NotFound();
            }
            try
            {
                TagsBusinessManager.DeleteSoftly(id);

                return Ok(tag);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an tag is existed

    }
}