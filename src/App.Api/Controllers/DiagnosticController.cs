using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{

    /// <summary>
    /// Контррлер для проверок
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {

        /// <summary>
        /// Проверка записи в лог файл
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(TestSerilog))]
        public string TestSerilog()
        {
            int i = 0;

            //int j = 8 / i;

            try
            {
                int j2 = 8 / i;
            }
            catch { }

            return "Serilog test";
        }
    }
}
