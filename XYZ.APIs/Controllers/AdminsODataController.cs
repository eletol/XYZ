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
    public class AdminsODataController : BaseODataController<IAdminsBusinessManager, Admin, AdminVM>
    {

        public IAdminsBusinessManager AdminsBusinessManager { get; set; }


        [Inject]
        public AdminsODataController(IAdminsBusinessManager adminsBusinessManager) : base(adminsBusinessManager)
        {
            AdminsBusinessManager = adminsBusinessManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/admins
        public IHttpActionResult Get()
        {


            try
            {
                var result = AdminsBusinessManager.Get();
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
        // GET api/admins/5
        [ResponseType(typeof(AdminVM))]
        [ODataRoute("Admins({id})")]

        public AdminVM Get(string id)
        {
            if (!EntityExisted(s=>s.Id==id)) // no admin with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var admin = AdminsBusinessManager.GetVMById(id);
                return admin;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(AdminVM))]
        public HttpResponseMessage Post(AdminVM admin)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                var response=AdminsBusinessManager.Save(admin);

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
        /// <param name="admin"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [ODataRoute("Admins({id})")]

        public IHttpActionResult Put(string id, AdminVM admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no admin with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            admin.Id = id;


            try
            {
                AdminsBusinessManager.Update(admin);
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
        [ODataRoute("Admins({id})")]
        public IHttpActionResult Delete(string id)
        {
            var admin = AdminsBusinessManager.GetVMById(id);
            if (admin == null)
            {
                return NotFound();
            }
            try
            {
                AdminsBusinessManager.Delete(id);

                return Ok(admin);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an admin is existed

    }
}