using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PBO_UAS.Entities
{
    public class Nilai
    {
        public int Id { get; set; }

        [Required]
        public string Nim { get; set; }

        [Required]
        public string KodeMK { get; set; }

        [Required]
        public string KodeSemester { get; set; }

        [Required]
        public string NilaiAngka { get; set; }

        [Required]
        public string NilaiHuruf { get; set; }

        public virtual MataKuliah MataKuliah { get; set; }
        public virtual Semester Semester { get; set; }
    }

    public class NilaiMap : EntityTypeConfiguration<Nilai>
    {
        public NilaiMap()
        {
            this.ToTable("Nilai");

            this.HasKey(x => x.Id);

            this.HasRequired(x => x.MataKuliah)
                .WithMany(y => y.Nilai)
                .HasForeignKey(x => x.KodeMK);

            this.HasRequired(x => x.Semester)
                .WithMany(y => y.Nilai)
                .HasForeignKey(x => x.KodeSemester);
        }
    }
}