using F_Data;
using F_Data.EFEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business
{
    public class PersonaBL : BaseBL<Persona>
    {
        public PersonaBL(AgroCampoContext dbContext) : base(dbContext)
        {

        }

        public async Task<Persona> GetBy(string documento)
        {
            var result = await _dbContext.Persona.AsNoTracking().FirstOrDefaultAsync(m => m.Documento == documento);
            return result;
        }
    }
}
