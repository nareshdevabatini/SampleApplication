using Elmah;
using System.Web;
using System.Web.Mvc;

namespace Application.UI.CustomException
{
    public class CustomExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var e = context.Exception;
            var httpcontext = HttpContext.Current;

            var signal = ErrorSignal.FromContext(httpcontext);
            if (signal != null)
            {
                signal.Raise(e, httpcontext);
            }
        }
    }
}