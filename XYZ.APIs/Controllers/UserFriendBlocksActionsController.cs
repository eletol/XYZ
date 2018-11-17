using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ninject;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.DAL.Models;

namespace XYZ.APIs.Controllers
{
    [RoutePrefix("api/UserFriendBlocks")]

    public class UserFriendBlocksActionsController : BaseActionsController<IUserFriendBlocksBusinessManager, UserFriendBlock, UserFriendBlockVM>
    {

        public IUserFriendBlocksBusinessManager UserFriendBlocksBusinessManager { get; set; }


        [Inject]
        public UserFriendBlocksActionsController(IUserFriendBlocksBusinessManager userFriendBlocksBusinessManager) : base(userFriendBlocksBusinessManager)
        {
            UserFriendBlocksBusinessManager = userFriendBlocksBusinessManager;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFriendBlock"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(UserFriendBlockVM))]
        [HttpPost]
        [Route("POST")]
        public HttpResponseMessage Post(UserFriendBlockVM userFriendBlock)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
              var response=  UserFriendBlocksBusinessManager.Save(userFriendBlock);

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
        /// <param name="userFriendBlock"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [Route("Put")]
        [HttpPut]

        public IHttpActionResult Put(long id, UserFriendBlockVM userFriendBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no userFriendBlock with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            userFriendBlock.Id = id;

            try
            {
                UserFriendBlocksBusinessManager.Update(userFriendBlock);
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
            var userFriendBlock = UserFriendBlocksBusinessManager.GetVMById(id);
            if (userFriendBlock == null)
            {
                return NotFound();
            }
            try
            {
                UserFriendBlocksBusinessManager.DeleteSoftly(id);

                return Ok(userFriendBlock);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an userFriendBlock is existed

    }
}