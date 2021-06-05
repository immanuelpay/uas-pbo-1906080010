using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBO_UAS.Entities
{
    [Table("Semester")]
    public class Semester
    {
        [Key]
        [Required]
        public string KodeSemester { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaSemester { get; set; }

        [Required]
        [Range(2007, 2100)]
        public int TahunAjaran { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Nilai> Nilai { get; set; }
    }
}