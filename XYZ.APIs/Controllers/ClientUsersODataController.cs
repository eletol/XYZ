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
    public class ClientUsersODataController : BaseODataController<IClientUsersBusinessManager, ClientUser, ClientUserVM>
    {

        public IClientUsersBusinessManager ClientUsersBusinessManager { get; set; }


        [Inject]
        public ClientUsersODataController(IClientUsersBusinessManager clientUsersBusinessManager) : base(clientUsersBusinessManager)
        {
            ClientUsersBusinessManager = clientUsersBusinessManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/clientUsers
        public IHttpActionResult Get()
        {


            try
            {
                var result = ClientUsersBusinessManager.Get();
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
        // GET api/clientUsers/5
        [ResponseType(typeof(ClientUserVM))]
        [ODataRoute("ClientUsers({id})")]

        public ClientUserVM Get(string id)
        {
            if (!EntityExisted(s=>s.Id==id)) // no clientUser with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var clientUser = ClientUsersBusinessManager.GetVMById(id);
                return clientUser;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientUser"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(ClientUserVM))]
        public HttpResponseMessage Post(ClientUserVM clientUser)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
               var response= ClientUsersBusinessManager.Save(clientUser);

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
        /// <param name="clientUser"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [ODataRoute("ClientUsers({id})")]

        public IHttpActionResult Put(string id, ClientUserVM clientUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no clientUser with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            clientUser.Id = id;


            try
            {
                ClientUsersBusinessManager.Update(clientUser);
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
        [ODataRoute("ClientUsers({id})")]
        public IHttpActionResult Delete(string id)
        {
            var clientUser = ClientUsersBusinessManager.GetVMById(id);
            if (clientUser == null)
            {
                return NotFound();
            }
            try
            {
                ClientUsersBusinessManager.Delete(id);

                return Ok(clientUser);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an clientUser is existed

    }
}