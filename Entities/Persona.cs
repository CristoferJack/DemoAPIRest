using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Persona : EntityBase
    {
        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(15)]
        [Column("document_number")]
        public string Documento { get; set; }
        [Required]
        [Column("salary")]
        public decimal Salario { get; set; }
        [Required]
        [Column("age")]
        public int Edad { get; set; }
        [Required]
        [StringLength(100)]
        [Column("profile")]
        public string Perfil { get; set; }
        [StringLength(9)]
        [Column("phone")]
        public string Telefono { get; set; }
        [StringLength(50)]
        [Column("email")]
        public string Email { get; set; }
    }
}
