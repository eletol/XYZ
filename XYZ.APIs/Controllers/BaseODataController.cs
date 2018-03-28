using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using XYZ.BL.BussinessMangers.Interfaces;
using Ninject;
using System.Web.OData;

namespace XYZ.APIs.Controllers
{
    //[Authorize]
    [EnableQuery]

    public class BaseODataController<TManger, TEntity, TEntityVM> : ODataController
        where TEntity :class
       where TEntityVM : class

        where TManger : IBaseBussinessManger<TEntity, TEntityVM>
   {
       IBaseBussinessManger<TEntity, TEntityVM> BussinessManger { get;  set; }
        public BaseODataController(IBaseBussinessManger<TEntity, TEntityVM> tBussinessManger)
        {
            BussinessManger = tBussinessManger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool EntityExisted(Expression<Func<TEntity, bool>> filter)
        {

            return BussinessManger.Count(filter) !=0 ;
        }
  
    }
}