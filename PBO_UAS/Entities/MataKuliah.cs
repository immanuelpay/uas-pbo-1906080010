using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBO_UAS.Entities
{
    [Table("MataKuliah")]
    public class MataKuliah
    {
        [Key]
        [Required]
        public string KodeMK { get; set; }

        [Required]
        [StringLength(100)]
        public string Nama { get; set; }

        public int JumlahSKS { get; set; }

        public virtual ICollection<Nilai> Nilai { get; set; }
    }
}