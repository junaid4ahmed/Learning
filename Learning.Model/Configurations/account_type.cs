using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class account_type
    : EntityTypeConfiguration<Entities.account_type> {

    public account_type() {
      HasKey(c => new { c.account_type_id });
      Property(propertyExpression: c => c.account_type_id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

      Property(c => c.name)
      .IsRequired()
      .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

      HasMany(at => at.accounts)
        .WithRequired(a => a.account_type)
        .HasForeignKey(fk => fk.account_type_id)
        .WillCascadeOnDelete(false);


    }


  }
}
