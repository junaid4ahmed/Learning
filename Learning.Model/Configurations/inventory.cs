using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class inventory 
    : EntityTypeConfiguration<Entities.inventory> {

    public inventory() {
      HasKey(i => i.id);

      Property(i => i.id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

    }
  }
}
