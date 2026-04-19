using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitesMediques.Domain.Entities
{
    [Table("VisitesMediques")]
    public class VisitaMedica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdVisita")]
        public long IdVisita { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("Nom_Pacient")]
        public string NomPacient { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("Nom_Metge")]
        public string NomMetge { get; set; }

        [Required]
        [Column("Data")]
        public DateTime Data { get; set; } 

        [Required]
        [MaxLength(250)]
        [Column("Diagnostic")]
        public string Diagnostic { get; set; }
    }
}