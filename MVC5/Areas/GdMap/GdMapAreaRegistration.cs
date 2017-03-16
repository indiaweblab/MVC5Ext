using System.Web.Mvc;

namespace MVC5.Areas.GdMap
{
    public class GdMapAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GdMap";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GdMap_default",
                "GdMap/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}