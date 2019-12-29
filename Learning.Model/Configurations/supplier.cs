using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class supplier
    : EntityTypeConfiguration<Entities.supplier> {

    public supplier() {
      HasKey(c => new { c.supplier_id });

      Property(c => c.supplier_id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


      Property(e => e.company)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

      HasMany(s => s.purchases)
        .WithRequired(p => p.supplier)
        .HasForeignKey(f => f.supplier_id)
        .WillCascadeOnDelete(false);
    }

  }
}
