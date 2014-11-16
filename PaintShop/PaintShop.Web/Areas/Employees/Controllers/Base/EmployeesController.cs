namespace PaintShop.Web.Areas.Employees.Controllers.Base
{
    using PaintShop.Data;
    using PaintShop.Web.Controllers.Base;
    using System.Web.Mvc;

    [Authorize(Roles="admin, employee")]
    public abstract class EmployeesController : BaseController
    {
        public EmployeesController(IPaintShopData data)
            : base(data)
        {
        }
    }
}