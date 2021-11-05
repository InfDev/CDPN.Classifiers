using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapBlazorApp.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult SetCulture(string culture, string redirectUri)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture)));
            }

            return LocalRedirect(redirectUri);
        }

        public IActionResult ResetCulture(string redirectUri)
        {
            HttpContext.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);

            return LocalRedirect(redirectUri);
        }
    }
}
