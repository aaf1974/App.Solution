using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        [HttpGet(nameof(TestSerilog))]
        public string TestSerilog()
        {
            int i = 0;

            int j = 8 / i;

            return "Serilog test";
        }
    }
}
