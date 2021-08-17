using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ex7_Filters.Filters
{
    public class TestActionFilter1 : /*ActionFilterAttribute*/ Attribute, IActionFilter
    {
        private readonly ILogger<TestActionFilter1> _logger;
        public TestActionFilter1(ILogger<TestActionFilter1> logger)
        {
            _logger = logger;
        }
        public /*override*/ void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("\nTestActionFilter1 + OnActionExecuted\n");
        }

        public /*override*/ void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("\nTestActionFilter1 + OnActionExecuting\n");
        }
    }
}
