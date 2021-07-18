using System;
using System.Collections.Generic;

#nullable disable

namespace F_Data.EFEntities
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
    }
}
