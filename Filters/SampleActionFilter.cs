using Microsoft.AspNetCore.Mvc.Filters;

namespace Tutorial.Filters
{
    // Filters are used to run some logic at a specific
    // stage of the request pipeline.
    // For example to run some logic before hitting the
    // action method or after creating the result.
    // There are five filters,
    // Authorization filter, runs first among all filters.
    // It is used to validate whether a user is authorized
    // for the request or not.
    // Resource filter, runs after the Authorization filter.
    // This has two methods and execution depends on logic.
    // 	OnResourceExecuting, runs after Authorization filter.
    //  OnResourceExecuted, runs agter the rest of the application.
    // Action filter, runs after the Resource filter.
    // This has two methods and execution depends on logic.
    //  OnActionExecuting, runs before an action method is called.
    //  OnActionExecuted, runs after an action method is called.
    // Exception filter, execute for the exception before written
    // to the response body. They can handle exceptions globally
    // individually except the Authorization filter.
    // Result filter, before and after the execution of action results.
    // It only runs if an action method is executed successfully.
    // These filter can be used in action methods, controllers or global.
    public class SampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Diagnostics.Debug.WriteLine("Sample Action Filter - OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            System.Diagnostics.Debug.WriteLine("Sample Action Filter - OnActionExecuted");
        }
    }
}
