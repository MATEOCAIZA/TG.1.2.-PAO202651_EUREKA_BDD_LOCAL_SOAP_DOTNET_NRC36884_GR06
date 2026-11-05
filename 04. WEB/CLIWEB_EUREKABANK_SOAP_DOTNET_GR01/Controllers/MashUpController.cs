using System.Web.Mvc;
using Newtonsoft.Json;
using CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Models;
using CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Services;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Controllers
{
    public class MashUpController : Controller
    {
        private readonly EurekaBankService _service = new EurekaBankService();

        private EmpleadoSession GetEmpleado()
        {
            if (Session["Empleado"] == null) return null;
            return JsonConvert.DeserializeObject<EmpleadoSession>(Session["Empleado"].ToString());
        }

        public ActionResult Index()
        {
            var emp = GetEmpleado();
            if (emp == null) return RedirectToAction("Login", "Auth");

            var cuentas = _service.ObtenerTodasCuentasEstado();
            ViewBag.Empleado = emp;
            return View(cuentas);
        }
    }
}

