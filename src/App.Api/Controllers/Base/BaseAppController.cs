using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize]
    public abstract class BaseAppController : ControllerBase
    {
        /// <summary>
        /// Генерирует URL для доступа к сохранённой сущности
        /// </summary>
        /// <param name="id">id сущности</param>
        protected string GenerateCreatedUrl(Guid id)
        {
            return $"{this.Request.Scheme}://{this.Request.Host}/api/{this.ControllerContext.ActionDescriptor.ControllerName}/{id}";
        }
    }
}
