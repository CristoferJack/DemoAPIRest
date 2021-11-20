using System;
using System.Collections.Generic;
using System.Text;

namespace Dto
{
    public class DtoPersonaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public decimal Salario { get; set; }
        public int Edad { get; set; }
        public string Perfil { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
