using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentACar.Entities;
using RentACar.Extentions;

namespace RentACar.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<Manager>("loggedManager")==null)
            {
                string requestPath = context.HttpContext.Request.Path.Value;

                context.Result = new RedirectResult("/Home/Login?url=" + requestPath);
            }
        }
    }
}
