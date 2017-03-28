using System.Web.Mvc;

namespace MVC5.Areas.JsExten
{
    public class JsExtenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JsExten";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JsExten_default",
                "JsExten/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}