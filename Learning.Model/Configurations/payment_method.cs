using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class payment_method
     : EntityTypeConfiguration<Entities.payment_method> {

    public payment_method() {

      HasKey(p => new { p.id });

      Property(p => p.id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

      
      Property(p => p.name)
          .IsRequired();

      HasMany(p => p.payments)
        .WithRequired(p => p.payment_method)
        .HasForeignKey(p => p.payment_method_id)
        .WillCascadeOnDelete(false);

    }

  }
}
