using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class category
    : EntityTypeConfiguration<Entities.category> {
    public category() {
      //  key 
      HasKey(c => new { c.category_id });

      Property(c => c.category_id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      //  Name
      Property(c => c.name)
          .IsRequired()
          .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

      //  Description
      Property(c => c.description)
          .HasMaxLength(128);

      //  Relationship
      HasMany(sc => sc.products)
          .WithRequired(p => p.category)
          .HasForeignKey(p => p.category_id)
          .WillCascadeOnDelete(false);
    }
  }
}
