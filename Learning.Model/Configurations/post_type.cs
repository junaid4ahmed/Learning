using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class post_type
    : EntityTypeConfiguration<Entities.post_type> {

    public post_type() {
      HasKey(pt => new { pt.post_type_id });
      Property(pt => pt.post_type_id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

      Property(pt => pt.name)
          .IsRequired()
          .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

      HasMany(pt => pt.posts)
        .WithRequired(p => p.post_type)
        .HasForeignKey(fk => fk.post_type_id)
        .WillCascadeOnDelete(false);

    }

  }
}
