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
    [RoutePrefix("api/UserFriends")]

    public class UserFriendsActionsController : BaseActionsController<IUserFriendsBusinessManager, UserFriend, UserFriendVM>
    {

        public IUserFriendsBusinessManager UserFriendsBusinessManager { get; set; }


        [Inject]
        public UserFriendsActionsController(IUserFriendsBusinessManager userFriendBusinessManager) : base(userFriendBusinessManager)
        {
            UserFriendsBusinessManager = userFriendBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFriend"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(UserFriendVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(UserFriendVM userFriend)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
              var response=  UserFriendsBusinessManager.Save(userFriend);

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
        /// <param name="userFriend"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(long id, UserFriendVM userFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no userFriend with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            userFriend.Id = id;

            try
            {
                UserFriendsBusinessManager.Update(userFriend);
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
            var userFriend = UserFriendsBusinessManager.GetVMById(id);
            if (userFriend == null)
            {
                return NotFound();
            }
            try
            {
                UserFriendsBusinessManager.DeleteSoftly(id);

                return Ok(userFriend);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an userFriend is existed

    }
}