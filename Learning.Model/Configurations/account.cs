using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class account
     : EntityTypeConfiguration<Entities.account> {

    public account() {

      HasKey(c => new { c.id });
      Property(propertyExpression: c => c.id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      Property(c => c.name)
          .IsRequired()
          .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

    }
  }
}
