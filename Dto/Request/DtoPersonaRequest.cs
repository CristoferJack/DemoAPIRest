using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Request
{
    public class DtoPersonaRequest
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(15)]
        public string Documento { get; set; }
        [Required]
        public decimal Salario { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        [StringLength(100)]
        public string Perfil { get; set; }
        [StringLength(9)]
        public string Telefono { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}
