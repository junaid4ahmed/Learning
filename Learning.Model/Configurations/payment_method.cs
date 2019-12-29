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

      HasKey(p => new { p.payment_method_id });

      Property(p => p.payment_method_id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

      // Name
      Property(p => p.name)
          .IsRequired();

      // payment_method and purchase
      HasMany(p => p.purchases).WithRequired(p => p.payment_method).HasForeignKey(p => p.payment_method_id);

    }

  }
}
