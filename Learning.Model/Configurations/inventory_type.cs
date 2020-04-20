using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class inventory_type
    : EntityTypeConfiguration<Entities.inventory_type> {
    public inventory_type() {
      HasKey(i => i.Id);
      Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
      Property(c => c.name).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
      HasMany(it => it.inventories).WithRequired(i => i.inventory_type).HasForeignKey(fk => fk.inventory_type_id).WillCascadeOnDelete(false);
    }
  }
}
