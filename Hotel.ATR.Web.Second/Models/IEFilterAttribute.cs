using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Hotel.ATR.Web.Second.Models
{
    public class IEFilterAttribute : Attribute, IResourceFilter
    {
        //срабатывает непосредственно ПОСЛЕ выполнения метода 
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        //срабатывает непосредственно ДО выполнения метода 
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            //if (Regex.IsMatch(userAgent, "Chrome"))
            if (userAgent.Contains("Chrome"))
            {
                context.Result = new ContentResult
                {
                    Content = "Ваш браузер не поддерживается"
                };
            }
        }
    }
}
