using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class purchase
    : EntityTypeConfiguration<Entities.purchase> {

    public purchase() {
      HasKey(p => new { p.purchase_id });
      Property(p => p.purchase_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


      HasMany(p => p.purchase_items).WithRequired(c => c.purchase).HasForeignKey(k => k.purchase_id).WillCascadeOnDelete(true);

    }
  }
}
