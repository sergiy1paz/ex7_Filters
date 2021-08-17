using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ex7_Filters.Filters
{
    public class TestActionFilter2 : /*ActionFilterAttribute*/ Attribute, IActionFilter
    {
        private readonly ILogger<TestActionFilter2> _logger;
        public TestActionFilter2(ILogger<TestActionFilter2> logger)
        {
            _logger = logger;
        }
        public /*override*/ void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("\nTestActionFilter2 + OnActionExecuted\n");
        }

        public /*override*/ void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("\nTestActionFilter2 + OnActionExecuting\n");
        }
    }
}
