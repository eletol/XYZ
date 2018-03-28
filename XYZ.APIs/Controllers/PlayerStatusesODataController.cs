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
using DAL.Models;
using XYZ.BL.BussinessMangers.Classes;
using XYZ.BL.BussinessMangers.Interfaces;
using XYZ.BL.ViewModels;
using XYZ.DAL.Models;
using Microsoft.AspNet.Identity;

namespace XYZ.APIs.Controllers
{
    public class PlayerStatusesODataController : BaseODataController<IPlayerStatusBusinessManager, PlayerStatus, PlayerStatusVM>
    {

        public IPlayerStatusBusinessManager PlayerStatusBusinessManager { get; set; }


        [Inject]
        public PlayerStatusesODataController(IPlayerStatusBusinessManager playerStatusesBusinessManager) : base(playerStatusesBusinessManager)
        {
            PlayerStatusBusinessManager = playerStatusesBusinessManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET api/playerCategorys
        public IHttpActionResult Get()
        {


            try
            {
                var result = PlayerStatusBusinessManager.Get();
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
        // GET api/playerCategorys/5
        [ResponseType(typeof(PlayerStatusVM))]
        [ODataRoute("PlayerCategorys({id})")]

        public PlayerStatusVM Get(int id)
        {
            if (!EntityExisted(s=>s.Id==id)) // no playerStatus with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            try
            {
                var playerCategory = PlayerStatusBusinessManager.GetVMById(id);
                return playerCategory;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerStatus"></param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(PlayerStatusVM))]
        public HttpResponseMessage Post(PlayerStatusVM playerStatus)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                var response=PlayerStatusBusinessManager.Save(playerStatus);

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
        /// <param name="playerStatus"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [ODataRoute("PlayerCategorys({id})")]

        public IHttpActionResult Put(int id, PlayerStatusVM playerStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!EntityExisted(s=>s.Id==id)) // no playerStatus with that id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            playerStatus.Id = id;


            try
            {
                PlayerStatusBusinessManager.Update(playerStatus);
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
        [ODataRoute("PlayerCategorys({id})")]
        public IHttpActionResult Delete(int id)
        {
            var playerCategory = PlayerStatusBusinessManager.GetVMById(id);
            if (playerCategory == null)
            {
                return NotFound();
            }
            try
            {
                PlayerStatusBusinessManager.Delete(id);

                return Ok(playerCategory);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        // Check if an playerStatus is existed

    }
}