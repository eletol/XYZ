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
    [RoutePrefix("api/Groups")]

    public class GroupsActionsController : BaseActionsController<IGroupsBusinessManager, Group, GroupVM>
    {

        public IGroupsBusinessManager GroupsBusinessManager { get; set; }


        [Inject]
        public GroupsActionsController(IGroupsBusinessManager tagStatussBusinessManager) : base(tagStatussBusinessManager)
        {
            GroupsBusinessManager = tagStatussBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(GroupVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(GroupVM item)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
              var response=  GroupsBusinessManager.Save(item);

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
        /// <param name="item"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(long id, GroupVM item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no item with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            item.Id = id;

            try
            {
                GroupsBusinessManager.Update(item);
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
            var item = GroupsBusinessManager.GetVMById(id);
            if (item == null)
            {
                return NotFound();
            }
            try
            {
                GroupsBusinessManager.DeleteSoftly(id);

                return Ok(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an item is existed

    }
}