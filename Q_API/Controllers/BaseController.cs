using F_Data;
using L_Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class, new()
    {
        protected readonly AgroCampoContext _dbContext;

        public BaseController(AgroCampoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            try
            {
                var bl = new BaseBL<T>(_dbContext);
                var result = await bl.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
