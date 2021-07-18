using F_Data;
using F_Data.EFEntities;
using L_Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_API.Controllers
{
    public class PersonaController : BaseController<Persona>
    {
        public PersonaController(AgroCampoContext dbContext) : base(dbContext)
        {

        }

        [HttpGet("persona/{documento}")]
        public async Task<IActionResult> GetBy(string documento)
        {
            try
            {
                var bl = new PersonaBL(_dbContext);
                var result = await bl.GetBy(documento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
