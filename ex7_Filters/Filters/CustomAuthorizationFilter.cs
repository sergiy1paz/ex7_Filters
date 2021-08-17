using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ex7_Filters.Filters
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly ILogger<CustomAuthorizationFilter> _logger;
        private readonly IConfiguration _config;
        public CustomAuthorizationFilter(ILogger<CustomAuthorizationFilter> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!Validate(context))
            {
                context.Result = new ContentResult { Content = "Запит не валідний! Тому виконання неможливе..." };
                _logger.LogWarning("Request did not pass the Authorization!");
            } else
            {
                _logger.LogInformation("Request was passed successfuly!");
            }

        }

        private bool Validate(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;

            try
            {
                var arg1 = double.Parse(request.Cookies[_config.GetSection("Cookies:Keys:arg1").Key]);
                var arg2 = double.Parse(request.Cookies[_config.GetSection("Cookies:Keys:arg2").Key]);

                var validateHeader = double.Parse(request.Headers[_config["Headers:ValidateHeader"]]);

                return arg1 * arg2 == validateHeader;
            } catch (Exception e)
            {
                _logger.LogError(e, "Cookies or header were not correct!");
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
