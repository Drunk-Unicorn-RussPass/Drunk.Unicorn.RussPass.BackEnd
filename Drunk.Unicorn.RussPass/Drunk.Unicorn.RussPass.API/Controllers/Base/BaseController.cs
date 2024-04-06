using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        internal new OkObjectResult Ok() => base.Ok(new
        {
            Done = true
        });

        internal OkObjectResult Ok(string message) => base.Ok(new
        {
            Done = true,
            Message = message
        });

        internal new BadRequestObjectResult BadRequest() => base.BadRequest(new
        {
            Done = false
        });

        internal BadRequestObjectResult BadRequest(string errorMessage) => base.BadRequest(new
        {
            Done = false,
            Message = errorMessage
        });
    }
}
