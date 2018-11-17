using System;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.OData;
using XYZ.BL.BussinessMangers.Interfaces;

namespace XYZ.APIs.Controllers
{
    //[Authorize]
    [EnableQuery]

    public class BaseActionsController<TManger, TEntity, TEntityVM> : ApiController
        where TEntity : class, new()
       where TEntityVM : class

        where TManger : IBaseBussinessManger<TEntity, TEntityVM>
    {
        IBaseBussinessManger<TEntity, TEntityVM> BussinessManger { get; set; }
        public int ClientId { get; private set; }

        public BaseActionsController(IBaseBussinessManger<TEntity, TEntityVM> tBussinessManger)
        {
            BussinessManger = tBussinessManger;
            //TODO: Read ClientId from Token
            ClientId = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool EntityExisted(Expression<Func<TEntity, bool>> filter)
        {

            return BussinessManger.Count(filter) != 0;
        }

    }
}