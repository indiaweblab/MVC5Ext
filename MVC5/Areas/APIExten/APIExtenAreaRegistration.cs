using System.Web.Mvc;

namespace MVC5.Areas.APIExten
{
    public class APIExtenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "APIExten";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "APIExten_default",
                "APIExten/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}