namespace PaintShop.Web.Areas.Administration.Controllers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PaintShop.Data;
    using PaintShop.Web.Controllers.Base;

    [Authorize(Roles="admin")]
    public abstract class AdministrationController : BaseController
    {
        public AdministrationController(IPaintShopData data) 
            : base(data)
        {
        }
    }
}