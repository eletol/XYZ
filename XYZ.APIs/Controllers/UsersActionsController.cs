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
    [RoutePrefix("api/Users")]

    public class UsersActionsController : BaseActionsController<IUsersBusinessManager, User, UserVM>
    {

        public IUsersBusinessManager UsersBusinessManager { get; set; }


        [Inject]
        public UsersActionsController(IUsersBusinessManager usersBusinessManager) : base(usersBusinessManager)
        {
            UsersBusinessManager = usersBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(UserVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(UserVM user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
              var response=  UsersBusinessManager.Save(user);

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
        /// <param name="user"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(string id, UserVM user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no user with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            user.Id = id;

            try
            {
                UsersBusinessManager.Update(user);
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
            var user = UsersBusinessManager.GetVMById(id);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                UsersBusinessManager.DeleteSoftly(id);

                return Ok(user);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an user is existed

    }
}