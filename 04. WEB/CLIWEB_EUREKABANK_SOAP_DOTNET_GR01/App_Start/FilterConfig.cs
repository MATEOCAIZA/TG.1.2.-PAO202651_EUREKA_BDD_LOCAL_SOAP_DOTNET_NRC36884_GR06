using System.Web;
using System.Web.Mvc;

namespace CLIWEB_EUREKABANK_SOAP_DOTNET_GR01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

