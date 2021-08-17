using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ex7_Filters.Exceptions;
using Microsoft.Extensions.Logging;

namespace ex7_Filters.Filters
{
    public class EvenIntNumberExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<EvenIntNumberExceptionFilter> _logger;
        public EvenIntNumberExceptionFilter(ILogger<EvenIntNumberExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EvenIntNumberException e)
            {
                context.Result = new ContentResult { Content = "Цей запит не може бути оброблено! Сталася помилка!" };
                context.ExceptionHandled = true;
                _logger.LogInformation($"EvenIntNumberException was handled and proccessed \n" +
                    $"Exception message: {e.Message}\n");
            } else
            {
                _logger.LogWarning("Another exception was handled!");
            }
        }
    }
}
