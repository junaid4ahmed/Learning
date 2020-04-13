using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;


using System.Data.Entity.ModelConfiguration;

namespace Learning.Model.Configurations {
  public class account
     : EntityTypeConfiguration<Entities.account> {
    public account() {
      HasKey(c => new { c.id });
      Property(propertyExpression: c => c.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      Property(c => c.name).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
      HasMany(a => a.posts).WithRequired(po => po.account).HasForeignKey(fk => fk.account_id).WillCascadeOnDelete(true);
      HasMany(a => a.purchases).WithRequired(p => p.account).HasForeignKey(fk => fk.account_id).WillCascadeOnDelete(false);
      HasMany(a => a.payments).WithRequired(p => p.account).HasForeignKey(fk => fk.account_id).WillCascadeOnDelete(false);
    }
  }
}
