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
    public class UsersController : BaseODataController<IUsersBusinessManager, User, UserVM>
    {

        public IUsersBusinessManager UsersBusinessManager { get; set; }


        [Inject]
        public UsersController(IUsersBusinessManager usersBusinessManager) : base(usersBusinessManager)
        {
            UsersBusinessManager = usersBusinessManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/Users
        public IHttpActionResult Get()
        {


            try
            {
                var result = UsersBusinessManager.Get();
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
        // GET api/Users/5
        [ResponseType(typeof(UserVM))]
        [ODataRoute("Users({id})")]

        public UserVM Get(string id)
        {
            if (!EntityExisted(s=>s.Id==id)) // no User with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var User = UsersBusinessManager.GetVMById(id);
                return User;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(UserVM))]
        public HttpResponseMessage Post(UserVM User)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
               var response= UsersBusinessManager.Save(User);

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
        /// <param name="User"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [ODataRoute("Users({id})")]

        public IHttpActionResult Put(string id, UserVM User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no User with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            User.Id = id;


            try
            {
                UsersBusinessManager.Update(User);
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
        [ODataRoute("Users({id})")]
        public IHttpActionResult Delete(string id)
        {
            var User = UsersBusinessManager.GetVMById(id);
            if (User == null)
            {
                return NotFound();
            }
            try
            {
                UsersBusinessManager.Delete(id);

                return Ok(User);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an User is existed

    }
}