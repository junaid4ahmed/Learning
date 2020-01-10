using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class purchase_status
    : EntityTypeConfiguration<Entities.purchase_status> {

    public purchase_status() {
      HasKey(p => new { p.id });

      Property(p => p.id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

      // Name
      Property(p => p.name)
          .IsRequired();

      // payment_method and purchase
      HasMany(p => p.purchases)
        .WithRequired(p => p.purchase_status)
        .HasForeignKey(p => p.status_id)
        .WillCascadeOnDelete(false);
    }
  }
}
