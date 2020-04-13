using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class post
     : EntityTypeConfiguration<Entities.post> {
    public post() {
      HasKey(p => new { p.post_id });
      
      Property(p => p.identifier)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name: "IX_identifier_post_type_id", order: 1) { IsUnique = true }));
      Property(c => c.post_type_id)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name: "IX_identifier_post_type_id", order: 0) { IsUnique = true }));

    }
  }
}
