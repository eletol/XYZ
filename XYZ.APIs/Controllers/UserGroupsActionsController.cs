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
    [RoutePrefix("api/UserGroups")]

    public class UserGroupsActionsController : BaseActionsController<IUserGroupsBusinessManager, UserGroup, UserGroupVM>
    {

        public IUserGroupsBusinessManager UserGroupsBusinessManager { get; set; }


        [Inject]
        public UserGroupsActionsController(IUserGroupsBusinessManager userGroupsBusinessManager) : base(userGroupsBusinessManager)
        {
            UserGroupsBusinessManager = userGroupsBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(UserGroupVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(UserGroupVM userGroup)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
              var response=  UserGroupsBusinessManager.Save(userGroup);

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
        /// <param name="userGroup"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(long id, UserGroupVM userGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no userGroup with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            userGroup.Id = id;

            try
            {
                UserGroupsBusinessManager.Update(userGroup);
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
            var userGroup = UserGroupsBusinessManager.GetVMById(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            try
            {
                UserGroupsBusinessManager.DeleteSoftly(id);

                return Ok(userGroup);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an userGroup is existed

    }
}