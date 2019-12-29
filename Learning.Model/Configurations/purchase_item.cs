using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class purchase_item
     : EntityTypeConfiguration<Entities.purchase_item> {
    public purchase_item() {

      HasKey(p => new { p.purchase_item_id });
      Property(p => p.purchase_item_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      
    }
  }
}
