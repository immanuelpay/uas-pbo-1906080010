using PBO_UAS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PBO_UAS.Entities
{
    //[Table("Mahasiswa")]
    public class Mahasiswa
    {
        public int Id { get; set; }

        [Required]
        public string Nim { get; set; }

        [Required]
        [StringLength(100)]
        public string Nama { get; set; }

        public string Jk { get; set; }

        [Range(2007, 2100)]
        public int Angkatan { get; set; }

        [StringLength(13)]
        public string NoHp { get; set; }

        [MinLength(10)]
        public string Alamat { get; set; }

        public virtual ApplicationUser User { get; set; }
    }

    public class MahasiswaMap : EntityTypeConfiguration<Mahasiswa>
    {
        public MahasiswaMap()
        {
            this.ToTable("Mahasiswa");
            this.HasKey(x => x.Id);
            this.HasRequired(x => x.User)
                .WithOptional(y => y.Mahasiswa)
                .WillCascadeOnDelete(false);
        }
    }
}