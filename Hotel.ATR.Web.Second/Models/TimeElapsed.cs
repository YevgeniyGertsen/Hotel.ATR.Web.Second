using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Hotel.ATR.Web.Second.Models
{
    public class TimeElapsed : Attribute, IActionFilter
    {
        private Stopwatch timer;

        //после завершения выполнения метода 
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = $"Time elapsed: {timer.Elapsed.TotalMilliseconds} ms";
        }

        //перед вызовом метода действия
        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
    }
}
