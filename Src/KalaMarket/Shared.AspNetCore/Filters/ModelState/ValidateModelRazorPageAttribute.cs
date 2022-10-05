using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shared.AspNetCore.Filters.ModelState;

public class ValidateModelRazorPageAttribute : Attribute, IPageFilter
{
    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {

    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new PageResult();
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {

    }
}